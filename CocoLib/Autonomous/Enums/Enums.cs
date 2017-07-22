using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoLib.Autonomous.Enums
{
    public enum CommandType
    {
        /// <summary>
        /// Turn the robot to a specific angle.
        /// </summary>
        TurnRobot,
        /// <summary>
        /// Turn a motor to a specific angle.
        /// </summary>
        TurnMotor,
        /// <summary>
        /// Drive forwards or backwards a specific amount.
        /// </summary>
        Drive,
        /// <summary>
        /// Drive to a specific point given distance and direction.
        /// </summary>
        DriveTo
    }

    public enum LinearUnit
    {
        Inches,
        Feet,
        Centimeters,
        Meters
    }

    public enum AngularUnit
    {
        Degrees,
        Radians
    }
}
