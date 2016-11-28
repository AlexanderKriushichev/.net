using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1.Serialization
{
    /// <summary>
    /// Класс обертка для сериализации
    /// </summary>
    /// <typeparam name="T"></typeparam>
   
    [Serializable]
    [XmlRoot]
    public class TankPack<T> where T : Tank
    {

        public List<T> tanks { get; set; }

        public TankPack(TankBattalion<T> tank)
        {
             tanks = tank.tanks;
        }

        public TankPack()
        {

        }
    }
}
