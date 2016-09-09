using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DynamicArmor: Armor
    {

        public DynamicArmor()
        {
            Create();
        }

        public override void Create()
        {
            strength = 500;
        }

        public override void Contact(float damage)
        {
            strength -= damage;
            if (strength != 0)
            {
                Console.WriteLine("Попадание в динамическую броню. Осталось брони: " + strength.ToString());
            }
            else
            {
                Destroy();
            }
        }

        public override void Destroy()
        {
            Console.WriteLine("Динамическая броня пробита");
        }
    }
}
