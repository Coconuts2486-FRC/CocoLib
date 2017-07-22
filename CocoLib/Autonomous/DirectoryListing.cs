using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoLib.Autonomous
{
    /// <summary>
    /// Lists all directories of the autonomous modes.
    /// The locations all default to <code>/home/lvuser/auto/</code>.
    /// </summary>
    public class DirectoryListing
    {
        /// <summary>
        /// Location for the test autonomous function.
        /// This is for development purposes so test code can be omitted from release autonomous modes.
        /// Example: "<see cref="Prefix"/>/test.json"
        /// </summary>
        public string Test { get; set; } = "/home/lvuser/auto/test.json";

        /// <summary>
        /// Location of the first red autonomous function.
        /// Example: "/home/lvuser/auto/autored1.json"
        /// </summary>
        public string AutoRed1 { get; set; } = "/home/lvuser/auto/autored1.json";

        /// <summary>
        /// Location of the second red autonomous function.
        /// Example: "/home/lvuser/auto/autored2.json"
        /// </summary>
        public string AutoRed2 { get; set; } = "/home/lvuser/auto/autored2.json";

        /// <summary>
        /// Location of the third red autonomous function.
        /// Example: "/home/lvuser/auto/autored3.json"
        /// </summary>
        public string AutoRed3 { get; set; } = "/home/lvuser/auto/autored3.json";

        /// <summary>
        /// Location of the fourth red autonomous function.
        /// Example: "/home/lvuser/auto/autored4.json"
        /// </summary>
        public string AutoRed4 { get; set; } = "/home/lvuser/auto/autored4.json";

        /// <summary>
        /// Location of the first blue autonomous function.
        /// Example: "/home/lvuser/auto/autoblue1.json"
        /// </summary>
        public string AutoBlue1 { get; set; } = "/home/lvuser/auto/autoblue1.json";

        /// <summary>
        /// Location of the second blue autonomous function.
        /// Example: "/home/lvuser/auto/autoblue2.json"
        /// </summary>
        public string AutoBlue2 { get; set; } = "/home/lvuser/auto/autoblue2.json";

        /// <summary>
        /// Location of the third blue autonomous function.
        /// Example: "/home/lvuser/auto/autoblue3.json"
        /// </summary>
        public string AutoBlue3 { get; set; } = "/home/lvuser/auto/autoblue3.json";

        /// <summary>
        /// Location of the fourth blue autonomous function.
        /// Example: "/home/lvuser/auto/autoblue4.json"
        /// </summary>
        public string AutoBlue4 { get; set; } = "/home/lvuser/auto/autoblue4.json";
    }
}
