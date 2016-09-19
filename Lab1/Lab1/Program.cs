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

            TankBattalion<Tank> tankBattalion = new TankBattalion<Tank>();

            

            Tank tank = new Tank(russianFactory, TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine);
            tank.Move();

            Tank tank1 = (Tank)tank.Clone();
            tankBattalion.Add(tank);
            tankBattalion.Add(tank1);
            tankBattalion.Add((Tank)tank.Clone());
            tank.gun.Destroy();

            foreach (Tank t in tankBattalion)
            {
                t.GetStatus();
                
            }

            Console.ReadLine();
        }
    }
}
