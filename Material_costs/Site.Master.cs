using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                ExitLinkButton.Visible = true;
            }
            else if(!isLogIn[0] && isLogIn[1])
            {
                ChangeUserLinkButton.Visible = true;
                ExitLinkButton.Visible = true;
            }
        }

        protected void RegLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void ExitLinkButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "key", "window.close()", true);
        }
    }
}