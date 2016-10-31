using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    [Serializable()]

    public class CompositeArmor: Armor
    {
        public CompositeArmor()
        {
            Create();
        }

        public override float GetHealth()
        {
            throw new NotImplementedException();
        }

        public override void Create()
        {
            health = 400;
        }

        public override void Reset()
        {
            health = 400;
        }

        public override void Contact(float damage)
        {
            health -= damage;
            if (health != 0)
            {
                Console.WriteLine("Попадание в композитную броню. Осталось брони: " + health.ToString());
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

        public override void Status()
        {
            Console.WriteLine("Композитная броня :");
            Console.WriteLine("Состояие " + health);
        }
    }
}
