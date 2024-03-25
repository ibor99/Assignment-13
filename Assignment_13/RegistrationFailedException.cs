using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_13
{
    public class RegistrationFailedException : Exception
    {
        public RegistrationFailedException(string message) : base(message) { }
        public RegistrationFailedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
