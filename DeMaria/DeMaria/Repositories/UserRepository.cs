using DeMaria.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.Repositories
{
    public class UserRepository
    {
        public List<User> Select(int pUserID, string pEmail, string pPassword, int pOption)
        {
            List<User> users = new List<User>();
            string query = "SELECT USR_ID, USR_NAME, USR_EMAIL FROM TBL_USER";

            switch (pOption)
            {
                case 2: query = $"{query} WHERE USR_ID = @P_USR_ID;"; 
                    break;
                case 3: query = $"{query} WHERE USR_EMAIL = @P_EMAIL AND USR_PASSWORD = @P_PASSWORD;";
                    break;
                case 4: query = $"{query}  WHERE USR_ID = @P_USR_ID AND USR_PASSWORD = @P_PASSWORD;";
                    break;
            }

            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();
                using (var trasaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new NpgsqlCommand(query, connection, trasaction))
                        {
                            cmd.Parameters.AddWithValue("P_USR_ID", pUserID);
                            cmd.Parameters.AddWithValue("P_EMAIL", pEmail);
                            cmd.Parameters.AddWithValue("P_PASSWORD", pPassword);
                            cmd.Parameters.AddWithValue("P_OPTION", pOption);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                                    users.Add(user);
                                }
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return users;
        }

        public void Insert(User pUser)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL INSERT_USER (@P_NAME, @P_EMAIL, @P_PASSWORD, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_NAME", pUser.USR_NAME);
                            cmd.Parameters.AddWithValue("P_EMAIL", pUser.USR_EMAIL);
                            cmd.Parameters.AddWithValue("P_PASSWORD", pUser.USR_PASSWORD);
                            cmd.Parameters.AddWithValue("P_ID_USER", pUser.CREATED_BY);
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public void Update(User pUser, int pUserID)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL UPDATE_USER (@P_NAME, @P_EMAIL, @P_PASSWORD, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_NAME", pUser.USR_NAME);
                            cmd.Parameters.AddWithValue("P_EMAIL", pUser.USR_EMAIL);
                            cmd.Parameters.AddWithValue("P_PASSWORD", pUser.USR_PASSWORD);
                            cmd.Parameters.AddWithValue("P_ID_USER", pUserID);
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public void UpdatePassword(User pUser, int pUserID)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL UPDATE_PASSWORD (@P_USR_ID, @P_PASSWORD, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_USR_ID", pUser.USR_NAME);
                            cmd.Parameters.AddWithValue("P_PASSWORD", pUser.USR_PASSWORD);
                            cmd.Parameters.AddWithValue("P_ID_USER", pUserID);
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
