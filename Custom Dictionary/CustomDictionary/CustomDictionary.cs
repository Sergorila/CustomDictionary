using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    class CustomDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private LinkedList<KeyValuePair<TKey, TValue>>[] _hashTable;
        private int _size = 16;

        public int Size
        {
            get { return _size; }
        }

        public int Count { get; set; }

        public bool IsReadOnly
        {
            get { return false; }
        }
        public TValue this[TKey key] 
        {
            get
            {
                int hashcode = GetMyHash(key);

                if (_hashTable[hashcode] == null)
                {
                    throw new Exception("Key not found.");
                }

                if (ContainsKey(key))
                {
                    foreach (var item in _hashTable[hashcode])
                    {
                        if (key.Equals(item.Key))
                        {
                            return item.Value;
                        }
                    }
                    
                }
               
                return default;
            }
            set
            {
                int hashcode = GetMyHash(key);

                if (ContainsKey(key))
                {
                    foreach (var item in _hashTable[hashcode])
                    {
                        if (item.Key.Equals(key))
                        {
                            _hashTable[hashcode].Remove(item);
                            _hashTable[hashcode].AddLast(new KeyValuePair<TKey, TValue>(item.Key, value));
                            break;
                        }
                    }
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys { get; set; }

        public ICollection<TValue> Values { get; set; }

        public CustomDictionary()
        {
            _hashTable = new LinkedList<KeyValuePair<TKey, TValue>>[_size];
            for (int i = 0; i < _hashTable.Length; i++)
            {
                _hashTable[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            Keys = new List<TKey>();
            Values = new List<TValue>();
            Count = 0;
        }

        public CustomDictionary(int size)
        {
            _size = size;
            _hashTable = new LinkedList<KeyValuePair<TKey, TValue>>[_size];
            for (int i = 0; i < _hashTable.Length; i++)
            {
                _hashTable[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            Keys = new List<TKey>();
            Values = new List<TValue>();
            Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            int hashcode = GetMyHash(key);

            if (!ContainsKey(key))
            {
                Count++;
                if (Count >= _size)
                {
                    ResizeCollection();
                }

                _hashTable[hashcode].AddLast(new KeyValuePair<TKey, TValue>(key, value));
                Keys.Add(key);
                Values.Add(value);
            }
            else
            {
                throw new Exception("This key already exist.");
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            int hashcode = GetMyHash(key);

            foreach (var item in _hashTable[hashcode])
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public bool Remove(TKey key)
        {
            int hashcode = GetMyHash(key);

            if (ContainsKey(key))
            {
                foreach (var item in _hashTable[hashcode])
                {
                    if (key.Equals(item.Key))
                    {
                        Keys.Remove(item.Key);
                        Values.Remove(item.Value);
                        _hashTable[hashcode].Remove(item);
                        Count--;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int hashcode = GetMyHash(key);
            value = default;

            if (ContainsKey(key))
            {
                foreach (var item in _hashTable[hashcode])
                {
                    value = item.Value;
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            Keys.Clear();
            Values.Clear();
            Count = 0;
            _size = 16;
            _hashTable = new LinkedList<KeyValuePair<TKey, TValue>>[_size];

            for (int i = 0; i < _hashTable.Length; i++)
            {
                _hashTable[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] arr, int index)
        {
            if (arr == null)
            {
                throw new Exception("Null reference exeption.");
            }

            if (index < 0)
            {
                throw new Exception("Index value is negative.");
            }

            if (arr.Length - index - 1 < Count)
            {
                throw new Exception("Not enough space for copy.");
            }

            List<KeyValuePair<TKey, TValue>> elems = new List<KeyValuePair<TKey, TValue>>();
            foreach (var lst in _hashTable)
            {
                foreach (var item in lst)
                {
                    elems.Add(item);
                }
            }

            for (int i = index; i < arr.Length; i++)
            {
                arr[i] = elems[Math.Abs(index - i)];
            }

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var lst in _hashTable)
            {
                foreach (var item in lst)
                {
                    yield return item;
                }
            }    
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetMyHash(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % _size;
        }

        private void ResizeCollection()
        {
            _size *= 2;
            LinkedList<KeyValuePair<TKey, TValue>>[] hashTableResize = new LinkedList<KeyValuePair<TKey, TValue>>[_size];

            for (int i = 0; i < hashTableResize.Length; i++)
            {
                hashTableResize[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            foreach (var lst in hashTableResize)
            {
                foreach (var item in lst)
                {
                    int hashcode = GetMyHash(item.Key);

                    hashTableResize[hashcode].AddLast(item);
                }
            }

            _hashTable = hashTableResize;
        }
    }
}
