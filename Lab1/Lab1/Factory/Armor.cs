﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1
{
    [Serializable()]
    [XmlInclude(typeof(CompositeArmor))]
    [XmlInclude(typeof(DynamicArmor))]
    public abstract class Armor: IComponent
    {
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

        public abstract void Contact(float damage);

        public abstract void Create();

        public abstract void Destroy();

        public abstract void Reset();

        public abstract void Status();

        public abstract float GetHealth();


    }
}
