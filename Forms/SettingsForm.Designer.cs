namespace BrailleConverter
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numBoxLeftMargin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numBoxTopMargin = new System.Windows.Forms.NumericUpDown();
            this.numBoxCharPerLine = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDoubleLineSpace = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonDoubleZ = new System.Windows.Forms.RadioButton();
            this.radioButtonSingleZ = new System.Windows.Forms.RadioButton();
            this.radioButtonDouble = new System.Windows.Forms.RadioButton();
            this.numBoxCopies = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSidnr = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxTopMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxCharPerLine)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxCopies)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numBoxLeftMargin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numBoxTopMargin);
            this.groupBox1.Controls.Add(this.numBoxCharPerLine);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxDoubleLineSpace);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Marginaler";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vänstermarginal";
            // 
            // numBoxLeftMargin
            // 
            this.numBoxLeftMargin.Location = new System.Drawing.Point(7, 46);
            this.numBoxLeftMargin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBoxLeftMargin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoxLeftMargin.Name = "numBoxLeftMargin";
            this.numBoxLeftMargin.Size = new System.Drawing.Size(38, 20);
            this.numBoxLeftMargin.TabIndex = 8;
            this.numBoxLeftMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoxLeftMargin.ValueChanged += new System.EventHandler(this.numBoxLeftMargin_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Toppmarginal";
            // 
            // numBoxTopMargin
            // 
            this.numBoxTopMargin.Location = new System.Drawing.Point(7, 19);
            this.numBoxTopMargin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBoxTopMargin.Name = "numBoxTopMargin";
            this.numBoxTopMargin.Size = new System.Drawing.Size(38, 20);
            this.numBoxTopMargin.TabIndex = 6;
            this.numBoxTopMargin.ValueChanged += new System.EventHandler(this.numBoxTopMargin_ValueChanged);
            // 
            // numBoxCharPerLine
            // 
            this.numBoxCharPerLine.Location = new System.Drawing.Point(6, 72);
            this.numBoxCharPerLine.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numBoxCharPerLine.Name = "numBoxCharPerLine";
            this.numBoxCharPerLine.Size = new System.Drawing.Size(39, 20);
            this.numBoxCharPerLine.TabIndex = 3;
            this.numBoxCharPerLine.ValueChanged += new System.EventHandler(this.numBoxCharPerLine_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Antal tecken per rad";
            // 
            // cbxDoubleLineSpace
            // 
            this.cbxDoubleLineSpace.AutoSize = true;
            this.cbxDoubleLineSpace.Location = new System.Drawing.Point(7, 104);
            this.cbxDoubleLineSpace.Name = "cbxDoubleLineSpace";
            this.cbxDoubleLineSpace.Size = new System.Drawing.Size(119, 17);
            this.cbxDoubleLineSpace.TabIndex = 5;
            this.cbxDoubleLineSpace.Text = "Dubbelt radavstånd";
            this.cbxDoubleLineSpace.UseVisualStyleBackColor = true;
            this.cbxDoubleLineSpace.CheckedChanged += new System.EventHandler(this.cbxDoubleLineSpace_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(250, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Spara";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(169, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Avbryt";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // radioButtonSingle
            // 
            this.radioButtonSingle.AutoSize = true;
            this.radioButtonSingle.Checked = true;
            this.radioButtonSingle.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSingle.Name = "radioButtonSingle";
            this.radioButtonSingle.Size = new System.Drawing.Size(95, 17);
            this.radioButtonSingle.TabIndex = 3;
            this.radioButtonSingle.TabStop = true;
            this.radioButtonSingle.Text = "Enkelsidig (A4)";
            this.radioButtonSingle.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonDoubleZ);
            this.groupBox2.Controls.Add(this.radioButtonSingleZ);
            this.groupBox2.Controls.Add(this.radioButtonDouble);
            this.groupBox2.Controls.Add(this.radioButtonSingle);
            this.groupBox2.Location = new System.Drawing.Point(178, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 127);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sidhantering";
            // 
            // radioButtonDoubleZ
            // 
            this.radioButtonDoubleZ.AutoSize = true;
            this.radioButtonDoubleZ.Location = new System.Drawing.Point(6, 91);
            this.radioButtonDoubleZ.Name = "radioButtonDoubleZ";
            this.radioButtonDoubleZ.Size = new System.Drawing.Size(102, 17);
            this.radioButtonDoubleZ.TabIndex = 6;
            this.radioButtonDoubleZ.Text = "Dubbelsidig (A3)";
            this.radioButtonDoubleZ.UseVisualStyleBackColor = true;
            this.radioButtonDoubleZ.CheckedChanged += new System.EventHandler(this.radioButtonDoubleZ_CheckedChanged);
            // 
            // radioButtonSingleZ
            // 
            this.radioButtonSingleZ.AutoSize = true;
            this.radioButtonSingleZ.Location = new System.Drawing.Point(6, 67);
            this.radioButtonSingleZ.Name = "radioButtonSingleZ";
            this.radioButtonSingleZ.Size = new System.Drawing.Size(95, 17);
            this.radioButtonSingleZ.TabIndex = 5;
            this.radioButtonSingleZ.Text = "Enkelsidig (A3)";
            this.radioButtonSingleZ.UseVisualStyleBackColor = true;
            this.radioButtonSingleZ.CheckedChanged += new System.EventHandler(this.radioButtonSingleZ_CheckedChanged);
            // 
            // radioButtonDouble
            // 
            this.radioButtonDouble.AutoSize = true;
            this.radioButtonDouble.Location = new System.Drawing.Point(6, 43);
            this.radioButtonDouble.Name = "radioButtonDouble";
            this.radioButtonDouble.Size = new System.Drawing.Size(102, 17);
            this.radioButtonDouble.TabIndex = 4;
            this.radioButtonDouble.Text = "Dubbelsidig (A4)";
            this.radioButtonDouble.UseVisualStyleBackColor = true;
            // 
            // numBoxCopies
            // 
            this.numBoxCopies.Location = new System.Drawing.Point(9, 32);
            this.numBoxCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoxCopies.Name = "numBoxCopies";
            this.numBoxCopies.Size = new System.Drawing.Size(38, 20);
            this.numBoxCopies.TabIndex = 6;
            this.numBoxCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Antal kopior";
            // 
            // comboBoxSidnr
            // 
            this.comboBoxSidnr.FormattingEnabled = true;
            this.comboBoxSidnr.Location = new System.Drawing.Point(185, 32);
            this.comboBoxSidnr.Name = "comboBoxSidnr";
            this.comboBoxSidnr.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSidnr.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Sidnummer";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numBoxCopies);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.comboBoxSidnr);
            this.groupBox4.Location = new System.Drawing.Point(12, 145);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 67);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(337, 262);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Utskriftinställningar";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxTopMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxCharPerLine)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxCopies)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numBoxCharPerLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numBoxLeftMargin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBoxTopMargin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radioButtonSingle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonDoubleZ;
        private System.Windows.Forms.RadioButton radioButtonSingleZ;
        private System.Windows.Forms.RadioButton radioButtonDouble;
        private System.Windows.Forms.CheckBox cbxDoubleLineSpace;
        private System.Windows.Forms.NumericUpDown numBoxCopies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSidnr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}