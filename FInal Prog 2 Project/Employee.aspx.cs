using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FInal_Prog_2_Project
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Application["user"].ToString();

            if (type != "Employee")
            {
                Response.Redirect("Default.aspx", true);
            }
        }
    }
}