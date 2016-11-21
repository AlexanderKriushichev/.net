using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab1.Serialization
{
    public class BinarySerialization<T> : ISerialization<T> where T : Tank
    {
        private readonly BinaryFormatter _binFormat;

        public BinarySerialization()
		{
			_binFormat = new BinaryFormatter();
		}
        public void Serialize(TankBattalion<T> tank, string filePath)
        {
			using (Stream fStream = new FileStream(filePath,
			   FileMode.Create, FileAccess.Write, FileShare.None))
			{
                _binFormat.Serialize(fStream, tank);
			}
		}

        public TankBattalion<T> Deserialize(string filePath)
        {
			using (var fs = new FileStream(filePath, FileMode.Open))
			{
                return (TankBattalion<T>)_binFormat.Deserialize(fs);
			}
		}
    }
}
