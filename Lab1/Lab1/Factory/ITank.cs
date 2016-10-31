using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface ITank<T> where T : IComponent
    {
        event Action<TankEventArgs> OnShot;
        event Action<TankEventArgs> OnMove;
        event Action<TankEventArgs> OnDestroy;

        string name { get; set; }


        //Armor armor { get; set; }
        //Engine engine { get; set; }
        //Gun gun { get; set; }

        void SetComponent(T component);
        void GetStatus();
        List<T> ReturnObject();
    }
}
