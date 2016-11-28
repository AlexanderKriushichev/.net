using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
namespace Lab1
{
    [Serializable()]
    [XmlInclude(typeof(RussianFactory))]
    [XmlInclude(typeof(AmericanFactory))]
    [DataContract]
    public abstract class Factory
    {

        protected int serialNumber;

        /// <summary>
        /// Установить имя
        /// </summary>
        /// <returns></returns>
        public abstract string SetName();
        /// <summary>
        /// Создать оружие
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract Gun CreateGun(TypeOfGun type);
        /// <summary>
        /// Создать броню
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract Armor CreateArmor(TypeOfArmor type);
        /// <summary>
        /// Создать двигатель
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract Engine CreateEngine(TypeOfEngine type);

    }
}

public enum TypeOfGun { Artillery, Tank}

public enum TypeOfArmor { Dynamic, Composite}

public enum TypeOfEngine { Diesel, Gasturbine}