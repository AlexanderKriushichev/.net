using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            RussianFactory russianFactory = new RussianFactory();

            Tank tank = new Tank(russianFactory, TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine);
            tank.Move();

            Tank tank2 = new Tank(russianFactory, TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine);
            tank2.Move();

            Tank tank3 = new Tank(russianFactory, TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine);
            tank3.Move();

            Tank tank1 = new Tank(new AmericanFactory(), TypeOfArmor.Composite, TypeOfGun.Tank, TypeOfEngine.Diesel);
            tank1.Move();

            foreach (IComponent comp in tank.components)
            {
                comp.Status();
            }

            Console.ReadLine();
        }
    }
}
