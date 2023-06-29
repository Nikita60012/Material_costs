using Npgsql;
using System.IO;

namespace Material_costs
{
    class DataConntection
    {
        //Изменить для соединения со своей базой данных
        
        private readonly NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;UserId=postgres;Password=12336;Database=MaterialCosts;");
        public void OpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public NpgsqlConnection getConnection()
        {
            return conn;
        }
    }

}