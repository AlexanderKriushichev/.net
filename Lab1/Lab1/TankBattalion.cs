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
        private List<T> tanks = new List<T>();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TankEnumerator(this);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new TankEnumerator(this);
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

        public class TankEnumerator : IEnumerator<T>
        {
            private TankBattalion<T> _collection;
            private int curIndex;
            private T curBox;


            public TankEnumerator(TankBattalion<T> collection)
            {
                _collection = collection;
                curIndex = -1;
                curBox = default(T);

            }

            public bool MoveNext()
            {
                if (++curIndex >= _collection.Count)
                {
                    return false;
                }
                else
                {
                    curBox = _collection[curIndex];
                }
                return true;
            }

            public void Reset() { curIndex = -1; }

            void IDisposable.Dispose() { }

            public T Current
            {
                get { return curBox; }
            }


            object IEnumerator.Current
            {
                get { return Current; }
            }

        }
    }
}
