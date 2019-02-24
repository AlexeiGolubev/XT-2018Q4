using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL.DB
{
    public class AwardDao : IAwardDao
    {
        private readonly string _connectionString;

        #region Constructor
        public AwardDao(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        public void Add(Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddAward";

                    var title = new SqlParameter("@Title", SqlDbType.NVarChar) { Value = award.Title };
                    command.Parameters.Add(title);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public void AddImage(int id, byte[] image)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddAwardImage";

                    var idAward = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idAward);
                    var imageAward = new SqlParameter("@Image", SqlDbType.VarBinary) { Value = image };
                    command.Parameters.Add(imageAward);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteAwardById";

                    var idAward = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idAward);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var repoAwards = new List<Award>();
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAllAwards";

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        repoAwards.Add(
                            new Award
                            {
                                Id = (int)reader["Id_Award"],
                                Title = (string)reader["Title"],
                                Image = reader["Image"] == DBNull.Value
                                ? null
                                : (byte[])reader["Image"],
                            });
                    }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return repoAwards;
        }

        public Award GetById(int id)
        {
            var award = new Award();
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAwardById";

                    var idAward = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idAward);

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        award = new Award
                        {
                            Id = (int)reader["Id_Award"],
                            Title = (string)reader["Title"],
                            Image = reader["Image"] == DBNull.Value
                            ? null
                            : (byte[])reader["Image"],
                        };
                    }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return award;
        }

        public void RemoveImage(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteAwardImage";

                    var idAward = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idAward);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public void Update(Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateAward";

                    var id = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = award.Id };
                    command.Parameters.Add(id);
                    var title = new SqlParameter("@Title", SqlDbType.NVarChar) { Value = award.Title };
                    command.Parameters.Add(title);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
    }
}
