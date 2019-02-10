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
    public class ImageDBDao : IImageDao
    {
        private string _connectionString;

        public ImageDBDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(Image image)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddImage";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parDOB = new SqlParameter("@image_value", image.Value);
                command.Parameters.Add(parDOB);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteImage";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@id", id);
                command.Parameters.Add(par);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Image> GetAll()
        {
            List<Image> images = new List<Image>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllImages";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    images.Add(
                        new Image
                        {
                            Id = (int)reader["id"],
                            Value = (string)reader["image"],
                        });
                }
            }
            return images;
        }

        public Image GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
