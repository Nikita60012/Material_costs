using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Material_costs
{
    public partial class MainMenu : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExitLinkButton_Click(object sender, EventArgs e)
        {
            Page.Dispose();
        }
    }
}