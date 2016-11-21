using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using Lab1;

namespace UnitTests
{
    [TestFixture]
    public class TankTest
    {
        private Tank tank;
        [SetUp]
        public void Init()
        {
            tank = new Tank(new RussianFactory(),TypeOfArmor.Composite, TypeOfGun.Tank,TypeOfEngine.Diesel);
        }

        [Test]
        public void CreateTank()
        {
            var testTank = new Tank(new RussianFactory(), TypeOfArmor.Composite, TypeOfGun.Tank, TypeOfEngine.Diesel);

            Assert.AreEqual(testTank.armor.health, 400);
            Assert.AreEqual(testTank.engine.health, 100);
            Assert.AreEqual(testTank.gun.health, 100);

        }

        [Test]
        public void MoveTest()
        {
            Assert.DoesNotThrow(() => tank.Move());
        }

        [Test]
        public void GoodShotTest()
        {
            var target = new Tank(new RussianFactory(), TypeOfArmor.Composite, TypeOfGun.Tank, TypeOfEngine.Diesel);
            var tankShot = new Tank(new RussianFactory(), TypeOfArmor.Composite, TypeOfGun.Tank, TypeOfEngine.Diesel);

            Assert.DoesNotThrow(() => tankShot.Shot(target));
            Assert.AreEqual(400 - tank.gun.strength, target.armor.health);
        }

    }
}
