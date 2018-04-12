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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] == "Add")
            {
                lblShow.Text = "Friend Request Accepted";
            }
            if (Request.QueryString["msg"] == "reject")
            {
                lblShow.Text = "Friend Request Rejected";
            }
            if (!IsPostBack)
            {
                //SqlCommand cmdSelect = new SqlCommand("select f.ID,(u.Fname+' '+u.Lname)as Name,u.Email,f.FromUser from FriendMaster f join Users u on(f.FromUser=u.User_id) and f.ToUser=@ToUser and Flag=0", DBConnection.conn);
                SqlCommand cmdSelect = new SqlCommand("select f.ID,(u.Fname+' '+u.Lname)as Name,u.Email,f.FromUser from FriendMaster f join Users u on(f.FromUser=u.User_id) and f.ToUser=@ToUser and Flag=0", DBConnection.conn);
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.Parameters.AddWithValue("@ToUser", Session["ID"].ToString());
                SqlDataAdapter daSelect = new SqlDataAdapter(cmdSelect);
                DataTable dtSelect = new DataTable();
                daSelect.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    GridView1.DataSource = dtSelect;
                    GridView1.DataBind();
                }
            }
        }
        protected void btnAccept_OnCommand(object sender, CommandEventArgs e)
        {
            int RequetId = Convert.ToInt32(e.CommandArgument);
            SqlCommand cmdUpdate = new SqlCommand("update FriendMaster set Flag=1 where Id="+ RequetId+"", DBConnection.conn);
            cmdUpdate.CommandType = CommandType.Text;
            DBConnection.conn.Open();
            cmdUpdate.ExecuteNonQuery();
            DBConnection.conn.Close();

            Response.Redirect("Request.aspx?msg=Add");

        }

        protected void btnReject_OnCommand(object sender, CommandEventArgs e)
        {
            int RequetId = Convert.ToInt32(e.CommandArgument);
            SqlCommand cmdUpdate = new SqlCommand("delete from FriendMaster where Id=" + RequetId + "", DBConnection.conn);
            cmdUpdate.CommandType = CommandType.Text;
            DBConnection.conn.Open();
            cmdUpdate.ExecuteNonQuery();
            DBConnection.conn.Close();

            Response.Redirect("Request.aspx?msg=reject");
        }
    }
}