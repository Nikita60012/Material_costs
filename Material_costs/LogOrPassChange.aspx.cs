using Npgsql;
using System;

using System.Net.Mail;


namespace Material_costs
{
    public partial class LogOrPassChange : System.Web.UI.Page
    {
        readonly private DataConntection connect = new DataConntection();
        private string newLogin;
        private string newPassword;
        private int userId;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            connect.OpenConnection();
            NpgsqlCommand comm = new NpgsqlCommand("select * from public.\"Accounts\" where \"Login\" Like '" + _Default.User + "'", connect.getConnection());
            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            string pass = "";
            while (reader.Read())
            {
                try
                {
                    userId = reader.GetInt32(0);
                    pass = reader.GetString(2);
                }
                catch
                {

                }
            }
            connect.CloseConnection();

            connect.OpenConnection();
            if (OldPasswordTextBox.Text.Equals(pass))
            {
                
                incorrectLabel.Visible = false;
                if (!NewLoginTextBox.Text.Equals(""))
                {
                    newLogin = NewLoginTextBox.Text;
                    bool isExist = false;
                    NpgsqlCommand existCheck = new NpgsqlCommand("select \"Login\" from public.\"Accounts\"", connect.getConnection());
                    NpgsqlDataReader isExistReader;
                    isExistReader = existCheck.ExecuteReader();
                    while (isExistReader.Read())
                    {
                        try
                        {
                            string account = isExistReader.GetString(0);
                            if (account.Equals(newLogin))
                            {
                                isExist = true;
                            }
                        }
                        catch { }
                    }
                    if (!isExist)
                    {
                        comm = new NpgsqlCommand("update public.\"Accounts\" set \"Login\"='" + newLogin + "' where \"Login\"='" + _Default.User + "'", connect.getConnection());
                        comm.ExecuteNonQuery();
                        _Default.User = newLogin;
                    }
                    else
                    {
                        incorrectLabel.Text = "Логин занят";
                        incorrectLabel.Visible = true;
                    }
                }
                
                if (!NewPasswordTextBox.Text.Equals(""))
                {
                    newPassword = NewPasswordTextBox.Text;
                    comm = new NpgsqlCommand("update public.\"Accounts\" set \"Password\"='" + newPassword + "' where \"Login\"='" + _Default.User + "'", connect.getConnection());
                    comm.ExecuteNonQuery();
                }
            }
            else
            {
                incorrectLabel.Visible = true;
            }
            connect.CloseConnection();
        }
    }
}