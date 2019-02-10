using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.DAL
{
    public class UserDBDao : IUserDao
    {
        private string _connectionString;

        public UserDBDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parName = new SqlParameter("@name", user.Name);
                command.Parameters.Add(parName);
                SqlParameter parDOB = new SqlParameter("@date_of_birth", user.DateOfBirth);
                command.Parameters.Add(parDOB);
                SqlParameter parIdImage = new SqlParameter("@id_image", user.ImageId);
                command.Parameters.Add(parIdImage);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@id", id);
                command.Parameters.Add(par);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllUsers";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(
                        new User
                        {
                            Id = (int)reader["id"],
                            Name = (string)reader["name"],
                            DateOfBirth = (DateTime)reader["date_of_birth"],
                            ImageId = (int)reader["id_image"],
                        });
                }
            }
            return users;
        }

        public User GetById(int id)
        {
            return (User)GetAll().Where(k => k.Id == id).ToList()[0];
        }

        public void Update(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UpdateUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parId = new SqlParameter("@id", user.Id);
                command.Parameters.Add(parId);
                SqlParameter parName = new SqlParameter("@name", user.Name);
                command.Parameters.Add(parName);
                SqlParameter parDOB = new SqlParameter("@date_of_birth", user.DateOfBirth);
                command.Parameters.Add(parDOB);
                SqlParameter parIdImage = new SqlParameter("@id_image", user.ImageId);
                command.Parameters.Add(parIdImage);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
