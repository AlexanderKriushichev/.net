using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Serialization
{
    interface ISerialization<T> where T: Tank
    {
        void Serialize(TankBattalion<T> tank, string filePath);

        TankBattalion<T> Deserialize(string filePath);
    }
}
