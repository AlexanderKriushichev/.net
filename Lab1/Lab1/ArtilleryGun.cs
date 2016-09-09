﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ArtilleryGun: Gun
    {

        public ArtilleryGun()
        {
            Create();
        }

        public override void Create()
        {
            strength = 50;
            range = 5000;
        }

        public override void Shot()
        {
            Console.WriteLine("Стреляет артилллерийская пушка");
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
        }
    }
}