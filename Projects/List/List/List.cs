using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class List<T> : IList<T>, IEnumerable
    {
        public T[] input = new T[6];
        public int count=0;

        public T this [int index]
        {
            get
            {
                return input[index];
            }

            set
            {
                input[index]= value;
            }
        }

        public int Count
        {
            get
            {
               return count ;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false; 
            }
        }

        public void Add(T value)
        {
            ResizeArray();
            input[count++] = value;
        }

        private void ResizeArray()
        {
            if (count == input.Length - 1)
            {
                Array.Resize(ref input, input.Length * 2);
            }
        }

        public void Clear()
        {
          count=-1;
        }

        public bool Contains (T value)
        {
            bool find = false;
            for(int i=0; i<input.Length; i++)
            {
                if (input[i].Equals(value))
                {
                    find = true;
                    break;
                }
            }
            return find;
        }

        public void CopyTo (T[] array, int index)
        {
            int k = index;
            for(int i = 0; i<count; i++)
            {
                array[k] = input[i];
                k++;
            }
        }

        IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return input[i]; ;
        }

        public int IndexOf (T value)
        {
            for(int i=0; i< count; i++)
            {
                if (input[i].Equals(value))
                    return i;
            }
            return -1;
        }

        public void Insert (int index, T value)
        {
            ResizeArray();
            for (int i = input.Length-1; i > index; i--)
            {
                input[i] = input[i - 1];
            }
            count++;
            input[index] = value;
        }

        public void Remove (T value)
        {
            if (Contains(value))
            {
                RemoveAt(IndexOf(value));
            }
            
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < input.Length - 1; i++)
            {
               input[i] = input[i + 1];
            }
           Array.Resize(ref input, input.Length - 1);
        }

          IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IList<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
