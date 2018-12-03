using System;

namespace Epam.Task3.MyUser
{
    public class MyUserClass
    {
        private string secondName;
        private string name;
        private string partonymic;
        private DateTime dateOfBirth;

        public MyUserClass() 
            : this(secondName: "no secondname", name: "no name", partonymic: "no partonymic", dateOfBirth: DateTime.Now)
        {
        }

        public MyUserClass(string secondName, string name, string partonymic, DateTime dateOfBirth)
        {
            this.SecondName = secondName;
            this.Name = name;
            this.Partonymic = partonymic;
            this.DateOfBirth = dateOfBirth;
        }

        public int Age
        {
            get => DateTime.Now.Year - this.dateOfBirth.Year;
        }

        public string SecondName
        {
            get => this.secondName;
            set
            {
                if (value.Length != 0)
                {
                    this.secondName = value;
                }
                else
                {
                    throw new Exception("Invalid second name!");
                }
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length != 0)
                {
                    this.name = value;
                }
                else
                {
                    throw new Exception("Invalid name!");
                }
            }
        }

        public string Partonymic
        {
            get => this.partonymic;
            set
            {
                if (value.Length != 0)
                {
                    this.partonymic = value;
                }
                else
                {
                    throw new Exception("Invalid partonymic!");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set => this.dateOfBirth = value;
        }

        public override string ToString()
        {
            return $"User:{Environment.NewLine}Second name: {this.SecondName}{Environment.NewLine}" +
                $"Name: {this.Name}{Environment.NewLine}" + $"Patronymic: {this.Partonymic}{Environment.NewLine}" +
                $"Date of birth: {this.DateOfBirth.ToString("yyyy.MM.dd")}{Environment.NewLine}" +
                $"Age: {this.Age}{Environment.NewLine}";
        }
    }
}
