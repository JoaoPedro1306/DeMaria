using DeMaria.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DeMaria.Repositories
{
    public class ProductRepository
    {
        public List<ProductModel> Select(int pProductID, int pOption)
        {
            List<ProductModel> products = new List<ProductModel>();
            string query = "SELECT PRD_ID, PRD_NAME, PRD_PRICE, PRD_STOCK FROM TBL_PRODUCT WHERE PRD_DELETE IS NULL";
            query = pOption == 2 ? query += " AND PRD_ID = @P_PRD_ID" : query;

            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new NpgsqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("P_PRD_ID", pProductID);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    ProductModel product = new ProductModel(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3));
                                    products.Add(product);
                                }
                            }
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
            return products;
        }

        public void Insert(ProductModel pProduct)
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
                            cmd.Parameters.AddWithValue("P_NAME", NpgsqlTypes.NpgsqlDbType.Varchar, pProduct.PRD_NAME);
                            cmd.Parameters.AddWithValue("P_PRICE", NpgsqlTypes.NpgsqlDbType.Numeric, pProduct.PRD_PRICE);
                            cmd.Parameters.AddWithValue("P_STOCK", NpgsqlTypes.NpgsqlDbType.Integer, pProduct.PRD_STOCK);
                            cmd.Parameters.AddWithValue("P_ID_USER", NpgsqlTypes.NpgsqlDbType.Integer, pProduct.CREATED_BY);
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

        public void Update(ProductModel pProduct)
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
                            cmd.Parameters.AddWithValue("P_PRD_ID", NpgsqlTypes.NpgsqlDbType.Integer, pProduct.PRD_ID);
                            cmd.Parameters.AddWithValue("P_NAME", NpgsqlTypes.NpgsqlDbType.Varchar, pProduct.PRD_NAME);
                            cmd.Parameters.AddWithValue("P_PRICE", NpgsqlTypes.NpgsqlDbType.Numeric, pProduct.PRD_PRICE);
                            cmd.Parameters.AddWithValue("P_STOCK", NpgsqlTypes.NpgsqlDbType.Integer, pProduct.PRD_STOCK);
                            cmd.Parameters.AddWithValue("P_ID_USER", NpgsqlTypes.NpgsqlDbType.Integer, pProduct.MODIFIED_BY);
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
        
        public void Delete(int productID, int userLoggedID)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL SOFT_DELETE_PRODUCT (@P_PRD_ID, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_PRD_ID", productID);
                            cmd.Parameters.AddWithValue("P_ID_USER", userLoggedID);
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
