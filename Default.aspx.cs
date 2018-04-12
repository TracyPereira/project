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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAdapter daGetPostUser = new SqlDataAdapter("GetPostData", DBConnection.conn);
                daGetPostUser.SelectCommand.CommandType = CommandType.StoredProcedure;
                daGetPostUser.SelectCommand.Parameters.AddWithValue("@User_id", Session["ID"].ToString());
                DataTable dt = new DataTable();
                daGetPostUser.Fill(dt);
                rp.DataSource = dt;
                rp.DataBind();
            }

            //SqlCommand cmd = new SqlCommand("select (u.Fname+' '+ u.Lname)as Name,u.Photo,p.fromUser,p.PostContent,p.Date from PostData p join Users u on(p.FromUser=u.User_id) where ToUser=" + Session["ID"].ToString() + "", DBConnection.conn);
            //cmd.CommandType = CommandType.Text;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    rp.DataSource = dt;
            //    rp.DataBind();
            //}
        }

        protected void rp_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                int PostId = Convert.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[0]);

                SqlDataAdapter daGetComments = new SqlDataAdapter("select cm.PostId, cm.User_id, cm.Comment,(u.fname+' '+u.Lname)as Name,u.Photo from dbo.CommentMaster cm inner join dbo.Users u on (cm.User_Id=u.User_id)  where cm.PostId=@PostId", DBConnection.conn);
                daGetComments.SelectCommand.Parameters.AddWithValue("@PostId", PostId);
                DataTable dtGetComment = new DataTable();
                daGetComments.Fill(dtGetComment);
                Repeater rp2 = (Repeater)e.Item.FindControl("rpComments");
                rp2.DataSource = dtGetComment;
                rp2.DataBind();
            }
        }

        protected void rp_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Comment")
            {
                int postId = Convert.ToInt32(e.CommandArgument);
                TextBox textBox = ((TextBox)e.Item.FindControl("txtComment"));
                String Comment = textBox.Text;
                SqlCommand cmdInsertComment = new SqlCommand("insert into CommentMaster(PostId, User_id, Comment)values(@PostId, @User_id, @Comment)", DBConnection.conn);
                cmdInsertComment.Parameters.AddWithValue("@PostId", postId);
                cmdInsertComment.Parameters.AddWithValue("@User_id", Session["ID"].ToString());
                cmdInsertComment.Parameters.AddWithValue("@Comment", Comment);
                DBConnection.conn.Open();
                cmdInsertComment.ExecuteNonQuery();
                DBConnection.conn.Close();
                Response.Redirect("Default.aspx");
            }
        }
    }
}
