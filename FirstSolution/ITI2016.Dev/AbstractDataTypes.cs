using System;
using System.Runtime.CompilerServices;

namespace ITI2016.Dev
{
    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }

    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
    }

    public interface IReadOnlyList<T> : IReadOnlyCollection<T>
    {
        T this[int i] { get; }
    }

    public interface IList<T> : IReadOnlyList<T>
    {
        new T this[int i] { get; set; }

        void Add( T e );

        void InsertAt( int i, T e );

        void RemoveAt( int i );

        void Clear();
    }

    public interface ISet<T> : IReadOnlyCollection<T>
    {
        void Add( T e );

        bool Contains( T e );

        void Remove( T e );
    }

    public interface IEnumerator<T>
    {
        bool MoveNext();

        T Current { get; }
    }

    public interface IEnumeratorJava<T>
    {
        bool HasNext();

        T GetNext();
    }

    public interface IDictionary<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>
    {
        TValue this[TKey key] { get; set; }
        IEnumerable<TKey> Keys { get; }
        IEnumerable<TValue> Values { get; }

        Boolean ContainsKey(TKey key);
        Boolean ContainsValue(TValue value);
        TValue GetValue(TKey key);
        void Add(TKey key, TValue value);
        Boolean Remove(TKey key);
    }

    public struct KeyValuePair<TKey, TValue>
    {
        public readonly TKey Key;
        public readonly TValue Value;

        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}