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
        public string name { get; set; }

        public event Action<TankEventArgs> OnShot;
        public event Action<TankEventArgs> OnMove;
        public event Action<TankEventArgs> OnDestroy;

        public Armor armor { get; set; }
        public Engine engine { get; set; }
        public Gun gun { get; set; }

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
            OnMove.Invoke(new TankEventArgs(EventType.Move));
            engine.Drive();
        }

        public void Shot(Tank target, Action act)
        {
            act.Invoke();
            gun.Shot(gun.Recharge);
            OnShot.Invoke(new TankShotEventArgs(target));
            target.armor.Contact(gun.strength);
        }

        public void Shot(Tank target)
        {
            gun.Shot(gun.Recharge);
            OnShot.Invoke(new TankShotEventArgs(target));

            target.armor.Contact(gun.strength);
        }

        public void Aimp(Func<float> fn)
        {
            if (fn.Invoke() > 100)
            {
                Console.WriteLine("Приоритетная цель");
            }
        }

        public void Contact()
        {
            armor.Contact(gun.strength);
        }

        public object Clone()
        {
            return new Tank(factory, typeOfArmor, typeOfGun, typeOfEngine);
        }

        public List<IComponent> ReturnObject()
        {
            return components;
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
