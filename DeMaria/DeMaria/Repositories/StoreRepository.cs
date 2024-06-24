using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeMaria.Models;
using DeMaria.Views.Customer;
using Npgsql;
namespace DeMaria.Repositories
{
    public class StoreRepository
    {
        public void Insert(SalesModel pSale, List<ProductSaleModel> pListProduct)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "SELECT INSERT_SALE(@P_CST_ID, @P_TOTAL_PRICE, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_CST_ID", NpgsqlTypes.NpgsqlDbType.Integer, pSale.CST_ID);
                            cmd.Parameters.AddWithValue("P_TOTAL_PRICE", NpgsqlTypes.NpgsqlDbType.Numeric, pSale.SLS_TOTAL_PRICE);
                            cmd.Parameters.AddWithValue("P_ID_USER", NpgsqlTypes.NpgsqlDbType.Integer, pSale.CREATED_BY);
                            pSale.SLS_ID = (int)cmd.ExecuteScalar();
                        }
                        query = "CALL INSERT_PRODUCT_SALE(@P_SALE_ID, @P_PRODUCT_ID, @P_QUANTITY, @P_PRICE, @P_ID_USER);";
                        foreach (var product in pListProduct)
                        {
                            using (var cmd = new NpgsqlCommand(query, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("P_SALE_ID", NpgsqlTypes.NpgsqlDbType.Integer, pSale.SLS_ID);
                                cmd.Parameters.AddWithValue("P_PRODUCT_ID", NpgsqlTypes.NpgsqlDbType.Integer, product.PRD_ID);
                                cmd.Parameters.AddWithValue("P_QUANTITY", NpgsqlTypes.NpgsqlDbType.Integer, product.PRS_QUANTITY);
                                cmd.Parameters.AddWithValue("P_PRICE", NpgsqlTypes.NpgsqlDbType.Numeric, product.PRD_PRICE);
                                cmd.Parameters.AddWithValue("P_ID_USER", NpgsqlTypes.NpgsqlDbType.Integer, pSale.CREATED_BY);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
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
