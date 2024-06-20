using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DeMaria.Repositories
{
    public class DatabaseConnection : IDisposable
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=DB_DEMARIA;Port=5432";
        private NpgsqlConnection connection;

        public NpgsqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new NpgsqlConnection(connectionString);
                }
                return connection;
            }
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
    }
}
