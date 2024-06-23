using DeMaria.Models;
using DeMaria.Views.Product;
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
        public List<CustomerModel> Select(int pCustomerID = 0)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            string query = "SELECT CST_ID, CST_NAME, CST_CPF, CST_EMAIL, CST_PHONE,ADR_ZIP_CODE, ADR_STREET, ADR_NUMBER, ADR_COMPLEMENT, ADR_CITY, ADR_STATE " +
                            "FROM TBL_CUSTOMER INNER JOIN TBL_ADDRESS ON CST_ID = ADR_ID " +
                            "WHERE CST_DELETE IS NULL"; 

            query = pCustomerID == 0 ? query : query += " AND CST_ID = @P_CST_ID;";
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_CST_ID", pCustomerID);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    CustomerModel customer = new CustomerModel(reader.GetInt32(0), //ID
                                                                               reader.GetString(1), //NAME
                                                                               reader.GetString(2), //CPF
                                                                               reader.GetString(3), //EMAIL
                                                                               reader.GetString(4), //PHONE
                                                                               reader.GetString(5), //ZIPCODE
                                                                               reader.GetString(6), //STREET
                                                                               reader.GetInt32(7), //NUMBER
                                                                               reader.GetString(8), //COMPLEMENT
                                                                               reader.GetString(9), //CITY 
                                                                               reader.GetString(10)); //STATE
                                    customers.Add(customer);
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
            return customers;
        }

        public void Insert(CustomerModel pCustomer)
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
                            cmd.Parameters.AddWithValue("P_ZIP_CODE", pCustomer.ADR_ZIP_CODE);
                            cmd.Parameters.AddWithValue("P_STREET", pCustomer.ADR_STREET);
                            cmd.Parameters.AddWithValue("P_NUMBER", pCustomer.ADR_NUMBER);
                            cmd.Parameters.AddWithValue("P_COMPLEMENT", pCustomer.ADR_COMPLEMENT);
                            cmd.Parameters.AddWithValue("P_CITY", pCustomer.ADR_CITY);
                            cmd.Parameters.AddWithValue("P_STATE", pCustomer.ADR_STATE);
                            cmd.Parameters.AddWithValue("P_ID_USER", pCustomer.CREATED_BY);
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

        public void Update(CustomerModel pCustomer)
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
                            cmd.Parameters.AddWithValue("P_ZIP_CODE", pCustomer.ADR_ZIP_CODE);
                            cmd.Parameters.AddWithValue("P_STREET", pCustomer.ADR_STREET);
                            cmd.Parameters.AddWithValue("P_NUMBER", pCustomer.ADR_NUMBER);
                            cmd.Parameters.AddWithValue("P_COMPLEMENT", pCustomer.ADR_COMPLEMENT);
                            cmd.Parameters.AddWithValue("P_CITY", pCustomer.ADR_CITY);
                            cmd.Parameters.AddWithValue("P_STATE", pCustomer.ADR_STATE);
                            cmd.Parameters.AddWithValue("P_ID_USER", pCustomer.MODIFIED_BY);
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

        public void Delete(int customerID, int userLoggedID)
        {
            using (var dbConnection = new DatabaseConnection())
            {
                var connection = dbConnection.Connection;
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CALL DELETE_CUSTOMER (@P_CST_ID, @P_ID_USER);";
                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("P_CST_ID", customerID);
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
