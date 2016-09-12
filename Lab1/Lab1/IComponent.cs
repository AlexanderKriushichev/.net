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
}
