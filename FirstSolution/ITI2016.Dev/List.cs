using System;
using System.Diagnostics;

namespace ITI2016.Dev
{
    public class List<T> : IList<T>
    {
        private const int InitialSize = 4;

        private T[] _array;
        private int _count;

        #region PROPERTIES

        /// <summary>
        /// Counts the number of elements in the list.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Gets the elements at the specified index.
        /// </summary>
        /// <param name="index">Index of the element to get.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <returns>The element found.</returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
                _array[index] = value;
            }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Instanciates a new reference of the list.
        /// </summary>
        public List()
        {
            _array = new T[InitialSize];
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Adds an item at the end of the list.
        /// </summary>
        /// <param name="item">Element to add.</param>
        public void Add(T item)
        {
            if(_count == _array.Length)
            {
                var array = new T[_array.Length + 1];
                Array.Copy(_array, array, _array.Length);
                _array = array;
            }
            Debug.Assert(_count < _array.Length, "The count must be lower than the array's length");
            this[_count++] = item;
        }

        /// <summary>
        /// Inserts an element in the list at the given position.
        /// </summary>
        /// <param name="index">Index of the element to insert.</param>
        /// <param name="item">Element to insert.</param>
        public void InsertAt(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clears the values of the list.
        /// </summary>
        public void Clear()
        {
            if (typeof (T).IsValueType)
            {
                for (var i = 0; i < _array.Length; i++) _array[i] = default(T);
            }
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
