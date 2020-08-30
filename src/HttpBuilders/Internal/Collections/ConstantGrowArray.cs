using System;
using System.Collections;
using System.Collections.Generic;

namespace Genbox.HttpBuilders.Internal.Collections
{
    /// <summary>An array that is lazy initialized with a configurable absolute growth factor. It also keeps track if it is sorted, and early exit if it is</summary>
    /// <typeparam name="T"></typeparam>
    internal class ConstantGrowArray<T> : IEnumerable<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly int _growBy;
        private T[]? _array;

        public ConstantGrowArray(int growBy, IComparer<T>? comparer = null)
        {
            _growBy = growBy;
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public int Count { get; private set; }
        internal bool Sorted { get; private set; }

        public ref T this[int index] => ref _array![index];

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (_array == null)
                _array = new T[_growBy];
            else if (_array.Length < Count + 1)
                Array.Resize(ref _array, Count + _growBy);

            if (Count > 0 && _comparer.Compare(item, _array[Count - 1]) < 0)
                Sorted = false;

            _array[Count++] = item;
        }

        public void Sort()
        {
            if (Sorted)
                return;

            Array.Sort(_array, _comparer);
            Sorted = true;
        }

        public void Clear()
        {
            if (_array != null)
                Array.Clear(_array, 0, _array.Length);

            Count = 0;
            Sorted = false;
        }

        private struct Enumerator : IEnumerator<T>
        {
            private readonly ConstantGrowArray<T> _list;
            private int _index;

            internal Enumerator(ConstantGrowArray<T> list)
            {
                _list = list;
                _index = 0;
                Current = default!;
            }

            public void Dispose()
            {
                //Nothing to dispose in this enumerator
            }

            public bool MoveNext()
            {
                ConstantGrowArray<T> localList = _list;

                if (_index < localList.Count)
                {
                    Current = localList._array![_index];
                    _index++;
                    return true;
                }

                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                _index = _list.Count + 1;
                Current = default!;
                return false;
            }

            public T Current { get; private set; }

            object IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || _index == _list.Count + 1)
                        throw new InvalidOperationException();

                    return Current!;
                }
            }

            void IEnumerator.Reset()
            {
                _index = 0;
                Current = default!;
            }
        }
    }
}