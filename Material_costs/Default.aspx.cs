using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Material_costs
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = Convert.ToString(LoginTextBox.Text);
            string password = Convert.ToString(PasswordTextBox.Text);
            if(login.Equals("nik") && password.Equals("123"))
            {
                incorrectLabel.Text = "Здравствуйте";
                incorrectLabel.Visible = true;
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                incorrectLabel.Text = "Логин или пароль неверны";
                incorrectLabel.Visible = true;
            }
        }
    }
}