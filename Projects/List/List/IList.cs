using System;
using System.Collections;

namespace List
{
    public interface IList
    {
        int this[int index] { get; set; }

        int Count { get; }
        bool IsReadOnly { get; }
        void Add(int value);
        void Clear();
        bool Contains(int value);
        void CopyTo(int[] array, int index);
        IEnumerator GetEnumerator();
        int IndexOf(int value);
        void Insert(int index, int value);
        void Remove(int value);
        void RemoveAt(int index);
       
    }
}