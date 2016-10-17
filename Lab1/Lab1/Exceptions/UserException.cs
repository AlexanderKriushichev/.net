using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exceptions
{
    public abstract class UserException: Exception
    {
        protected UserException(string message) : base(message) { }
    }

    public class TankShotException : UserException
    {
        public TankShotException(string message) : base(message) { }
    }

    public class FileFormatException : UserException
    {
        public FileFormatException(string message) : base(message) { }
    }
}
