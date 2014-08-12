using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BrailleConverter
{
    public partial class SettingsForm : Form
    {
        private int maxCharPerLine = 33;
        private int linePerPage = 28;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            comboBoxSidnr.Items.Add((new ComboBoxItem("0","Ingen")));
            comboBoxSidnr.Items.Add((new ComboBoxItem("1", "Uppe")));
            comboBoxSidnr.Items.Add((new ComboBoxItem("2", "Uppe vänster")));
            comboBoxSidnr.Items.Add((new ComboBoxItem("3", "Uppe höger")));
            comboBoxSidnr.Items.Add((new ComboBoxItem("4", "nere")));
            comboBoxSidnr.Items.Add((new ComboBoxItem("5", "nere vänster")));
            comboBoxSidnr.Items.Add((new ComboBoxItem("6", "nere höger")));

            numBoxTopMargin.Value = Convert.ToInt16(Settings.Default.TopMargin.Remove(0, 2));
            numBoxLeftMargin.Value = Convert.ToInt16(Settings.Default.LeftMargin.Remove(0, 2));
            numBoxCharPerLine.Value = Convert.ToInt16(Settings.Default.CharLine.Remove(0, 2));
            linePerPage = Convert.ToInt16(Settings.Default.LinesPage.Remove(0, 2));

            int selectedPageNr = Convert.ToInt16(Settings.Default.PageNumber.Remove(0, 2));
            comboBoxSidnr.SelectedIndex = selectedPageNr;

            numBoxCopies.Value = Convert.ToInt16(Settings.Default.Copies.Remove(0, 2));

            if (Settings.Default.PageMode == "DP1")
                radioButtonSingle.Checked = true;
            else if (Settings.Default.PageMode == "DP2")
                radioButtonDouble.Checked = true;
            else if (Settings.Default.PageMode == "DP8")
                radioButtonSingleZ.Checked = true;
            else if (Settings.Default.PageMode == "DP4")
                radioButtonDoubleZ.Checked = true;

            if (Settings.Default.LineSpacing == "LS100")
            {
                cbxDoubleLineSpace.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.TopMargin = "TM" + numBoxTopMargin.Value.ToString();
            Settings.Default.LeftMargin = "BI" + numBoxLeftMargin.Value.ToString();
            Settings.Default.CharLine = "CH" + numBoxCharPerLine.Value.ToString();
            Settings.Default.LinesPage = "LP" + linePerPage.ToString();

            if (radioButtonSingle.Checked)
                Settings.Default.PageMode = "DP1";
            else if (radioButtonDouble.Checked)
                Settings.Default.PageMode = "DP2";
            else if (radioButtonSingleZ.Checked)
                Settings.Default.PageMode = "DP8";
            else if (radioButtonDoubleZ.Checked)
                Settings.Default.PageMode = "DP4";

            if (cbxDoubleLineSpace.Checked)
                Settings.Default.LineSpacing = "LS100";
            else
                Settings.Default.LineSpacing = "LS50";

            Settings.Default.Copies = "MC" + numBoxCopies.Value.ToString();

            if (comboBoxSidnr.SelectedItem == null)
                Settings.Default.PageNumber = "PN0";
            else
                Settings.Default.PageNumber = "PN" + (comboBoxSidnr.SelectedItem as ComboBoxItem).Value.ToString();

            Settings.Default.Save();

            this.Close();
        }

        private void numBoxLeftMargin_ValueChanged(object sender, EventArgs e)
        {
            int maxValue = (int)numBoxLeftMargin.Value + (int)numBoxCharPerLine.Value;

            if (maxValue > this.maxCharPerLine)
            {
                numBoxCharPerLine.Value--;
            }
        }

        private void numBoxCharPerLine_ValueChanged(object sender, EventArgs e)
        {
            int maxValue = (int)numBoxLeftMargin.Value + (int)numBoxCharPerLine.Value;

            if (maxValue > this.maxCharPerLine)
            {
                numBoxLeftMargin.Value--;
            }
        }

        private void cbxDoubleLineSpace_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDoubleLineSpace.Checked)
            {
                linePerPage = 19 - (int)numBoxTopMargin.Value;
            }
            else
            {
                linePerPage = 28 - (int)numBoxTopMargin.Value;
            }
        }

        private void numBoxTopMargin_ValueChanged(object sender, EventArgs e)
        {
            if (cbxDoubleLineSpace.Checked)
            {
                linePerPage = 19 - (int)numBoxTopMargin.Value;
            }
            else
            {
                linePerPage = 28 - (int)numBoxTopMargin.Value;
            }

            if ((int)numBoxTopMargin.Value == 0)
            {
                comboBoxSidnr.SelectedIndex = 0;
                comboBoxSidnr.Enabled = false;
            }
            else
            {
                comboBoxSidnr.Enabled = true;
            }
        }

        private void radioButtonSingleZ_CheckedChanged(object sender, EventArgs e)
        {
            changeLS();
        }

        private void radioButtonDoubleZ_CheckedChanged(object sender, EventArgs e)
        {
            changeLS();
        }

        private void changeLS()
        {
            if (radioButtonSingleZ.Checked || radioButtonDoubleZ.Checked)
            {
                cbxDoubleLineSpace.Checked = false;
                cbxDoubleLineSpace.Enabled = false;
            }
            else
            {
                cbxDoubleLineSpace.Enabled = true;
            }
        }
    }

    public class ComboBoxItem
    {
        public string Value;
        public string Text;

        public ComboBoxItem(string val, string text)
        {
            Value = val;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
