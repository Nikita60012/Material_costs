using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Material_costs
{
    public partial class Adding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void IsStandart_CheckedChanged(object sender, EventArgs e)
        {
            if (IsStandart.Checked == true)
            {
                AluminumTextBox.Enabled = false;
                CopperWireTextBox.Enabled = false;
                OilTextBox.Enabled = false;
            }
            else
            {
                AluminumTextBox.Enabled = true;
                CopperWireTextBox.Enabled = true;
                OilTextBox.Enabled = true;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

        }
    }
}