using Newtonsoft.Json;
using System.IO;

namespace CocoLib.Autonomous
{
    public class AutoFactory
    {
        public enum AutoModes
        {
            Disabled = 0x00, // = 0
            Test     = 0x01, // = 1

            Red1     = 0x11, // = 17
            Red2     = 0x12, // = 18
            Red3     = 0x13, // = 19
            Red4     = 0x14, // = 20

            Blue1    = 0x21, // = 33
            Blue2    = 0x22, // = 34
            Blue3    = 0x23, // = 35
            Blue4    = 0x24  // = 36
        }

        private DirectoryListing directories;

        /// <summary>
        /// Creates a new instance of AutoFactory with the specified directory listing.
        /// </summary>
        /// <param name="directories">The current directory listing. <seealso cref="DirectoryListing"/></param>
        public AutoFactory(DirectoryListing directories)
        {
            this.directories = directories;
        }

        public void RunAuto(AutoModes autoMode)
        {
            AutoInstruction auto = Switcher(autoMode);
            foreach(IQuantity x in auto.Commands)
            {
                x.Run();
            }
        }

        private AutoInstruction Switcher(AutoModes autoMode)
        {
            if ((int)autoMode < 20) // Not blue.
            {
                if ((int)autoMode > 16) // Red.
                {
                    switch (autoMode)
                    {
                        case AutoModes.Red1:
                            return JsonParser(directories.AutoRed1);
                        case AutoModes.Red2:
                            return JsonParser(directories.AutoRed2);
                        case AutoModes.Red3:
                            return JsonParser(directories.AutoRed3);
                        case AutoModes.Red4:
                            return JsonParser(directories.AutoRed4);
                        default:
                            Logging.Functions.AddErrorToLog("Error in red auto switcher.");
                            break;
                    }
                }
                else // Not red.
                {
                    switch (autoMode)
                    {
                        case AutoModes.Disabled:
                            return new AutoInstruction();
                        case AutoModes.Test:
                            return JsonParser(directories.Test);
                        default:
                            Logging.Functions.AddErrorToLog("Error in special auto switcher.");
                            break;
                    }
                }
            }
            else // Blue.
            {
                switch (autoMode)
                {
                    case AutoModes.Blue1:
                        JsonParser(directories.AutoBlue1);
                        break;
                    case AutoModes.Blue2:
                        JsonParser(directories.AutoBlue2);
                        break;
                    case AutoModes.Blue3:
                        JsonParser(directories.AutoBlue3);
                        break;
                    case AutoModes.Blue4:
                        JsonParser(directories.AutoBlue4);
                        break;
                    default:
                        Logging.Functions.AddErrorToLog("Error in blue auto switcher.");
                        break;
                }
            }
            return null;
        }

        private AutoInstruction JsonParser(string directory)
        {
            return JsonConvert.DeserializeObject<AutoInstruction>(File.ReadAllText(directory));
        }
    }
}