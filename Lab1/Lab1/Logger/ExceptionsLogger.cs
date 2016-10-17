using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab1.Exceptions;

namespace Lab1.Logger
{
    class ExceptionsLogger
    {
        /// <summary>
        /// Путь к файлу для записи
        /// </summary>
        public static string FilePath = "ExceptionsLog1.txt";

        /// <summary>
        /// Вести запись в файл? Иначе в консоль
        /// </summary>
        public static bool ToFile = true;

        /// <summary>
        /// Логгирование пользовательского исключения
        /// </summary>
        /// <param name="ex">Исключение</param>
        public static void LogUserException(UserException ex)
        {
            if (FilePath != null && ToFile)
            {
                if (!File.Exists(FilePath))
                {
                    var fs = File.Create(FilePath);
                    fs.Close();
                }
            }
            using (var writer = ToFile && FilePath != null ? File.AppendText(FilePath) : Console.Out)
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ": " + ex.Message + " (Пользовательское исключение)");
            }
        }

        /// <summary>
        /// Логгирование системного исключения
        /// </summary>
        /// <param name="ex">Исключение</param>
        public static void LogSystemException(Exception ex)
        {
            if (FilePath != null && ToFile)
            {
                if (!File.Exists(FilePath))
                {
                    var fs = File.Create(FilePath);
                    fs.Close();
                }
            }
            using (var writer = ToFile && FilePath != null ? File.AppendText(FilePath) : Console.Out)
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ": " + ex.Message + " (Системное исключение)");
            }
        }
    }
}
