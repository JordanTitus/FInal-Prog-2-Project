using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FInal_Prog_2_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Check whether user is real. Checks the data vs the table of the option (Employee or Farmer)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pword"></param>
        /// <returns></returns>
        private bool ValidateUser(string name, string pword)
        {
            string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["PrototypeDatabaseConnectionString"].ConnectionString;

            SqlConnection SqlConnection = new SqlConnection(Connection);
            SqlCommand Command;
            string lookupPassword = null;
            int lookupID = 0;

            if ((null == name) || (0 == name.Length) || (name.Length > 10))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of name failed");
                return false;
            }

            if ((null == pword) || (0 == pword.Length) || (pword.Length > 10))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of password failed");
                return false;
            }

            if ((SelectUserType.Value == "Default") || (SelectUserType.SelectedIndex == 0))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Option not selected");
                return false;
            }

            try
            { 
                string type = SelectUserType.Value;

                using (SqlConnection)
                {
                    SqlConnection.Open();

                    switch (type)
                    {
                        default:
                            Command = new SqlCommand("");
                            Response.Redirect("Login.aspx", true);
                            break;

                        //Employee Validation
                        case "Employee":
                            Command = new SqlCommand("Select Id from TBL_Employee where EmployeeName=@name", SqlConnection);
                            Command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 10);
                            Command.Parameters["@name"].Value = name;

                            lookupID = Convert.ToInt32(Command.ExecuteScalar());

                            Command = new SqlCommand("Select hashedPassword from TBL_EmployeePassword where EmployeeID=@lookupID", SqlConnection);
                            Command.Parameters.Add("@lookupID", System.Data.SqlDbType.Int);
                            Command.Parameters["@lookupID"].Value = lookupID;
                            Application["user"] = "Employee";
                            break;

                        //Farmer Validation
                        case "Farmer":
                            Command = new SqlCommand("Select Id from TBL_Farmer where FarmerName=@name", SqlConnection);
                            Command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 10);
                            Command.Parameters["@name"].Value = name;

                            lookupID = Convert.ToInt32(Command.ExecuteScalar());

                            Application["FarmerID"] = lookupID;

                            Command = new SqlCommand("Select hashedPassword from TBL_FarmerPassword where FarmerID=@lookupID", SqlConnection);
                            Command.Parameters.Add("@lookupID", System.Data.SqlDbType.Int);
                            Command.Parameters["@lookupID"].Value = lookupID;

                            Application["user"] = "Farmer";
                            break;
                    }

                    lookupPassword = (string)Command.ExecuteScalar();
                    Command.Dispose();

                }
            }
            //Exception Handling
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            if (null == lookupPassword)
            {
                return false;
            }

            return (0 == string.Compare(lookupPassword, pword, false));
        }

        /// <summary>
        /// Server Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {
            if (ValidateUser(txtUserName.Value, txtUserPassword.Value))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Value, CheckPersistCookie.Checked);
            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.cmdLogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);
        }
    }
}