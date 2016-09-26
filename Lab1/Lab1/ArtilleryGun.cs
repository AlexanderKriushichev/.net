using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ArtilleryGun: Gun, IComponentInfo<ArtilleryGun>
    {
        public string name = "ArtilleryGun";

        public ArtilleryGun()
        {
            Create();
        }

        public void Info(ArtilleryGun obj)
        {
            Console.Write("Info " + obj.name);
        }

        public override void Create()
        {
            strength = 50;
            range = 5000;
            health = 100;
        }

        public override void Reset()
        {
            health = 100;
        }

        public override void Shot(Del del)
        {
            Console.WriteLine("Стреляет артилллерийская пушка");
            del.Invoke();
        }

        public override void Recharge()
        {
            Console.WriteLine("Артилллерийская пушка перезарежается");
        }

        public override void Aiming()
        {
            Console.WriteLine("Артилллерийская пушка наводится на цель");
        }

        public override void Destroy()
        {
            Console.WriteLine("Артилллерийская пушка вышла из строя");
            health = 0;

        }

        public override void Status()
        {
            Console.WriteLine("Артилллерийская пушка:");
            Console.WriteLine("Дальность " + range + " м.");
            Console.WriteLine("Урон " + strength);
            Console.WriteLine("Состояие " + health);
        }
    }
}
