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

        public int Add(Image image)
        {
            int id = 1;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddImage";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parDOB = new SqlParameter("@image_value", image.Value);
                command.Parameters.Add(parDOB);
                sqlConnection.Open();
                command.ExecuteNonQuery();

                var commandGetId = sqlConnection.CreateCommand();
                commandGetId.CommandText = "GetImageId";
                commandGetId.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = commandGetId.ExecuteReader();

                while (reader.Read())
                {
                    id = (int)reader["id"];
                }
            }
            return id;
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
                        new Image((int)reader["id"], (string)reader["image_value"]));
                }
            }
            return images;
        }

        public Image GetById(int id)
        {
            return (Image)GetAll().Where(k => k.Id == id).ToList()[0];
        }
    }
}
