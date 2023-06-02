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
        public static bool[] isLogIn = new bool[2];
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = Convert.ToString(LoginTextBox.Text);
            string password = Convert.ToString(PasswordTextBox.Text);
            isLogIn = Accaunts.AdminCheck(login, password);
            
          
            if (isLogIn[0])
            {
                incorrectLabel.Visible = false;
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                incorrectLabel.Visible = true;
            }
        }
        public void auth()
        {
            Response.Redirect("MainMenu.aspx");
        }
        public static bool[] GetAdmin()
        {
            return isLogIn;
        }
    }
}