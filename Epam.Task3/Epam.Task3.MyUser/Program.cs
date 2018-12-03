using System;

namespace Epam.Task3.MyUser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"The application demonstrates the class 'MyUser' using.{Environment.NewLine}");

            MyUserClass user = new MyUserClass(secondName: "Dadonov", name: "Maksim", partonymic: "Yrievich", dateOfBirth: new DateTime(year: 1998, month: 4, day: 30));
            Console.WriteLine($"1: {user}{Environment.NewLine}");
            user = new MyUserClass(secondName: "Bezos", name: "Jeffrey", partonymic: "Preston", dateOfBirth: new DateTime(year: 1964, month: 1, day: 12));
            Console.WriteLine($"2: {user}{Environment.NewLine}");
            MyUserClass anotherUser = new MyUserClass();
            Console.WriteLine($"Another user:{Environment.NewLine}3: {anotherUser}{Environment.NewLine}");
            anotherUser.Name = "Alexey";
            anotherUser.SecondName = "Korolev";
            anotherUser.DateOfBirth = new DateTime(2018, 12, 1);
            Console.WriteLine($"Updated another user:{Environment.NewLine}3: {anotherUser}{Environment.NewLine}");
        }
    }
}
