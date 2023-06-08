using Npgsql;

namespace Material_costs
{
    public class AccauntCheck
    {
        private static bool isAdmin = false;
        private static bool isAuthorized = false;
        private static readonly bool[] logIn = new bool[2];
        readonly private DataConntection connect = new DataConntection();

        //Проверка на администратора
        public  bool[] AdminCheck(string login, string password)
        {
            connect.OpenConnection();
            NpgsqlCommand comm = new NpgsqlCommand("select * from public.\"Accounts\"", connect.getConnection());
            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    string account = reader.GetString(1);
                    string pass = reader.GetString(2);
                    if (login.Equals(account) && account.Equals("Admin") && password.Equals(pass))
                    {
                        isAdmin = true;
                        isAuthorized = true;
                    }
                    else if (login.Equals(account) && password.Equals(pass))
                    {
                        isAuthorized = true;
                    }
                    logIn[0] = isAuthorized;
                    logIn[1] = isAdmin;
                    if (isAuthorized)
                    {
                        isAuthorized = false;
                        isAdmin = false;
                        break;
                    }
                    isAuthorized = false;
                    isAdmin = false;
                    
                }
                catch{ }
            }
            connect.CloseConnection();
            
            return logIn;
        }
    }
}