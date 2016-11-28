using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exceptions
{
    /// <summary>
    /// Пользовательские исключения
    /// </summary>
    public abstract class UserException: Exception
    {
        protected UserException(string message) : base(message) { }
    }
    /// <summary>
    /// Исключение выстрела
    /// </summary>
    public class TankShotException : UserException
    {
        public TankShotException(string message) : base(message) { }
    }
    /// <summary>
    /// Исключение формата файла
    /// </summary>
    public class FileFormatException : UserException
    {
        public FileFormatException(string message) : base(message) { }
    }
}
