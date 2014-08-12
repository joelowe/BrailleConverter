using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;

namespace BrailleConverter
{
    public partial class Form1 : Form
    {
        private bool textConverted = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void printPage(string content, bool doubleSpace)
        {
            int CharPerLine = Convert.ToInt16(Settings.Default.CharLine.Remove(0, 2));

            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings.PrinterName = "\\\\ORE11\\EKE-P-SKOLAN";

            if (pd.ShowDialog() == DialogResult.OK)
            {
                content = splitAndCheckForWrap(CharPerLine, content);

                //string escapeSequence = "DDP1,BI4,TM1,CH31,LP27;";

                string escapeSequence = "D";
                escapeSequence += Settings.Default.LineSpacing + ",";
                escapeSequence += Settings.Default.PageMode + ",";
                escapeSequence += Settings.Default.LeftMargin + ",";
                escapeSequence += Settings.Default.TopMargin + ",";
                escapeSequence += Settings.Default.CharLine + ",";
                escapeSequence += Settings.Default.LinesPage + ",";
                
                if (Settings.Default.Copies != "MC1")
                    escapeSequence += Settings.Default.Copies + ",";

                escapeSequence += Settings.Default.PageNumber;
                escapeSequence += ";";

                bool status = RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, content, escapeSequence, doubleSpace);

                //MessageBox.Show(escapeSequence);

                if (status == false)
                {
                    MessageBox.Show("Det gick inte att skriva ut till skrivaren");
                }
            }
        }

        private string changeToBraille(string content)
        {
            string convertedText = content;

            if (!textConverted)
            {
                convertingBraille cb = new convertingBraille();
                convertedText = cb.convertNumbersToBrailleNumbers(convertedText);
                convertedText = cb.convertCapitalsToUnderscore(convertedText);

                textConverted = true;

                toolStripButtonConvertToBraille.Enabled = false;
            }

            return convertedText;
        }

        private string changeToText(string content)
        {
            System.Drawing.Font f = new System.Drawing.Font("Lucida Console", 16);
            richTextBoxEditor.Font = f;

            convertingBraille cb = new convertingBraille();
            content = cb.convertBackToPrint(content);

            textConverted = false;

            toolStripButtonConvertToBraille.Enabled = true;

            return content;
        }

