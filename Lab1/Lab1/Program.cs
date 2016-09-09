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
            Tank tank = new Tank(new RussianFactory(), TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine);
            tank.Move();

            Tank tank1 = new Tank(new AmericanFactory(), TypeOfArmor.Composite, TypeOfGun.Tank, TypeOfEngine.Diesel);
            tank1.Move();

            tank.Shot(tank1);
            tank1.Shot(tank);
            tank.Shot(tank1);
            tank1.Shot(tank);
            tank.Shot(tank1);
            tank1.Shot(tank);
            tank.Shot(tank1);
            tank1.Shot(tank);
            tank.Shot(tank1);
            tank1.Shot(tank);
            tank.Shot(tank1);
            tank1.Shot(tank);
            tank.Shot(tank1);
            tank1.Shot(tank);
            tank.Shot(tank1);
            tank1.Shot(tank);
 


            Console.ReadLine();
        }
    }
}
