using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class Armor: IComponent
    {
        protected float _strength;
        public float strength
        {
            get
            {
                return _strength;
            }
            set
            {
                if (value <= 0)
                {
                    _strength = 0;
                }
                else
                {
                    _strength = value;
                }
            }
        }

        public abstract void Contact(float damage);

        public abstract void Create();

        public abstract void Destroy();


    }
}
