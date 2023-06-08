using Npgsql;
using System;
using System.Web.UI;

namespace Material_costs
{
    public partial class Registration : Page
    {
        readonly private  DataConntection connect = new DataConntection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Создание записи в таблице с аккаунтами и создание таблицы с записями о материальных расходах нового пользователя
        protected void RegButton_Click(object sender, EventArgs e)
        {
            TablesExistCheck createCostTable = new TablesExistCheck();
            createCostTable.CheckCosts(LoginTextBox.Text);
            bool isExist = false;
            NpgsqlCommand existCheck = new NpgsqlCommand("select \"Login\" from public.\"Accounts\"", connect.getConnection());
            connect.OpenConnection();
            NpgsqlDataReader reader;
            reader = existCheck.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    string account = reader.GetString(0);
                    if (account.Equals(LoginTextBox.Text))
                    {
                        isExist = true;
                    }
                }
                catch { }
            }
            if (!isExist)
            {
                NpgsqlCommand comm = new NpgsqlCommand("INSERT into public.\"Accounts\" (\"Login\", \"Password\") VALUES ('" + LoginTextBox.Text + "', '" + PasswordTextBox.Text + "')", connect.getConnection());
                comm.ExecuteNonQuery();
                PasswordTextBox.Text = "";
                LoginTextBox.Text = "пользователь зарегистрирован";
            }
            else
            {
                PasswordTextBox.Text = "";
                LoginTextBox.Text = "пользователь уже существует";
            }
            connect.CloseConnection();
        }
    }
}