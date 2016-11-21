using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using Lab1;
namespace UnitTests
{
    [TestFixture]
    public class FabricsTest
    {
        [Test]
        public void RussianFabricTest()
        {
            var fab = new RussianFactory();
            Assert.DoesNotThrow(() =>
            {
                var gun = fab.CreateGun(TypeOfGun.Tank);
                Assert.NotNull(gun);

                var gun1 = fab.CreateGun(TypeOfGun.Artillery);
                Assert.NotNull(gun1);

                var armor = fab.CreateArmor(TypeOfArmor.Composite);
                Assert.NotNull(armor);

                var armor1 = fab.CreateArmor(TypeOfArmor.Dynamic);
                Assert.NotNull(armor1);

                var engine = fab.CreateEngine(TypeOfEngine.Diesel);
                Assert.NotNull(engine);

                var engine1 = fab.CreateEngine(TypeOfEngine.Diesel);
                Assert.NotNull(engine1);
            });
        }

        [Test]
        public void AmericanFabricTest()
        {
            var fab = new AmericanFactory();
            Assert.DoesNotThrow(() =>
            {
                var gun = fab.CreateGun(TypeOfGun.Tank);
                Assert.NotNull(gun);

                var gun1 = fab.CreateGun(TypeOfGun.Artillery);
                Assert.NotNull(gun1);

                var armor = fab.CreateArmor(TypeOfArmor.Composite);
                Assert.NotNull(armor);

                var armor1 = fab.CreateArmor(TypeOfArmor.Dynamic);
                Assert.NotNull(armor1);

                var engine = fab.CreateEngine(TypeOfEngine.Diesel);
                Assert.NotNull(engine);

                var engine1 = fab.CreateEngine(TypeOfEngine.Diesel);
                Assert.NotNull(engine1);
            });
        }
    }
}
