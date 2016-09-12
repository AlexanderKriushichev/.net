using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class RussianFactory: Factory
    {


        public override string SetName()
        {
            serialNumber++;
            return "Армата " + serialNumber;
        }

        public override Gun CreateGun(TypeOfGun type)
        {
            switch (type)
            {
                case TypeOfGun.Artillery:
                    {
                        return new ArtilleryGun();
                    }
                case TypeOfGun.Tank:
                    {
                        return new TankGun();
                    }
                default:
                    {
                        return new TankGun();
                    }
            }
        }

        public override Armor CreateArmor(TypeOfArmor type)
        {
            switch (type)
            {
                case TypeOfArmor.Dynamic:
                    {
                        return new DynamicArmor();
                    }
                case TypeOfArmor.Composite:
                    {
                        return new CompositeArmor();
                    }
                default:
                    {
                        return new CompositeArmor();
                    }
            }
        }

        public override Engine CreateEngine(TypeOfEngine type)
        {
            switch (type)
            {
                case TypeOfEngine.Diesel:
                    {
                        return new DieselEngine();
                    }
                case TypeOfEngine.Gasturbine:
                    {
                        return new GasturbineEngine();
                    }
                default:
                    {
                        return new GasturbineEngine();
                    }
            }
        }
    }
}
