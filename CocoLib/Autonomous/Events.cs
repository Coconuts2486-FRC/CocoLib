using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoLib.Autonomous
{
    public class Events
    {
        public delegate void AutoEventDelegate(double amount);
        public static event AutoEventDelegate TurnRobot;
        public static event AutoEventDelegate TurnMotor;
        public static event AutoEventDelegate Drive;

        public static void RaiseTurnRobot(double amount) => TurnRobot(amount);
        public static void RaiseTurnMotor(double amount) => TurnMotor(amount);
        public static void RaiseDrive(double amount) => Drive(amount);
    }
}
