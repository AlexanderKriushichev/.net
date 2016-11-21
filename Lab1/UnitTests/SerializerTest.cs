using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using System;
using Lab1;
using Lab1.Serialization;
using System.Collections.Generic;
using System.IO;
namespace UnitTests
{
    [TestFixture]
    public class SerializerTest
    {

        private TankBattalion<Tank> bat;

        private const string pathXml = "bat.xml";
        private const string pathJson = "bat.json";
        private const string pathBin = "bat.bin";

        [OneTimeTearDown]
        public void DeleteFiles()
        {
            File.Delete(pathXml);
            File.Delete(pathJson);
            File.Delete(pathBin);
        }

        [SetUp]
        public void Init()
        {
            var tanks = new List<Tank>
            {
                new Tank(new RussianFactory(), TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine),
                new Tank(new AmericanFactory(), TypeOfArmor.Composite, TypeOfGun.Artillery, TypeOfEngine.Gasturbine),
                new Tank(new RussianFactory(), TypeOfArmor.Dynamic, TypeOfGun.Tank, TypeOfEngine.Gasturbine),
                new Tank(new RussianFactory(), TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Diesel),
            };

            bat = new TankBattalion<Tank>(tanks);
        }

        [Test]
        public void XmlTest()
        {
            var xmlSer = new XmlSerialization<Tank>();
            xmlSer.Serialize(bat, pathXml);

            var bat2 = xmlSer.Deserialize(pathXml);
            CollectionAssert.AreEqual(bat.tanks, bat2.tanks);
        }

        [Test]
        public void JsonTest()
        {
            var jsonSer = new JSONSerialization<Tank>();
            jsonSer.Serialize(bat, pathJson);

            var bat2 = jsonSer.Deserialize(pathJson);
            CollectionAssert.AreEqual(bat.tanks, bat2.tanks);
        }

        [Test]
        public void BinaryTest()
        {
            var binSer = new BinarySerialization<Tank>();
            binSer.Serialize(bat, pathBin);

            var bat2 = binSer.Deserialize(pathBin);
            CollectionAssert.AreEqual(bat.tanks, bat2.tanks);
        }
    }
}
