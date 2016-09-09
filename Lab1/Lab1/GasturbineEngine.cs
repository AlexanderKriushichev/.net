using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class GasturbineEngine: Engine
    {

        public GasturbineEngine()
        {
            Create();
        }

        public override void Create()
        {
            fuelСapacity = 1000;
            power = 1200;
        }

        public override void Drive()
        {
            Console.WriteLine("Танк с газотурбинным  двигателем передвигается");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Газотурбинный двигатель заведен");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Газотурбинный двигатель заглушен");
        }

        public override void Destroy()
        {
            Console.WriteLine("Газотурбинный двигатель вышел из строя");
        }
    }
}
