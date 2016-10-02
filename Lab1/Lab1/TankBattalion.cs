using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class TankBattalion<T> : ICollection<T> where T : Tank
    {

        public delegate List<T> Del(List<T> newList);

        public Del del;

        public TankBattalion(Del newDel)
        {
            del = newDel;
        }

        private List<T> tanks = new List<T>();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return  TankEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return  TankEnumerator();
        }

        public void Sort()
        {
            T obmTank;
            for (int i = 0; i < tanks.Count-1; i++)
            {
                if (tanks[i].armor.health < tanks[i + 1].armor.health)
                {
                    obmTank = tanks[i];
                    tanks[i] = tanks[i + 1];
                    tanks[i + 1] = obmTank;
                }
            }
        }

        public void newSort()
        {
            tanks = del(tanks);
        }

        public T Comparison(TypeOfComparison typeOfComparison, T firstTank, T secondTank)
        {
            switch (typeOfComparison)
            {
                case TypeOfComparison.Armor:
                    {
                        if (firstTank.armor.health > secondTank.armor.health)
                        {
                            return firstTank;
                        }
                        else
                        {
                            return secondTank;
                        }
                    }
                case TypeOfComparison.Engine :
                        {
                            if (firstTank.engine.health > secondTank.engine.health)
                            {
                                return firstTank;
                            }
                            else
                            {
                                return secondTank;
                            }
                        }
                case TypeOfComparison.Gun:
                        {
                            if (firstTank.gun.health > secondTank.gun.health)
                            {
                                return firstTank;
                            }
                            else
                            {
                                return secondTank;
                            }
                        }
                default:
                        {
                            return firstTank;
                        }
            }
        }

        public bool Contains(T item)
        {
            bool found = false;

            foreach (T t in tanks)
            {
                if (t.Equals(item))
                {
                    found = true;
                }
            }

            return found;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {

            tanks.Add(item);
        }

        public void Clear()
        {
            tanks.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < tanks.Count; i++)
            {
                array[i + arrayIndex] = tanks[i];
            }
        }

        public int Count
        {
            get
            {
                return tanks.Count;
            }
        }
        public bool Remove(T item)
        {
            bool result = false;


            for (int i = 0; i < tanks.Count; i++)
            {

                T curTanks = (T)tanks[i];

                if (curTanks.gun == item.gun && curTanks.armor == item.armor&& curTanks.engine == item.engine)
                {
                    tanks.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }

        public T this[int index]
        {
            get { return (T)tanks[index]; }
            set { tanks[index] = value; }
        }

        public IEnumerator<T> TankEnumerator()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                yield return tanks[i];
                if (i == tanks.Count)
                {
                    i = 0;
                }
            }
        }
    }
}

public enum TypeOfComparison { Armor, Gun, Engine}