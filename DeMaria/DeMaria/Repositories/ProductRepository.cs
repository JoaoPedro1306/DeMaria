using DeMaria.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.Repositories
{
    public class ProductRepository
    {
        public static void Select(int pProductID, int pOption)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "SELECT SELECT_PRODUCT(@P_PRD_ID, @P_OPTION);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_PRD_ID", pProductID);
                            cmd.Parameters.AddWithValue("P_OPTION", pOption);
                            var cursor = cmd.ExecuteScalar();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void Insert(Product pProduct, int pUserID)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL INSERT_PRODUCT (@P_NAME, @P_PRICE, @P_STOCK, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_NAME", pProduct.PRD_NAME);
                            cmd.Parameters.AddWithValue("P_PRICE", pProduct.PRD_PRICE);
                            cmd.Parameters.AddWithValue("P_STOCK", pProduct.PRD_STOCK);
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

        public static void Update(Product pProduct, int pUserID)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL UPDATE_PRODUCT (@P_PRD_ID, @P_NAME, @P_PRICE, @P_STOCK, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_PRD_ID", pProduct.PRD_ID);
                            cmd.Parameters.AddWithValue("P_NAME", pProduct.PRD_NAME);
                            cmd.Parameters.AddWithValue("P_PRICE", pProduct.PRD_PRICE);
                            cmd.Parameters.AddWithValue("P_STOCK", pProduct.PRD_STOCK);
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
