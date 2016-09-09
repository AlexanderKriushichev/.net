using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Tank
    {
        public string name;

        public Armor armor;
        public Engine engine;
        public Gun gun;

        public Tank(Factory factory, TypeOfArmor armorType, TypeOfGun gunType, TypeOfEngine engineType)
        {
            name = factory.SetName();
            gun = factory.CreateGun(gunType);
            engine = factory.CreateEngine(engineType);
            armor = factory.CreateArmor(armorType);
        }

        public void Move()
        {
            Console.Write(name + ": ");
            engine.Drive();
        }

        public void Shot(Tank target)
        {
            Console.Write(name + ": ");
            gun.Shot();
            Console.Write(target.name + ": ");

            target.armor.Contact(gun.strength);
        }

        public void Contact()
        {
            armor.Contact(gun.strength);
        }
    }
}
