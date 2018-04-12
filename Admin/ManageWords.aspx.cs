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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] == "add")
            {
                lblShow.Text = "Word Add Successfully";
            }
            if (Request.QueryString["msg"] == "delete")
            {
                lblShow.Text = "Word Delete Successfully";
            }
            if (!IsPostBack)
            {
                FillGridView();
            }
        }
        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            SqlCommand cmdInsert = new SqlCommand("Delete from Directory where bId=@bId", DBConnection.conn);
            cmdInsert.Parameters.AddWithValue("@bId", e.CommandArgument);
            DBConnection.conn.Open();
            cmdInsert.ExecuteNonQuery();
            DBConnection.conn.Close();

            Response.Redirect("ManageWords.aspx?msg=delete");
        }
        protected void FillGridView()
        {
            SqlCommand cmd = new SqlCommand("Select * from Directory", DBConnection.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmdInsert = new SqlCommand("Insert into Directory(Word)values(@Word)", DBConnection.conn);
            cmdInsert.Parameters.AddWithValue("@Word", txtWord.Text);
            DBConnection.conn.Open();
            cmdInsert.ExecuteNonQuery();
            DBConnection.conn.Close();

            Response.Redirect("ManageWords.aspx?msg=add");
        }
    }
}