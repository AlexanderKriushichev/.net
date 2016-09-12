using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class TankGun: Gun
    {

        public TankGun()
        {
            Create();
        }

        public override void Create()
        {
            strength = 100;
            range = 1000;
            health = 100;
        }

        public override void Reset()
        {
            health = 100;
        }

        public override void Shot()
        {
            Console.WriteLine("Стреляет танковая пушка");
        }

        public override void Recharge()
        {
            Console.WriteLine("Танковая пушка перезарежается");
        }

        public override void Aiming()
        {
            Console.WriteLine("Танковая пушка наводится на цель");
        }

        public override void Destroy()
        {
            Console.WriteLine("Танковая пушка вышла из строя");
        }

        public override void Status()
        {
            Console.WriteLine("Танковая пушка:");
            Console.WriteLine("Дальность " + range + " м.");
            Console.WriteLine("Урон " + strength);
            Console.WriteLine("Состояие " + health);
        }
    }
}
