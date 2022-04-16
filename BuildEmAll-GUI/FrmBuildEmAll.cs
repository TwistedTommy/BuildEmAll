using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Windows.Forms;
using Serilog;
using System.Diagnostics;

namespace BuildEmAll_GUI
{
    /// <summary>
    /// The BuildEmAll GUI Form Class which interacts with the Main Program Class.
    /// </summary>
    public partial class FrmBuildEmAll : Form
    {
        #region Constructors

        BuildEmAll.BuildEmAll BEA = new BuildEmAll.BuildEmAll();

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmBuildEmAll()
        {
            // Initialize the form.
            InitializeComponent();

            // Print the version.
            BEA.PrintVersion();

            // Hide the Help and License tabs.
            tcMain.TabPages.Remove(tabHelp);
            tcMain.TabPages.Remove(tabLicense);

            // Load the default options passed from the command line arguments.
            BEA.LoadOptionsFromCLI(Environment.GetCommandLineArgs());

            // Load the default options passed from the default options file.
            BEA.LoadOptionsFromFile();

            // Add data bindings.
            txtPathROMsDir.DataBindings.Add("Text", BEA, "PathROMsDir");
            txtPathPatchesDir.DataBindings.Add("Text", BEA, "PathPatchesDir");
            txtPathDatsDir.DataBindings.Add("Text", BEA, "PathDatsDir");
            txtPathDatPPDXMLFile.DataBindings.Add("Text", BEA, "PathDatPPDXMLFile");
            txtPathXdeltaFile.DataBindings.Add("Text", BEA, "PathXdeltaFile");
            txtXdeltaBuildCommand.DataBindings.Add("Text", BEA, "XdeltaBuildCommand");
            txtDelimiter.DataBindings.Add("Text", BEA, "Delimiter");
            txtMachineName.DataBindings.Add("Text", BEA, "MachineName");
            txtComment.DataBindings.Add("Text", BEA, "Comment");
            cbSounds.DataBindings.Add("SelectedItem", BEA, "Sounds");
            cbLanguage.DataBindings.Add("SelectedItem", BEA, "Language");
            cbLogLevel.DataBindings.Add("SelectedItem", BEA, "LogLevel");

            // Set the title.
            UpdateTitle();

            // Load the GUI RichTextBoxes from resources.
            rtbHelp.Text = BuildEmAll.Properties.Resources.BuildEmAll_HELP;
            rtbLicense.Text = BuildEmAll.Properties.Resources.BuildEmAll_LICENSE;
        }

        #endregion

        #region Getters/Setters Public Accessors

        /// LogLines
        public string[] LogLines
        {
            get { return rtbLog.Lines; }
            set { rtbLog.Lines = value; }
        }

        #endregion

        #region Log

        /// <summary>
        /// Saves the log to a text file.
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public bool SaveLogToFile(string strPath = null)
        {
            try
            {
                if (strPath != null)
                {
                    BEA.PathLogFile = strPath;
                }

                // Determine if the user selected a log filename.
                if (BEA.PathLogFile.Length == 0)
                {
                    // Return a bool value.
                    return false;
                }
                else
                {
                    // Print to screen
                    Log.Information("Saving log file ...");

                    // Create log file directory if it doesn't exist.
                    if (Directory.Exists(Path.GetDirectoryName(BEA.PathLogFile)) == false) Directory.CreateDirectory(Path.GetDirectoryName(BEA.PathLogFile));

                    // Save the contents of the log to a text file.
                    File.WriteAllLines(BEA.PathLogFile, LogLines);

                    // Print to screen
                    Log.Information("Log file saved (" + BEA.PathLogFile + ")");

                    // Return a bool value.
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Saving log file failed");
                Log.Error(ex.Message);

                // Return a bool value.
                return false;
            }
        }

        #endregion

        #region Startup Tasks

        /// <summary>
        /// StartupTasks DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartupTasks_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // 
        }

        /// <summary>
        /// StartupTasks RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartupTasks_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // Print to screen.
                Log.Information("Startup tasks canceled");
                Log.Information("Ready");
            }
            else if (e.Error != null)
            {
                // Print to screen.
                Log.Error("Startup tasks failed");
                Log.Error("" + e.Error.Message);
                Log.Information("Ready");
            }
            else
            {
                // Print to screen.
                Log.Information("Startup tasks completed");
                Log.Information("Ready");
            }

            // Update the status message label.
            UpdateStatusMessageLabel("Ready");

