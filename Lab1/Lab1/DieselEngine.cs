using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DieselEngine: Engine
    {
        public DieselEngine()
        {
            Create();
        }

        public override void Create()
        {
            fuelСapacity = 1000;
            power = 800;
            health = 100;
        }

        public override void Reset()
        {
            fuelСapacity = 1000;
            health = 100;
        }

        public override void Drive()
        {
            Console.WriteLine("Танк с дизельным двигателем передвигается");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Дизельный двигатель заведен");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Дизельный двигатель заглушен");
        }

        public override void Destroy()
        {
            Console.WriteLine("Дизельный двигатель вышел из строя");
        }

        public override void Status()
        {
            Console.WriteLine("Газотурбинный двигатель :");
            Console.WriteLine("Мощность " + power);
            Console.WriteLine("Запас горючего " + fuelСapacity);
            Console.WriteLine("Состояие " + health);
        }
    }
}
