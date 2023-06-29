using System;
using System.Web.UI;

namespace Material_costs
{
    public partial class _Default : Page
    {
        public static new string User;
        public static bool[] isLogIn = new bool[2];
        private AccauntCheck accCheck = new AccauntCheck();
        readonly private TablesExistCheck check = new TablesExistCheck();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Проверка на существование таблицы с аккаунтами
            check.CheckAccounts();
        }

        protected void LogInButton_Click(object sender, EventArgs e)
        { 
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            isLogIn = accCheck.AdminCheck(login, password);

            //Проверка на существование  таблицы с записями материальных затрат и переход на главную страницу
            if (isLogIn[0])
            {
                incorrectLabel.Visible = false;
                check.CheckCosts(login);
                User = LoginTextBox.Text;
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                incorrectLabel.Visible = true;
            }
        }
        public static bool[] GetAdmin()
        {
            return isLogIn;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}