namespace MnL4Extractor
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCodePath = new System.Windows.Forms.TextBox();
            this.btnBrowseCode = new System.Windows.Forms.Button();
            this.radioBtnAuto = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioBtnManual = new System.Windows.Forms.RadioButton();
            this.offModeTabContainer = new System.Windows.Forms.TabControl();
            this.offModeAutoTab = new System.Windows.Forms.TabPage();
            this.offModeAutoRegion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.offModeManualTab = new System.Windows.Forms.TabPage();
            this.offModeManualTblStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBoxOutHexNum = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.offModeTabContainer.SuspendLayout();
            this.offModeAutoTab.SuspendLayout();
            this.offModeManualTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Decompressed code.bin or .cro";
            // 
            // textBoxCodePath
            // 
            this.textBoxCodePath.Location = new System.Drawing.Point(12, 25);
            this.textBoxCodePath.Name = "textBoxCodePath";
            this.textBoxCodePath.Size = new System.Drawing.Size(428, 20);
            this.textBoxCodePath.TabIndex = 2;
            // 
            // btnBrowseCode
            // 
            this.btnBrowseCode.Location = new System.Drawing.Point(446, 23);
            this.btnBrowseCode.Name = "btnBrowseCode";
            this.btnBrowseCode.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseCode.TabIndex = 3;
            this.btnBrowseCode.Text = "Browse";
            this.btnBrowseCode.UseVisualStyleBackColor = true;
            // 
            // radioBtnAuto
            // 
            this.radioBtnAuto.AutoSize = true;
            this.radioBtnAuto.Enabled = false;
            this.radioBtnAuto.Location = new System.Drawing.Point(12, 172);
            this.radioBtnAuto.Name = "radioBtnAuto";
            this.radioBtnAuto.Size = new System.Drawing.Size(72, 17);
            this.radioBtnAuto.TabIndex = 4;
            this.radioBtnAuto.Text = "Automatic";
            this.radioBtnAuto.UseVisualStyleBackColor = true;
            this.radioBtnAuto.CheckedChanged += new System.EventHandler(this.radioBtnSelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File offset table mode";
            // 
            // radioBtnManual
            // 
            this.radioBtnManual.AutoSize = true;
            this.radioBtnManual.Checked = true;
            this.radioBtnManual.Location = new System.Drawing.Point(90, 172);
            this.radioBtnManual.Name = "radioBtnManual";
            this.radioBtnManual.Size = new System.Drawing.Size(60, 17);
            this.radioBtnManual.TabIndex = 6;
            this.radioBtnManual.TabStop = true;
            this.radioBtnManual.Text = "Manual";
            this.radioBtnManual.UseVisualStyleBackColor = true;
            this.radioBtnManual.CheckedChanged += new System.EventHandler(this.radioBtnSelectionChanged);
            // 
            // offModeTabContainer
            // 
            this.offModeTabContainer.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.offModeTabContainer.Controls.Add(this.offModeManualTab);
            this.offModeTabContainer.Controls.Add(this.offModeAutoTab);
            this.offModeTabContainer.ItemSize = new System.Drawing.Size(0, 1);
            this.offModeTabContainer.Location = new System.Drawing.Point(12, 196);
            this.offModeTabContainer.Name = "offModeTabContainer";
            this.offModeTabContainer.SelectedIndex = 0;
            this.offModeTabContainer.Size = new System.Drawing.Size(509, 68);
            this.offModeTabContainer.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.offModeTabContainer.TabIndex = 7;
            // 
            // offModeAutoTab
            // 
            this.offModeAutoTab.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.offModeAutoTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.offModeAutoTab.Controls.Add(this.offModeAutoRegion);
            this.offModeAutoTab.Controls.Add(this.label3);
            this.offModeAutoTab.Location = new System.Drawing.Point(4, 5);
            this.offModeAutoTab.Name = "offModeAutoTab";
            this.offModeAutoTab.Padding = new System.Windows.Forms.Padding(3);
            this.offModeAutoTab.Size = new System.Drawing.Size(501, 59);
            this.offModeAutoTab.TabIndex = 0;
            this.offModeAutoTab.Text = "tabPage1";
            // 
            // offModeAutoRegion
            // 
            this.offModeAutoRegion.FormattingEnabled = true;
            this.offModeAutoRegion.Items.AddRange(new object[] {
            "JPN",
            "EUR",
            "USA"});
            this.offModeAutoRegion.Location = new System.Drawing.Point(86, 17);
            this.offModeAutoRegion.Name = "offModeAutoRegion";
            this.offModeAutoRegion.Size = new System.Drawing.Size(121, 21);
            this.offModeAutoRegion.TabIndex = 1;
            this.offModeAutoRegion.Text = "JPN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Game region";
            // 
            // offModeManualTab
            // 
            this.offModeManualTab.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.offModeManualTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.offModeManualTab.Controls.Add(this.offModeManualTblStart);
            this.offModeManualTab.Controls.Add(this.label4);
            this.offModeManualTab.Location = new System.Drawing.Point(4, 5);
            this.offModeManualTab.Name = "offModeManualTab";
            this.offModeManualTab.Padding = new System.Windows.Forms.Padding(3);
            this.offModeManualTab.Size = new System.Drawing.Size(501, 59);
            this.offModeManualTab.TabIndex = 1;
            this.offModeManualTab.Text = "tabPage2";
            // 
            // offModeManualTblStart
            // 
            this.offModeManualTblStart.Location = new System.Drawing.Point(139, 19);
            this.offModeManualTblStart.Name = "offModeManualTblStart";
            this.offModeManualTblStart.Size = new System.Drawing.Size(127, 20);
            this.offModeManualTblStart.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Table start offset(in hex)";
            // 
            // chkBoxOutHexNum
            // 
            this.chkBoxOutHexNum.AutoSize = true;
            this.chkBoxOutHexNum.Location = new System.Drawing.Point(310, 173);
            this.chkBoxOutHexNum.Name = "chkBoxOutHexNum";
            this.chkBoxOutHexNum.Size = new System.Drawing.Size(207, 17);
            this.chkBoxOutHexNum.TabIndex = 8;
            this.chkBoxOutHexNum.Text = "Use hex when writing output filenames";
            this.chkBoxOutHexNum.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(510, 106);
            this.label5.TabIndex = 9;
            this.label5.Text = "\r\n\r\n\r\n                                                              Drag and Drop" +
    " your files here                                                           \r\n\r\n\r" +
    "\n\r\n\r\n";
            this.label5.DragDrop += new System.Windows.Forms.DragEventHandler(this.label5_DragDrop);
            this.label5.DragEnter += new System.Windows.Forms.DragEventHandler(this.label5_DragEnter);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(534, 271);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkBoxOutHexNum);
            this.Controls.Add(this.offModeTabContainer);
            this.Controls.Add(this.radioBtnManual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioBtnAuto);
            this.Controls.Add(this.btnBrowseCode);
            this.Controls.Add(this.textBoxCodePath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MnL4 File Extractor";
            this.offModeTabContainer.ResumeLayout(false);
            this.offModeAutoTab.ResumeLayout(false);
            this.offModeAutoTab.PerformLayout();
            this.offModeManualTab.ResumeLayout(false);
            this.offModeManualTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCodePath;
        private System.Windows.Forms.Button btnBrowseCode;
        private System.Windows.Forms.RadioButton radioBtnAuto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioBtnManual;
        private System.Windows.Forms.TabControl offModeTabContainer;
        private System.Windows.Forms.TabPage offModeAutoTab;
        private System.Windows.Forms.TabPage offModeManualTab;
        private System.Windows.Forms.ComboBox offModeAutoRegion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox offModeManualTblStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBoxOutHexNum;
        private System.Windows.Forms.Label label5;
    }
}

