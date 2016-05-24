using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T>: IEnumerable<T>
    {
        Node guard;
        private int count;

        public LinkedList()
        {
            this.guard = new Node(default(T));
            guard.Next = guard;
            guard.Previous =guard;
            this.count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get { return this.count == 0; }

        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Clear()
        {
            count = 0;
            guard.Next = guard;
            guard.Previous = guard;
        }
        public void Add(T item)
        {
            this.AddLast(item);
        }

        public void AddFirst(T item)
        {
            var newNode = new Node (item)
            { Next = guard.Next,
              Previous = guard
            };
            guard.Next.Previous = newNode;
            guard.Next = newNode;
            count++;

        }
        public void AddLast(T item)
        {
            var newNode = new Node(item)
            { Next = guard,
              Previous = guard.Previous
            };
            guard.Previous.Next = newNode;
            guard.Previous = newNode;
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node i = guard.Next; i != guard; i = i.Next)
            {
                yield return (T)i.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
                           
        public void Remove(int index)
        {
            Node current = guard;
            for (int i = 0; i < index; i++)
            current = current.Next;
            current.Next = current.Next.Next;
            current.Next.Previous = current;
            count--;

        }
    }
    
}
