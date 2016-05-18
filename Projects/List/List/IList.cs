using System;
using System.Collections;

namespace List
{
    public interface IList<T>
    {
        T this[int index] { get; set; }
        int Count { get; }
        bool IsReadOnly { get; }
        void Add(T value);
        void Clear();
        bool Contains (T value);
        void CopyTo(T[] array, int index);
        IEnumerator GetEnumerator();
        int IndexOf(T value);
        void Insert(int index, T value);
        void Remove(T value);
        void RemoveAt(int index);
       
    }
}