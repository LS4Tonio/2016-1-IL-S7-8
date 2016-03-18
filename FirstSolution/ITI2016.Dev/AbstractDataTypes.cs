using System;

namespace ITI2016.Dev
{
    public interface IEnumerator<T>
    {
        T Current { get; }

        Boolean MoveNext();
    }

    public interface IEnumeratorJava<T>
    {
        Boolean HasNext();
        T GetNext();
    }

    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }

    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        Int32 Count { get; }
    }

    public interface IReadOnlyList<T> : IReadOnlyCollection<T>
    {
        T this[Int32 index] { get; }
    }

    public interface IList<T> : IReadOnlyList<T>
    {
        new T this[Int32 index] { get; set; }

        void Add(T item);
        void InsertAt(Int32 index, T item);
        void RemoveAt(Int32 index);
        void Clear();
    }

    public interface ISet<T> : IReadOnlyCollection<T>
    {
        void Add(T item);
        void Contains(T item);
        void Remove(T item);
    }
}