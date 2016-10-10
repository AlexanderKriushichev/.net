using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Интерфейс для логгера
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ILogger<out T> where T: ITank<IComponent>
    {
        /// <summary>
        /// Событие для внешнего метода печати
        /// </summary>
        event Action<TextWriter, T, TankEventArgs> Log;
    }
}
