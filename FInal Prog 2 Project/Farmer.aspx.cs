using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FInal_Prog_2_Project
{
    public partial class Farmer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Application["user"].ToString()) != "Farmer")
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void DBsave(string prodName, string prodType, int quant, int id, int unit)
        {
            string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["PrototypeDatabaseConnectionString"].ConnectionString;

            SqlConnection SqlConnection = new SqlConnection(Connection);
            SqlCommand Command;

            using (SqlConnection)
            {
                var SqlCommand = "INSERT INTO TBL_Product (ProductName, ProductType, FarmerId, Quantity, UnitPrice)" +
                     "VALUES (@prodName, @prodType, @id, @quant, @unit)";

                using (Command = new SqlCommand(SqlCommand, SqlConnection))
                {
                    Command.Parameters.AddWithValue("@prodName", prodName);
                    Command.Parameters.AddWithValue("@prodType", prodType);
                    Command.Parameters.AddWithValue("@id", id);
                    Command.Parameters.AddWithValue("@quant", quant);
                    Command.Parameters.AddWithValue("@unit", unit);
                    Command.ExecuteNonQuery();
                }
            }
        }

        protected void btnSubmitProd_ServerClick(object sender, EventArgs e)
        {
            int price;
            int quant;
            if ((txtProductName.Value != null) && (txtProductPrice.Value != null) && (txtProductQuantiity.Value != null))
            {
                if ((int.TryParse(txtProductPrice.Value, out price)) && (int.TryParse(txtProductQuantiity.Value, out quant)))
                {
                    string name = txtProductName.Value;
                    string type = SelectProduct.Value;
                    int id = (Int32)Application["FarmerID"];
                    DBsave(name, type, price, id, quant);
                }
                else
                {

                }
            }
            else
            {

            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.btnSubmitProduct.ServerClick += new System.EventHandler(this.btnSubmitProd_ServerClick);

        }
    }
}