using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Entities
{
    public class Constants
    {
        public const string USERNAME_REGEX = "^[a-zA-Z0-9А-Яа-я]{1,}$";
        public const string AWARD_TITLE_REGEX = "^[a-zA-Z0-9А-Яа-я ]{3,50}$";
        public const int MAX_AGE = 150;
        public const string USERS_DATA_PATH = @"users_data.txt";
        public const string AWARDS_DATA_PATH = @"awards_data.txt";
        public const string USERS_AND_AWARDS_DEPENDENCIES_DATA_PATH = @"users_and_awards_dependencies_data.txt";
        public const char FILE_DATA_DELIMITIER = ';';
    }
}
