using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FilterUnwantedMSG_OSN.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmdcheck = new SqlCommand("select aId,Username,Password from AdminLogin where Username=@Username and Password=@Password", DBConnection.conn);
            cmdcheck.CommandType = CommandType.Text;
            cmdcheck.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmdcheck.Parameters.AddWithValue("@Password", txtPassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmdcheck);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Id"] = dt.Rows[0]["aId"].ToString();

                Response.Redirect("Default.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Messege", "alert('Invalid Username and Password')", true);
            }
        }
    }
}