using System;
using CocoLib.Autonomous.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocoLib.Autonomous.Exceptions;

namespace CocoLib.Autonomous
{
    public interface IQuantity
    {
        void Run();
    }

    public struct Scalar : IQuantity
    {
        public Distance Distance { get; set; }

        public CommandType Type { get; set; }

        public Scalar(Distance Distance, CommandType Type)
        {
            this.Distance = Distance;
            this.Type = Type;
        }

        public void Run()
        {
            switch (Type)
            {
                case CommandType.Drive:
                    Events.RaiseDrive(Distance.GetScaledAmount());
                    break;
                case CommandType.TurnMotor:
                    Events.RaiseTurnMotor(Distance.GetScaledAmount());
                    break;
                case CommandType.TurnRobot:
                    Events.RaiseTurnRobot(Distance.GetScaledAmount());
                    break;
                default:
                    throw new InvalidTypeException("Given type was not found or is not valid for a scalar command.");
            }
        }
    }

    public struct Vector : IQuantity
    {
        public Distance Distance { get; set; }

        public Direction Direction { get; set; }

        CommandType Type { get; set; }

        public Vector(Distance Distance, Direction Direction, CommandType Type)
        {
            this.Distance = Distance;
            this.Direction = Direction;
            this.Type = Type;
        }

        public void Run()
        {
            switch (Type)
            {
                case CommandType.DriveTo:
                    Events.RaiseTurnRobot(Direction.GetScaledAmount());
                    Events.RaiseDrive(Distance.GetScaledAmount());
                    break;
                default:
                    throw new InvalidTypeException("Given type was not found or is not valid for a scalar command.");
            }
        }
    }

    public struct Direction
    {
        public double Amount { get; set; }
        public AngularUnit Unit { get; set; }

        /// <summary>
        /// Converts the amount to radians.
        /// </summary>
        /// <returns><see cref="Amount"/> in radians.</returns>
        public double GetScaledAmount()
        {
            switch (Unit)
            {
                case AngularUnit.Degrees:
                    return Amount * (Math.PI / 180);
                case AngularUnit.Radians:
                    return Amount;
                default:
                    throw new InvalidUnitException("No unit declared.");
            }
        }
    }

    public struct Distance
    {
        public double Amount { get; set; }
        public LinearUnit Unit { get; set; }

        /// <summary>
        /// Converts the amount to centimeters.
        /// </summary>
        /// <returns><see cref="Amount"/> in centimeters.</returns>
        public double GetScaledAmount()
        {
            switch (Unit)
            {
                case LinearUnit.Centimeters:
                    return Amount;
                case LinearUnit.Feet:
                    return Amount * 2.54 * 12;
                case LinearUnit.Inches:
                    return Amount * 2.54;
                case LinearUnit.Meters:
                    return Amount * 0.01;
                default:
                    throw new InvalidUnitException("No unit declared.");
            }
        }
    }
}
