using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Lab1;
using Lab1.Serialization;

namespace LibExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            RussianFactory russianFactory = new RussianFactory();

            TankBattalion<Tank> tankBattalion = new TankBattalion<Tank>(2);

            foreach (Tank tank in tankBattalion.FindTanksWithGunStrength(50))
            {
               tank.GetStatus();
            }
            Console.WriteLine(tankBattalion.ConvertToString());

            Console.Read();
        }
    }

    /// <summary>
    /// Класс расширение
    /// </summary>
    public static class TankExtension
    {
        /// <summary>
        /// Поиск всех таков с заданым уровнем силы оружия
        /// </summary>
        /// <typeparam name="T">Тип коллекции</typeparam>
        /// <param name="bat">Коллекция</param>
        /// <param name="strength">Сила</param>
        /// <returns>Список танков</returns>
        public static List<T> FindTanksWithGunStrength<T>(this TankBattalion<T> bat, int strength)
            where T : Tank
        {
            ExtensionLogger.Log("Вызван метод расширения найти танк с максимальной силой оружия");
            return bat.Where(t => t.gun.strength == strength).ToList();
        }

        /// <summary>
        /// Метод перевода коллекции в json-строку
        /// </summary>
        /// <typeparam name="T">Тип обобощенной коллекции</typeparam>
        /// <param name="bat">Коллекция</param>
        /// <returns>json-строка с объектами коллекции</returns>
        public static string ConvertToString<T>(this TankBattalion<T> bat) where T : Tank
        {
            ExtensionLogger.Log("Вызван метод конвертации коллекции в строку");
            TankPack<T> wrap = new TankPack<T>(bat);
            var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var json = JsonConvert.SerializeObject(wrap, jset);
            return json;
        }

      

    }

    /// <summary>
    /// Логгер
    /// </summary>
    public static class ExtensionLogger
    {
        public static string filePath = "";

        public static void Log(string mes)
        {
            if (filePath == "")
                Console.WriteLine(DateTime.Now + " : " + mes);
            else
            {
                File.AppendAllText(DateTime.Now + " : " + filePath, mes);
            }
        }
    }
}
