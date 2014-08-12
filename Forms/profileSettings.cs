using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BrailleConverter
{
    public partial class profileSettings : Form
    {
        //public string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BrailleConverter\\profiles";

        public profileSettings()
        {
            InitializeComponent();
        }

        private void profileSettings_Load(object sender, EventArgs e)
        {
            //this.path = this.path.Remove(0, 6) + "\\profiles";

            DirectoryInfo dir = new DirectoryInfo(this.path);

            if (!dir.Exists)
            {
                dir.Create();
            } 

            string[] filePaths = Directory.GetFiles(this.path, "*.dat");

            //MessageBox.Show(this.path);
            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            foreach (string file in filePaths)
            {
                string[] fileName = file.Split('\\');
                string fileNameShort = fileName[fileName.Length - 1].Replace(".dat", "");
                comboBoxSettings.Items.Add(fileNameShort);
                comboBoxSettings.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == "")
            {
                MessageBox.Show("Du måste fylla i ett namn för profilen", "Namn saknas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string[] lines = {
                    Settings.Default.TopMargin,
                    Settings.Default.LeftMargin,
                    Settings.Default.CharLine,
                    Settings.Default.LinesPage,
                    Settings.Default.PageMode,
                    Settings.Default.LineSpacing,
                    Settings.Default.Copies,
                    Settings.Default.PageNumber
                };

                string name = tbxName.Text;

                try
                {
                    if (!System.IO.Directory.Exists(this.path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }

                    if (!System.IO.File.Exists(path + "\\" + name + ".dat"))
                    {
                        System.IO.File.WriteAllLines(path + "\\" + name + ".dat", lines);
                        comboBoxSettings.Items.Add(name);
                        tbxName.Text = "";

                        MessageBox.Show("Profilen är sparad", "Profil sparad", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (MessageBox.Show("Filen finns redan. Vill du skriva över den?", "Filen finns redan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.IO.File.WriteAllLines(path + "\\" + name + ".dat", lines);
                            comboBoxSettings.Items.Add(name);
                            tbxName.Text = "";

                            MessageBox.Show("Profilen är sparad", "Profil sparad", MessageBoxButtons.OK);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Något blev fel: " + error.Message, "Något blev fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSettings.SelectedIndex != 0)
            {
                //READ FILE INTO ARRAY
                string[] lines = System.IO.File.ReadAllLines(this.path + "\\" + comboBoxSettings.SelectedItem.ToString() + ".dat");
                
                Settings.Default.TopMargin = lines[0];
                Settings.Default.LeftMargin = lines[1];
                Settings.Default.CharLine = lines[2];
                Settings.Default.LinesPage = lines[3];
                Settings.Default.PageMode = lines[4];
                Settings.Default.LineSpacing = lines[5];
                Settings.Default.Copies = lines[6];
                Settings.Default.PageNumber = lines[7];
            }
        }

        private void btnDeleteSetting_Click(object sender, EventArgs e)
        {
            if (comboBoxSettings.SelectedIndex != 0)
            {
                try
                {
                    File.Delete(path + "\\" + comboBoxSettings.SelectedItem.ToString() + ".dat");
                    comboBoxSettings.Items.Remove(comboBoxSettings.SelectedItem);
                    comboBoxSettings.SelectedIndex = 0;
                    MessageBox.Show("Profilen är raderad");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Kunde inte radera profilen: " + error.Message);
                }
            }
        }
    }
}
