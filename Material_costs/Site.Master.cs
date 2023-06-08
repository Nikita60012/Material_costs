using System;
using System.Web.UI;

namespace Material_costs
{
    public partial class SiteMaster : MasterPage
    {
        private bool[] isLogIn = new bool[2];
        
        protected void Page_Load(object sender, EventArgs e)
        {
            isLogIn = _Default.GetAdmin();
            if (isLogIn[0] && isLogIn[1])
            {
                RegLinkButton.Visible = true;
                ChangeUserLinkButton.Visible = true;  
            }
            else if(isLogIn[0] && !isLogIn[1]){ChangeUserLinkButton.Visible = true;}
        }


        protected void ExitLinkButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1); 
        }

        protected void ChangeUserLinkButton_Click(object sender, EventArgs e)
        {
            isLogIn[0] = false;
            isLogIn[1] = false;
            Response.Redirect("Default.aspx");
        }
    }
}