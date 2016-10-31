using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Тип события
    /// </summary>
    public enum EventType
    {
        Move,
        Shot,
        Destroy
    }

    /// <summary>
    /// Класс события для танка 
    /// </summary>
    public class TankEventArgs
    {
        public EventType type;
        public TankEventArgs(EventType eventType)
        {
            type = eventType;
        }
    }

    /// <summary>
    /// Класс события выстрела
    /// </summary>
    class TankShotEventArgs : TankEventArgs
    {
        public ITank<IComponent> target;
        public TankShotEventArgs(ITank<IComponent> tank)
            : base(EventType.Shot)
        {
            target = tank;
        }
    }
}
