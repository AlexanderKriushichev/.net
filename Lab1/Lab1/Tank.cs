using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Tank : ICloneable, ITank<IComponent> 
    {
        public string name;

        public Armor armor;
        public Engine engine;
        public Gun gun;

        public List<IComponent> components = new List<IComponent>();

        private Factory factory;
        private TypeOfArmor typeOfArmor;
        private TypeOfGun typeOfGun;
        private TypeOfEngine typeOfEngine;

        public Tank(Factory factoryType, TypeOfArmor armorType, TypeOfGun gunType, TypeOfEngine engineType)
        {
            name = factoryType.SetName();
            gun = factoryType.CreateGun(gunType);
            SetComponent(gun);
            engine = factoryType.CreateEngine(engineType);
            SetComponent(engine);
            armor = factoryType.CreateArmor(armorType);
            SetComponent(armor);

            factory = factoryType;
            typeOfArmor = armorType;
            typeOfGun = gunType;
            typeOfEngine = engineType;
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

        public object Clone()
        {
            return new Tank(factory, typeOfArmor, typeOfGun, typeOfEngine);
        }

        public void GetStatus()
        {
            foreach (IComponent comp in components)
            {
                comp.Status();
            }
        }

        public void SetComponent(IComponent comp)
        {
            components.Add(comp);
        }
    }
}
