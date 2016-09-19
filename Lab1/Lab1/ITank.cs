using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface ITank<T>
        where T:IComponent
    {
        void SetComponent(T component);
        void GetStatus();
    }
}
