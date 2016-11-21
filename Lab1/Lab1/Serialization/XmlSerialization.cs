using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Serialization
{
    public class XmlSerialization<T> :ISerialization<T> where T: Tank
    {
        private XmlSerializer xml;

        public XmlSerialization()
        {
            xml = new XmlSerializer(typeof(TankPack<T>));
        }

        public void Serialize(TankBattalion<T> tank, string filePath)
        {
            var wrap = new TankPack<T>(tank);
            using (Stream fStream = new FileStream(filePath,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xml.Serialize(fStream, wrap);
            }
        }

        public TankBattalion<T> Deserialize(string filePath)
        {
            TankPack<T> wrap;
            using (Stream fStream = new FileStream(filePath, FileMode.Open))
            {
                wrap = (TankPack<T>)xml.Deserialize(fStream);
            }
            var temp = wrap.tanks.Select(tank => (T)tank).ToList();
            TankBattalion<T> bat = new TankBattalion<T>(temp);
            return bat;
        }
    }
}
