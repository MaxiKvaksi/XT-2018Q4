using System;


namespace Epam.Task3.Employee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates the class 'Employee' using.");
            Employee developer = new Employee(secondName: "Dadonov", name: "Maksim", partonymic: "Yrievich", 
                dateOfBirth: new DateTime(1998, 4, 30), position: Position.Developer, workExperience: 5);
            Console.WriteLine(developer + Environment.NewLine);
            Employee projectManager = new Employee(secondName: "Mask", name: "Elon", partonymic: "Reeve",
                dateOfBirth: new DateTime(1971, 6, 27), position: Position.ProjectManager, workExperience: 30);
            Console.WriteLine(projectManager);
        }
    }
}
