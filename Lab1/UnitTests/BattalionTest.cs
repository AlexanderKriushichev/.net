using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using Lab1;
namespace UnitTests
{
    [TestFixture]
    public class BattalionTest
    {

        private List<Tank> tanks;

        [SetUp]
        public void Init()
        {
            tanks = new List<Tank>
            {
                new Tank(new RussianFactory(), TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine),
                new Tank(new AmericanFactory(), TypeOfArmor.Composite, TypeOfGun.Artillery, TypeOfEngine.Gasturbine),
                new Tank(new RussianFactory(), TypeOfArmor.Dynamic, TypeOfGun.Tank, TypeOfEngine.Gasturbine),
                new Tank(new RussianFactory(), TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Diesel),
            };
        }

        public void BattalionGenTest()
        {
            var bat = new TankBattalion<Tank>(10);
            CollectionAssert.AllItemsAreNotNull(bat.tanks);
        }

        [Test]
        public void CreateTest()
        {
            var bat = new TankBattalion<Tank>(tanks);

            Assert.AreEqual(4, bat.Count);
        }

        [Test]
        public void PrintTest()
        {
            var bat = new TankBattalion<Tank>(tanks);

            Assert.DoesNotThrow(()=>bat.PrintTanks());
        }

        [Test]
        public void MethodsTest()
        {
            var bat = new TankBattalion<Tank>(tanks);
            var tank = new Tank(new RussianFactory(), TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Diesel);

            bat.Add(tank);
            Assert.AreEqual(5, bat.Count);

            Assert.True(bat.Contains(tank));

            bat[0] = tank;
            Assert.AreEqual(tank, bat[0]);

            bat.Remove(tank);
            Assert.AreEqual(4, bat.Count);

            bat.Clear();
            Assert.AreEqual(0, bat.Count);

            Assert.DoesNotThrow(() =>
            {
                var enumerator = bat.GetEnumerator();
            });

            Assert.IsFalse(bat.IsReadOnly);
        }

        [Test]
        public void SortTest()
        {
            var bat = new TankBattalion<Tank>(tanks);

            bat.Sort();

            Assert.IsTrue(bat[0].typeOfArmor == TypeOfArmor.Composite);
        }
    }
}
