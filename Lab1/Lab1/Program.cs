                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab1.Exceptions;
using Lab1.Logger;
using Lab1.Serialization;
namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            RussianFactory russianFactory = new RussianFactory();

            TankBattalion<Tank> tankBattalion = new TankBattalion<Tank>(1);

            var xmlSer = new XmlSerialization<Tank>();

            xmlSer.Serialize(tankBattalion, "xml1.xml");

            TankBattalion<Tank> tankBattalion1 = xmlSer.Deserialize("xml1.xml");

            foreach (Tank t in tankBattalion)
            {
                t.GetStatus();
            }

            Console.WriteLine("______");

            foreach (Tank t in tankBattalion1)
            {
                t.GetStatus();
            }


            //Tank tank = new Tank(russianFactory, TypeOfArmor.Dynamic, TypeOfGun.Artillery, TypeOfEngine.Gasturbine);
            //Tank tank1 = Tank.CreateFromFile("tank.txt");

            //var consLogger = new ConsoleLogger<ITank<IComponent>>(tank);
            //var fileLogger = new FileLogger<ITank<IComponent>>(tank1, "log1.txt");

            //consLogger.Log += LogOnLog;
            //fileLogger.Log += LogOnLog;

            ////tank.Move();
            ////tank.Shot(tank1);

            //// �� ���������, ��� ��� ��� ����, ���������������� ���������� 
            //try
            //{
            //    tank1.Shot(null);
            //}
            //catch (UserException error)
            //{
            //    ExceptionsLogger.LogUserException(error);
            //}
            //catch (Exception error)
            //{
            //    ExceptionsLogger.LogSystemException(error);
            //}

            //// �� ���������, ������ �������� ���, ��������� ����������
            //try
            //{
            //    tank1.Shot(tankBattalion[0]);
            //}
            //catch (UserException error)
            //{
            //    ExceptionsLogger.LogUserException(error);
            //}
            //catch (Exception error)
            //{
            //    ExceptionsLogger.LogSystemException(error);
            //}
            ////tank.Shot(tank1);
            ////tank1.Move();
            ////tank1.Shot(tank);
            ////tank.Move();
            ////tank.Aimp(tank1.armor.GetHealth);

            //tankBattalion.Add(tank);
            //tankBattalion.Add(tank1);
            //tankBattalion.Add((Tank)tank.Clone());
            //tank.gun.Destroy();


            //Task t = tankBattalion.AsyncSort();
            //t.Wait();

            

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

        /// <summary>
        /// ����� ������ ����
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="tank"></param>
        /// <param name="args"></param>
        public static void LogOnLog(TextWriter writer, ITank<IComponent> tank, TankEventArgs args)
        {
            string message = "";
            switch (args.type)
            {
                case EventType.Move:
                    message = "���� " + tank.name + " ��������";
                    break;
                case EventType.Destroy:
                    message = "���� " + tank.name + " ���������";
                    break;
                case EventType.Shot:
                    message = "���� " + tank.name + " �������� �� " + (args as  TankShotEventArgs).target.name;
                    break;
                
            }
            writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " " + message);
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 