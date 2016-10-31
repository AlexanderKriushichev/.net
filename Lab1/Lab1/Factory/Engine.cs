using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1
{
    [Serializable()]
    [XmlInclude(typeof(DieselEngine))]
    [XmlInclude(typeof(GasturbineEngine))]
    public abstract class Engine: IComponent
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

        private float _health;

        public float health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 0;
                }
            }
        }

        public abstract void Create();

        public float power { get; set; }

        public abstract void Drive();

        public abstract void TurnOn();

        public abstract void TurnOff();

        public abstract void Destroy();

        public abstract void Reset();

        public abstract void Status();

    }
}
