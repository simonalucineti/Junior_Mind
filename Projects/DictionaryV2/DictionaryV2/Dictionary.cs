using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryV2
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private struct Entry
        {
            public TKey key;
            public TValue value;
            public int next;
        }

        private int[] buckets;
        private Entry[] items;
        private int count;
        private int freeIndex;
        private int freeCount;

        public Dictionary()
        {
            buckets = new int[10];
            items = new Entry[10];
            count = 0;
            freeIndex = -1;
            freeCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                buckets[i] = -1;
                items[i].next = -1;
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

        public int Count
        {
            get
            {
                return count - freeCount;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                int i = GetEntry(key);
                return items[i].value;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % buckets.Length;
        }

        public int GetEntry(TKey key)
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

        public bool ContainsKey(TKey key)
        {
            return GetEntry(key) >= 0;
        }

        public void Add(TKey key, TValue value)
        {
            int k = GetHash(key);
            int index;
            if (freeCount > 0)
            {
                index = freeIndex;
                freeIndex = items[index].next;
                freeCount--;
                items[index].key = key;
                items[index].value = value;
                buckets[k] = index;

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

        public bool Remove(TKey key)
        {
            if (buckets != null)
            {
                int k = GetHash(key);
               for (int i = buckets[k]; i >= 0; i = items[i].next)
                {
                   if (ContainsKey(key))
                    {
                       
                        items[i].key = default(TKey);
                        items[i].value = default(TValue);
                        items[i].next = freeIndex;
                        freeIndex = i;
                        freeCount++;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int i = GetEntry(key);
            if (i >= 0)
            {
                value = items[i].value;
                return true;
            }
            value = default(TValue);
            return false;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
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
                freeIndex = -1;
                count = 0;
                freeCount = 0;
            }
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
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