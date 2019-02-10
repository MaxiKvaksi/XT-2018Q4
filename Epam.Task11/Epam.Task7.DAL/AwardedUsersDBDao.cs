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
    public class AwardedUsersDBDao : IAwardedUsersDao
    {
        private string _connectionString;
        private List<AwardedUser> awardedUsers = new List<AwardedUser>();

        public AwardedUsersDBDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            awardedUsers = (List<AwardedUser>)GetAll();
    }

        public void Add(AwardedUser awardedUser)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddAwardedUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parName = new SqlParameter("@id_user", awardedUser.IdUser);
                command.Parameters.Add(parName);
                SqlParameter parDOB = new SqlParameter("@id_award", awardedUser.IdAward);
                command.Parameters.Add(parDOB);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Add(int user, int award)
        {
            AwardedUser awardedUser = new AwardedUser(user, award);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddAwardedUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parName = new SqlParameter("@id_user", awardedUser.IdUser);
                command.Parameters.Add(parName);
                SqlParameter parDOB = new SqlParameter("@id_award", awardedUser.IdAward);
                command.Parameters.Add(parDOB);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int userId, int awardId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteAwardedUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parAw = new SqlParameter("@idAward", awardId);
                command.Parameters.Add(parAw);
                SqlParameter parUs = new SqlParameter("@idUser", userId);
                command.Parameters.Add(parUs);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteByIdAward(int idAward)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteAwardedUserByIdAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@idAward", idAward);
                command.Parameters.Add(par);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<AwardedUser> GetAll()
        {
            List<AwardedUser> awardedUsers = new List<AwardedUser>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllAwardedUsers";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    awardedUsers.Add(
                        new AwardedUser
                        {
                            IdUser = (int)reader["idUser"],
                            IdAward = (int)reader["idAward"],
                        });
                }
            }
            return awardedUsers;
        }

        public IEnumerable<AwardedUser> GetByAwardId(int id)
        {
            awardedUsers = (List<AwardedUser>)GetAll();
            return this.awardedUsers.Where(x => x.IdAward == id);
        }

        public IEnumerable<AwardedUser> GetByUserId(int id)
        {
            awardedUsers = (List<AwardedUser>)GetAll();
            return this.awardedUsers.Where(x => x.IdUser == id);
        }
    }
}
