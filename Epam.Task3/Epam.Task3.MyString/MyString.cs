using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString
{
    public class MyString
    {
        private char[] characters;

        public MyString()
        {
            this.characters = new char[0];
        }

        public MyString(params char[] characters)
        {
            this.characters = characters;
        }

        public int Length
        {
            get => this.characters.Length;
        }

        public char this[int index]
        {
            get
            {
                return this.characters[index];
            }

            set
            {
                this.characters[index] = value;
            }
        }

        public static bool operator ==(MyString firstMyString, MyString secondMyString)
        {
            return firstMyString.Equals(secondMyString);
        }

        public static bool operator !=(MyString firstMyString, MyString secondMyString)
        {
            return !firstMyString.Equals(secondMyString);
        }

        public static MyString operator +(MyString firstMyString, MyString secondMyString)
        {
            char[] characters = new char[firstMyString.Length + secondMyString.Length];
            for (int i = 0; i < firstMyString.characters.Length; i++)
            {
                characters[i] = firstMyString[i];
            }

            for (int i = firstMyString.Length, j = 0; j < secondMyString.Length; i++, j++)
            {
                characters[i] = secondMyString[j];
            }

            return new MyString(characters: characters);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return new string(this.characters);
        }

        public MyString Concat(MyString myString)
        {
            char[] characters = new char[this.Length + myString.Length];
            for (int i = 0; i < this.characters.Length; i++)
            {
                characters[i] = this[i];
            }

            for (int i = this.Length, j = 0; j < myString.Length; i++, j++)
            {
                characters[i] = myString[j];
            }

            return new MyString(characters: characters);
        }

        public char[] ToCharArray()
        {
            return this.characters;
        }

        public int IndexOf(char character)
        {
            int index = -1;
            for (int i = 0; i < this.characters.Length; i++)
            {
                if (character.Equals(this.characters[i]))
                {
                    return i;
                }
            }

            return index;
        }
    }
}
