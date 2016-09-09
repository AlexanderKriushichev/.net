using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class Engine: IComponent
    {
        protected float _fuel;
        public float fuelСapacity
        {
            get
            {
                return _fuel;
            }
            set 
            {
                if (value <= 0)
                {
                    _fuel = 0;
                }
                else
                {
                    _fuel = value;
                }
            }
        }

        public abstract void Create();

        public float power { get; protected set; }

        public abstract void Drive();

        public abstract void TurnOn();

        public abstract void TurnOff();

        public abstract void Destroy();
    }
}
