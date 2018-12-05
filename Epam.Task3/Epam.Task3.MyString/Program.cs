using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates the class 'MyString' using." + Environment.NewLine);
            MyString myString = new MyString(new char[] { 'a', 'b', 'c' });
            MyString anotherMyString = new MyString('d', 'e', 'f');
            Console.WriteLine("First string: " + myString);
            Console.WriteLine("Second string: " + anotherMyString);
            Console.WriteLine("Using '+' operation for first string and second string: " + myString + anotherMyString);
            Console.WriteLine("Using 'Concat' function for first string and second string: " + myString.Concat(anotherMyString));
            anotherMyString = myString;
            Console.WriteLine("Second string: " + anotherMyString);
            Console.WriteLine("Using '==' operation for first string and second string: " + (myString == anotherMyString));
            Console.WriteLine("Using 'GetHashCode' function for first string: " + myString.GetHashCode());
            Console.WriteLine("Using 'IndexOf' function for first string with 'b' character: " + myString.IndexOf('b'));
            Console.WriteLine("Using 'ToCharArray' function for first string: " + myString.ToCharArray());
            Console.WriteLine("Using 'ToStringBuilder' function for first string: " + myString.ToStringBuilder());
        }
    }
}
