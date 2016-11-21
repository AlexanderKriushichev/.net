using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Lab1.Serialization
{
    public class JSONSerialization<T> : ISerialization<T> where T : Tank
    {
        public void Serialize(TankBattalion<T> tank, string filePath)
        {
            TankPack<T> wrap = new TankPack<T>(tank);
            var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var json = JsonConvert.SerializeObject(wrap, jset);
            File.WriteAllText(filePath, json);
        }

        public TankBattalion<T> Deserialize(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var wrap = JsonConvert.DeserializeObject<TankPack<T>>(json, jset);
            return new TankBattalion<T>(wrap.tanks);
        }
    }
}
