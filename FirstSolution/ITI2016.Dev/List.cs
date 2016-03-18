using System;
using System.Diagnostics;

namespace ITI2016.Dev
{
    public class List<T> : IList<T>
    {
        private const int InitialSizeArray = 4;

        private T[] _array;
        private int _count;

        public List()
        {
            _array = new T[InitialSizeArray];
        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= _count) throw new IndexOutOfRangeException();
                return _array[i];
            }
            set
            {
                if (i < 0 || i >= _count) throw new IndexOutOfRangeException();
                _array[i] = value;
            }
        }

        public int Count => _count;

        public void Add(T e)
        {
            EnsureEnoughSpace();
            Debug.Assert(_count < _array.Length);
            _array[_count++] = e;
        }

        public void Clear()
        {
            if (!typeof(T).IsValueType)
            {
                for (var i = 0; i < _count; ++i) _array[i] = default(T);
            }
            _count = 0;
        }

        public void InsertAt(int i, T e)
        {
            if (i < 0 || i > _count) throw new IndexOutOfRangeException();
            EnsureEnoughSpace();
            var lengthToMove = _count++ - i;
            if (lengthToMove > 0) Array.Copy(_array, i, _array, i + 1, lengthToMove);
            _array[i] = e;
        }

        public void RemoveAt(int i)
        {
            if (i < 0 || i >= _count) throw new IndexOutOfRangeException();
            Array.Copy(_array, i + 1, _array, i, --_count - i);
            _array[_count] = default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        private void EnsureEnoughSpace()
        {
            Debug.Assert(_count <= _array.Length, "This is an INVARIANT !!!!!!!");
            if (_count == _array.Length)
            {
                var t = new T[_count + 1];
                for (var i = 0; i < _count; ++i)
                {
                    t[i] = _array[i];
                }
                _array = t;
            }
        }
    }

    public class ListEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> _list;
        private int _currentIndex;

        public T Current
        {
            get
            {
                if (_currentIndex < 0 || _currentIndex >= _list.Count) throw new InvalidOperationException();
                return _list[_currentIndex];
            }
        }

        public ListEnumerator(List<T> list)
        {
            _list = list;
            _currentIndex = -1;
        }

        public bool MoveNext()
        {
            return (_currentIndex > -1 && _currentIndex++ < _list.Count);
        }
    }
}