namespace Flux.GSA.Controller
{
    partial class FluxSAP2000
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
            this.cboProjectsFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.fluxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReceive = new System.Windows.Forms.Button();
            this.cboKeysFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabFlux = new System.Windows.Forms.TabControl();
            this.tabFromFlux = new System.Windows.Forms.TabPage();
            this.chkAutoAnalyze = new System.Windows.Forms.CheckBox();
            this.tabToFlux = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLists = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboKeysTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboProjectsTo = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblGSAFile = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.staMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.mnuMainMenu.SuspendLayout();
            this.tabFlux.SuspendLayout();
            this.tabFromFlux.SuspendLayout();
            this.tabToFlux.SuspendLayout();
            this.staMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboProjectsFrom
            // 
            this.cboProjectsFrom.DisplayMember = "name";
            this.cboProjectsFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectsFrom.FormattingEnabled = true;
            this.cboProjectsFrom.Location = new System.Drawing.Point(16, 74);
            this.cboProjectsFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProjectsFrom.Name = "cboProjectsFrom";
            this.cboProjectsFrom.Size = new System.Drawing.Size(366, 28);
            this.cboProjectsFrom.TabIndex = 0;
            this.cboProjectsFrom.ValueMember = "id";
            this.cboProjectsFrom.SelectedIndexChanged += new System.EventHandler(this.cboProjectsFrom_SelectedIndexChanged);
            this.cboProjectsFrom.DataSourceChanged += new System.EventHandler(this.cboProjectsFrom_DataSourceChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Flux Project:";
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fluxToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.testToolStripMenuItem});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mnuMainMenu.Size = new System.Drawing.Size(436, 35);
            this.mnuMainMenu.TabIndex = 2;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // fluxToolStripMenuItem
            // 
            this.fluxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.toolStripSeparator1,
            this.cmdExit});
            this.fluxToolStripMenuItem.Name = "fluxToolStripMenuItem";
            this.fluxToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fluxToolStripMenuItem.Text = "&File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(248, 30);
            this.mnuOpen.Text = "&Open GSA Model...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // cmdExit
            // 
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(248, 30);
            this.cmdExit.Text = "E&xit";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogIn,
            this.mnuLogOut});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.helpToolStripMenuItem.Text = "Flu&x";
            // 
            // mnuLogIn
            // 
            this.mnuLogIn.Name = "mnuLogIn";
            this.mnuLogIn.Size = new System.Drawing.Size(217, 30);
            this.mnuLogIn.Text = "Log In to Flux...";
            this.mnuLogIn.Click += new System.EventHandler(this.mnuLogIn_Click);
            // 
            // mnuLogOut
            // 
            this.mnuLogOut.Name = "mnuLogOut";
            this.mnuLogOut.Size = new System.Drawing.Size(217, 30);
            this.mnuLogOut.Text = "Log &Out";
            this.mnuLogOut.Click += new System.EventHandler(this.mnuLogOut_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearNodesToolStripMenuItem,
            this.testNodeToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.testToolStripMenuItem.Text = "GSA";
            // 
            // clearNodesToolStripMenuItem
            // 
            this.clearNodesToolStripMenuItem.Name = "clearNodesToolStripMenuItem";
            this.clearNodesToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.clearNodesToolStripMenuItem.Text = "Clear Entities";
            this.clearNodesToolStripMenuItem.Click += new System.EventHandler(this.clearNodesToolStripMenuItem_Click);
            // 
            // testNodeToolStripMenuItem
            // 
            this.testNodeToolStripMenuItem.Name = "testNodeToolStripMenuItem";
            this.testNodeToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.testNodeToolStripMenuItem.Text = "TestNode";
            this.testNodeToolStripMenuItem.Click += new System.EventHandler(this.testNodeToolStripMenuItem_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(243, 478);
            this.btnReceive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(141, 45);
            this.btnReceive.TabIndex = 3;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // cboKeysFrom
            // 
            this.cboKeysFrom.DisplayMember = "label";
            this.cboKeysFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKeysFrom.FormattingEnabled = true;
            this.cboKeysFrom.Location = new System.Drawing.Point(16, 165);
            this.cboKeysFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboKeysFrom.Name = "cboKeysFrom";
            this.cboKeysFrom.Size = new System.Drawing.Size(366, 28);
            this.cboKeysFrom.TabIndex = 4;
            this.cboKeysFrom.ValueMember = "id";
            this.cboKeysFrom.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboBoxFormat);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Flux Data Key:";
            // 
            // tabFlux
            // 
            this.tabFlux.Controls.Add(this.tabFromFlux);
            this.tabFlux.Controls.Add(this.tabToFlux);
            this.tabFlux.Enabled = false;
            this.tabFlux.Location = new System.Drawing.Point(9, 62);
            this.tabFlux.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFlux.Name = "tabFlux";
            this.tabFlux.SelectedIndex = 0;
            this.tabFlux.Size = new System.Drawing.Size(422, 592);
            this.tabFlux.TabIndex = 6;
            // 
            // tabFromFlux
            // 
            this.tabFromFlux.Controls.Add(this.chkAutoAnalyze);
            this.tabFromFlux.Controls.Add(this.btnReceive);
            this.tabFromFlux.Controls.Add(this.label2);
            this.tabFromFlux.Controls.Add(this.label1);
            this.tabFromFlux.Controls.Add(this.cboKeysFrom);
            this.tabFromFlux.Controls.Add(this.cboProjectsFrom);
            this.tabFromFlux.Location = new System.Drawing.Point(4, 29);
            this.tabFromFlux.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFromFlux.Name = "tabFromFlux";
            this.tabFromFlux.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFromFlux.Size = new System.Drawing.Size(414, 559);
            this.tabFromFlux.TabIndex = 1;
            this.tabFromFlux.Text = "Receive from Flux";
            this.tabFromFlux.UseVisualStyleBackColor = true;
            // 
            // chkAutoAnalyze
            // 
            this.chkAutoAnalyze.AutoSize = true;
            this.chkAutoAnalyze.Location = new System.Drawing.Point(16, 234);
            this.chkAutoAnalyze.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAutoAnalyze.Name = "chkAutoAnalyze";
            this.chkAutoAnalyze.Size = new System.Drawing.Size(228, 24);
            this.chkAutoAnalyze.TabIndex = 7;
            this.chkAutoAnalyze.Text = "Run analysis after updating";
            this.chkAutoAnalyze.UseVisualStyleBackColor = true;
            // 
            // tabToFlux
            // 
            this.tabToFlux.Controls.Add(this.label6);
            this.tabToFlux.Controls.Add(this.label5);
            this.tabToFlux.Controls.Add(this.cboLists);
            this.tabToFlux.Controls.Add(this.label4);
            this.tabToFlux.Controls.Add(this.cboKeysTo);
            this.tabToFlux.Controls.Add(this.label3);
            this.tabToFlux.Controls.Add(this.cboProjectsTo);
            this.tabToFlux.Controls.Add(this.btnSend);
            this.tabToFlux.Location = new System.Drawing.Point(4, 29);
            this.tabToFlux.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabToFlux.Name = "tabToFlux";
            this.tabToFlux.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabToFlux.Size = new System.Drawing.Size(414, 559);
            this.tabToFlux.TabIndex = 0;
            this.tabToFlux.Text = "Send to Flux";
            this.tabToFlux.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 414);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "21 elements will be sent to Flux";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 237);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "GSA List to Send";
            // 
            // cboLists
            // 
            this.cboLists.DisplayMember = "name";
            this.cboLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLists.FormattingEnabled = true;
            this.cboLists.Location = new System.Drawing.Point(20, 265);
            this.cboLists.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLists.Name = "cboLists";
            this.cboLists.Size = new System.Drawing.Size(366, 28);
            this.cboLists.TabIndex = 8;
            this.cboLists.ValueMember = "ref";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Flux Data Key:";
            // 
            // cboKeysTo
            // 
            this.cboKeysTo.DisplayMember = "label";
            this.cboKeysTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKeysTo.FormattingEnabled = true;
            this.cboKeysTo.Location = new System.Drawing.Point(20, 175);
            this.cboKeysTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboKeysTo.Name = "cboKeysTo";
            this.cboKeysTo.Size = new System.Drawing.Size(366, 28);
            this.cboKeysTo.TabIndex = 6;
            this.cboKeysTo.ValueMember = "id";
            this.cboKeysTo.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboBoxFormat);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Flux Project:";
            // 
            // cboProjectsTo
            // 
            this.cboProjectsTo.DisplayMember = "name";
            this.cboProjectsTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectsTo.FormattingEnabled = true;
            this.cboProjectsTo.Location = new System.Drawing.Point(20, 78);
            this.cboProjectsTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProjectsTo.Name = "cboProjectsTo";
            this.cboProjectsTo.Size = new System.Drawing.Size(366, 28);
            this.cboProjectsTo.TabIndex = 2;
            this.cboProjectsTo.ValueMember = "id";
            this.cboProjectsTo.SelectedIndexChanged += new System.EventHandler(this.cboProjectsTo_SelectedIndexChanged);
            this.cboProjectsTo.DataSourceChanged += new System.EventHandler(this.cboProjectsTo_DataSourceChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(252, 455);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(135, 46);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblGSAFile
            // 
            this.lblGSAFile.AutoSize = true;
            this.lblGSAFile.Location = new System.Drawing.Point(20, 65);
            this.lblGSAFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGSAFile.Name = "lblGSAFile";
            this.lblGSAFile.Size = new System.Drawing.Size(0, 20);
            this.lblGSAFile.TabIndex = 7;
            // 
            // staMain
            // 
            this.staMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.staMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsProgress});
            this.staMain.Location = new System.Drawing.Point(0, 661);
            this.staMain.Name = "staMain";
            this.staMain.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.staMain.Size = new System.Drawing.Size(436, 31);
            this.staMain.SizingGrip = false;
            this.staMain.TabIndex = 9;
            this.staMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(198, 26);
            this.toolStripStatusLabel1.Text = "No GSA model is loaded.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(75, 25);
            this.tsProgress.Value = 20;
            // 
            // FluxSAP2000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 692);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.lblGSAFile);
            this.Controls.Add(this.tabFlux);
            this.Controls.Add(this.mnuMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuMainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FluxSAP2000";
            this.Text = "Flux GSA Controller";
            //this.Load += new System.EventHandler(this.FluxGSA_Load);
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.tabFlux.ResumeLayout(false);
            this.tabFromFlux.ResumeLayout(false);
            this.tabFromFlux.PerformLayout();
            this.tabToFlux.ResumeLayout(false);
            this.tabToFlux.PerformLayout();
            this.staMain.ResumeLayout(false);
            this.staMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProjectsFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem fluxToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.ComboBox cboKeysFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabFlux;
        private System.Windows.Forms.TabPage tabToFlux;
        private System.Windows.Forms.TabPage tabFromFlux;
        private System.Windows.Forms.CheckBox chkAutoAnalyze;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKeysTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboProjectsTo;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ToolStripMenuItem cmdExit;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblGSAFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.ToolStripMenuItem mnuLogOut;
        private System.Windows.Forms.ToolStripMenuItem mnuLogIn;
        private System.Windows.Forms.StatusStrip staMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testNodeToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboLists;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.Label label6;
    }
}