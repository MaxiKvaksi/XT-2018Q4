using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task7.Entities
{
    public class User
    {
        private int id;
        private string name;
        private DateTime dateOfBirth;

        public int Id { get => this.id; set => this.id = value; }

        public string Name
        {
            get => this.name;
            set
            {
                if (!Regex.IsMatch(value, Constants.USERNAME_REGEX))
                {
                    throw new ArgumentException("Invalid username");
                }

                this.name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set
            {
                if (value.Year <= DateTime.Now.Year
                    && DateTime.Now.Year - value.Year <= Constants.MAX_AGE)
                {
                    this.dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentException("Invalid date of birth");
                }
            }
        }

        public int Age { get => DateTime.Now.Year - this.dateOfBirth.Year; }

        public override string ToString()
        {
            return $"{id}: Name: {name} Date of birth: {dateOfBirth.ToShortDateString()} Age: {this.Age}";
        }
    }
}
