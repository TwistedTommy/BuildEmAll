using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Serilog;
using Serilog.Sinks.LogEmAll;

namespace BuildEmAll
{
    /// <summary>
    /// The BuildEmAll Class which interacts with the Main Program Class.
    /// </summary>
    public class BuildEmAll : INotifyPropertyChanged
    {
        #region Constructors

        /// <summary>
        /// BuildEmAll Constructor
        /// </summary>
        public BuildEmAll()
        {
            // Construct a BuildEmAll object.
        }

        #endregion

        #region INotifyPropertyChanged

        /// PropertyChanged Event
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// NotifyPropertyChanged
        /// </summary>
        /// <param name="pName"></param>
        private void NotifyPropertyChanged(String pName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pName));
        }

        #endregion

        #region Private Members

        private readonly string _strAppName = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductName;
        private readonly string _strAppVersion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductVersion;
        private readonly string _strAppCopyright = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).LegalCopyright;
        private string _strCommandSwitch = "-help";
        private string _strPathOptionsFile = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Options", "BuildEmAll-Options.xml");
        private string _strPathROMsDir = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "ROMs");
        private string _strPathPatchesDir = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Patches");
        private string _strPathDatsDir = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Dats");
        private string _strPathDatPPDXMLFile = "";
        private string _strPathXdeltaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Xdelta", "xdelta3-3.1.0-i686.exe");
        private string _strXdeltaBuildCommand = "-e -9 -s";
        private string _strDelimiter = " -- ";
        private string _strMachineName = "";
        private string _strComment = "";
        private string _strPathLogFile = "";
        private string _strSounds = "Off";
        private ListStringLog _logLines = new ListStringLog();
        private string _strLanguage = "en";
        private string _strLogLevel = "Information";

        #endregion

        #region Getters/Setters Public Accessors

        /// AppName
        public string AppName
        {
            get { return _strAppName; }
            set { }
        }
        /// AppVersion
        public string AppVersion
        {
            get { return _strAppVersion; }
            set { }
        }
        /// AppCopyright
        public string AppCopyright
        {
            get { return _strAppCopyright; }
            set { }
        }
        /// PathOptionsFile
        public string PathOptionsFile
        {
            get { return _strPathOptionsFile; }
            set { _strPathOptionsFile = value; }
        }
        /// PathROMsDir
        public string PathROMsDir
        {
            get { return _strPathROMsDir; }
            set { _strPathROMsDir = value; NotifyPropertyChanged("PathROMsDir"); }
        }
        /// PathPatchesDir
        public string PathPatchesDir
        {
            get { return _strPathPatchesDir; }
            set { _strPathPatchesDir = value; NotifyPropertyChanged("PathPatchesDir"); }
        }
        /// PathDatsDir
        public string PathDatsDir
        {
            get { return _strPathDatsDir; }
            set { _strPathDatsDir = value; NotifyPropertyChanged("PathDatsDir"); }
        }
        /// PathDatPPDXMLFile
        public string PathDatPPDXMLFile
        {
            get { return _strPathDatPPDXMLFile; }
            set { _strPathDatPPDXMLFile = value; NotifyPropertyChanged("PathDatPPDXMLFile"); }
        }
        /// PathXdeltaFile
        public string PathXdeltaFile
        {
            get { return _strPathXdeltaFile; }
            set { _strPathXdeltaFile = value; NotifyPropertyChanged("PathXdeltaFile"); }
        }
        /// XdeltaBuildCommand
        public string XdeltaBuildCommand
        {
            get { return _strXdeltaBuildCommand; }
            set { _strXdeltaBuildCommand = value; NotifyPropertyChanged("XdeltaBuildCommand"); }
        }
        /// Delimiter
        public string Delimiter
        {
            get { return _strDelimiter; }
            set { _strDelimiter = value; NotifyPropertyChanged("Delimiter"); }
        }
        /// MachineName
        public string MachineName
        {
            get { return _strMachineName; }
            set { _strMachineName = value; NotifyPropertyChanged("MachineName"); }
        }
        /// Comment
        public string Comment
        {
            get { return _strComment; }
            set { _strComment = value; NotifyPropertyChanged("Comment"); }
        }
        /// PathLogFile
        public string PathLogFile
        {
            get { return _strPathLogFile; }
            set { _strPathLogFile = value; }
        }
        /// CommandSwitch
        public string CommandSwitch
        {
            get { return _strCommandSwitch; }
            set { _strCommandSwitch = value; }
        }
        /// Sounds
        public string Sounds
        {
            get { return _strSounds; }
            set { _strSounds = value; NotifyPropertyChanged("Sounds"); }
        }
        /// LogLines
        public ListStringLog LogLines
        {
            get { return _logLines; }
            set { _logLines = value; }
        }
        /// Language
        public string Language
        {
            get { return _strLanguage; }
            set { _strLanguage = value; NotifyPropertyChanged("Language"); }
        }
        /// LogLevel
        public string LogLevel
        {
            get { return _strLogLevel; }
            set { _strLogLevel = value; NotifyPropertyChanged("LogLevel"); }
        }

        #endregion

        #region Startup Tasks

        /// <summary>
        /// Performs the startup tasks.
        /// </summary>
        private void StartupTasks()
        {
            // 
        }

        #endregion

        #region Options

        /// <summary>
        /// Loads and sets the options variables from the options file.
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public bool LoadOptionsFromFile(string strPath = null)
        {
            try
            {
                if (strPath != null)
                {
                    PathOptionsFile = strPath;
                }

                if (File.Exists(PathOptionsFile) == true)
                {
                    // Load the options from the XML file.
                    XDocument xdocOptions = XDocument.Load(PathOptionsFile);

                    // Set the variables.
                    PathROMsDir = xdocOptions.Element("Options").Element("PathROMsDir").Value;
                    PathPatchesDir = xdocOptions.Element("Options").Element("PathPatchesDir").Value;
                    PathDatsDir = xdocOptions.Element("Options").Element("PathDatsDir").Value;
                    PathDatPPDXMLFile = xdocOptions.Element("Options").Element("PathDatPPDXMLFile").Value;
                    PathXdeltaFile = xdocOptions.Element("Options").Element("PathXdeltaFile").Value;
                    XdeltaBuildCommand = xdocOptions.Element("Options").Element("XdeltaBuildCommand").Value;
                    MachineName = xdocOptions.Element("Options").Element("MachineName").Value;
                    Delimiter = xdocOptions.Element("Options").Element("Delimiter").Value;
                    Comment = xdocOptions.Element("Options").Element("Comment").Value;
                    Sounds = xdocOptions.Element("Options").Element("Sounds").Value;
                    Language = xdocOptions.Element("Options").Element("Language").Value;
                    LogLevel = xdocOptions.Element("Options").Element("LogLevel").Value;

                    // Print to screen
                    Log.Information("Options file loaded (" + PathOptionsFile + ")");

                    // Return a bool value.
                    return true;
                }
                else
                {
                    // Print to screen
                    Log.Information("Options file was not found");

                    // Return a bool value.
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Loading options from file failed");
                Log.Error("" + ex.Message);

                // Return a bool value.
                return false;
            }
        }

        /// <summary>
        /// Saves a new options file.
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public bool SaveOptionsToFile(string strPath = null)
        {
            try
            {
                if (strPath != null)
                {
                    PathOptionsFile = strPath;
                }

                // Print to screen
                Log.Information("Saving options file ...");

                // Create a new options XDocument.
                XDocument xdocOptions = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("This is a BuildEmAll options file"),
                    new XComment("WARNING: Using invalid values might cause this app to crash!"),
                    new XElement("Options",
                        new XAttribute("Version", AppVersion),
                        new XElement("PathROMsDir", PathROMsDir),
                        new XElement("PathPatchesDir", PathPatchesDir),
                        new XElement("PathDatsDir", PathDatsDir),
                        new XElement("PathDatPPDXMLFile", PathDatPPDXMLFile),
                        new XElement("PathXdeltaFile", PathXdeltaFile),
                        new XElement("XdeltaBuildCommand", XdeltaBuildCommand),
                        new XElement("MachineName", MachineName),
                        new XElement("Delimiter", Delimiter),
                        new XElement("Comment", Comment),
                        new XElement("Sounds", Sounds),
                        new XElement("Language", Language),
                        new XElement("LogLevel", LogLevel)
                    )
                );

                // Create options file directory if it doesn't exist.
                if (Directory.Exists(Path.GetDirectoryName(PathOptionsFile)) == false) Directory.CreateDirectory(Path.GetDirectoryName(PathOptionsFile));

                // Save the contents of the options XDocument to the file.
                xdocOptions.Save(PathOptionsFile);

                // Print to screen
                Log.Information("Options file saved (" + PathOptionsFile + ")");

                // Return a bool value.
                return true;
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Saving options failed");
                Log.Error("" + ex.Message);
                Log.Information("Ready");

                // Return a bool value.
                return false;
            }
        }

        /// <summary>
        /// Sets the variables passed from the CLI.
        /// </summary>
        /// <param name="strArgs"></param>
        public void LoadOptionsFromCLI(string[] strArgs)
        {
            try
            {
                foreach (string strArg in strArgs)
                {
                    if (Regex.IsMatch(strArg, "^-", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the command switch.
                        CommandSwitch = strArg;
                    }
                    if (Regex.IsMatch(strArg, "^RD:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the path to the ROMs directory.
                        PathROMsDir = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^PD:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the path to the patches directory.
                        PathPatchesDir = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^DD:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the path to the datafiles directory.
                        PathDatsDir = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^DF:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the path to the Dat/PPD/XML file.
                        PathDatPPDXMLFile = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^XF:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the path to the Xdelta file.
                        PathXdeltaFile = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^XC:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the Xdelta command to use for building patches.
                        XdeltaBuildCommand = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^DL:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the delimiter to use between game names.
                        Delimiter = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^MN:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the machine name to use for building an official datafile.
                        MachineName = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^CO:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the comment to use in patches and prepatches datafiles.
                        Comment = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^OF:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the path to the options file.
                        PathOptionsFile = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^LF:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the path to the log file.
                        PathLogFile = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^SO:", RegexOptions.IgnoreCase) == true)
                    {
                        // Turn the sounds on or off.
                        Sounds = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^LA:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the language.
                        Language = strArg.Substring(3);
                    }
                    if (Regex.IsMatch(strArg, "^LL:", RegexOptions.IgnoreCase) == true)
                    {
                        // Set the log level.
                        LogLevel = strArg.Substring(3);
                    }
                }
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Loading options from CLI failed");
                Log.Error("" + ex.Message);
            }
        }

        #endregion

        #region CLI Methods

        /// <summary>
        /// Updates/Sets the application title.
        /// </summary>
        /// <param name="strTitle"></param>
        /// <returns></returns>
        public bool UpdateTitle(string strTitle = "")
        {
            try
            {
                Console.Title = AppName + " v" + AppVersion + strTitle;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

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
                    PathLogFile = strPath;
                }

                // Determine if the user selected a log filename.
                if (PathLogFile.Length == 0)
                {
                    // Return a bool value.
                    return false;
                }
                else
                {
                    // Print to screen
                    Log.Information("Saving log file ...");

                    // Create log file directory if it doesn't exist.
                    if (Directory.Exists(Path.GetDirectoryName(PathLogFile)) == false) Directory.CreateDirectory(Path.GetDirectoryName(PathLogFile));

                    // Save the contents of the log to a text file.
                    File.WriteAllLines(PathLogFile, LogLines);

                    // Print to screen
                    Log.Information("Log file saved (" + PathLogFile + ")");

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

        /// <summary>
        /// Processes the command switch.
        /// </summary>
        public void ProcessCommandSwitch()
        {
            switch (CommandSwitch)
            {
                case "-buildroms":
                    StartupTasks();        // Check and set the activation and options variables from the WWW.
                    BuildROMs();				        // Build all possible ROMs.
                    break;
                case "-buildpatches":
                    StartupTasks();        // Check and set the activation and options variables from the WWW.
                    BuildPatches();				        // Build all possible patches.
                    break;
                case "-buildpatchesdat":
                    StartupTasks();        // Check and set the activation and options variables from the WWW.
                    BuildPatchesDatafile();		        // Build a datafile from the patches directory.
                    break;
                case "-license":
                    PrintLicense();				        // Print the license text.
                    break;
                case "-version":
                    // Do nothing.				        // Do nothing.
                    break;
                default:
                    PrintHelp();				        // Print the help text.
                    break;
            }
        }

        #endregion

        #region Build ROMs

        /// <summary>
        /// Builds all possible ROMs from all supplied patches.
        /// </summary>
        public void BuildROMs()
        {
            try
            {
                // Print to screen
                Log.Information("Building all possible ROMs ...");

                // Declarations
                bool boolExitFlag = false;                              // Exit flag
                int intCounterTotalBuilt = 0;                           // Total built counter
                int intCountArrDirFiles = 0;                            // Total loop count
                string strPathRomsDir = PathROMsDir;                    // Path to the ROMs directory
                string strPathPatchesDir = PathPatchesDir;              // Path to the Patches directory
                string strPathXdeltaFile = PathXdeltaFile;              // Path to the Xdelta file
                string strDelimiter = Delimiter;                        // Delimiter

                // Checkers
                bool boolPathROMsDirCheck = PathROMsDirCheck();
                bool boolPathPatchesDirCheck = PathPatchesDirCheck();
                bool boolPathXdeltaFileCheck = PathXdeltaFileCheck();

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
                                        // Increment the counter.
                                        intCounterTotalBuilt++;

                                        // Set exit flag.
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
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Building all possible ROMs failed");
                Log.Error("" + ex.Message);
            }
        }

        #endregion

        #region Build Patches

        /// <summary>
        /// Builds all possible patches from all supplied ROMs.
        /// </summary>
        public void BuildPatches()
        {
            try
            {
                // Print to screen
                Log.Information("Building all possible patches ...");

                // Declarations
                int intCounterTotalBuilt = 0;                               // Total built counter
                int intCountXdocPatches = 0;                                // Total loop counter
                string strPathXdeltaFile = PathXdeltaFile;                  // Path to the Xdelta file
                string strXdeltaBuildCommand = XdeltaBuildCommand;          // Xdelta build command
                string strPathDatPPDXMLFile = PathDatPPDXMLFile;            // Path to the Dat/PPD/XML file
                string strPathRomsDir = PathROMsDir;                        // Path to the ROMs directory
                string strPathPatchesDir = PathPatchesDir;                  // Path to the Patches directory
                string strDelimiter = Delimiter;                            // Delimiter

                // Checkers
                bool boolPathROMsDirCheck = PathROMsDirCheck();
                bool boolPathPatchesDirCheck = PathPatchesDirCheck();
                bool boolPathXdeltaFileCheck = PathXdeltaFileCheck();
                bool boolPathDatPPDXMLFileCheck = PathDatPPDXMLFileCheck();

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
                                        // Increment the counter.
                                        intCounterTotalBuilt++;
                                    }
                                    else
                                    {
                                        // Print the output of Xdelta to the screen.
                                        Log.Error("Bad patch (" + strPatchName + ")");
                                        Log.Error(strError);
                                    }
                                }
                            }
                            else
                            {
                                // Print to screen
                                Log.Error("Bad patch name (" + arrPatchNames[0] + ")");
                            }
                        }
                    }

                    // Stop the stopwatch.
                    stopWatch.Stop();

                    // Print to screen
                    Log.Information("" + intCounterTotalBuilt + " Patches built successfully in " + stopWatch.Elapsed);
                }

                // Print to screen
                Log.Information("Building all possible patches completed");
            }
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Building all possible patches failed");
                Log.Error(ex.Message);
            }
        }

        #endregion

        #region Build Patches Datafile

        /// <summary>
        /// Builds a datafile from the patches directory.
        /// </summary>
        public void BuildPatchesDatafile()
        {
            try
            {
                // Print to screen
                Log.Information("Building patches datafile ...");

                // Declarations
                int intCounterTotalBuilt = 0;                                   // Total built counter
                int intCountArrDirFiles = 0;                                    // Total loop count
                string strPathPatchesDir = PathPatchesDir;                      // Path to the Patches directory
                string strPathDatsDir = PathDatsDir;                            // Path to the Dats directory
                string strName = MachineName;                                   // Datafile name
                string strVersion = DateTime.Now.ToString("yyyyMMdd HHmmss");   // Datafile version
                string strDate = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");  // Datafile date
                string strDescription = MachineName + " - Patches (0) (" + strVersion + ")";    // Datafile description
                string strCategory = "Patches";                                 // Datafile category
                string strAuthor = AppName + " v" + AppVersion;                 // Datafile author
                string strComment = Comment;                                    // Datafile comment
                string strPathSaveFilename = "";                                // Path to the new datafile
                string strXdeltaFile = Path.GetFileName(PathXdeltaFile);        // Datafile Xdelta file
                string strXdeltaBuildCommand = XdeltaBuildCommand;              // Datafile Xdelta build command
                string strMachineName = MachineName + " - Patches";             // Datafile machine name

                // Checkers
                bool boolPathDatsDirCheck = PathDatsDirCheck();
                bool boolPathPatchesDirCheck = PathPatchesDirCheck();

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

                            // Get the game name, category and description.
                            string strGameName = Path.GetFileNameWithoutExtension(strPathFile);
                            string strGameCategory = "Patches";
                            string strGameDescription = Path.GetFileNameWithoutExtension(strPathFile);

                            // Get the patch hashes.
                            byte[] arrRomFileHashSHA1 = new SHA1CryptoServiceProvider().ComputeHash(File.OpenRead(strPathFile));
                            byte[] arrRomFileHashMD5 = new MD5CryptoServiceProvider().ComputeHash(File.OpenRead(strPathFile));
                            byte[] arrRomFileHashCRC = new CRC32CryptoServiceProvider().ComputeHash(File.OpenRead(strPathFile));
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
            catch (Exception ex)
            {
                // Print to screen
                Log.Error("Building patches datafile failed");
                Log.Error(ex.Message);
            }
        }

        #endregion

        #region Checkers

        /// <summary>
        /// Checks the Dat/PPD/XML file path.
        /// </summary>
        /// <returns></returns>
        public bool PathDatPPDXMLFileCheck()
        {
            // Check if the file exists.
            if (File.Exists(PathDatPPDXMLFile) == true)
            {
                // Return the exit value.
                return false;
            }
            else
            {
                // Print to screen and set the exit flag value.
                Log.Error("The Dat/PPD/XML file path does not exist (" + PathDatPPDXMLFile + ")");
                return true;
            }
        }

        /// <summary>
        /// Checks the ROMs directory path.
        /// </summary>
        /// <returns></returns>
        public bool PathROMsDirCheck()
        {
            // Check if the directory exists.
            if (Directory.Exists(PathROMsDir) == true)
            {
                // Return the exit value.
                return false;
            }
            else
            {
                // Print to screen and set the exit flag value.
                Log.Error("The ROMs directory path does not exist (" + PathROMsDir + ")");
                return true;
            }
        }

        /// <summary>
        /// Checks the Xdelta file path.
        /// </summary>
        /// <returns></returns>
        public bool PathXdeltaFileCheck()
        {
            // Check if the file exists.
            if (File.Exists(PathXdeltaFile) == true)
            {
                // Return the exit value.
                return false;
            }
            else
            {
                // Print to screen and set the exit flag value.
                Log.Error("The Xdelta file path does not exist (" + PathXdeltaFile + ")");
                return true;
            }
        }

        /// <summary>
        /// Checks the Patches directory path.
        /// </summary>
        /// <returns></returns>
        public bool PathPatchesDirCheck()
        {
            // Check if the directory exists.
            if (Directory.Exists(PathPatchesDir) == true)
            {
                // Return the exit value.
                return false;
            }
            else
            {
                // Print to screen and set the exit flag value.
                Log.Error("The Patches directory path does not exist (" + PathPatchesDir + ")");
                return true;
            }
        }

        /// <summary>
        /// Checks the Dats directory path.
        /// </summary>
        /// <returns></returns>
        public bool PathDatsDirCheck()
        {
            // Check if the directory exists.
            if (Directory.Exists(PathDatsDir) == true)
            {
                // Return the exit value.
                return false;
            }
            else
            {
                // Print to screen and set the exit flag value.
                Log.Error("The Dats directory path does not exist (" + PathDatsDir + ")");
                return true;
            }
        }

        #endregion

        #region Printers

        /// <summary>
        /// EnumerateLines
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public IEnumerable<string> EnumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        /// <summary>
        /// ReadAllResourceLines
        /// </summary>
        /// <param name="resourceText"></param>
        /// <returns></returns>
        public string[] ReadAllResourceLines(string resourceText)
        {
            using (StringReader reader = new StringReader(resourceText))
            {
                return EnumerateLines(reader).ToArray();
            }
        }

        /// <summary>
        /// Prints the help text.
        /// </summary>
        public void PrintHelp()
        {
            // Read all of the lines of the file into an array.
            string[] arrLines = ReadAllResourceLines(Properties.Resources.BuildEmAll_HELP_CMD);

            // Loop through each line of the array.
            foreach (string strLine in arrLines)
            {
                // Print to screen.
                Log.Information(strLine);
            }
        }

        /// <summary>
        /// Prints the license text.
        /// </summary>
        public void PrintLicense()
        {
            // Read all of the lines of the file into an array.
            string[] arrLines = ReadAllResourceLines(Properties.Resources.BuildEmAll_LICENSE);

            // Loop through each line of the array.
            foreach (string strLine in arrLines)
            {
                // Print to screen.
                Log.Information(strLine);
            }
        }

        /// <summary>
        /// Prints the version and copyright notice texts.
        /// </summary>
        public void PrintVersion()
        {
            // Print to screen
            Log.Information("-------------------------------------------------------------------------");
            Log.Information(AppName + " v" + AppVersion);
            Log.Information(AppCopyright);
            Log.Information("-------------------------------------------------------------------------");
        }

        #endregion
    }
}
