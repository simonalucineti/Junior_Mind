using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class List : IList, IEnumerable
    {
        public int[] input = new int[6];
        public int count=0;

        public int this[int index]
        {
            get
            {
                return input[index];
            }

            set
            {
                input[index]=(int)value;
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

        public void Add(int value)
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

        public bool Contains(int value)
        {
            bool find = false;
            for(int i=0; i<input.Length; i++)
            {
                if (input[i]== value)
                {
                    find = true;
                    break;
                }
            }
            return find;
        }

        public void CopyTo(int[] array, int index)
        {
            int k = index;
            for(int i = 0; i<count; i++)
            {
                array[k] = input[i];
                k++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return input[i]; ;
        }

        public int IndexOf(int value)
        {
            for(int i=0; i< count; i++)
            {
                if (input[i] == value)
                    return i;
            }
            return -1;
        }

        public void Insert(int index, int value)
        {
            ResizeArray();
            for (int i = input.Length-1; i > index; i--)
            {
                input[i] = input[i - 1];
            }
            count++;
            input[index] = value;
        }

        public void Remove(int value)
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

    }
}
