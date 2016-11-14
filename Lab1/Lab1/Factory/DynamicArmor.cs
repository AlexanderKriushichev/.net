using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
namespace Lab1
{
    [Serializable]
    [DataContract]
    public class DynamicArmor: Armor
    {

        public DynamicArmor()
        {
            Create();
        }

        public override float GetHealth()
        {
            throw new NotImplementedException();
        }

        public override void Create()
        {
            health = 500;
        }

        public override void Reset()
        {
            health = 500;
        }

        public override void Contact(float damage)
        {
            health -= damage;
            if (health != 0)
            {
                Console.WriteLine("Попадание в динамическую броню. Осталось брони: " + health.ToString());
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

        public override void Status()
        {
            Console.WriteLine("Динамическая броня :");
            Console.WriteLine("Состояие " + health);
        }
    }
}
