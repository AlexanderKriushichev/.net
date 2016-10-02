using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            RussianFactory russianFactory = new RussianFactory();

            TankBattalion<Tank> tankBattalion = new TankBattalion<Tank>(sort);

            

            Tank tank = new Tank(russianFactory, TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine);
            Tank tank1 = (Tank)tank.Clone();

            //tank.Move();
            //tank.Shot(tank1);
            tank.Shot(tank1, tank1.Move);

            //tank.Aimp(tank1.armor.GetHealth);

            tankBattalion.Add(tank);
            tankBattalion.Add(tank1);
            tankBattalion.Add((Tank)tank.Clone());
            tank.gun.Destroy();

            foreach (Tank t in tankBattalion)
            {
                t.GetStatus();

            }

            tankBattalion.newSort();

            foreach (Tank t in tankBattalion)
            {
                t.GetStatus();

            }

            Console.ReadLine();
        }



        public static List<Tank> sort(List<Tank> massive)
        {
            if (massive.Count == 1)
                return massive;
            int mid_point = massive.Count / 2;
            return merge(sort(massive.Take(mid_point).ToList()), sort(massive.Skip(mid_point).ToList()));
        }
        public static List<Tank> merge(List<Tank> mass1, List<Tank> mass2)
        {
            Console.WriteLine("123");
            int a = 0, b = 0;
            Tank[] merged = new Tank[mass1.Count + mass2.Count];
            for (int i = 0; i < mass1.Count + mass2.Count; i++)
            {
                if (b < mass2.Count && a < mass1.Count)
                    if (mass1[a].armor.health > mass2[b].armor.health && b < mass2.Count)
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Count)
                        merged[i] = mass2[b++];
                    else
                        merged[i]= mass1[a++];
            }
            return merged.ToList();
        }
    }
}
