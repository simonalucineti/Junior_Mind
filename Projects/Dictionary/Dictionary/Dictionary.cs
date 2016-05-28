using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue> {
        private struct Entry
        {
            public TKey key;
            public TValue value;
            public int next;
         
        }
            private int count = 0;
            private int[] buckets;
            private Entry[] items;
            private int freeIndex;
        
        public Dictionary()
        {
            buckets = new int[6];
            items = new Entry[6];
            count = 0;
            freeIndex = 0;

        }

        private int GetHash (TKey key)
        {
            return key.GetHashCode() % buckets.Length;
        }

        public TValue this[TKey key]
        {
            get
            {
                int k = FindEntry(key);
                return items[k].value;
            }
            set {
               throw new NotImplementedException();
            }
           
        }

        public int Count
        {
            get
            {
                return count-freeIndex;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            int k = GetHash(key);
            if (freeIndex > 0)
            {
                items[freeIndex].key = key;
                items[freeIndex].value = value;
                buckets[k] = freeIndex;
                freeIndex = items[freeIndex].next;
             }
            else
            {

                items[count].key = key;
                items[count].value = value;
                if (buckets[k] != -1)
                    items[count].next = buckets[k];
                buckets[k] = count;
                count++;
            }

        }

        public void Clear()
        {
            if (count > 0)
            {
                for (int i = 0; i < buckets.Length; i++)
                {
                    buckets[i] = -1;
                }
                Array.Clear(items, 0, count);
                count = 0;
                freeIndex = 0;
            }
        }

        private int FindEntry(TKey key)
        {
            int k = GetHash(key);
            if (buckets != null)
            {
                for (int i = buckets[k]; i >= 0; i = items[i].next)
                {
                    if (items[i].key.Equals(key)) return i;
                }
            }
            return -1;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
           return FindEntry(key) >= 0;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            int k = GetHash(key);
            if (ContainsKey(key))
            {
                int i = buckets[k];
                while (i >= 0)
                {
                    freeIndex = i;
                    items[i].key = default (TKey);
                    items[i].value = default(TValue);
                    i = items[i].next;
                    count--;
                }
                buckets[k] = 0;
                return true; 
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int k = GetHash(key);
            if (k >= 0)
            {
                value = items[k].value;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var i = items[count]; count != 0; i = items[--count])
                {
                    yield return i.value;
                }
            
        }
       
    }

}
