using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс для печати лога в консоль
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ConsoleLogger<T>: ILogger<T> where T: ITank<IComponent>
    {
        public event Action<TextWriter, T, TankEventArgs> Log;

        private T tank;

        /// <summary>
        /// Конструктор логгера в консоль
        /// </summary>
        /// <param name="_tank">Логгируемы танк</param>
        public ConsoleLogger(T _tank)
        {
            tank = _tank;
            tank.OnShot += TankEventHandler;
            tank.OnMove += TankEventHandler;
            tank.OnDestroy += TankEventHandler;
        }

        /// <summary>
        /// Метод обработчика событий
        /// </summary>
        /// <param name="args"></param>
        private void TankEventHandler(TankEventArgs args)
        {
            using (var writer = Console.Out)
            {
                if (Log != null)
                {
                    Log(writer, tank, args);
                }
            }
        }

    }
}
