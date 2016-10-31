using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1
{
    [Serializable]
    [XmlInclude(typeof(TankGun))]
    [XmlInclude(typeof(ArtilleryGun))]
    public abstract class Gun: IComponent 
    {
        public delegate void Del();

        public abstract void Create();

        public float strength { get;  set; }

        public float range { get;  set; }

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

        public abstract void Shot(Del del);

        public abstract void Recharge();

        public abstract void Aiming();

        public abstract void Destroy();

        public abstract void Reset();

        public abstract void Status();
    }

    
}
