using Npgsql;

namespace Material_costs
{
    public class TablesExistCheck
    {
        readonly private DataConntection connect = new DataConntection();

        //Проверка существования таблицы с аккаунтами
       public void CheckAccounts()
       {
            
            NpgsqlCommand comm = new NpgsqlCommand("SELECT EXISTS (SELECT * FROM pg_tables WHERE tablename = 'Accounts' AND schemaname = 'public')", connect.getConnection());
            connect.OpenConnection();
            string isExist = comm.ExecuteScalar().ToString();
            connect.CloseConnection();
            if (isExist.Equals("False"))
            {
                CreateAccauntTable(comm);
            }
            
       }

        //Проверка существования таблицы с записями о затратах материала
        public void CheckCosts(string login)
        {
            NpgsqlCommand comm = new NpgsqlCommand("SELECT EXISTS (SELECT * FROM pg_tables WHERE tablename = '" + login + "Cost' AND schemaname = 'public')", connect.getConnection());
            connect.OpenConnection();
            string isExist = comm.ExecuteScalar().ToString();
            connect.CloseConnection();
            if (isExist.Equals("False"))
            {
                CreateCostTable(login);
            }
        }

        //Создание таблицы с аккаунтами и записью администратора
        private void CreateAccauntTable(NpgsqlCommand comm)
        {
            connect.OpenConnection();
            string createAccountsTable = "CREATE TABLE public.\"Accounts\"(\"ID\" serial, \"Login\" text COLLATE pg_catalog.\"default\", \"Password\" text COLLATE pg_catalog.\"default\", CONSTRAINT \"Accounts_pkey\" PRIMARY KEY (\"ID\"))WITH (OIDS = FALSE) TABLESPACE pg_default; ALTER TABLE public.\"Accounts\" OWNER to postgres;";
            comm.CommandText = createAccountsTable;
            comm.ExecuteNonQuery();
            comm.CommandText = "insert into public.\"Accounts\" (\"Login\", \"Password\") values ('Admin','12336')";
            comm.ExecuteNonQuery();
            connect.CloseConnection();
        }

        //Создание таблицы с записями о затратах материала
        private void CreateCostTable(string login)
        {
            string createCommand = "CREATE TABLE public.\"" + login + "Cost\"(\"ID\" serial, \"Date\" date, \"Quantity\" integer, \"IsStandart\" boolean, \"AluminiumBlank\" text COLLATE pg_catalog.\"default\", \"CopperWire\" text COLLATE pg_catalog.\"default\", \"Oil\" text COLLATE pg_catalog.\"default\", CONSTRAINT \"" + login + "Cost_pkey\" PRIMARY KEY (\"ID\"))WITH (OIDS = FALSE) TABLESPACE pg_default;ALTER TABLE public.\"" + login + "Cost\" OWNER to postgres;";
            NpgsqlCommand comm = new NpgsqlCommand(createCommand, connect.getConnection());
            connect.OpenConnection();
            comm.ExecuteNonQuery();
            connect.CloseConnection();
        }
    }
}