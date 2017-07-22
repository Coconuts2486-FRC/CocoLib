using System;
using CocoLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocoLib.Autonomous;
using CocoLib.Autonomous.Enums;

namespace DebugSpace.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            CocoLib.Logging.Functions.Directory = "C:\\Users\\Zach\\Desktop\\Log.txt";

            AutoInstruction instruction = new AutoInstruction();
            Scalar command1 = new Scalar()
            {
                Distance = new Distance()
                {
                    Amount = 10,
                    Unit = LinearUnit.Feet
                },
                Type = CommandType.Drive
            };
            instruction.Commands.Add(command1);

            instruction.Save("C:\\Users\\Zach\\Desktop\\Auto\\AutoRed1.json");

            string prefix = "C:\\Users\\Zach\\Desktop\\Auto\\";
            DirectoryListing listing = new DirectoryListing()
            {
                AutoBlue1 = prefix + "AutoBlue1.json",
                AutoBlue2 = prefix + "AutoBlue2.json",
                AutoBlue3 = prefix + "AutoBlue3.json",
                AutoBlue4 = prefix + "AutoBlue4.json",
                AutoRed1 = prefix + "AutoRed1.json",
                AutoRed2 = prefix + "AutoRed2.json",
                AutoRed3 = prefix + "AutoRed3.json",
                AutoRed4 = prefix + "AutoRed4.json",
                Test = prefix + "Test.json"
            };

            AutoFactory autoFactory = new AutoFactory(listing);
            autoFactory.RunAuto(AutoFactory.AutoModes.Red1);
        }
    }

    public interface Polygon
    {
        double GetArea();
    }

    public class Shape<T> where T : Polygon
    {
        public T type;
    }

    public struct Triangle : Polygon
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double GetArea()
        {
            return 0.5 * Length * Width;
        }
    }

    public struct Rectangle : Polygon
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double GetArea()
        {
            return Length * Width;
        }
    }
}
