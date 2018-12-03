using System;
using Epam.Task3.User;

namespace Epam.Task3.Employee
{
    public class Employee : User.MyUserClass
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
                if (value >= 0 && value <= this.Age)
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
            return base.ToString() +
                $"Position: {this.Position}{Environment.NewLine}" +
                $"Work experience: {this.workExperience} years.";
        }
    }
}
