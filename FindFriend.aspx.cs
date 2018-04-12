using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FilterUnwantedMSG_OSN
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmdSearch = new SqlCommand(" select * from Users where (Fname like '%" + txtSearch.Text + "%' or Lname like '%" + txtSearch.Text + "%' or Email like '%" + txtSearch.Text + "%') and User_id<>" + Session["ID"].ToString() + "", DBConnection.conn);
            cmdSearch.CommandType = CommandType.Text;
            //cmdSearch.Parameters.AddWithValue("@Fname", txtSearch.Text.Trim());
            //cmdSearch.Parameters.AddWithValue("@Lname", txtSearch.Text.Trim());
            //cmdSearch.Parameters.AddWithValue("@Email", txtSearch.Text.Trim());
            SqlDataAdapter daSearch = new SqlDataAdapter(cmdSearch);
            DataTable dtSearch = new DataTable();
            daSearch.Fill(dtSearch);

            GridView1.DataSource = dtSearch;
            GridView1.DataBind();
            DBConnection.conn.Close();

        }

        protected void Button1_OnCommand(object sender, EventArgs e)
        {
            //int Friend_id = Convert.ToInt32(e.CommandArgument);
        }

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Friend_id = Convert.ToInt32(e.CommandArgument);
           // SqlCommand cmdCheck = new SqlCommand("", DBConnection.conn);

            SqlCommand cmdinsert = new SqlCommand("insert into FriendMaster(FromUser, ToUser, Flag) values(@FromUser, @ToUser, @Flag)", DBConnection.conn);
            cmdinsert.CommandType = CommandType.Text;
            cmdinsert.Parameters.AddWithValue("@FromUser", Session["ID"].ToString());
            cmdinsert.Parameters.AddWithValue("@ToUser", Friend_id);
            cmdinsert.Parameters.AddWithValue("@Flag", 0);
            DBConnection.conn.Open();
            cmdinsert.ExecuteNonQuery();
            DBConnection.conn.Close();

            lblShow.Text = "Send Request";
        }
    }
}