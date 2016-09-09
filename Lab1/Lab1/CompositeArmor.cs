using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class CompositeArmor: Armor
    {
        public CompositeArmor()
        {
            Create();
        }

        public override void Create()
        {
            strength = 400;
        }

        public override void Contact(float damage)
        {
            strength -= damage;
            if (strength != 0)
            {
                Console.WriteLine("Попадание в композитную броню. Осталось брони: " + strength.ToString());
            }
            else
            {
                Destroy();
            }
        }

        public override void Destroy()
        {
            Console.WriteLine("Композитная броня пробита");
        }
    }
}
