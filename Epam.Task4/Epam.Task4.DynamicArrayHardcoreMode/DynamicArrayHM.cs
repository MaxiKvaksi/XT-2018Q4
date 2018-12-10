using System;
using System.Collections.Generic;
using Epam.Task4.DynamicArray;

namespace Epam.Task4.DynamicArrayHardcoreMode
{
    public class DynamicArrayHM<T> : DynamicArray.DynamicArray<T>, ICloneable
    {
        public DynamicArrayHM() : base()
        {
        }

        public DynamicArrayHM(int capacity) : base(capacity)
        {
        }

        public DynamicArrayHM(IEnumerable<T> collection) : base(collection)
        {
        }

        public new int Capacity
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
                if (this.array.Length > newArray.Length)
                {
                    for (int i = 0; i < newArray.Length; i++)
                    {
                        newArray[i] = this.array[i];
                    }
                }
                else
                {
                    this.array.CopyTo(newArray, 0);
                    this.Length = this.array.Length;
                }

                this.array = newArray;
            }
        }

        public new T this[int index]
        {
            get
            {
                if (Math.Abs(index) >= this.Length)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                if (index < 0)
                {
                    return this.array[this.Length + index];
                }
                else
                {
                    return this.array[index];
                }
            }

            set
            {
                if (Math.Abs(index) >= this.Length)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                if (index < 0)
                {
                    this.array[this.Length + index] = value;
                }
                else
                {
                    this.array[index] = value;
                }
            }
        }

        public void SetCapacity(int value)
        {
            this.Length = value;
            this.Capacity = value;
        }

        object ICloneable.Clone()
        {
            return new Exception("Is deprecated!");
        }

        public T[] ToArray()
        {
            return this.array;
        }
    }
}
