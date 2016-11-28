using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface IComponent
    {
        /// <summary>
        /// Создать
        /// </summary>
        void Create();

        /// <summary>
        /// Обновить
        /// </summary>
        void Reset();

        /// <summary>
        /// Вывести статус
        /// </summary>
        void Status();

        /// <summary>
        /// Уничтожить
        /// </summary>
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
