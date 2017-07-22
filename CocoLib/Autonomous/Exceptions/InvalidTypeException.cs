using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoLib.Autonomous.Exceptions
{
    class InvalidTypeException : ApplicationException
    {
        public InvalidTypeException() : base() { }
        public InvalidTypeException(string message) : base(message) { }
        public InvalidTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
