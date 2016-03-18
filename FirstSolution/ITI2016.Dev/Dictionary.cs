using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI2016.Dev
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public int Count { get; }

        public TValue this[TKey key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IEnumerable<TKey> Keys { get; }
        public IEnumerable<TValue> Values { get; }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(TValue value)
        {
            throw new NotImplementedException();
        }

        public TValue GetValue(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}