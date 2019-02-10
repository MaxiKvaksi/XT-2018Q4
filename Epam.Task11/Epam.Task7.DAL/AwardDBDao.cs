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
    public class AwardDBDao : IAwardDao
    {
        private string _connectionString;

        public AwardDBDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(Award award)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parName = new SqlParameter("@title", award.Title);
                command.Parameters.Add(parName);
                SqlParameter parIdImage = new SqlParameter("@id_image", award.IdImage);
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
                command.CommandText = "DeleteAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@id", id);
                command.Parameters.Add(par);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> awards = new List<Award>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllAwards";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    awards.Add(
                        new Award
                        {
                            Id = (int)reader["id"],
                            Title = (string)reader["title"],
                            IdImage = (int)reader["idImage"],
                        });
                }
            }
            return awards;
        }

        public Award GetById(int id)
        {
            return (Award)GetAll().Where(k => k.Id == id);
        }

        public void Update(Award award)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UpdateAward";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parId = new SqlParameter("@id", award.Id);
                command.Parameters.Add(parId);
                SqlParameter parName = new SqlParameter("@title", award.Title);
                command.Parameters.Add(parName);
                SqlParameter parIdImage = new SqlParameter("@id_image", award.IdImage);
                command.Parameters.Add(parIdImage);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
