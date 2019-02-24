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
    public class AwardedUsersDao : IAwardedUsersDao
    {
        private readonly string _connectionString;

        #region Constructor
        public AwardedUsersDao(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        public void Add(int user, int award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddAwardedUser";

                    var idUser = new SqlParameter("@Id_User", SqlDbType.Int) { Value = user };
                    command.Parameters.Add(idUser);
                    var idAward = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = award };
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

        public void Delete(int userId, int awardId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteAwardedUser";

                    var idUser = new SqlParameter("@Id_User", SqlDbType.Int) { Value = userId };
                    command.Parameters.Add(idUser);
                    var idAward = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = awardId };
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

        public void DeleteAwardToAllUsers(int awardId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteAwardToAllUsers";

                    var idAward = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = awardId };
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

        public IEnumerable<AwardedUser> GetAll()
        {
            var awardedUsers = new List<AwardedUser>();
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAllAwardedUsers";

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        awardedUsers.Add(
                            new AwardedUser
                            {
                                IdUser = (int)reader["Id_User"],
                                IdAward = (int)reader["Id_Award"],
                            });
                    }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return awardedUsers;
        }

        public IEnumerable<AwardedUser> GetByAwardId(int id)
        {
            var awardedUsers = new List<AwardedUser>();
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAwardedUsersByAwardId";

                    var idAward = new SqlParameter("@Id_Award", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idAward);

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        awardedUsers.Add(
                            new AwardedUser
                            {
                                IdUser = (int)reader["Id_User"],
                                IdAward = (int)reader["Id_Award"],
                            });
                    }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return awardedUsers;
        }

        public IEnumerable<AwardedUser> GetByUserId(int id)
        {
            var awardedUsers = new List<AwardedUser>();
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAwardedUsersByUserId";

                    var idUser = new SqlParameter("@Id_User", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idUser);

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        awardedUsers.Add(
                            new AwardedUser
                            {
                                IdUser = (int)reader["Id_User"],
                                IdAward = (int)reader["Id_Award"],
                            });
                    }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return awardedUsers;
        }
    }
}
