using System;
using System.Threading.Tasks;
using Serilog;
using Serilog.Formatting.Display;
using Serilog.Sinks.LogEmAll;

namespace BuildEmAll_CLI
{
    /// <summary>
    /// The Main Program Class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The Main entry point for the program.
        /// </summary>
        static void Main(string[] args)
        {
            // Configure the Logger.
            ConfigureSerilog();

            // Create a new program object.
            BuildEmAll.BuildEmAll BEA = new BuildEmAll.BuildEmAll();

            // Set the title.
            BEA.UpdateTitle();

            // Print the version.
            BEA.PrintVersion();

            // Load the default options passed from the command line arguments.
            BEA.LoadOptionsFromCLI(args);

            // Load the default options passed from the default options file.
            BEA.LoadOptionsFromFile();

            // Process the command switch.
            BEA.ProcessCommandSwitch();

            // Output the log to a text file.
            BEA.SaveLogToFile();
        }

        /// <summary>
        /// Configure the logger.
        /// </summary>
        public static void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(outputTemplate: "{Level:u4}: {Message:lj}{NewLine}{Exception}")
                .WriteToListString(new MessageTemplateTextFormatter("{Level:u4}: {Message:lj}{Exception}"))
                .CreateLogger();
        }
    }
}
