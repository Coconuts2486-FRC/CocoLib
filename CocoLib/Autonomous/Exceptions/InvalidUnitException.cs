using System;

namespace CocoLib.Autonomous.Exceptions
{
    class InvalidUnitException : ApplicationException
    {
        public InvalidUnitException() : base() { }
        public InvalidUnitException(string message) : base(message) { }
        public InvalidUnitException(string message, Exception innerException) : base(message, innerException) { }
    }
}
