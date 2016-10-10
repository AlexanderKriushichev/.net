using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IComponent
    {
        void Create();

        void Reset();

        void Status();

        void Destroy();
    }

    interface IComponentName<out T> : IComponent
    {
        T ReturnName();
    }

    interface IComponentInfo<in T> : IComponent
    {
        void Info(T obj);
    }
}
