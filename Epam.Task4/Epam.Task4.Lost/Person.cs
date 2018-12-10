using System;

namespace Epam.Task4.Lost
{
    public class Person
    {
       private int index;

        public Person(int index)
        {
            this.index = index;
        }

        public int Index
        {
            get => this.index;
            set
            {
                if (value > 0)
                {
                    this.index = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public override string ToString()
        {
            return $"Person {this.index}";
        }
    }
}