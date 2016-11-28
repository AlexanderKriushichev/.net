using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Serialization
{
    /// <summary>
    /// Интерфейс сериализации
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ISerialization<T> where T: Tank
    {
        /// <summary>
        /// Сериализация объекта
        /// </summary>
        /// <param name="tank">Объект</param>
        /// <param name="filePath">Путь к файлу</param>
        void Serialize(TankBattalion<T> tank, string filePath);

        /// <summary>
        /// Десериализация объекта
        /// </summary>
        /// <param name="filePath">Путь к файду</param>
        /// <returns>Объект</returns>
        TankBattalion<T> Deserialize(string filePath);
    }
}
