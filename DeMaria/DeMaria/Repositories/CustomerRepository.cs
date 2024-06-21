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
    public class CustomerRepository
    {
        public static void Select(int pCustomerID, int pOption)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "SELECT SELECT_CUSTOMER(@P_CST_ID, @P_OPTION)";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_CST_ID", pCustomerID);
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

        public static void Insert(Customer pCustomer, Address pAddress, int pUserID)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL INSERT_CUSTOMER(@P_NAME, @P_CPF, @P_EMAIL, @P_PHONE, @P_ZIP_CODE, @P_STREET, @P_NUMBER, @P_COMPLEMENT, @P_CITY, @P_STATE, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_NAME", pCustomer.CST_NAME);
                            cmd.Parameters.AddWithValue("P_CPF", pCustomer.CST_CPF);
                            cmd.Parameters.AddWithValue("P_EMAIL", pCustomer.CST_EMAIL);
                            cmd.Parameters.AddWithValue("P_PHONE", pCustomer.CST_PHONE);
                            cmd.Parameters.AddWithValue("P_ZIP_CODE", pAddress.ADR_ZIP_CODE);
                            cmd.Parameters.AddWithValue("P_STREET", pAddress.ADR_STREET);
                            cmd.Parameters.AddWithValue("P_NUMBER", pAddress.ADR_NUMBER);
                            cmd.Parameters.AddWithValue("P_COMPLEMENT", pAddress.ADR_COMPLEMENT);
                            cmd.Parameters.AddWithValue("P_CITY", pAddress.ADR_CITY);
                            cmd.Parameters.AddWithValue("P_STATE", pAddress.ADR_STATE);
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

        public static void Update(Customer pCustomer, Address pAddress, int pUserID)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL UPDATE_CUSTOMER(@P_CST_ID, @P_NAME, @P_CPF, @P_EMAIL, @P_PHONE, @P_ZIP_CODE, @P_STREET, @P_NUMBER, @P_COMPLEMENT, @P_CITY, @P_STATE, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_CST_ID", pCustomer.CST_ID);
                            cmd.Parameters.AddWithValue("P_NAME", pCustomer.CST_NAME);
                            cmd.Parameters.AddWithValue("P_CPF", pCustomer.CST_CPF);
                            cmd.Parameters.AddWithValue("P_EMAIL", pCustomer.CST_EMAIL);
                            cmd.Parameters.AddWithValue("P_PHONE", pCustomer.CST_PHONE);
                            cmd.Parameters.AddWithValue("P_ZIP_CODE", pAddress.ADR_ZIP_CODE);
                            cmd.Parameters.AddWithValue("P_STREET", pAddress.ADR_STREET);
                            cmd.Parameters.AddWithValue("P_NUMBER", pAddress.ADR_NUMBER);
                            cmd.Parameters.AddWithValue("P_COMPLEMENT", pAddress.ADR_COMPLEMENT);
                            cmd.Parameters.AddWithValue("P_CITY", pAddress.ADR_CITY);
                            cmd.Parameters.AddWithValue("P_STATE", pAddress.ADR_STATE);
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
