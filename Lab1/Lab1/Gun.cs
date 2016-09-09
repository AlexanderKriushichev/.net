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

        public abstract void Shot();

        public abstract void Recharge();

        public abstract void Aiming();

        public abstract void Destroy();
    }

    
}
