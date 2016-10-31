using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Exceptions;
using System.IO;
using System.Xml.Serialization;

namespace Lab1
{
    [Serializable()]
    [XmlRoot("Person")]
    public class Tank : ICloneable, ITank<IComponent> 
    {
        public string name { get; set; }

        public event Action<TankEventArgs> OnShot;
        public event Action<TankEventArgs> OnMove;
        public event Action<TankEventArgs> OnDestroy;

        
        public Armor armor;
        public Engine engine;
        public Gun gun;

        private List<IComponent> components = new List<IComponent>();

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

        public Tank()
        {
            //var factoryType = new RussianFactory();
            //name = factoryType.SetName();
            //gun = factoryType.CreateGun(TypeOfGun.Tank);
            //SetComponent(gun);
            //engine = factoryType.CreateEngine(TypeOfEngine.Diesel);
            //SetComponent(engine);
            //armor = factoryType.CreateArmor(TypeOfArmor.Composite);
            //SetComponent(armor);

            //factory = factoryType;
            //typeOfArmor = TypeOfArmor.Composite;
            //typeOfGun = TypeOfGun.Tank;
            //typeOfEngine = TypeOfEngine.Diesel;
        }

        public Tank(Armor _armor, Engine _engine, Gun _gun)
        {
            armor = _armor;
            engine = _engine;
            gun = _gun;
            SetComponent(gun);
            SetComponent(engine);
            SetComponent(armor);
        }

        public void Move()
        {
            OnMove.Invoke(new TankEventArgs(EventType.Move));
            engine.Drive();
        }

        public static Tank CreateFromFile(string path)
        {
            var info = File.ReadAllLines(path);

            TypeOfArmor armorType = TypeOfArmor.Composite;
            TypeOfEngine engineType = TypeOfEngine.Gasturbine;
            TypeOfGun gunType = TypeOfGun.Tank;
            Factory factoryType = new RussianFactory();

            try
            {
                switch (info[0])
                {
                    case "Russian":
                        {
                            factoryType = new RussianFactory();
                            break;
                        }
                    case "American":
                        {
                            factoryType = new AmericanFactory();
                            break;
                        }
                }
                switch (info[1])
                {
                    case "Artillery":
                        {
                            gunType = TypeOfGun.Artillery;
                            break;
                        }
                    case "Tank":
                        {
                            gunType = TypeOfGun.Tank;
                            break;
                        }
                }
                switch (info[2])
                {
                    case "Dynamic":
                        {
                            armorType = TypeOfArmor.Dynamic;
                            break;
                        }
                    case "Composite":
                        {
                            armorType = TypeOfArmor.Composite;
                            break;
                        }
                }
                switch (info[3])
                {
                    case "Diesel":
                        {
                            engineType = TypeOfEngine.Diesel;
                            break;
                        }
                    case "Gasturbine":
                        {
                            engineType = TypeOfEngine.Gasturbine;
                            break;
                        }
                }               
            }
            catch (FormatException) { throw new FileFormatException("Входной файл имел неверный формат"); }

            return new Tank(factoryType, armorType, gunType, engineType);
        }

        public void Shot(Tank target)
        {
            if (target == this)
                throw new TankShotException("Нельзя стрелять по самому себе");
            if (target == null)
                throw new TankShotException("Выберите цель для выстрела");
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
