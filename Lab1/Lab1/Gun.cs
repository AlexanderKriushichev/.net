using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class Gun: IComponent
    {
        public abstract void Create();

        public float strength { get; protected set; }

        public float range { get; protected set; }

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

        public abstract void Shot();

        public abstract void Recharge();

        public abstract void Aiming();

        public abstract void Destroy();

        public abstract void Reset();

        public abstract void Status();
    }

    
}
