namespace BuildEmAll_GUI
{
    partial class FrmBuildEmAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuildEmAll));
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.txtLoadedDatafile = new System.Windows.Forms.TextBox();
            this.lbFromDat = new System.Windows.Forms.ListBox();
            this.btnLoadDat = new System.Windows.Forms.Button();
            this.lbToDat = new System.Windows.Forms.ListBox();
            this.btnRemoveAllPrepatches = new System.Windows.Forms.Button();
            this.btnAddPrepatch = new System.Windows.Forms.Button();
            this.btnRemovePrepatch = new System.Windows.Forms.Button();
            this.lbPrepatches = new System.Windows.Forms.ListBox();
            this.btnLoadPPD = new System.Windows.Forms.Button();
            this.lblCountPrepatches = new System.Windows.Forms.Label();
            this.btnSavePPD = new System.Windows.Forms.Button();
            this.btnCheckPrepatches = new System.Windows.Forms.Button();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBuildROMs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBuildPatches = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBuildPatchesDatafile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLoadOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPPDBuilder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbBuildROMs = new System.Windows.Forms.ToolStripButton();
            this.tsbBuildPatches = new System.Windows.Forms.ToolStripButton();
            this.tsbBuildPatchesDatafile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbViewLog = new System.Windows.Forms.ToolStripButton();
            this.tsbViewOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbViewPPDBuilder = new System.Windows.Forms.ToolStripButton();
            this.tsbViewHelp = new System.Windows.Forms.ToolStripButton();
            this.tsbViewLicense = new System.Windows.Forms.ToolStripButton();
            this.tsbViewToolbar = new System.Windows.Forms.ToolStripButton();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tsslSnap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslStarusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbBuildProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tssbCancel = new System.Windows.Forms.ToolStripSplitButton();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.rtbLog = new Serilog.Sinks.LogEmAll.RichTextBoxLog();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.gbOptionsInfo = new System.Windows.Forms.GroupBox();
            this.lblOptionsInfo2 = new System.Windows.Forms.Label();
            this.lblOptionsInfo1 = new System.Windows.Forms.Label();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cbLogLevel = new System.Windows.Forms.ComboBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.cbSounds = new System.Windows.Forms.ComboBox();
            this.lblLogLevel = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.txtXdeltaBuildCommand = new System.Windows.Forms.TextBox();
            this.txtPathXdeltaFile = new System.Windows.Forms.TextBox();
            this.txtPathDatPPDXMLFile = new System.Windows.Forms.TextBox();
            this.txtPathDatsDir = new System.Windows.Forms.TextBox();
            this.txtPathPatchesDir = new System.Windows.Forms.TextBox();
            this.txtPathROMsDir = new System.Windows.Forms.TextBox();
            this.lblSounds = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.lblXdeltaBuildCommand = new System.Windows.Forms.Label();
            this.lblPathXdeltaFile = new System.Windows.Forms.Label();
            this.lblPathDatPPDXMLFile = new System.Windows.Forms.Label();
            this.lblPathDatsDir = new System.Windows.Forms.Label();
            this.lblPathPatchesDir = new System.Windows.Forms.Label();
            this.lblPathROMsDir = new System.Windows.Forms.Label();
            this.tabPPDBuilder = new System.Windows.Forms.TabPage();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.rtbHelp = new System.Windows.Forms.RichTextBox();
            this.tabLicense = new System.Windows.Forms.TabPage();
            this.rtbLicense = new System.Windows.Forms.RichTextBox();
            this.bgwBuildROMs = new System.ComponentModel.BackgroundWorker();
            this.bgwBuildPatches = new System.ComponentModel.BackgroundWorker();
            this.bgwBuildDatafile = new System.ComponentModel.BackgroundWorker();
            this.bgwStartupTasks = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.msMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.gbOptionsInfo.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.tabPPDBuilder.SuspendLayout();
            this.tabHelp.SuspendLayout();
            this.tabLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.lbPrepatches);
            this.splitContainer4.Panel2.Controls.Add(this.btnLoadPPD);
            this.splitContainer4.Panel2.Controls.Add(this.lblCountPrepatches);
            this.splitContainer4.Panel2.Controls.Add(this.btnSavePPD);
            this.splitContainer4.Panel2.Controls.Add(this.btnCheckPrepatches);
            // 
            // splitContainer5
            // 
            resources.ApplyResources(this.splitContainer5, "splitContainer5");
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.txtLoadedDatafile);
            this.splitContainer5.Panel1.Controls.Add(this.lbFromDat);
            this.splitContainer5.Panel1.Controls.Add(this.btnLoadDat);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.lbToDat);
            this.splitContainer5.Panel2.Controls.Add(this.btnRemoveAllPrepatches);
            this.splitContainer5.Panel2.Controls.Add(this.btnAddPrepatch);
            this.splitContainer5.Panel2.Controls.Add(this.btnRemovePrepatch);
            // 
            // txtLoadedDatafile
            // 
            resources.ApplyResources(this.txtLoadedDatafile, "txtLoadedDatafile");
            this.txtLoadedDatafile.Name = "txtLoadedDatafile";
            this.txtLoadedDatafile.ReadOnly = true;
            // 
            // lbFromDat
            // 
            resources.ApplyResources(this.lbFromDat, "lbFromDat");
            this.lbFromDat.FormattingEnabled = true;
            this.lbFromDat.Name = "lbFromDat";
            this.lbFromDat.Sorted = true;
            // 
            // btnLoadDat
            // 
            this.btnLoadDat.Image = global::BuildEmAll_GUI.Properties.Resources.LoadDat_16x16;
            resources.ApplyResources(this.btnLoadDat, "btnLoadDat");
            this.btnLoadDat.Name = "btnLoadDat";
            this.btnLoadDat.UseVisualStyleBackColor = true;
            this.btnLoadDat.Click += new System.EventHandler(this.LoadDat_Click);
            // 
            // lbToDat
            // 
            resources.ApplyResources(this.lbToDat, "lbToDat");
            this.lbToDat.FormattingEnabled = true;
            this.lbToDat.Name = "lbToDat";
            this.lbToDat.Sorted = true;
            // 
            // btnRemoveAllPrepatches
            // 
            resources.ApplyResources(this.btnRemoveAllPrepatches, "btnRemoveAllPrepatches");
            this.btnRemoveAllPrepatches.Image = global::BuildEmAll_GUI.Properties.Resources.RemoveAllPrepatches_16x16;
            this.btnRemoveAllPrepatches.Name = "btnRemoveAllPrepatches";
            this.btnRemoveAllPrepatches.UseVisualStyleBackColor = true;
            this.btnRemoveAllPrepatches.Click += new System.EventHandler(this.RemoveAllPrepatches_Click);
            // 
            // btnAddPrepatch
            // 
            resources.ApplyResources(this.btnAddPrepatch, "btnAddPrepatch");
            this.btnAddPrepatch.Image = global::BuildEmAll_GUI.Properties.Resources.AddPrepatch_16x16;
            this.btnAddPrepatch.Name = "btnAddPrepatch";
            this.btnAddPrepatch.UseVisualStyleBackColor = true;
            this.btnAddPrepatch.Click += new System.EventHandler(this.AddPrepatch_Click);
            // 
            // btnRemovePrepatch
            // 
            resources.ApplyResources(this.btnRemovePrepatch, "btnRemovePrepatch");
            this.btnRemovePrepatch.Image = global::BuildEmAll_GUI.Properties.Resources.RemovePrepatch_16x16;
            this.btnRemovePrepatch.Name = "btnRemovePrepatch";
            this.btnRemovePrepatch.UseVisualStyleBackColor = true;
            this.btnRemovePrepatch.Click += new System.EventHandler(this.RemovePrepatch_Click);
            // 
            // lbPrepatches
            // 
            resources.ApplyResources(this.lbPrepatches, "lbPrepatches");
            this.lbPrepatches.FormattingEnabled = true;
            this.lbPrepatches.Name = "lbPrepatches";
            // 
            // btnLoadPPD
            // 
            this.btnLoadPPD.Image = global::BuildEmAll_GUI.Properties.Resources.LoadPPD_16x16;
            resources.ApplyResources(this.btnLoadPPD, "btnLoadPPD");
            this.btnLoadPPD.Name = "btnLoadPPD";
            this.btnLoadPPD.UseVisualStyleBackColor = true;
            this.btnLoadPPD.Click += new System.EventHandler(this.LoadPPD_Click);
            // 
            // lblCountPrepatches
            // 
            resources.ApplyResources(this.lblCountPrepatches, "lblCountPrepatches");
            this.lblCountPrepatches.Name = "lblCountPrepatches";
            // 
            // btnSavePPD
            // 
            this.btnSavePPD.Image = global::BuildEmAll_GUI.Properties.Resources.SavePPD_16x16;
            resources.ApplyResources(this.btnSavePPD, "btnSavePPD");
            this.btnSavePPD.Name = "btnSavePPD";
            this.btnSavePPD.UseVisualStyleBackColor = true;
            this.btnSavePPD.Click += new System.EventHandler(this.SavePPD_Click);
            // 
            // btnCheckPrepatches
            // 
            resources.ApplyResources(this.btnCheckPrepatches, "btnCheckPrepatches");
            this.btnCheckPrepatches.Image = global::BuildEmAll_GUI.Properties.Resources.CheckPrepatches_16x16;
            this.btnCheckPrepatches.Name = "btnCheckPrepatches";
            this.btnCheckPrepatches.UseVisualStyleBackColor = true;
            this.btnCheckPrepatches.Click += new System.EventHandler(this.CheckPrepatches_Click);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCommands,
            this.tsmiView});
            resources.ApplyResources(this.msMain, "msMain");
            this.msMain.Name = "msMain";
            // 
            // tsmiCommands
            // 
            this.tsmiCommands.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBuildROMs,
            this.tsmiBuildPatches,
            this.tsmiBuildPatchesDatafile,
            this.toolStripSeparator1,
            this.tsmiLoadOptions,
            this.tsmiSaveOptions,
            this.toolStripSeparator2,
            this.tsmiSaveLog,
            this.toolStripSeparator3,
            this.tsmiExit});
            this.tsmiCommands.Name = "tsmiCommands";
            resources.ApplyResources(this.tsmiCommands, "tsmiCommands");
            // 
            // tsmiBuildROMs
            // 
            resources.ApplyResources(this.tsmiBuildROMs, "tsmiBuildROMs");
            this.tsmiBuildROMs.Image = global::BuildEmAll_GUI.Properties.Resources.BuildROMs_32x32;
            this.tsmiBuildROMs.Name = "tsmiBuildROMs";
            this.tsmiBuildROMs.Click += new System.EventHandler(this.BuildROMs_Click);
            // 
            // tsmiBuildPatches
            // 
            resources.ApplyResources(this.tsmiBuildPatches, "tsmiBuildPatches");
            this.tsmiBuildPatches.Image = global::BuildEmAll_GUI.Properties.Resources.BuildPatches_32x32;
            this.tsmiBuildPatches.Name = "tsmiBuildPatches";
            this.tsmiBuildPatches.Click += new System.EventHandler(this.BuildPatches_Click);
            // 
            // tsmiBuildPatchesDatafile
            // 
            resources.ApplyResources(this.tsmiBuildPatchesDatafile, "tsmiBuildPatchesDatafile");
            this.tsmiBuildPatchesDatafile.Image = global::BuildEmAll_GUI.Properties.Resources.BuildDatafile_32x32;
            this.tsmiBuildPatchesDatafile.Name = "tsmiBuildPatchesDatafile";
            this.tsmiBuildPatchesDatafile.Click += new System.EventHandler(this.BuildPatchesDatafile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsmiLoadOptions
            // 
            resources.ApplyResources(this.tsmiLoadOptions, "tsmiLoadOptions");
            this.tsmiLoadOptions.Image = global::BuildEmAll_GUI.Properties.Resources.LoadOptions_32x32;
            this.tsmiLoadOptions.Name = "tsmiLoadOptions";
            this.tsmiLoadOptions.Click += new System.EventHandler(this.LoadOptions_Click);
            // 
            // tsmiSaveOptions
            // 
            resources.ApplyResources(this.tsmiSaveOptions, "tsmiSaveOptions");
            this.tsmiSaveOptions.Image = global::BuildEmAll_GUI.Properties.Resources.SaveOptions_32x32;
            this.tsmiSaveOptions.Name = "tsmiSaveOptions";
            this.tsmiSaveOptions.Click += new System.EventHandler(this.SaveOptions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsmiSaveLog
            // 
            resources.ApplyResources(this.tsmiSaveLog, "tsmiSaveLog");
            this.tsmiSaveLog.Image = global::BuildEmAll_GUI.Properties.Resources.SaveLog_32x32;
            this.tsmiSaveLog.Name = "tsmiSaveLog";
            this.tsmiSaveLog.Click += new System.EventHandler(this.SaveLog_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::BuildEmAll_GUI.Properties.Resources.Exit_32x32;
            this.tsmiExit.Name = "tsmiExit";
            resources.ApplyResources(this.tsmiExit, "tsmiExit");
            this.tsmiExit.Click += new System.EventHandler(this.ExitApp_Click);
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLog,
            this.toolStripSeparator7,
            this.tsmiOptions,
            this.toolStripSeparator8,
            this.tsmiPPDBuilder,
            this.toolStripSeparator9,
            this.tsmiHelp,
            this.toolStripSeparator10,
            this.tsmiLicense,
            this.toolStripSeparator11,
            this.tsmiToolbar});
            this.tsmiView.Name = "tsmiView";
            resources.ApplyResources(this.tsmiView, "tsmiView");
            // 
            // tsmiLog
            // 
            this.tsmiLog.Checked = true;
            this.tsmiLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiLog.Name = "tsmiLog";
            resources.ApplyResources(this.tsmiLog, "tsmiLog");
            this.tsmiLog.Click += new System.EventHandler(this.ViewLog_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.Checked = true;
            this.tsmiOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiOptions.Name = "tsmiOptions";
            resources.ApplyResources(this.tsmiOptions, "tsmiOptions");
            this.tsmiOptions.Click += new System.EventHandler(this.ViewOptions_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // tsmiPPDBuilder
            // 
            this.tsmiPPDBuilder.Checked = true;
            this.tsmiPPDBuilder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiPPDBuilder.Name = "tsmiPPDBuilder";
            resources.ApplyResources(this.tsmiPPDBuilder, "tsmiPPDBuilder");
            this.tsmiPPDBuilder.Click += new System.EventHandler(this.ViewPPDBuilder_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            resources.ApplyResources(this.tsmiHelp, "tsmiHelp");
            this.tsmiHelp.Click += new System.EventHandler(this.ViewHelp_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // tsmiLicense
            // 
            this.tsmiLicense.Name = "tsmiLicense";
            resources.ApplyResources(this.tsmiLicense, "tsmiLicense");
            this.tsmiLicense.Click += new System.EventHandler(this.ViewLicense_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // tsmiToolbar
            // 
            this.tsmiToolbar.Checked = true;
            this.tsmiToolbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiToolbar.Name = "tsmiToolbar";
            resources.ApplyResources(this.tsmiToolbar, "tsmiToolbar");
            this.tsmiToolbar.Click += new System.EventHandler(this.ViewToolbar_Click);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBuildROMs,
            this.tsbBuildPatches,
            this.tsbBuildPatchesDatafile,
            this.toolStripSeparator4,
            this.tsbLoadOptions,
            this.tsbSaveOptions,
            this.toolStripSeparator5,
            this.tsbSaveLog,
            this.toolStripSeparator6,
            this.tsbViewLog,
            this.tsbViewOptions,
            this.tsbViewPPDBuilder,
            this.tsbViewHelp,
            this.tsbViewLicense,
            this.tsbViewToolbar});
            resources.ApplyResources(this.tsMain, "tsMain");
            this.tsMain.Name = "tsMain";
            // 
            // tsbBuildROMs
            // 
            this.tsbBuildROMs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbBuildROMs, "tsbBuildROMs");
            this.tsbBuildROMs.Image = global::BuildEmAll_GUI.Properties.Resources.BuildROMs_32x32;
            this.tsbBuildROMs.Name = "tsbBuildROMs";
            this.tsbBuildROMs.Click += new System.EventHandler(this.BuildROMs_Click);
            // 
            // tsbBuildPatches
            // 
            this.tsbBuildPatches.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbBuildPatches, "tsbBuildPatches");
            this.tsbBuildPatches.Image = global::BuildEmAll_GUI.Properties.Resources.BuildPatches_32x32;
            this.tsbBuildPatches.Name = "tsbBuildPatches";
            this.tsbBuildPatches.Click += new System.EventHandler(this.BuildPatches_Click);
            // 
            // tsbBuildPatchesDatafile
            // 
            this.tsbBuildPatchesDatafile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbBuildPatchesDatafile, "tsbBuildPatchesDatafile");
            this.tsbBuildPatchesDatafile.Image = global::BuildEmAll_GUI.Properties.Resources.BuildDatafile_32x32;
            this.tsbBuildPatchesDatafile.Name = "tsbBuildPatchesDatafile";
            this.tsbBuildPatchesDatafile.Click += new System.EventHandler(this.BuildPatchesDatafile_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // tsbLoadOptions
            // 
            this.tsbLoadOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbLoadOptions, "tsbLoadOptions");
            this.tsbLoadOptions.Image = global::BuildEmAll_GUI.Properties.Resources.LoadOptions_32x32;
            this.tsbLoadOptions.Name = "tsbLoadOptions";
            this.tsbLoadOptions.Click += new System.EventHandler(this.LoadOptions_Click);
            // 
            // tsbSaveOptions
            // 
            this.tsbSaveOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbSaveOptions, "tsbSaveOptions");
            this.tsbSaveOptions.Image = global::BuildEmAll_GUI.Properties.Resources.SaveOptions_32x32;
            this.tsbSaveOptions.Name = "tsbSaveOptions";
            this.tsbSaveOptions.Click += new System.EventHandler(this.SaveOptions_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // tsbSaveLog
            // 
            this.tsbSaveLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbSaveLog, "tsbSaveLog");
            this.tsbSaveLog.Image = global::BuildEmAll_GUI.Properties.Resources.SaveLog_32x32;
            this.tsbSaveLog.Name = "tsbSaveLog";
            this.tsbSaveLog.Click += new System.EventHandler(this.SaveLog_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // tsbViewLog
            // 
            this.tsbViewLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewLog.Image = global::BuildEmAll_GUI.Properties.Resources.Log_32x32;
            resources.ApplyResources(this.tsbViewLog, "tsbViewLog");
            this.tsbViewLog.Name = "tsbViewLog";
            this.tsbViewLog.Click += new System.EventHandler(this.ViewLog_Click);
            // 
            // tsbViewOptions
            // 
            this.tsbViewOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewOptions.Image = global::BuildEmAll_GUI.Properties.Resources.Options_32x32;
            resources.ApplyResources(this.tsbViewOptions, "tsbViewOptions");
            this.tsbViewOptions.Name = "tsbViewOptions";
            this.tsbViewOptions.Click += new System.EventHandler(this.ViewOptions_Click);
            // 
            // tsbViewPPDBuilder
            // 
            this.tsbViewPPDBuilder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewPPDBuilder.Image = global::BuildEmAll_GUI.Properties.Resources.PPDBuilder_32x32;
            resources.ApplyResources(this.tsbViewPPDBuilder, "tsbViewPPDBuilder");
            this.tsbViewPPDBuilder.Name = "tsbViewPPDBuilder";
            this.tsbViewPPDBuilder.Click += new System.EventHandler(this.ViewPPDBuilder_Click);
            // 
            // tsbViewHelp
            // 
            this.tsbViewHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewHelp.Image = global::BuildEmAll_GUI.Properties.Resources.Help_32x32;
            resources.ApplyResources(this.tsbViewHelp, "tsbViewHelp");
            this.tsbViewHelp.Name = "tsbViewHelp";
            this.tsbViewHelp.Click += new System.EventHandler(this.ViewHelp_Click);
            // 
            // tsbViewLicense
            // 
            this.tsbViewLicense.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewLicense.Image = global::BuildEmAll_GUI.Properties.Resources.License_32x32;
            resources.ApplyResources(this.tsbViewLicense, "tsbViewLicense");
            this.tsbViewLicense.Name = "tsbViewLicense";
            this.tsbViewLicense.Click += new System.EventHandler(this.ViewLicense_Click);
            // 
            // tsbViewToolbar
            // 
            this.tsbViewToolbar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewToolbar.Image = global::BuildEmAll_GUI.Properties.Resources.Toolbar_32x32;
            resources.ApplyResources(this.tsbViewToolbar, "tsbViewToolbar");
            this.tsbViewToolbar.Name = "tsbViewToolbar";
            this.tsbViewToolbar.Click += new System.EventHandler(this.ViewToolbar_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSnap,
            this.tsslStarusMessage,
            this.tspbBuildProgress,
            this.tssbCancel});
            resources.ApplyResources(this.ssMain, "ssMain");
            this.ssMain.Name = "ssMain";
            // 
            // tsslSnap
            // 
            this.tsslSnap.Name = "tsslSnap";
            resources.ApplyResources(this.tsslSnap, "tsslSnap");
            this.tsslSnap.Spring = true;
            // 
            // tsslStarusMessage
            // 
            this.tsslStarusMessage.Name = "tsslStarusMessage";
            resources.ApplyResources(this.tsslStarusMessage, "tsslStarusMessage");
            // 
            // tspbBuildProgress
            // 
            this.tspbBuildProgress.Name = "tspbBuildProgress";
            resources.ApplyResources(this.tspbBuildProgress, "tspbBuildProgress");
            // 
            // tssbCancel
            // 
            this.tssbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbCancel.DropDownButtonWidth = 0;
            resources.ApplyResources(this.tssbCancel, "tssbCancel");
            this.tssbCancel.Image = global::BuildEmAll_GUI.Properties.Resources.Cancel_16x16;
            this.tssbCancel.Name = "tssbCancel";
            this.tssbCancel.Click += new System.EventHandler(this.CancelBuild_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabLog);
            this.tcMain.Controls.Add(this.tabOptions);
            this.tcMain.Controls.Add(this.tabPPDBuilder);
            this.tcMain.Controls.Add(this.tabHelp);
            this.tcMain.Controls.Add(this.tabLicense);
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.rtbLog);
            resources.ApplyResources(this.tabLog, "tabLog");
            this.tabLog.Name = "tabLog";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            resources.ApplyResources(this.rtbLog, "rtbLog");
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.gbOptionsInfo);
            this.tabOptions.Controls.Add(this.gbOptions);
            resources.ApplyResources(this.tabOptions, "tabOptions");
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // gbOptionsInfo
            // 
            resources.ApplyResources(this.gbOptionsInfo, "gbOptionsInfo");
            this.gbOptionsInfo.Controls.Add(this.lblOptionsInfo2);
            this.gbOptionsInfo.Controls.Add(this.lblOptionsInfo1);
            this.gbOptionsInfo.Name = "gbOptionsInfo";
            this.gbOptionsInfo.TabStop = false;
            // 
            // lblOptionsInfo2
            // 
            resources.ApplyResources(this.lblOptionsInfo2, "lblOptionsInfo2");
            this.lblOptionsInfo2.Name = "lblOptionsInfo2";
            // 
            // lblOptionsInfo1
            // 
            resources.ApplyResources(this.lblOptionsInfo1, "lblOptionsInfo1");
            this.lblOptionsInfo1.Name = "lblOptionsInfo1";
            // 
            // gbOptions
            // 
            resources.ApplyResources(this.gbOptions, "gbOptions");
            this.gbOptions.Controls.Add(this.cbLogLevel);
            this.gbOptions.Controls.Add(this.cbLanguage);
            this.gbOptions.Controls.Add(this.cbSounds);
            this.gbOptions.Controls.Add(this.lblLogLevel);
            this.gbOptions.Controls.Add(this.lblLanguage);
            this.gbOptions.Controls.Add(this.txtComment);
            this.gbOptions.Controls.Add(this.txtMachineName);
            this.gbOptions.Controls.Add(this.txtDelimiter);
            this.gbOptions.Controls.Add(this.txtXdeltaBuildCommand);
            this.gbOptions.Controls.Add(this.txtPathXdeltaFile);
            this.gbOptions.Controls.Add(this.txtPathDatPPDXMLFile);
            this.gbOptions.Controls.Add(this.txtPathDatsDir);
            this.gbOptions.Controls.Add(this.txtPathPatchesDir);
            this.gbOptions.Controls.Add(this.txtPathROMsDir);
            this.gbOptions.Controls.Add(this.lblSounds);
            this.gbOptions.Controls.Add(this.lblComment);
            this.gbOptions.Controls.Add(this.lblMachineName);
            this.gbOptions.Controls.Add(this.lblDelimiter);
            this.gbOptions.Controls.Add(this.lblXdeltaBuildCommand);
            this.gbOptions.Controls.Add(this.lblPathXdeltaFile);
            this.gbOptions.Controls.Add(this.lblPathDatPPDXMLFile);
            this.gbOptions.Controls.Add(this.lblPathDatsDir);
            this.gbOptions.Controls.Add(this.lblPathPatchesDir);
            this.gbOptions.Controls.Add(this.lblPathROMsDir);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.TabStop = false;
            // 
            // cbLogLevel
            // 
            resources.ApplyResources(this.cbLogLevel, "cbLogLevel");
            this.cbLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLogLevel.FormattingEnabled = true;
            this.cbLogLevel.Items.AddRange(new object[] {
            resources.GetString("cbLogLevel.Items")});
            this.cbLogLevel.Name = "cbLogLevel";
            // 
            // cbLanguage
            // 
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            resources.GetString("cbLanguage.Items")});
            this.cbLanguage.Name = "cbLanguage";
            // 
            // cbSounds
            // 
            resources.ApplyResources(this.cbSounds, "cbSounds");
            this.cbSounds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSounds.FormattingEnabled = true;
            this.cbSounds.Items.AddRange(new object[] {
            resources.GetString("cbSounds.Items"),
            resources.GetString("cbSounds.Items1")});
            this.cbSounds.Name = "cbSounds";
            // 
            // lblLogLevel
            // 
            resources.ApplyResources(this.lblLogLevel, "lblLogLevel");
            this.lblLogLevel.Name = "lblLogLevel";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            // 
            // txtMachineName
            // 
            resources.ApplyResources(this.txtMachineName, "txtMachineName");
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.ReadOnly = true;
            // 
            // txtDelimiter
            // 
            resources.ApplyResources(this.txtDelimiter, "txtDelimiter");
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.ReadOnly = true;
            // 
            // txtXdeltaBuildCommand
            // 
            resources.ApplyResources(this.txtXdeltaBuildCommand, "txtXdeltaBuildCommand");
            this.txtXdeltaBuildCommand.Name = "txtXdeltaBuildCommand";
            this.txtXdeltaBuildCommand.ReadOnly = true;
            // 
            // txtPathXdeltaFile
            // 
            resources.ApplyResources(this.txtPathXdeltaFile, "txtPathXdeltaFile");
            this.txtPathXdeltaFile.Name = "txtPathXdeltaFile";
            this.txtPathXdeltaFile.ReadOnly = true;
            this.txtPathXdeltaFile.Click += new System.EventHandler(this.ChangePathXdeltaFile_Click);
            // 
            // txtPathDatPPDXMLFile
            // 
            resources.ApplyResources(this.txtPathDatPPDXMLFile, "txtPathDatPPDXMLFile");
            this.txtPathDatPPDXMLFile.Name = "txtPathDatPPDXMLFile";
            this.txtPathDatPPDXMLFile.ReadOnly = true;
            this.txtPathDatPPDXMLFile.Click += new System.EventHandler(this.ChangePathDatPPDXMLFile_Click);
            // 
            // txtPathDatsDir
            // 
            resources.ApplyResources(this.txtPathDatsDir, "txtPathDatsDir");
            this.txtPathDatsDir.Name = "txtPathDatsDir";
            this.txtPathDatsDir.ReadOnly = true;
            this.txtPathDatsDir.Click += new System.EventHandler(this.ChangePathDatsDir_Click);
            // 
            // txtPathPatchesDir
            // 
            resources.ApplyResources(this.txtPathPatchesDir, "txtPathPatchesDir");
            this.txtPathPatchesDir.Name = "txtPathPatchesDir";
            this.txtPathPatchesDir.ReadOnly = true;
            this.txtPathPatchesDir.Click += new System.EventHandler(this.ChangePathPatchesDir_Click);
            // 
            // txtPathROMsDir
            // 
            resources.ApplyResources(this.txtPathROMsDir, "txtPathROMsDir");
            this.txtPathROMsDir.Name = "txtPathROMsDir";
            this.txtPathROMsDir.ReadOnly = true;
            this.txtPathROMsDir.Click += new System.EventHandler(this.ChangePathRomsDir_Click);
            // 
            // lblSounds
            // 
            resources.ApplyResources(this.lblSounds, "lblSounds");
            this.lblSounds.Name = "lblSounds";
            // 
            // lblComment
            // 
            resources.ApplyResources(this.lblComment, "lblComment");
            this.lblComment.Name = "lblComment";
            // 
            // lblMachineName
            // 
            resources.ApplyResources(this.lblMachineName, "lblMachineName");
            this.lblMachineName.Name = "lblMachineName";
            // 
            // lblDelimiter
            // 
            resources.ApplyResources(this.lblDelimiter, "lblDelimiter");
            this.lblDelimiter.Name = "lblDelimiter";
            // 
            // lblXdeltaBuildCommand
            // 
            resources.ApplyResources(this.lblXdeltaBuildCommand, "lblXdeltaBuildCommand");
            this.lblXdeltaBuildCommand.Name = "lblXdeltaBuildCommand";
            // 
            // lblPathXdeltaFile
            // 
            resources.ApplyResources(this.lblPathXdeltaFile, "lblPathXdeltaFile");
            this.lblPathXdeltaFile.Name = "lblPathXdeltaFile";
            // 
            // lblPathDatPPDXMLFile
            // 
            resources.ApplyResources(this.lblPathDatPPDXMLFile, "lblPathDatPPDXMLFile");
            this.lblPathDatPPDXMLFile.Name = "lblPathDatPPDXMLFile";
            // 
            // lblPathDatsDir
            // 
            resources.ApplyResources(this.lblPathDatsDir, "lblPathDatsDir");
            this.lblPathDatsDir.Name = "lblPathDatsDir";
            // 
            // lblPathPatchesDir
            // 
            resources.ApplyResources(this.lblPathPatchesDir, "lblPathPatchesDir");
            this.lblPathPatchesDir.Name = "lblPathPatchesDir";
            // 
            // lblPathROMsDir
            // 
            resources.ApplyResources(this.lblPathROMsDir, "lblPathROMsDir");
            this.lblPathROMsDir.Name = "lblPathROMsDir";
            // 
            // tabPPDBuilder
            // 
            this.tabPPDBuilder.Controls.Add(this.splitContainer4);
            resources.ApplyResources(this.tabPPDBuilder, "tabPPDBuilder");
            this.tabPPDBuilder.Name = "tabPPDBuilder";
            this.tabPPDBuilder.UseVisualStyleBackColor = true;
            // 
            // tabHelp
            // 
            this.tabHelp.Controls.Add(this.rtbHelp);
            resources.ApplyResources(this.tabHelp, "tabHelp");
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.UseVisualStyleBackColor = true;
            // 
            // rtbHelp
            // 
            resources.ApplyResources(this.rtbHelp, "rtbHelp");
            this.rtbHelp.Name = "rtbHelp";
            this.rtbHelp.ReadOnly = true;
            // 
            // tabLicense
            // 
            this.tabLicense.Controls.Add(this.rtbLicense);
            resources.ApplyResources(this.tabLicense, "tabLicense");
            this.tabLicense.Name = "tabLicense";
            this.tabLicense.UseVisualStyleBackColor = true;
            // 
            // rtbLicense
            // 
            resources.ApplyResources(this.rtbLicense, "rtbLicense");
            this.rtbLicense.Name = "rtbLicense";
            this.rtbLicense.ReadOnly = true;
            // 
            // bgwBuildROMs
            // 
            this.bgwBuildROMs.WorkerReportsProgress = true;
            this.bgwBuildROMs.WorkerSupportsCancellation = true;
            this.bgwBuildROMs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BuildROMs_DoWork);
            this.bgwBuildROMs.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BuildROMs_ProgressChanged);
            this.bgwBuildROMs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BuildROMs_RunWorkerCompleted);
            // 
            // bgwBuildPatches
            // 
            this.bgwBuildPatches.WorkerReportsProgress = true;
            this.bgwBuildPatches.WorkerSupportsCancellation = true;
            this.bgwBuildPatches.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BuildPatches_DoWork);
            this.bgwBuildPatches.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BuildPatches_ProgressChanged);
            this.bgwBuildPatches.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BuildPatches_RunWorkerCompleted);
            // 
            // bgwBuildDatafile
            // 
            this.bgwBuildDatafile.WorkerReportsProgress = true;
            this.bgwBuildDatafile.WorkerSupportsCancellation = true;
            this.bgwBuildDatafile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BuildDatafile_DoWork);
            this.bgwBuildDatafile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BuildDatafile_ProgressChanged);
            this.bgwBuildDatafile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BuildDatafile_RunWorkerCompleted);
            // 
            // bgwStartupTasks
            // 
            this.bgwStartupTasks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.StartupTasks_DoWork);
            this.bgwStartupTasks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.StartupTasks_RunWorkerCompleted);
            // 
            // FrmBuildEmAll
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "FrmBuildEmAll";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.gbOptionsInfo.ResumeLayout(false);
            this.gbOptionsInfo.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.tabPPDBuilder.ResumeLayout(false);
            this.tabHelp.ResumeLayout(false);
            this.tabLicense.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiCommands;
        private System.Windows.Forms.ToolStripMenuItem tsmiBuildROMs;
        private System.Windows.Forms.ToolStripMenuItem tsmiBuildPatches;
        private System.Windows.Forms.ToolStripMenuItem tsmiBuildPatchesDatafile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiPPDBuilder;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiLicense;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.TabPage tabPPDBuilder;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.TabPage tabLicense;
        private System.Windows.Forms.ToolStripStatusLabel tsslSnap;
        private System.Windows.Forms.ToolStripStatusLabel tsslStarusMessage;
        private System.Windows.Forms.ToolStripButton tsbBuildROMs;
        private System.Windows.Forms.ToolStripButton tsbBuildPatches;
        private System.Windows.Forms.ToolStripButton tsbBuildPatchesDatafile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbLoadOptions;
        private System.Windows.Forms.ToolStripButton tsbSaveOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbSaveLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbViewLog;
        private System.Windows.Forms.ToolStripButton tsbViewOptions;
        private System.Windows.Forms.ToolStripButton tsbViewPPDBuilder;
        private System.Windows.Forms.ToolStripButton tsbViewHelp;
        private System.Windows.Forms.ToolStripButton tsbViewLicense;
        private System.Windows.Forms.ToolStripButton tsbViewToolbar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.ComponentModel.BackgroundWorker bgwBuildROMs;
        private System.ComponentModel.BackgroundWorker bgwBuildPatches;
        private System.ComponentModel.BackgroundWorker bgwBuildDatafile;
        private System.Windows.Forms.RichTextBox rtbHelp;
        private System.Windows.Forms.RichTextBox rtbLicense;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.TextBox txtXdeltaBuildCommand;
        private System.Windows.Forms.TextBox txtPathXdeltaFile;
        private System.Windows.Forms.TextBox txtPathDatPPDXMLFile;
        private System.Windows.Forms.TextBox txtPathDatsDir;
        private System.Windows.Forms.TextBox txtPathPatchesDir;
        private System.Windows.Forms.TextBox txtPathROMsDir;
        private System.Windows.Forms.Label lblSounds;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.Label lblXdeltaBuildCommand;
        private System.Windows.Forms.Label lblPathXdeltaFile;
        private System.Windows.Forms.Label lblPathDatPPDXMLFile;
        private System.Windows.Forms.Label lblPathDatsDir;
        private System.Windows.Forms.Label lblPathPatchesDir;
        private System.Windows.Forms.Label lblPathROMsDir;
        private System.ComponentModel.BackgroundWorker bgwStartupTasks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolbar;
        private System.Windows.Forms.ToolStripProgressBar tspbBuildProgress;
        private System.Windows.Forms.ToolStripSplitButton tssbCancel;
        private System.Windows.Forms.Button btnLoadDat;
        private System.Windows.Forms.Button btnRemoveAllPrepatches;
        private System.Windows.Forms.Button btnRemovePrepatch;
        private System.Windows.Forms.Button btnAddPrepatch;
        private System.Windows.Forms.Label lblCountPrepatches;
        private System.Windows.Forms.Button btnCheckPrepatches;
        private System.Windows.Forms.Button btnSavePPD;
        private System.Windows.Forms.Button btnLoadPPD;
        private System.Windows.Forms.ListBox lbFromDat;
        private System.Windows.Forms.ListBox lbToDat;
        private System.Windows.Forms.ListBox lbPrepatches;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private Serilog.Sinks.LogEmAll.RichTextBoxLog rtbLog;
        private System.Windows.Forms.TextBox txtLoadedDatafile;
        private System.Windows.Forms.Label lblLogLevel;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cbLogLevel;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.ComboBox cbSounds;
        private System.Windows.Forms.GroupBox gbOptionsInfo;
        private System.Windows.Forms.Label lblOptionsInfo2;
        private System.Windows.Forms.Label lblOptionsInfo1;
    }
}

