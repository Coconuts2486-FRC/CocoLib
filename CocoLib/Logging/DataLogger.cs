using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CocoLib.Logging
{
    public static class Functions
    {
        private static bool FirstWrite { get; set; } = false;
        /// <summary>
        /// The directory to read and write from. If you want to change the directory, set it before calling any methods.
        /// </summary>
        public static string Directory { get; set; } = "/home/lvuser/logs/RobotData.txt";

        private static StreamWriter writer;

        ///// <summary>
        ///// Instantiates a new class of DataLogger with the default directory of
        ///// <code>/home/lvuser/logs/RobotData.txt</code>.
        ///// <seealso cref="Directory"/>
        ///// </summary>
        //public static Log() { }

        ///// <summary>
        ///// Instantiates a new class of Log with the given directory.
        ///// <seealso cref="Directory"/>
        ///// </summary>
        ///// <param name="directory"></param>
        //public static Log(string directory)
        //{
        //    Directory = directory;
        //}

        /// <summary>
        /// Formats a message to be easily visible and traceable from the log file.
        /// </summary>
        /// <param name="error">Error information to add to the file.</param>
        /// <param name="memberName">Calling method. Can be overridden, but is supplied by <see cref="CallerMemberNameAttribute"/>.</param>
        /// <param name="filePath">File path of the calling method. Can be overridden, but is supplied by <see cref="CallerFilePathAttribute"/>.</param>
        /// <param name="sourceLineNumber">Line number withing the file. Can be overridden, but is supplied by <see cref="CallerLineNumberAttribute"/>.</param>
        public static void AddErrorToLog(string error, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!FirstWrite)
                Initialize();
            Console.WriteLine(String.Format("[{0}] {1}\n  - Member Name: {2}\n  - File Path: {3}\n  - Line Number: {4}", DateTime.UtcNow, error, memberName, filePath, sourceLineNumber));
        }

        /// <summary>
        /// Adds data with a key value to be searched for and the data.
        /// </summary>
        /// <param name="key">What the data is about.</param>
        /// <param name="data">The data to be logged.</param>
        public static void AddDataToLog(string key, string data)
        {
            if (!FirstWrite)
                Initialize();
            Console.WriteLine(String.Format("[{0}] {1}: {2}", DateTime.UtcNow, key, data));
        }

        /// <summary>
        /// Adds a message to the log with a timestamp.
        /// To print raw data without a timestamp, use <see cref="AddRaw(string)"/>
        /// </summary>
        /// <param name="message"></param>
        public static void AddMessageToLog(string message)
        {
            if (!FirstWrite)
                Initialize();
            Console.WriteLine(String.Format("[{0}] {1}", DateTime.UtcNow, message));
        }

        /// <summary>
        /// Initializes the console stream and adds a header. By default, this is run every time the program is restarted.
        /// </summary>
        public static void Initialize()
        {
            writer = new StreamWriter(Directory)
            {
                AutoFlush = true
            };
            Console.SetOut(writer);

            Console.WriteLine(String.Format("\n-----\nBegin new data set on {0}.\n-----\n", DateTime.UtcNow));
            FirstWrite = true;
        }

        /// <summary>
        /// Print a raw message to the filestream. Any formatting is supported.
        /// </summary>
        /// <param name="data">The data to write to the file.</param>
        public static void AddRaw(string data)
        {
            Console.WriteLine(data);
        }
    }
}
