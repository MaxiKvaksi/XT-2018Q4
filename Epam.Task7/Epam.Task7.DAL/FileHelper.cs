using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class FileHelper
    {
        public static Dictionary<int, User> ReadUsersData()
        {
            Dictionary<int, User> users = new Dictionary<int, User>();
            if (!File.Exists(Constants.USERS_DATA_PATH))
            {
                return users;
            }
            
            using (StreamReader sr = new StreamReader(Constants.USERS_DATA_PATH))
            {
                string buffer;
                string[] data;
                while (!sr.EndOfStream)
                {
                    buffer = sr.ReadLine();
                    data = buffer.Split(Constants.FILE_DATA_DELIMITIER);
                    try
                    {
                        int id = int.Parse(data[0]);
                        DateTime dateTime = DateTime.Parse(data[2]);
                        users.Add(
                            id, 
                            new User()
                        {
                            Id = id,
                            Name = data[1],
                            DateOfBirth = dateTime,
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return users;
        }

        public static Dictionary<int, Award> ReadAwardsData()
        {
            Dictionary<int, Award> awards = new Dictionary<int, Award>();
            if (!File.Exists(Constants.AWARDS_DATA_PATH))
            {
                return awards;
            }

            using (StreamReader sr = new StreamReader(Constants.AWARDS_DATA_PATH))
            {
                string buffer;
                string[] data;
                while (!sr.EndOfStream)
                {
                    buffer = sr.ReadLine();
                    data = buffer.Split(Constants.FILE_DATA_DELIMITIER);
                    try
                    {
                        int id = int.Parse(data[0]);
                        awards.Add(
                            id, 
                            new Award()
                        {
                            Id = id,
                            Title = data[1],
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return awards;
        }

        public static List<AwardedUser> ReadAwardedUsersData()
        {
            List<AwardedUser> awards = new List<AwardedUser>();
            if (!File.Exists(Constants.USERS_AND_AWARDS_DEPENDENCIES_DATA_PATH))
            {
                return awards;
            }

            using (StreamReader sr = new StreamReader(Constants.USERS_AND_AWARDS_DEPENDENCIES_DATA_PATH))
            {
                string buffer;
                string[] data;
                while (!sr.EndOfStream)
                {
                    buffer = sr.ReadLine();
                    data = buffer.Split(Constants.FILE_DATA_DELIMITIER);
                    try
                    {
                        int idUser = int.Parse(data[0]);
                        int idAward = int.Parse(data[1]);
                        awards.Add(new AwardedUser()
                        {
                            IdUser = idUser,
                            IdAward = idAward,
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return awards;
        }

        public static void WriteAwardsData(Dictionary<int, Award> awards)
        {
            if (!File.Exists(Constants.AWARDS_DATA_PATH))
            {
                File.Create(Constants.AWARDS_DATA_PATH).Close();
            }

            using (StreamWriter sw = new StreamWriter(Constants.AWARDS_DATA_PATH))
            {
                foreach (var item in awards)
                {
                    sw.WriteLine($"{item.Value.Id}{Constants.FILE_DATA_DELIMITIER}{item.Value.Title}");
                }
            }
        }

        public static void WriteUsersData(Dictionary<int, User> users)
        {
            if (!File.Exists(Constants.USERS_DATA_PATH))
            {
                File.Create(Constants.USERS_DATA_PATH).Close();
            }

            using (StreamWriter sw = new StreamWriter(Constants.USERS_DATA_PATH))
            {
                foreach (var item in users)
                {
                    sw.WriteLine($"{item.Value.Id}{Constants.FILE_DATA_DELIMITIER}{item.Value.Name}{Constants.FILE_DATA_DELIMITIER}{item.Value.DateOfBirth.ToShortDateString()}");
                }
            }
        }

        public static void WriteAwardedUsersData(List<AwardedUser> awardedUsers)
        {
            if (!File.Exists(Constants.USERS_AND_AWARDS_DEPENDENCIES_DATA_PATH))
            {
                File.Create(Constants.USERS_AND_AWARDS_DEPENDENCIES_DATA_PATH).Close();
            }

            using (StreamWriter sw = new StreamWriter(Constants.USERS_AND_AWARDS_DEPENDENCIES_DATA_PATH))
            {
                foreach (var item in awardedUsers)
                {
                    sw.WriteLine($"{item.IdUser}{Constants.FILE_DATA_DELIMITIER}{item.IdAward}");
                }
            }
        }
    }
}
