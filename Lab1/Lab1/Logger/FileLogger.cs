using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс для печати лога в файл 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class FileLogger<T>: ILogger<T> where T: ITank<IComponent>
    {
        public event Action<TextWriter, T, TankEventArgs> Log;

        private T tank;

        private string filePath;

        /// <summary>
        /// Конструктор логгера в файл
        /// </summary>
        /// <param name="_tank">Логгируемы танк</param>
        /// <param name="_filePath">Путь до файла</param>
        public FileLogger(T _tank, string _filePath)
        {
            tank = _tank;
            filePath = _filePath;
            tank.OnShot += TankEventHandler;
            tank.OnMove += TankEventHandler;
            tank.OnDestroy += TankEventHandler;

            if (!File.Exists(filePath))
            {
                var fs = File.Create(filePath);
                fs.Close();
            }

        }

        /// <summary>
        /// Метод обработчика событий
        /// </summary>
        /// <param name="args"></param>
        private void TankEventHandler(TankEventArgs args)
        {
            using (var writer = File.AppendText(filePath))
            {
                if (Log != null)
                {
                    Log(writer, tank, args);
                }
            }
        }
    }
}
