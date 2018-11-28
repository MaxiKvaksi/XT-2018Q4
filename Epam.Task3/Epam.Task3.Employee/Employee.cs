using System;
using Epam.Task3.User;

namespace Epam.Task3.Employee
{
    public class Employee : User.User
    {
        private Position position;
        private int workExperience;

        public Employee(string secondName, string name, string partonymic, DateTime dateOfBirth, Position position, byte workExperience) 
            : base(secondName: secondName, name: name, partonymic: partonymic, dateOfBirth: dateOfBirth)
        {
            this.Position = position;
            this.WorkExperience = workExperience;
        }

        public Position Position { get => this.position; set => this.position = value; }

        public int WorkExperience
        {
            get => this.workExperience;

            set
            {
                if (value >= 0)
                {
                    this.workExperience = value;
                }
                else
                {
                    throw new Exception("Invalid 'experience' value!");
                }
            }
        }

        public override string ToString()
        {
            return $"Employee:{Environment.NewLine}" +
                $"Second name: {this.SecondName}{Environment.NewLine}" +
                $"Name: {this.Name} {Environment.NewLine}" +
                $"Patronymic: {this.Partonymic}{Environment.NewLine}" +
                $"Date of birth: {this.DateOfBirth.ToString("yyyy.MM.dd")}{Environment.NewLine}" +
                $"Age: {this.Age}{Environment.NewLine}" +
                $"Position: {this.Position}{Environment.NewLine}" +
                $"Work experience: {this.workExperience} years.";
        }
    }
}