            // Enable all buttons.
            EnableAllButtons();
        }

        #endregion

        #region GUI Methods

        /// <summary>
        /// Updates the build progress status progress bar.
        /// </summary>
        /// <param name="intPercentage"></param>
        private void UpdateStatusBuildProgress(int intPercentage)
        {
            // Update the build progress status progress bar.
            tspbBuildProgress.Value = intPercentage;
        }

        /// <summary>
        /// Updates the progress status message label.
        /// </summary>
        /// <param name="strMsg"></param>
        private void UpdateStatusMessageLabel(string strMsg)
        {
            // Update the progress status message label.
            tsslStarusMessage.Text = strMsg;
        }

        /// <summary>
        /// Updates/Sets the application title.
        /// </summary>
        /// <param name="strTitle"></param>
        /// <returns></returns>
        private bool UpdateTitle(string strTitle = "")
        {
            try
            {
                if (this.InvokeRequired && !this.IsDisposed)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        // Update the application title.
                        this.Text = BEA.AppName + " v" + BEA.AppVersion + strTitle;
                    }));
                }
                else if (!this.IsDisposed)
                {
                    // Update the application title.
                    this.Text = BEA.AppName + " v" + BEA.AppVersion + strTitle;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Cancels the current build operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBuild_Click(object sender, EventArgs e)
        {
            // Print to screen
            Log.Information("Cancellation pending after current operation");

            // Disable the cancel button.
            tssbCancel.Enabled = false;

            if (bgwBuildROMs.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                bgwBuildROMs.CancelAsync();
            }
            if (bgwBuildPatches.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                bgwBuildPatches.CancelAsync();
            }
            if (bgwBuildDatafile.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                bgwBuildDatafile.CancelAsync();
            }
        }

        /// <summary>
        /// Loads an options file.
        /// </summary>
        private void LoadOptions_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable all buttons.
                DisableAllButtons();

                // Create and initialize an OpenFileDialog for the options file.
                OpenFileDialog ofdOptions = new OpenFileDialog
                {
                    DefaultExt = "*.xml",
                    Filter = "XML Files|*.xml",
                    Title = "Please enter a path to the options file: ",
                    InitialDirectory = Path.Combine(Application.StartupPath, "Options")
                };

                // Determine if the user selected a file name from the OpenFileDialog.
                if (ofdOptions.ShowDialog() == DialogResult.OK && ofdOptions.FileName.Length > 0)
                {
                    // Set the options file path.
                    BEA.PathOptionsFile = ofdOptions.FileName;

                    // Select the Log tab.
                    if (tcMain.TabPages.Contains(tabLog)) { tcMain.SelectTab(tabLog); }

                    // Load the options.
                    BEA.LoadOptionsFromFile();

                    // Print to screen
                    Log.Information("Ready");
                }

                // Dispose of the OpenFileDialog.
                ofdOptions.Dispose();

                // Enable all buttons.
                EnableAllButtons();
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Loading options failed");
                Log.Error("" + ex.Message);
                Log.Information("Ready");
            }
        }

        /// <summary>
        /// Saves an options file.
        /// </summary>
        private void SaveOptions_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable all buttons.
                DisableAllButtons();

                // Create and initialize a SaveFileDialog for the options file.
                SaveFileDialog sfdOptions = new SaveFileDialog
                {
                    DefaultExt = "*.xml",
                    Filter = "XML Files|*.xml",
                    FileName = "BuildEmAll-Options.xml",
                    Title = "Please enter a path to the options file: ",
                    InitialDirectory = Path.Combine(Application.StartupPath, "Options")
                };

                // Determine if the user selected a file name from the SaveFileDialog.
                if (sfdOptions.ShowDialog() == DialogResult.OK && sfdOptions.FileName.Length > 0)
                {
                    // Set the options file path.
                    BEA.PathOptionsFile = sfdOptions.FileName;

                    // Select the Log tab.
                    if (tcMain.TabPages.Contains(tabLog)) { tcMain.SelectTab(tabLog); }

                    // Save the options.
                    BEA.SaveOptionsToFile();

                    // Print to screen
                    Log.Information("Ready");
                }

                // Dispose of the SaveFileDialog.
                sfdOptions.Dispose();

                // Enable all buttons.
                EnableAllButtons();
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Saving options failed");
                Log.Error("" + ex.Message);
                Log.Information("Ready");
            }

        }

        /// <summary>
        /// Saves a log file.
        /// </summary>
        private void SaveLog_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable all buttons.
                DisableAllButtons();

                // Create and initialize a SaveFileDialog for the log file.
                SaveFileDialog sfdLog = new SaveFileDialog
                {
                    DefaultExt = "*.txt",
                    Filter = "TXT Files|*.txt",
                    FileName = "BuildEmAll-Log-" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt",
                    Title = "Please enter a path to the log file: ",
                    InitialDirectory = Path.Combine(Application.StartupPath, "Logs")
                };

                // Determine if the user selected a log filename.
                if (sfdLog.ShowDialog() == DialogResult.OK && sfdLog.FileName.Length > 0)
                {
                    // Set the log file path.
                    BEA.PathLogFile = sfdLog.FileName;

                    // Select the Log tab.
                    if (tcMain.TabPages.Contains(tabLog)) { tcMain.SelectTab(tabLog); }

                    // Save the log.
                    SaveLogToFile(BEA.PathLogFile);

                    // Print to screen
                    Log.Information("Ready");
                }

                // Dispose of the SaveFileDialog.
                sfdLog.Dispose();

                // Enable all buttons.
                EnableAllButtons();
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Saving log file failed");
                Log.Error("" + ex.Message);
                Log.Information("Ready");
            }
        }

        /// <summary>
        /// Enables all of the buttons.
        /// </summary>
        private void EnableAllButtons()
        {
            // Enable all Menu Item buttons.
            tsmiCommands.Enabled = true;
            tsmiExit.Enabled = true;
            tsmiBuildROMs.Enabled = true;
            tsmiBuildPatches.Enabled = true;
            tsmiBuildPatchesDatafile.Enabled = true;
            tsmiLoadOptions.Enabled = true;
            tsmiSaveOptions.Enabled = true;
            tsmiSaveLog.Enabled = true;

            // Enable all Toolbar buttons.
            tsbBuildROMs.Enabled = true;
            tsbBuildPatches.Enabled = true;
            tsbBuildPatchesDatafile.Enabled = true;
            tsbLoadOptions.Enabled = true;
            tsbSaveOptions.Enabled = true;
            tsbSaveLog.Enabled = true;

            // Enable all Options buttons.
            txtPathROMsDir.Enabled = true;
            txtPathPatchesDir.Enabled = true;
            txtPathDatsDir.Enabled = true;
            txtPathDatPPDXMLFile.Enabled = true;
            txtPathXdeltaFile.Enabled = true;
            txtXdeltaBuildCommand.Enabled = true;
            txtDelimiter.Enabled = true;
            txtMachineName.Enabled = true;
            txtComment.Enabled = true;
            cbSounds.Enabled = true;
            cbLanguage.Enabled = true;
            cbLogLevel.Enabled = true;
        }

        /// <summary>
        /// Disables all of the buttons.
        /// </summary>
        private void DisableAllButtons()
        {
            // Disable all Menu Item buttons.
            tsmiCommands.Enabled = false;
            tsmiExit.Enabled = false;
            tsmiBuildROMs.Enabled = false;
            tsmiBuildPatches.Enabled = false;
            tsmiBuildPatchesDatafile.Enabled = false;
            tsmiLoadOptions.Enabled = false;
            tsmiSaveOptions.Enabled = false;
            tsmiSaveLog.Enabled = false;

            // Disable all Toolbar buttons.
            tsbBuildROMs.Enabled = false;
            tsbBuildPatches.Enabled = false;
            tsbBuildPatchesDatafile.Enabled = false;
            tsbLoadOptions.Enabled = false;
            tsbSaveOptions.Enabled = false;
            tsbSaveLog.Enabled = false;

            // Disable all Options buttons.
            txtPathROMsDir.Enabled = false;
            txtPathPatchesDir.Enabled = false;
            txtPathDatsDir.Enabled = false;
            txtPathDatPPDXMLFile.Enabled = false;
            txtPathXdeltaFile.Enabled = false;
            txtXdeltaBuildCommand.Enabled = false;
            txtDelimiter.Enabled = false;
            txtMachineName.Enabled = false;
            txtComment.Enabled = false;
            cbSounds.Enabled = false;
            cbLanguage.Enabled = false;
            cbLogLevel.Enabled = false;
        }

        /// <summary>
        /// Exits the WinForm app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Change Options Click Events

        /// <summary>
        /// Changes the path to the ROMs directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePathRomsDir_Click(object sender, EventArgs e)
        {
            // Disable all buttons.
            DisableAllButtons();

            if (txtPathROMsDir.Text == "") { txtPathROMsDir.Text = Path.Combine(Application.StartupPath, "ROMs"); }

            // Play a sound.
            PlaySound("Confirm");

            // Create and initialize a FolderBrowserDialog for the ROMs directory.
            FolderBrowserDialog fbdPathRomsDir = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Please enter a path to the ROMs directory: ",
                SelectedPath = Path.Combine(Application.StartupPath, "ROMs")
            };

            // Determine if the user selected a folder name from the FolderBrowserDialog.
            if (fbdPathRomsDir.ShowDialog() == DialogResult.OK)
            {
                // Set both variables for compatibility for Windows .Net and Mono.
                BEA.PathROMsDir = fbdPathRomsDir.SelectedPath;
                txtPathROMsDir.Text = fbdPathRomsDir.SelectedPath;
            }

            // Enable all buttons.
            EnableAllButtons();
        }

        /// <summary>
        /// Changes the path to the patches directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePathPatchesDir_Click(object sender, EventArgs e)
        {
            // Disable all buttons.
            DisableAllButtons();

            if (txtPathPatchesDir.Text == "") { txtPathPatchesDir.Text = Path.Combine(Application.StartupPath, "Patches"); }

            // Play a sound.
            PlaySound("Confirm");

            // Create and initialize a FolderBrowserDialog for the patches directory.
            FolderBrowserDialog fbdPathPatchesDir = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Please enter a path to the patches directory: ",
                SelectedPath = Path.Combine(Application.StartupPath, "Patches")
            };

            // Determine if the user selected OK from the FolderBrowserDialog.
            if (fbdPathPatchesDir.ShowDialog() == DialogResult.OK)
            {
                // Set both variables for compatibility for Windows .Net and Mono.
                BEA.PathPatchesDir = fbdPathPatchesDir.SelectedPath;
                txtPathPatchesDir.Text = fbdPathPatchesDir.SelectedPath;
            }

            // Enable all buttons.
            EnableAllButtons();
        }

        /// <summary>
        /// Changes the path to the dats directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePathDatsDir_Click(object sender, EventArgs e)
        {
            // Disable all buttons.
            DisableAllButtons();

            if (txtPathDatsDir.Text == "") { txtPathDatsDir.Text = Path.Combine(Application.StartupPath, "Dats"); }

            // Play a sound.
            PlaySound("Confirm");

            // Create and initialize a FolderBrowserDialog for the dats directory.
            FolderBrowserDialog fbdPathDatsDir = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Please enter a path to the dats directory: ",
                SelectedPath = Path.Combine(Application.StartupPath, "Dats")
            };

            // Determine if the user selected a folder name from the FolderBrowserDialog.
            if (fbdPathDatsDir.ShowDialog() == DialogResult.OK)
            {
                // Set both variables for compatibility for Windows .Net and Mono.
                BEA.PathDatsDir = fbdPathDatsDir.SelectedPath;
                txtPathDatsDir.Text = fbdPathDatsDir.SelectedPath;
            }

            // Enable all buttons.
            EnableAllButtons();
        }

        /// <summary>
        /// Changes the path to the Dat/PPD/XML file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePathDatPPDXMLFile_Click(object sender, EventArgs e)
        {
            // Disable all buttons.
            DisableAllButtons();

            // Play a sound.
            PlaySound("Confirm");

            // Create and initialize an OpenFileDialog for the Dat/PPD/XML file.
            OpenFileDialog ofdPathDatFile = new OpenFileDialog
            {
                DefaultExt = "*.dat",
                Filter = "All Datafiles|*.dat;*.ppd;*.xml|DAT Files|*.dat|PPD Files|*.ppd|XML Files|*.xml",
                Title = "Please enter a path to the Dat/PPD/XML file: ",
                InitialDirectory = Path.Combine(Application.StartupPath, "Dats")
            };

            // Determine if the user selected a file name from the OpenFileDialog.
            if (ofdPathDatFile.ShowDialog() == DialogResult.OK && ofdPathDatFile.FileName.Length > 0)
            {
                // Set both variables for compatibility for Windows .Net and Mono.
                BEA.PathDatPPDXMLFile = ofdPathDatFile.FileName;
                txtPathDatPPDXMLFile.Text = ofdPathDatFile.FileName;
            }

            // Enable all buttons.
            EnableAllButtons();
        }

        /// <summary>
        /// Changes the path to the Xdelta file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePathXdeltaFile_Click(object sender, EventArgs e)
        {
            // Disable all buttons.
            DisableAllButtons();

            // Play a sound.
            PlaySound("Confirm");

            // Create and initialize an OpenFileDialog for the Xdelta file.
            OpenFileDialog ofdPathXdeltaFile = new OpenFileDialog
            {
                DefaultExt = "*.exe",
                Filter = "EXE Files|*.exe|BIN Files|*.bin",
                Title = "Please enter a path to the Xdelta file: ",
                InitialDirectory = Path.Combine(Application.StartupPath, "Xdelta")
            };

            // Determine if the user selected a file name from the OpenFileDialog.
            if (ofdPathXdeltaFile.ShowDialog() == DialogResult.OK && ofdPathXdeltaFile.FileName.Length > 0)
            {
                // Set both variables for compatibility for Windows .Net and Mono.
                BEA.PathXdeltaFile = ofdPathXdeltaFile.FileName;
                txtPathXdeltaFile.Text = ofdPathXdeltaFile.FileName;
            }

            // Enable all buttons.
            EnableAllButtons();
        }

        // Command must end with '-s' and should not contain '-v'

        #endregion

        #region View Click Events

        /// <summary>
        /// Toggles the visibility of the log.
        /// </summary>
        private void ViewLog_Click(object sender, EventArgs e)
        {
            if (tsmiLog.Checked)
            {
                tsmiLog.Checked = false;
                tsmiLog.CheckState = CheckState.Unchecked;
                tcMain.TabPages.Remove(tabLog);
            }
            else
            {
                tsmiLog.Checked = true;
                tsmiLog.CheckState = CheckState.Checked;
                tcMain.TabPages.Add(tabLog);
                tcMain.SelectTab(tabLog);
            }
        }

        /// <summary>
        /// Toggles the visibility of the options.
        /// </summary>
        private void ViewOptions_Click(object sender, EventArgs e)
        {
            if (tsmiOptions.Checked)
            {
                tsmiOptions.Checked = false;
                tsmiOptions.CheckState = CheckState.Unchecked;
                tcMain.TabPages.Remove(tabOptions);
            }
            else
            {
                tsmiOptions.Checked = true;
                tsmiOptions.CheckState = CheckState.Checked;
                tcMain.TabPages.Add(tabOptions);
                tcMain.SelectTab(tabOptions);
            }
        }

        /// <summary>
        /// Toggles the visibility of the PPD Builder.
        /// </summary>
        private void ViewPPDBuilder_Click(object sender, EventArgs e)
        {
            if (tsmiPPDBuilder.Checked)
            {
                tsmiPPDBuilder.Checked = false;
                tsmiPPDBuilder.CheckState = CheckState.Unchecked;
                tcMain.TabPages.Remove(tabPPDBuilder);
            }
            else
            {
                tsmiPPDBuilder.Checked = true;
                tsmiPPDBuilder.CheckState = CheckState.Checked;
                tcMain.TabPages.Add(tabPPDBuilder);
                tcMain.SelectTab(tabPPDBuilder);
            }
        }

        /// <summary>
        /// Toggles the visibility of the help.
        /// </summary>
        private void ViewHelp_Click(object sender, EventArgs e)
        {
            if (tsmiHelp.Checked)
            {
                tsmiHelp.Checked = false;
                tsmiHelp.CheckState = CheckState.Unchecked;
                tcMain.TabPages.Remove(tabHelp);
            }
            else
            {
                tsmiHelp.Checked = true;
                tsmiHelp.CheckState = CheckState.Checked;
                tcMain.TabPages.Add(tabHelp);
                tcMain.SelectTab(tabHelp);
            }
        }

        /// <summary>
        /// Toggles the visibility of the license.
        /// </summary>
        private void ViewLicense_Click(object sender, EventArgs e)
        {
            if (tsmiLicense.Checked)
            {
                tsmiLicense.Checked = false;
                tsmiLicense.CheckState = CheckState.Unchecked;
                tcMain.TabPages.Remove(tabLicense);
            }
            else
            {
                tsmiLicense.Checked = true;
                tsmiLicense.CheckState = CheckState.Checked;
                tcMain.TabPages.Add(tabLicense);
                tcMain.SelectTab(tabLicense);
            }
        }

        /// <summary>
        /// Toggles the visibility of the toolbar.
        /// </summary>
        private void ViewToolbar_Click(object sender, EventArgs e)
        {
            if (tsMain.Visible)
            {
                tsMain.Visible = false;
                tsmiToolbar.Checked = false;
            }
            else
            {
                tsMain.Visible = true;
                tsmiToolbar.Checked = true;
            }
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Form Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Shown(object sender, EventArgs e)
        {
            // Perform the startup tasks.
            bgwStartupTasks.RunWorkerAsync();
        }

        /// <summary>
        /// Check some things to make sure it is safe to exit the WinForms application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgwBuildROMs.IsBusy == true || bgwBuildPatches.IsBusy == true || bgwBuildDatafile.IsBusy == true)
            {
                if (MessageBox.Show("The builder is currently running. Exiting now may cause corrupt or incomplete files! Are you sure you want to exit now?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Sounds

        /// <summary>
        /// Plays a Resource sound file.
        /// </summary>
        /// <param name="strSoundName"></param>
        private void PlaySound(string strSoundName)
        {
            // Check to see if the sounds are turned on.
            if (BEA.Sounds == "On")
            {
                // Create a new SoundPlayer object.
                SoundPlayer soundPlayer = new SoundPlayer();

                // Set the stream resource.
                if (strSoundName == "Confirm")
                {
                    soundPlayer.Stream = Properties.Resources.Confirm;
                }
                if (strSoundName == "Fail")
                {
                    soundPlayer.Stream = Properties.Resources.Fail;
                }
                if (strSoundName == "AddRemove")
                {
                    soundPlayer.Stream = Properties.Resources.AddRemove;
                }
                if (strSoundName == "Complete")
                {
                    soundPlayer.Stream = Properties.Resources.Complete;
                }

                // Play the sound.
                soundPlayer.Play();
            }
        }

        #endregion

        #region Build ROMs

        /// <summary>
        /// Builds all possible ROMs from all supplied patches.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildROMs_Click(object sender, EventArgs e)
        {
            // Select the Log tab.
            if (tcMain.TabPages.Contains(tabLog)) { tcMain.SelectTab(tabLog); }

            // Disable all buttons.
            DisableAllButtons();

            // Enable the cancel button.
            tssbCancel.Enabled = true;

            // Change the log background color.
            rtbLog.BackColor = Color.LightGreen;

            // Update the status message label.
            UpdateStatusMessageLabel("Building ROMs ...");

            // Build ROMs.
            bgwBuildROMs.RunWorkerAsync();
        }

        /// <summary>
        /// Does the work for the Build ROMs bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildROMs_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e != null && e.Cancel == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Print to screen
                    Log.Information("Building all possible ROMs ...");

                    // Declarations
                    BackgroundWorker worker = sender as BackgroundWorker;   // Background worker
                    int intProgress = 0;                                    // Background worker progress
                    bool boolExitFlag = false;                              // Exit flag
                    int intCounterTotalBuilt = 0;                           // Total built counter
                    int intCountArrDirFiles = 0;                            // Total loop count
                    string strPathRomsDir = BEA.PathROMsDir;                    // Path to the ROMs directory
                    string strPathPatchesDir = BEA.PathPatchesDir;              // Path to the Patches directory
                    string strPathXdeltaFile = BEA.PathXdeltaFile;              // Path to the Xdelta file
                    string strDelimiter = BEA.Delimiter;                        // Delimiter

                    // Checkers
                    bool boolPathROMsDirCheck = BEA.PathROMsDirCheck();
                    bool boolPathPatchesDirCheck = BEA.PathPatchesDirCheck();
                    bool boolPathXdeltaFileCheck = BEA.PathXdeltaFileCheck();

                    // Check the paths and directories.
                    if (boolPathROMsDirCheck == false && boolPathPatchesDirCheck == false && boolPathXdeltaFileCheck == false)
                    {
                        // Print to screen
                        Log.Information("Options: ROMs Directory (" + strPathRomsDir + ")");
                        Log.Information("Options: Patches Directory (" + strPathPatchesDir + ")");
                        Log.Information("Options: Xdelta File (" + strPathXdeltaFile + ")");
                        Log.Information("Options: Delimiter (" + strDelimiter + ")");

                        // Get the directory files array and count.
                        string[] arrDirFiles = Directory.GetFiles(strPathPatchesDir, "*.xd3");
                        intCountArrDirFiles = arrDirFiles.Count();

                        // Create and start a stopwatch.
                        var stopWatch = new Stopwatch();
                        stopWatch.Start();

                        // Main loop - Build all possible ROMs from all supplied patches.
                        while (intCountArrDirFiles > 0 && boolExitFlag == false)
                        {
                            // Set the exit flag to true.
                            boolExitFlag = true;

                            // Loop through the patches directory files array.
                            foreach (string strPatchName in arrDirFiles)
                            {
                                // Explode the patch filename.
                                string strPatchNameNew = Path.GetFileName(strPatchName);
                                string[] arrDelimiters = { strDelimiter };
                                string[] arrPatchNames = strPatchNameNew.Split(arrDelimiters, StringSplitOptions.RemoveEmptyEntries);

                                // Check for source and destination parts.
                                if (arrPatchNames.Count() > 1)
                                {
                                    // Rename the source and destination file.
                                    string strPatchNameSrc = arrPatchNames[0];
                                    string strPatchNameDest = arrPatchNames[1].Replace(".xd3", "");

                                    // If the source file exists and the destination file doesn't exist, build the destination file.
                                    if (File.Exists(Path.Combine(strPathRomsDir, strPatchNameSrc)) == true && File.Exists(Path.Combine(strPathRomsDir, strPatchNameDest)) == false)
                                    {
                                        // Print to screen
                                        Log.Information("Building: " + strPatchNameDest);
                                        Log.Information("From: " + strPatchNameSrc);
                                        UpdateStatusMessageLabel("Building " + (intCounterTotalBuilt + 1) + " of " + intCountArrDirFiles + " ROMs from patches dir ...");

                                        // Build the ROM.
                                        Process pProcess = new Process();
                                        pProcess.StartInfo.UseShellExecute = false;
                                        pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                        pProcess.StartInfo.CreateNoWindow = true;
                                        pProcess.StartInfo.RedirectStandardInput = true;
                                        pProcess.StartInfo.RedirectStandardOutput = true;
                                        pProcess.StartInfo.RedirectStandardError = true;
                                        pProcess.StartInfo.FileName = strPathXdeltaFile;
                                        pProcess.StartInfo.Arguments = "-d -s \"" + Path.Combine(strPathRomsDir, strPatchNameSrc) + "\" \"" + Path.Combine(strPathPatchesDir, strPatchNameNew) + "\" \"" + Path.Combine(strPathRomsDir, strPatchNameDest) + "\"";
                                        pProcess.Start();
                                        string strError = pProcess.StandardError.ReadToEnd();
                                        pProcess.WaitForExit();

                                        // This isn't the preferred way to check for errors.
                                        if (strError == "")
                                        {
                                            // Increment the counter and progress bar.
                                            intCounterTotalBuilt++;
                                            intProgress = (int)((double)intCounterTotalBuilt / (double)intCountArrDirFiles * 100);
                                            worker.ReportProgress(intProgress);
                                            boolExitFlag = false;
                                        }
                                        else
                                        {
                                            // Print the output of Xdelta to the screen.
                                            Log.Error("Bad patch (" + strPatchNameNew + ")");
                                            Log.Error(strError);
                                        }
                                    }
                                }
                                else
                                {
                                    // Print to screen
                                    Log.Error("Bad patch name (" + arrPatchNames[0] + ")");
                                }

                                // Check if the background worker is pending cancellation.
                                if (worker.CancellationPending == true)
                                {
                                    boolExitFlag = true;
                                    e.Cancel = true;
                                    break;
                                }
                            }
                        }

                        // Stop the stopwatch.
                        stopWatch.Stop();

                        // Print to screen
                        Log.Information("" + intCounterTotalBuilt + " ROMs built successfully in " + stopWatch.Elapsed);
                    }

                    // Print to screen
                    Log.Information("Building all possible ROMs completed");
                }
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Building all possible ROMs failed");
                Log.Error("" + ex.Message);
            }
        }

        /// <summary>
        /// Changes the progress of the Build ROMs bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildROMs_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Display the changed progress status.
            UpdateStatusBuildProgress(e.ProgressPercentage);
        }

        /// <summary>
        /// Completes the Build ROMs bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildROMs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // Print to screen.
                Log.Information("Building all possible ROMs canceled");
                Log.Information("Ready");
            }
            else if (e.Error != null)
            {
                // Print to screen.
                Log.Error("Building all possible ROMs failed");
                Log.Error("" + e.Error.Message);
                Log.Information("Ready");
            }
            else
            {
                // Print to screen.
                Log.Information("Ready");
            }

            // Reset the log background color.
            rtbLog.BackColor = SystemColors.Control;

            // Enable all buttons.
            EnableAllButtons();

            // Reset the progress status.
            UpdateStatusBuildProgress(0);

            // Update the status message label.
            UpdateStatusMessageLabel("Ready");

            // Disable the cancel button.
            tssbCancel.Enabled = false;

            // Play a sound.
            PlaySound("Complete");
        }

        #endregion

        #region Build Patches

        /// <summary>
        /// Builds all possible patches from all supplied ROMs and a datafile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildPatches_Click(object sender, EventArgs e)
        {
            // Select the Log tab.
            if (tcMain.TabPages.Contains(tabLog)) { tcMain.SelectTab(tabLog); }

            // Disable all buttons.
            DisableAllButtons();

            // Enable the cancel button.
            tssbCancel.Enabled = true;

            // Change the log background color.
            rtbLog.BackColor = Color.LightGreen;

            // Update the status message label.
            UpdateStatusMessageLabel("Building Patches ...");

            // Build patches.
            bgwBuildPatches.RunWorkerAsync();
        }

        /// <summary>
        /// Does the work for the Build Patches bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildPatches_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e != null && e.Cancel == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Print to screen
                    Log.Information("Info: Building all possible patches ...");

                    // Declarations
                    BackgroundWorker worker = sender as BackgroundWorker;               // Background worker
                    int intProgress = 0;                                                // Background worker progress
                    int intCounterTotalBuilt = 0;                                       // Total built counter
                    int intCountXdocPatches = 0;                                        // Total loop counter
                    string strPathXdeltaFile = BEA.PathXdeltaFile;                          // Path to the Xdelta file
                    string strXdeltaBuildCommand = BEA.XdeltaBuildCommand;                  // Xdelta build command
                    string strPathDatPPDXMLFile = BEA.PathDatPPDXMLFile;                    // Path to the Dat/PPD/XML file
                    string strPathRomsDir = BEA.PathROMsDir;                                // Path to the ROMs directory
                    string strPathPatchesDir = BEA.PathPatchesDir;                          // Path to the Patches directory
                    string strDelimiter = BEA.Delimiter;                                    // Delimiter

                    // Checkers
                    bool boolPathROMsDirCheck = BEA.PathROMsDirCheck();
                    bool boolPathPatchesDirCheck = BEA.PathPatchesDirCheck();
                    bool boolPathXdeltaFileCheck = BEA.PathXdeltaFileCheck();
                    bool boolPathDatPPDXMLFileCheck = BEA.PathDatPPDXMLFileCheck();

                    // Check the paths and directories.
                    if (boolPathROMsDirCheck == false && boolPathPatchesDirCheck == false && boolPathXdeltaFileCheck == false && boolPathDatPPDXMLFileCheck == false)
                    {
                        // Print to screen
                        Log.Information("Options: ROMs Directory (" + strPathRomsDir + ")");
                        Log.Information("Options: Patches Directory (" + strPathPatchesDir + ")");
                        Log.Information("Options: Dat/PPD/XML File (" + strPathDatPPDXMLFile + ")");
                        Log.Information("Options: Xdelta File (" + strPathXdeltaFile + ")");
                        Log.Information("Options: Xdelta Build Command (" + strXdeltaBuildCommand + ")");

                        // Get the patches XDocument from the dat file and count.
                        XDocument xdocPatches = new XDocument();
                        xdocPatches = XDocument.Load(strPathDatPPDXMLFile);
                        intCountXdocPatches = xdocPatches.Descendants("rom").Count();

                        // Create and start a stopwatch.
                        var stopWatch = new Stopwatch();
                        stopWatch.Start();

                        // Main Loop - Build the patches from the datafile and all supplied ROMs.
                        if (intCountXdocPatches > 0)
                        {
                            // Loop through the rom elements.
                            foreach (XElement xmlRom in xdocPatches.Descendants("rom"))
                            {
                                // Get the XML decoded patch name.
                                string strPatchName = xmlRom.Attribute("name").Value;

                                // Explode the patch filename.
                                string[] arrDelimiters = { strDelimiter };
                                string[] arrPatchNames = strPatchName.Split(arrDelimiters, StringSplitOptions.RemoveEmptyEntries);

                                // Check for source and destination parts.
                                if (arrPatchNames.Count() > 1)
                                {
                                    // Rename the source and destination file.
                                    string strPatchNameSrc = arrPatchNames[0];
                                    string strPatchNameDest = arrPatchNames[1].Replace(".xd3", "");

                                    // If the source file exists, the destination file exists and the patch doesn't exist, build the patch.
                                    if (File.Exists(Path.Combine(strPathRomsDir, strPatchNameSrc)) == true && File.Exists(Path.Combine(strPathRomsDir, strPatchNameDest)) == true && File.Exists(Path.Combine(strPathPatchesDir, strPatchName)) == false)
                                    {
                                        // Print to screen
                                        Log.Information("Building: " + strPatchName);
                                        UpdateStatusMessageLabel("Building " + (intCounterTotalBuilt + 1) + " of " + intCountXdocPatches + " patches from datafile ...");

                                        // Build the patch.
                                        Process pProcess = new Process();
                                        pProcess.StartInfo.UseShellExecute = false;
                                        pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                        pProcess.StartInfo.CreateNoWindow = true;
                                        pProcess.StartInfo.RedirectStandardInput = true;
                                        pProcess.StartInfo.RedirectStandardOutput = true;
                                        pProcess.StartInfo.RedirectStandardError = true;
                                        pProcess.StartInfo.FileName = strPathXdeltaFile;
                                        pProcess.StartInfo.Arguments = strXdeltaBuildCommand + " \"" + Path.Combine(strPathRomsDir, strPatchNameSrc) + "\" \"" + Path.Combine(strPathRomsDir, strPatchNameDest) + "\" \"" + Path.Combine(strPathPatchesDir, strPatchName) + "\"";
                                        pProcess.Start();
                                        string strError = pProcess.StandardError.ReadToEnd();
                                        pProcess.WaitForExit();

                                        // This isn't the preferred way to check for errors.
                                        if (strError == "")
                                        {
                                            // Increment the counter and progress bar.
                                            intCounterTotalBuilt++;
                                            intProgress = (int)((double)intCounterTotalBuilt / (double)intCountXdocPatches * 100);
                                            worker.ReportProgress(intProgress);
                                        }
                                        else
                                        {
                                            // Print the output of Xdelta to the screen.
                                            Log.Information("Bad patch (" + strPatchName + ")");
                                            Log.Information(strError);
                                        }
                                    }
                                }
                                else
                                {
                                    // Print to screen
                                    Log.Information("Bad patch name (" + arrPatchNames[0] + ")");
                                }

                                // Check if the background worker is pending cancellation.
                                if (worker.CancellationPending == true)
                                {
                                    e.Cancel = true;
                                    break;
                                }
                            }
                        }

                        // Stop the stopwatch.
                        stopWatch.Stop();

                        // Print to screen
                        Log.Information(intCounterTotalBuilt + " Patches built successfully in " + stopWatch.Elapsed);
                    }

                    // Print to screen
                    Log.Information("Building all possible patches completed");
                }
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Building all possible patches failed");
                Log.Error(ex.Message);
            }
        }

        /// <summary>
        /// Changes the progress of the Build ROMs bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildPatches_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Display the changed progress status.
            UpdateStatusBuildProgress(e.ProgressPercentage);
        }

        /// <summary>
        /// Completes the Build ROMs bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildPatches_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // Print to screen.
                Log.Information("Building all possible patches canceled");
                Log.Information("Ready");
            }
            else if (e.Error != null)
            {
                // Print to screen.
                Log.Error("Building all possible patches failed");
                Log.Error("" + e.Error.Message);
                Log.Information("Ready");
            }
            else
            {
                // Print to screen.
                Log.Information("Ready");
            }

            // Reset the log background color.
            rtbLog.BackColor = SystemColors.Control;

            // Enable all buttons.
            EnableAllButtons();

            // Reset the progress status.
            UpdateStatusBuildProgress(0);

            // Update the status message label.
            UpdateStatusMessageLabel("Ready");

            // Disable the cancel button.
            tssbCancel.Enabled = false;

            // Play a sound.
            PlaySound("Complete");
        }

        #endregion

        #region Build Patches Datafile

        /// <summary>
        /// Builds a datafile from the patches directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildPatchesDatafile_Click(object sender, EventArgs e)
        {
            // Select the Log tab.
            if (tcMain.TabPages.Contains(tabLog)) { tcMain.SelectTab(tabLog); }

            // Disable all buttons.
            DisableAllButtons();

            // Enable the cancel button.
            tssbCancel.Enabled = true;

            // Change the log background color.
            rtbLog.BackColor = Color.LightGreen;

            // Update the status message label.
            UpdateStatusMessageLabel("Building Patches Datafile ...");

            // Build patches datafile.
            bgwBuildDatafile.RunWorkerAsync();
        }

        /// <summary>
        /// Does the work for the Build Patches Datafile bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildDatafile_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e != null && e.Cancel == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Print to screen
                    Log.Information("Building patches datafile ...");

                    // Declarations
                    BackgroundWorker worker = sender as BackgroundWorker;           // Background worker
                    int intProgress = 0;                                            // Background worker progress
                    int intCounterTotalBuilt = 0;                                   // Total built counter
                    int intCountArrDirFiles = 0;                                    // Total loop count
                    string strPathPatchesDir = BEA.PathPatchesDir;                      // Path to the Patches directory
                    string strPathDatsDir = BEA.PathDatsDir;                            // Path to the Dats directory
                    string strName = BEA.MachineName;                                   // Datafile name
                    string strVersion = DateTime.Now.ToString("yyyyMMdd HHmmss");   // Datafile version
                    string strDate = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");  // Datafile date
                    string strDescription = BEA.MachineName + " - Patches (0) (" + strVersion + ")";    // Datafile description
                    string strCategory = "Patches";                                 // Datafile category
                    string strAuthor = BEA.AppName + " v" + BEA.AppVersion;             // Datafile author
                    string strComment = BEA.Comment;                                    // Datafile comment
                    string strPathSaveFilename = "";                                // Path to the new datafile
                    string strXdeltaFile = Path.GetFileName(BEA.PathXdeltaFile);        // Datafile Xdelta file
                    string strXdeltaBuildCommand = BEA.XdeltaBuildCommand;              // Datafile Xdelta build command
                    string strMachineName = BEA.MachineName + " - Patches";             // Datafile machine name

                    // Checkers
                    bool boolPathDatsDirCheck = BEA.PathDatsDirCheck();
                    bool boolPathPatchesDirCheck = BEA.PathPatchesDirCheck();

                    // Check the paths and directories.
                    if (boolPathDatsDirCheck == false && boolPathPatchesDirCheck == false)
                    {
                        // Print to screen
                        Log.Information("Options: Patches Directory (" + strPathPatchesDir + ")");
                        Log.Information("Options: Dats Directory (" + strPathDatsDir + ")");
                        Log.Information("Options: Dat Name (" + strName + ")");
                        Log.Information("Options: Dat Category (" + strCategory + ")");
                        Log.Information("Options: Dat Date (" + strDate + ")");
                        Log.Information("Options: Dat Comment (" + strComment + ")");
                        Log.Information("Options: Xdelta File (" + strXdeltaFile + ")");
                        Log.Information("Options: Xdelta Build Command (" + strXdeltaBuildCommand + ")");

                        // Get the directory files array and count.
                        string[] arrDirFiles = Directory.GetFiles(strPathPatchesDir, "*.xd3");
                        intCountArrDirFiles = arrDirFiles.Count();

                        // Create and start a stopwatch.
                        var stopWatch = new Stopwatch();
                        stopWatch.Start();

                        // Main loop - Build a datafile from the patches directory files.
                        if (intCountArrDirFiles > 0)
                        {
                            // Create a new datafile XDocument.
                            XDocument xdocDatafile = new XDocument(
                                new XDeclaration("1.0", "utf-8", "yes"),
                                new XElement("datafile",
                                    new XElement("header",
                                        new XElement("name", strName),
                                        new XElement("description", strDescription),
                                        new XElement("category", strCategory),
                                        new XElement("version", strVersion),
                                        new XElement("date", strDate),
                                        new XElement("author", strAuthor),
                                        new XElement("comment", strComment),
                                        new XElement("buildemall",
                                            new XAttribute("xdeltafile", strXdeltaFile),
                                            new XAttribute("xdeltabuildcommand", strXdeltaBuildCommand)
                                        )
                                    )
                                )
                            );

                            // Loop through the directory files array.
                            foreach (string strPathFile in arrDirFiles)
                            {
                                // Get the patch filesize and filename.
                                string strRomFilename = Path.GetFileName(strPathFile);
                                string strRomFileSize = new FileInfo(strPathFile).Length.ToString();

                                // Print to screen
                                Log.Information("Adding: " + strRomFilename);
                                UpdateStatusMessageLabel("Adding " + (intCounterTotalBuilt + 1) + " of " + intCountArrDirFiles + " patches to datafile ...");

                                // Get the game name, category and description.
                                string strGameName = Path.GetFileNameWithoutExtension(strPathFile);
                                string strGameCategory = "Patches";
                                string strGameDescription = Path.GetFileNameWithoutExtension(strPathFile);

                                // Get the patch hashes.
                                byte[] arrRomFileHashSHA1 = new SHA1CryptoServiceProvider().ComputeHash(File.OpenRead(strPathFile));
                                byte[] arrRomFileHashMD5 = new MD5CryptoServiceProvider().ComputeHash(File.OpenRead(strPathFile));
                                byte[] arrRomFileHashCRC = new BuildEmAll.CRC32CryptoServiceProvider().ComputeHash(File.OpenRead(strPathFile));
                                string strRomFileHashSHA1 = BitConverter.ToString(arrRomFileHashSHA1).Replace("-", "").ToLower();
                                string strRomFileHashMD5 = BitConverter.ToString(arrRomFileHashMD5).Replace("-", "").ToLower();
                                string strRomFileHashCRC = BitConverter.ToString(arrRomFileHashCRC).Replace("-", "").ToLower();

                                // Add the patch file to the datafile XDocument.
                                xdocDatafile.Element("datafile").Add(
                                    new XElement("game",
                                        new XAttribute("name", strGameName),
                                        new XElement("category", strGameCategory),
                                        new XElement("description", strGameDescription),
                                        new XElement("rom",
                                            new XAttribute("name", strRomFilename),
                                            new XAttribute("size", strRomFileSize),
                                            new XAttribute("crc", strRomFileHashCRC),
                                            new XAttribute("md5", strRomFileHashMD5),
                                            new XAttribute("sha1", strRomFileHashSHA1)
                                        )
                                    )
                                );

                                // Increment the counter.
                                intCounterTotalBuilt++;
                                intProgress = (int)((double)intCounterTotalBuilt / (double)intCountArrDirFiles * 100);
                                worker.ReportProgress(intProgress);

                                // Check if the background worker is pending cancellation.
                                if (worker.CancellationPending == true)
                                {
                                    e.Cancel = true;
                                    break;
                                }
                            }

                            // Modify the datafile header elements and filename.
                            xdocDatafile.Element("datafile").Element("header").Element("description").Value = strMachineName + " (" + intCounterTotalBuilt + ") (" + strVersion + ")";
                            strPathSaveFilename = Path.Combine(strPathDatsDir, strMachineName + " (" + intCounterTotalBuilt + ") (" + strVersion + ").dat");

                            // Save the contents of the datafile XDocument to the file.
                            xdocDatafile.Save(strPathSaveFilename);
                        }

                        // Stop the stopwatch.
                        stopWatch.Stop();

                        // Print to screen
                        Log.Information("" + intCounterTotalBuilt + " patches added to datafile successfully in " + stopWatch.Elapsed);
                    }

                    // Print to screen
                    Log.Information("Building patches datafile completed");
                }
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Building patches datafile failed");
                Log.Error(ex.Message);
            }
        }

        /// <summary>
        /// Changes the progress of the Build Patches Datafile bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildDatafile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Display the changed progress status.
            UpdateStatusBuildProgress(e.ProgressPercentage);
        }

        /// <summary>
        /// Completes the Build Patches Datafile bgw process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildDatafile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // Print to screen.
                Log.Information("Building patches datafile canceled");
                Log.Information("Ready");
            }
            else if (e.Error != null)
            {
                // Print to screen.
                Log.Error("Building patches datafile failed");
                Log.Error("" + e.Error.Message);
                Log.Information("Ready");
            }
            else
            {
                // Print to screen.
                Log.Information("Ready");
            }

            // Reset the log background color.
            rtbLog.BackColor = SystemColors.Control;

            // Enable all buttons.
            EnableAllButtons();

            // Reset the progress status.
            UpdateStatusBuildProgress(0);

            // Update the status message label.
            UpdateStatusMessageLabel("Ready");

            // Disable the cancel button.
            tssbCancel.Enabled = false;

            // Play a sound.
            PlaySound("Complete");
        }

        #endregion

        #region PPD Builder

        /// <summary>
        /// Updates the prepatch counter label.
        /// </summary>
        private void UpdateLblCountPrepatches()
        {
            // Update the prepatch counter label.
            lblCountPrepatches.Text = lbPrepatches.Items.Count + " Prepatches";
        }

        /// <summary>
        /// Adds the selected prepatch to the prepatches ListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPrepatch_Click(object sender, EventArgs e)
        {
            if (lbFromDat.SelectedItem != null && lbToDat.SelectedItem != null)
            {
                // Declarations
                string strPrepatchName = lbFromDat.SelectedItem.ToString() + BEA.Delimiter + lbToDat.SelectedItem.ToString() + ".xd3";

                // Add the selected prepatch to the prepatches ListBox if it doesn't already exist.
                if (lbPrepatches.Items.Contains(strPrepatchName) == false)
                {
                    // Play a sound.
                    PlaySound("AddRemove");

                    // Add the prepatch to the Prepatches Listbox.
                    lbPrepatches.Items.Add(strPrepatchName);

                    // Update the prepatches counter label.
                    UpdateLblCountPrepatches();

                    // Select the added item.
                    lbPrepatches.SelectedItem = strPrepatchName;
                }
                else
                {
                    // Play a sound.
                    PlaySound("Fail");
                }
            }
            else
            {
                // Play a sound.
                PlaySound("Fail");
            }
        }

        /// <summary>
        /// Removes the selected prepatch from the prepatches ListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemovePrepatch_Click(object sender, EventArgs e)
        {
            if (lbPrepatches.SelectedItem != null)
            {
                // Play a sound.
                PlaySound("AddRemove");

                // Remove the selected prepatch from the prepatches ListBox.
                lbPrepatches.Items.Remove(lbPrepatches.SelectedItem);

                // Update the prepatches counter label.
                UpdateLblCountPrepatches();
            }
            else
            {
                // Play a sound.
                PlaySound("Fail");
            }
        }

        /// <summary>
        /// Removes all of the items from the prepatches ListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAllPrepatches_Click(object sender, EventArgs e)
        {
            // Clear all of the prepatches if any exist.
            if (lbPrepatches.Items.Count > 0)
            {
                // Play a sound.
                PlaySound("Confirm");

                // Display a dialog box with a question icon and a default button.
                DialogResult drClearPatches = MessageBox.Show("Are you sure you want to remove all prepatches?",
                "Removal Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

                // Clear all of the items from the prepatches ListBox.
                if (drClearPatches == DialogResult.Yes)
                {
                    lbPrepatches.Items.Clear();
                }

                // Update the prepatches counter label.
                UpdateLblCountPrepatches();
            }
            else
            {
                // Play a sound.
                PlaySound("Fail");
            }
        }

        /// <summary>
        /// Saves the PPD file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePPD_Click(object sender, EventArgs e)
        {
            // Disable all buttons.
            DisableAllButtons();

            // Play a sound.
            PlaySound("Confirm");

            // Declarations
            int intCountPrepatches = lbPrepatches.Items.Count;
            string strName = BEA.MachineName;
            string strVersion = DateTime.Now.ToString("yyyyMMdd HHmmss");
            string strDescription = BEA.MachineName + " - Prepatches (" + intCountPrepatches + ") (" + strVersion + ")";
            string strCategory = "Prepatches";
            string strDate = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string strAuthor = BEA.AppName + " v" + BEA.AppVersion;
            string strComment = BEA.Comment;
            string strXdeltaFile = Path.GetFileName(BEA.PathXdeltaFile);
            string strXdeltaBuildCommand = BEA.XdeltaBuildCommand;
            string strPathDatsDir = BEA.PathDatsDir;
            string strPathSaveFilename = Path.Combine(strPathDatsDir, strDescription + ".ppd");

            // Create and initialize a SaveFileDialog for the PPD.
            SaveFileDialog sfdPPD = new SaveFileDialog
            {
                DefaultExt = "*.ppd",
                Filter = "PPD Files|*.ppd",
                FileName = strPathSaveFilename,
                Title = "Please enter a path to the PPD file",
                InitialDirectory = strPathDatsDir
            };

            // Determine if the user selected a file name from the SaveFileDialog.
            if (sfdPPD.ShowDialog() == DialogResult.OK && sfdPPD.FileName.Length > 0)
            {
                try
                {
                    // Create a new datafile XDocument.
                    XDocument xdocDatafile = new XDocument(
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("datafile",
                            new XElement("header",
                                new XElement("name", strName),
                                new XElement("description", strDescription),
                                new XElement("category", strCategory),
                                new XElement("version", strVersion),
                                new XElement("date", strDate),
                                new XElement("author", strAuthor),
                                new XElement("comment", strComment),
                                new XElement("clrmamepro"),
                                new XElement("buildemall",
                                    new XAttribute("xdeltafile", strXdeltaFile),
                                    new XAttribute("xdeltabuildcommand", strXdeltaBuildCommand)
                                )
                            )
                        )
                    );

                    // Loop through the prepatches.
                    foreach (string strPrepatchName in lbPrepatches.Items)
                    {
                        // Get the patch filesize and filename.
                        string strRomFilename = Path.GetFileName(strPrepatchName);
                        string strRomFileSize = "0";

                        // Get the game name, category and description.
                        string strGameName = Path.GetFileNameWithoutExtension(strPrepatchName);
                        string strGameCategory = "Patches";
                        string strGameDescription = Path.GetFileNameWithoutExtension(strPrepatchName);

                        // Get the patch hashes.
                        string strRomFileHashSHA1 = "0";
                        string strRomFileHashMD5 = "0";
                        string strRomFileHashCRC = "0";

                        // Add the patch file to the datafile XDocument.
                        xdocDatafile.Element("datafile").Add(
                            new XElement("game",
                                new XAttribute("name", strGameName),
                                new XElement("category", strGameCategory),
                                new XElement("description", strGameDescription),
                                new XElement("rom",
                                    new XAttribute("name", strRomFilename),
                                    new XAttribute("size", strRomFileSize),
                                    new XAttribute("crc", strRomFileHashCRC),
                                    new XAttribute("md5", strRomFileHashMD5),
                                    new XAttribute("sha1", strRomFileHashSHA1)
                                )
                            )
                        );
                    }

                    // Save the contents of the PPD XDocument to the file.
                    xdocDatafile.Save(sfdPPD.FileName);

                    // Print to screen
                    Log.Information("PPD Builder: Saved PPD file (" + sfdPPD.FileName + ")");
                    Log.Information("Ready");
                }
                catch (Exception ex)
                {
                    // Print to screen
                    Log.Error("PPD Builder: Save PPD failed");
                    Log.Error("" + ex.Message);
                    Log.Information("Ready");
                }
            }

            // Dispose of the SaveFileDialog.
            sfdPPD.Dispose();

            // Enable all buttons.
            EnableAllButtons();
        }

        /// <summary>
        /// Adds all of the patches from the ppd file into the lbPrepatches ListBox after clearing the ListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadPPD_Click(object sender, EventArgs e)
        {
            // Disable all buttons.
            DisableAllButtons();

            // Play a sound.
            PlaySound("Confirm");

            // Declarations
            string strPathDatsDir = BEA.PathDatsDir;                                            // Datafile dats directory path

            // Create and initialize an OpenFileDialog for the ppd file.
            OpenFileDialog ofdPathDatFile = new OpenFileDialog
            {
                DefaultExt = "*.ppd",
                Filter = "PPD Files|*.ppd",
                Title = "Please enter a path to the PPD file",
                InitialDirectory = strPathDatsDir
            };

            // Determine if the user selected a file name from the OpenFileDialog.
            if (ofdPathDatFile.ShowDialog() == DialogResult.OK && ofdPathDatFile.FileName.Length > 0)
            {
                try
                {
                    // Clear the ListBox.
                    lbPrepatches.Items.Clear();

                    // Load the prepatch names from the XML datafile.
                    XDocument xdocDatafile = XDocument.Load(ofdPathDatFile.FileName);

                    // Add all of the the prepatch names to the lbPrepatches ListBox.
                    foreach (XElement xelemRom in xdocDatafile.Descendants("rom"))
                    {
                        // Add the selected prepatch to the prepatches ListBox if it doesn't already exist.
                        if (lbPrepatches.Items.Contains(xelemRom.Attribute("name").Value) == false)
                        {
                            lbPrepatches.Items.Add(xelemRom.Attribute("name").Value);
                        }
                        else
                        {
                            // Print to screen
                            Log.Information("PPD Builder: Removed duplicate prepatch: " + xelemRom.Attribute("name").Value);
                        }
                    }

                    // Update the prepatches counter label.
                    UpdateLblCountPrepatches();

                    // Print to screen
                    Log.Information("PPD Builder: Loaded PPD file (" + ofdPathDatFile.FileName + ")");
                    Log.Information("Ready");
                }
                catch (Exception ex)
                {
                    // Print to screen
                    Log.Error("PPD Builder: Load PPD failed");
                    Log.Error("" + ex.Message);
                    Log.Information("Ready");
                }
            }

            // Dispose of the OpenFileDialog.
            ofdPathDatFile.Dispose();

            // Enable all buttons.
            EnableAllButtons();
        }

        /// <summary>
        /// Adds all of the ROM names from the dat file into the FromDat ListBox and the ToDat ListBox after clearing the FromDat and ToDat ListBoxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDat_Click(object sender, EventArgs e)
        {
            // Disable all buttons.
            DisableAllButtons();

            // Play a sound.
            PlaySound("Confirm");

            // Declarations
            string strPathDatsDir = BEA.PathDatsDir;                                            // Datafile dats directory path

            // Create and initialize an OpenFileDialog for the dat file.
            OpenFileDialog ofdPathDatFile = new OpenFileDialog
            {
                DefaultExt = "*.dat",
                Filter = "DAT Files|*.dat|XML Files|*.xml",
                Title = "Please enter a path to the dat file",
                InitialDirectory = strPathDatsDir
            };

            // Determine if the user selected a file name from the OpenFileDialog.
            if (ofdPathDatFile.ShowDialog() == DialogResult.OK && ofdPathDatFile.FileName.Length > 0)
            {
                try
                {
                    // Load the ROM names from the XML datafile.
                    XDocument xdocDatafile = XDocument.Load(ofdPathDatFile.FileName);

                    // Clear the ListBoxes.
                    lbFromDat.Items.Clear();
                    lbToDat.Items.Clear();

                    // Add all of the the ROM names to the FromDat ListBox.
                    foreach (XElement xelemRom in xdocDatafile.Descendants("rom"))
                    {
                        // Add the ROM name.
                        lbFromDat.Items.Add(xelemRom.Attribute("name").Value);
                    }

                    // Add all of the the ROM names to the ToDat ListBox.
                    foreach (XElement xelemRom in xdocDatafile.Descendants("rom"))
                    {
                        // Add the ROM name.
                        lbToDat.Items.Add(xelemRom.Attribute("name").Value);
                    }

                    // Update the loaded datafile textbox.
                    txtLoadedDatafile.Text = ofdPathDatFile.FileName;

                    // Print to screen
                    Log.Information("PPD Builder: Loaded dat file (" + ofdPathDatFile.FileName + ")");
                    Log.Information("Ready");
                }
                catch (Exception ex)
                {
                    // Print to screen
                    Log.Error("PPD Builder: Load Dat failed");
                    Log.Error("" + ex.Message);
                    Log.Information("Ready");
                }
            }

            // Dispose of the OpenFileDialog.
            ofdPathDatFile.Dispose();

            // Enable all buttons.
            EnableAllButtons();
        }

        /// <summary>
        /// Checks the prepatches.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPrepatches_Click(object sender, EventArgs e)
        {
            // Select the Log tab
            if (tcMain.TabPages.Contains(tabLog)) { tcMain.SelectTab(tabLog); }

            // Disable all buttons.
            DisableAllButtons();

            // Change the log background color.
            rtbLog.BackColor = Color.LightGreen;

            // Print to screen
            Log.Information("PPD Builder: Checking prepatches ...");

            // Check prepatches.
            foreach (string strPrepatchName in lbPrepatches.Items)
            {
                // Explode the prepatch name.
                string[] arrDelimiters = { BEA.Delimiter };
                string[] arrPrepatchNames = strPrepatchName.Split(arrDelimiters, StringSplitOptions.RemoveEmptyEntries);

                // Check for source and destination parts.
                if (arrPrepatchNames.Count() > 1)
                {
                    // Set the source and destination ROM names.
                    string strPrepatchNameSrc = arrPrepatchNames[0];
                    string strPrepatchNameDest = arrPrepatchNames[1].Replace(".xd3", "");

                    // Set the opposite prepatch name.
                    string strPrepatchNameOpposite = strPrepatchNameDest + BEA.Delimiter + strPrepatchNameSrc + ".xd3";

                    // Check if the opposite prepatch exists.
                    if (lbPrepatches.Items.Contains(strPrepatchNameOpposite) == false)
                    {
                        // Print to screen
                        Log.Warning("PPD Builder: Missing opposite prepatch: " + strPrepatchNameOpposite);
                    }

                    // Check if a dat has been loaded.
                    if (lbFromDat.Items.Count > 0 && lbToDat.Items.Count > 0)
                    {
                        // Check for bad prepatch ROM names.
                        if (lbFromDat.Items.Contains(strPrepatchNameSrc) == false || lbToDat.Items.Contains(strPrepatchNameDest) == false)
                        {
                            // Print to screen
                            Log.Error("PPD Builder: Bad prepatch ROM name in: " + strPrepatchName);
                        }
                    }

                    // Check for self prepatches.
                    if (strPrepatchNameSrc == strPrepatchNameDest)
                    {
                        // Print to screen
                        Log.Error("PPD Builder: Bad self prepatch: " + strPrepatchName);
                    }
                }
                else
                {
                    // Print to screen
                    Log.Error("PPD Builder: Bad prepatch name: " + strPrepatchName);
                }
            }

            // Print to screen
            Log.Information("PPD Builder: Checking prepatches completed");
            Log.Information("Ready");

            // Reset the log background color.
            rtbLog.BackColor = SystemColors.Control;

            // Enable all buttons.
            EnableAllButtons();

            // Play a sound.
            PlaySound("Complete");
        }

        #endregion
    }
}