        private string splitAndCheckForWrap(int charPerLine, string content)
        {
            string[] sentences = content.Split('\n');
            string newContent = "";

            foreach (string sentence in sentences)
            {
                if (sentence.Length > charPerLine)
                {
                    // Split the sentence
                    string splittedSentence = "";
                    string[] words = sentence.Split(' ');
                    int countChar = 0;

                    foreach (string word in words)
                    {
                        if ((countChar + word.Length) > (charPerLine - 1))
                        {
                            splittedSentence += Environment.NewLine;
                            splittedSentence += word + " ";

                            countChar = word.Length + 1;
                        }
                        else
                        {
                            splittedSentence += word + " ";
                            countChar += word.Length + 1;
                        }
                    }

                    newContent += splittedSentence + Environment.NewLine;
                }
                else
                {
                    newContent += sentence + Environment.NewLine;
                }
            }

            return newContent;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
                richTextBoxEditor.Text += (string)Clipboard.GetData("Text"); 
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxEditor.SelectionLength > 0)
                richTextBoxEditor.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxEditor.SelectionLength > 0)
                richTextBoxEditor.Cut();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFile(openFileDialog1.FileName);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            openFile(FileList[0]);
        }

        private void openFile(string fileName)
        {
            string[] fileSplit = fileName.Split('.');

            if (fileSplit[fileSplit.Length - 1] == "docx")
            {
                DocxToText dtt = new DocxToText(fileName);
                richTextBoxEditor.Text = dtt.ExtractText();
            }
            else if (fileSplit[fileSplit.Length - 1] == "doc")
            {
                MessageBox.Show("Tyvärr stödjer inte programmet det gamla wordformatet (.doc). Prova med att spara om det till det nya formatet (.docx), eller som en textfil", "Fel filformat", MessageBoxButtons.OK, MessageBoxIcon.Stop);               
            }
            else if(fileSplit[fileSplit.Length - 1] == "rtf")
            {
                richTextBoxEditor.LoadFile(fileName, RichTextBoxStreamType.RichText);
            }
            else if (fileSplit[fileSplit.Length - 1] == "pdf")
            {
                richTextBoxEditor.Clear();

                PdfReader pdfread = new PdfReader(fileName);
                PdfReaderContentParser pdfparser = new PdfReaderContentParser(pdfread);
                ITextExtractionStrategy strategy;
 
                for (int i = 1; i <= pdfread.NumberOfPages; i++) 
                {
                    strategy = pdfparser.ProcessContent(i, new SimpleTextExtractionStrategy());
                    richTextBoxEditor.Text += strategy.GetResultantText();
                }
            }
            else if (fileSplit[fileSplit.Length - 1] == "txt")
            {
                richTextBoxEditor.LoadFile(fileName, RichTextBoxStreamType.PlainText);
            }
            else
            {
                richTextBoxEditor.LoadFile(fileName, RichTextBoxStreamType.PlainText);
            }

            textToolStripMenuItem.Enabled = false;
            punktToolStripMenuItem.Enabled = false;
            textToolStripMenuItem.Checked = false;
            punktToolStripMenuItem.Checked = false;
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            string content = richTextBoxEditor.Text;
            content = changeToBraille(content);

            bool doubleSpace = false;

            if (Settings.Default.LineSpacing == "LS100")
                doubleSpace = true;

            printPage(content, doubleSpace);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string content = richTextBoxEditor.Text;
            content = changeToBraille(content);

            bool doubleSpace = false;

            if (Settings.Default.LineSpacing == "LS100")
                doubleSpace = true;

            printPage(content, doubleSpace);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBoxEditor.Clear();
            richTextBoxEditor.Text = changeToText(richTextBoxEditor.Text);

            textToolStripMenuItem.Enabled = false;
            punktToolStripMenuItem.Enabled = false;
            textToolStripMenuItem.Checked = false;
            punktToolStripMenuItem.Checked = false;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFile(openFileDialog1.FileName);
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBoxEditor.SelectionLength > 0)
                richTextBoxEditor.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBoxEditor.SelectionLength > 0)
                richTextBoxEditor.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
                richTextBoxEditor.Text += (string)Clipboard.GetData("Text"); 
                //richTextBoxEditor.Paste();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBoxEditor.AllowDrop = true;
            richTextBoxEditor.DragEnter += new DragEventHandler(richTextBoxEditor_DragEnter);
            richTextBoxEditor.DragDrop += new DragEventHandler(richTextBoxEditor_DragDrop);
        }

        void richTextBoxEditor_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            openFile(FileList[0]);
        }

        void richTextBoxEditor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            translateToBraille();
            changeToBrailleFont();

            textToolStripMenuItem.Enabled = true;
            textToolStripMenuItem.Checked = true;
            punktToolStripMenuItem.Enabled = true;
        }

        private void richTextBoxEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblCharNum.Text = richTextBoxEditor.TextLength.ToString();
        }

        private void profilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileSettings ps = new profileSettings();
            ps.ShowDialog();
        }

        private void översättTillPunktskriftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            translateToBraille();
        }

        private void translateToBraille()
        {
            string content = richTextBoxEditor.Text;
            content = changeToBraille(content);
            richTextBoxEditor.Text = content;

            //float rightMargin = Convert.ToInt16(Settings.Default.CharLine.Remove(0, 2)) * (float)14.8;
            int rightMargin = setRightMargin(richTextBoxEditor.Font);
            richTextBoxEditor.RightMargin = rightMargin;

            lblCharNum.Text = richTextBoxEditor.TextLength.ToString();
        }

        private int setRightMargin(System.Drawing.Font f)
        {
            string tmpText = "";

            for (int i = 0; i < Convert.ToInt16(Settings.Default.CharLine.Remove(0, 2)); i++)
            {
                tmpText = tmpText + "A";
            }

            int rMargin = TextRenderer.MeasureText(tmpText, richTextBoxEditor.Font).Width;

            //Debug
            Console.Write("\n" + TextRenderer.MeasureText("a", f).Width.ToString() + " " + rMargin.ToString());
            Console.Write("\n" + richTextBoxEditor.Font.Name);

            return rMargin;
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeToTextFont();
        }

        private void punktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeToBrailleFont();    
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeToBrailleFont()
        {
            //define a private font collection
            System.Drawing.Text.PrivateFontCollection pfc2 = new System.Drawing.Text.PrivateFontCollection();
            //read your resource font into a byte array
            byte[] Bytes = Properties.Resources.SimBraille;
            //allocate some memory and get a pointer to it
            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(Bytes.Length);
            //copy the font data byte array to memory
            System.Runtime.InteropServices.Marshal.Copy(Bytes, 0, ptr, Bytes.Length);
            //Add the font to the private font collection
            pfc2.AddMemoryFont(ptr, Bytes.Length);
            //free up the previously allocated memory
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(ptr);
            //define a font from the private font collection
            System.Drawing.Font fnt2 = new System.Drawing.Font(pfc2.Families[0], 16);
            //dispose of the private font collection
            pfc2.Dispose();

            System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources\\";
            string font = "SimBraille.ttf";

            try
            {
                pfc.AddFontFile(path + font);
                System.Drawing.Font fnt = new System.Drawing.Font(pfc.Families[0], 16);

                richTextBoxEditor.Font = fnt;
                richTextBoxEditor.SelectionStart = 0;
                richTextBoxEditor.SelectionLength = richTextBoxEditor.TextLength;
                richTextBoxEditor.SelectionFont = fnt;
                richTextBoxEditor.SelectionStart = 0;
                richTextBoxEditor.SelectionLength = 0;

                int rightMargin = setRightMargin(fnt2);
                richTextBoxEditor.RightMargin = rightMargin;

                fnt.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            //return the font created from your font resource

            textToolStripMenuItem.Checked = false;
            punktToolStripMenuItem.Checked = true;  
        }

        private void changeToTextFont()
        {
            System.Drawing.Font f = new System.Drawing.Font("Lucida Console", 16);
            richTextBoxEditor.Font = f;

            int rightMargin = setRightMargin(f);
            richTextBoxEditor.RightMargin = rightMargin;

            textToolStripMenuItem.Checked = true;
            punktToolStripMenuItem.Checked = false;
        }
    }
}
