using System.Collections;
using System.Collections.Generic;
using Epam.Task4.DynamicArray;

namespace Epam.Task4.DynamicArrayHardcoreMode
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerator
    {
        public CycledDynamicArray() : base()
        {
        }

        public CycledDynamicArray(int capacity) : base(capacity)
        {
        }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        {
        }

        public object Current => this.array[this.currentIndexPosition];

        public bool MoveNext()
        {
            this.currentIndexPosition++;
            if (this.currentIndexPosition >= this.Length)
            {
                this.currentIndexPosition = 0;
            }

            return true;
        }

        public void Reset()
        { 
        }
    }
}
