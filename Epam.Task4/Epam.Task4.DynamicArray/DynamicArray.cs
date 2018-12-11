using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, IEnumerator, IEnumerator<T>
    {
        private T[] array;
        private int length;
        private int capacity;
        private int currentIndexPosition = -1;

        public DynamicArray()
        {
            this.array = new T[8];
            this.length = 0;
            this.capacity = this.array.Length;
        }

        public DynamicArray(int capacity) : this()
        {
            this.array = new T[capacity];
            this.length = 0;
            this.capacity = this.array.Length;
        }

        public DynamicArray(IEnumerable<T> collection) : this()
        {
            this.length = collection.Count();
            this.CalculateCapacity(this.Length);
            collection.ToArray().CopyTo(this.array, 0);
        }

        public int Length
        {
            get => this.length;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The length is less 0");
                }

                this.length = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The capacity is less 0");
                }

                this.capacity = value;
                T[] newArray = new T[this.capacity];
                this.array.CopyTo(newArray, 0);
                this.array = newArray;
            }
        }

        public override string ToString()
        {
            return $"Dynamic array: {string.Join(", ", this)} Length: {this.Length} Capacity: {this.Capacity}";
        }

        object IEnumerator.Current => this.array[this.currentIndexPosition];

        T IEnumerator<T>.Current => this.array[this.currentIndexPosition];

        public T this[int index]
        {
            get => this.array[index];
            set
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                this.array[index] = value;
            }
        }

        public void Add(T item)
        {
            this.Length++;
            this.CalculateCapacity(this.Length);
            this.array[this.Length - 1] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int initialLength = this.Length;
            this.Length += collection.Count();
            this.CalculateCapacity(this.Length);
            var newArray = collection.ToArray();

            for (int i = initialLength, j = 0; i < this.Length; i++, j++)
            {
                this.array[i] = newArray[j];
            }
        }

        public bool Insert(int index, T item)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            this.Length++;
            this.CalculateCapacity(this.Length);
            this.MoveRigthElements(index);
            this[index] = item;
            return true;
        }

        public bool Remove(int index)
        {
            if (index < 0 || index > this.Length)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            this.MoveLeftElements(index);
            this[this.Length - 1] = default(T);
            this.Length--;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return this.array.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)this.array).GetEnumerator();
        }

        void IDisposable.Dispose()
        {
        }

        bool IEnumerator.MoveNext()
        {
            this.currentIndexPosition++;
            if (this.currentIndexPosition >= this.Length)
            {
                this.currentIndexPosition = -1;
                return false;
            }
            else
            {
                return true;
            }
        }

        void IEnumerator.Reset()
        {
            this.currentIndexPosition = -1;
        }

        protected void CalculateCapacity(int length)
        {
            if (this.Capacity > length)
            {
                return;
            }

            if (length == 0)
            {
                this.Capacity = 8;
            }
            else
            {
                this.Capacity *= (int)Math.Pow(2, ((length - this.Capacity) / this.Capacity) + 1);
            }
        }

        private void MoveLeftElements(int startIndex)
        {
            for (int i = startIndex + 1; i < this.Length; i++)
            {
                this[i - 1] = this[i];
            }
        }

        private void MoveRigthElements(int startIndex)
        {
            for (int i = this.Length - 2; i >= startIndex; i--)
            {
                this[i + 1] = this[i];
            }
        }
    }
}
