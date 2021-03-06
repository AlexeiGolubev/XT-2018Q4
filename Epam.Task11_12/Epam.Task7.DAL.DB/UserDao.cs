﻿using System;
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
    public class UserDao : IUserDao
    {
        private readonly string _connectionString;

        #region Constructor
        public UserDao(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        public void Add(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddUser";

                    var name = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = user.Name };
                    command.Parameters.Add(name);
                    var dateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.Date) { Value = user.DateOfBirth };
                    command.Parameters.Add(dateOfBirth);

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
                    command.CommandText = "AddUserImage";

                    var idUser = new SqlParameter("@Id_User", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idUser);
                    var imageUser = new SqlParameter("@Image", SqlDbType.VarBinary) { Value = image };
                    command.Parameters.Add(imageUser);

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
                    command.CommandText = "DeleteUserById";

                    var idUser = new SqlParameter("@Id_User", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idUser);

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

        public IEnumerable<User> GetAll()
        {
            var repoUsers = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAllUsers";

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        repoUsers.Add(
                            new User
                            {
                                Id = (int)reader["Id_User"],
                                Name = (string)reader["Name"],
                                DateOfBirth = ((DateTime)reader["DateOfBirth"]),
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

            return repoUsers;
        }

        public User GetById(int id)
        {
            var user = new User();
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetUserById";

                    var idUser = new SqlParameter("@Id_User", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idUser);

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                            user = new User
                            {
                                Id = (int)reader["Id_User"],
                                Name = (string)reader["Name"],
                                DateOfBirth = ((DateTime)reader["DateOfBirth"]),
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

            return user;
        }

        public void RemoveImage(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteUserImage";

                    var idUser = new SqlParameter("@Id_User", SqlDbType.Int) { Value = id };
                    command.Parameters.Add(idUser);

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

        public void Update(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateUser";

                    var id = new SqlParameter("@Id_User", SqlDbType.Int) { Value = user.Id };
                    command.Parameters.Add(id);
                    var name = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = user.Name };
                    command.Parameters.Add(name);
                    var dateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.Date) { Value = user.DateOfBirth };
                    command.Parameters.Add(dateOfBirth);

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
