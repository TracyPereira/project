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
    public partial class WebForm7 : System.Web.UI.Page
    {
        public static List<string> lstBadWords = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlFriend();
                FillRepeater();
            }
        }

        protected void FillRepeater()
        {
            SqlDataAdapter daGetPosts = new SqlDataAdapter("Select PostId, FromUser, ToUser, PostContent, Date from dbo.PostData where FromUser =@FromUser", DBConnection.conn);
            daGetPosts.SelectCommand.Parameters.AddWithValue("@FromUser", Session["ID"].ToString());
            DataTable dtGetPosts = new DataTable();
            daGetPosts.Fill(dtGetPosts);
            rpParent.DataSource = dtGetPosts;
            rpParent.DataBind();
        }

        protected void FillddlFriend()
        {
            SqlCommand cmdSelect = new SqlCommand("FriendList", DBConnection.conn);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@id", Session["ID"].ToString());
            SqlDataAdapter daSelect = new SqlDataAdapter(cmdSelect);
            DataTable dtSelect = new DataTable();
            daSelect.Fill(dtSelect);
            if (dtSelect.Rows.Count > 0)
            {
                ddlFriend.DataSource = dtSelect;
                ddlFriend.DataBind();
                ddlFriend.Items.Insert(0, new ListItem("Select Friend", "0"));
            }
        }
        protected void rpParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                int PostId = Convert.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[0]);

                SqlDataAdapter daGetComments = new SqlDataAdapter("select cm.PostId, cm.User_id, cm.Comment,(u.fname+' '+u.Lname)as Name,u.Photo from dbo.CommentMaster cm inner join dbo.Users u on (cm.User_Id=u.User_id)  where cm.PostId=@PostId", DBConnection.conn);
                daGetComments.SelectCommand.Parameters.AddWithValue("@PostId", PostId);
                DataTable dtGetComment = new DataTable();
                daGetComments.Fill(dtGetComment);
                Repeater rp2 = (Repeater)e.Item.FindControl("rpChild");
                rp2.DataSource = dtGetComment;
                rp2.DataBind();
            }
        }


        protected void btnPost_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (txtPost.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Messege", "alert('Please Enter Post Text')", true);
            }
            else
            {
                SqlCommand cmdInsert = new SqlCommand("insert into PostData (FromUser,ToUser, PostContent, Date)values(@FromUser, @ToUser,@PostContent, @Date)", DBConnection.conn);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Parameters.AddWithValue("@FromUser", Session["ID"].ToString());
                cmdInsert.Parameters.AddWithValue("@ToUser", ddlFriend.SelectedValue);
                cmdInsert.Parameters.AddWithValue("@PostContent", txtPost.Text);
                cmdInsert.Parameters.AddWithValue("@Date", DateTime.Now.Date);
                DBConnection.conn.Open();
                cmdInsert.ExecuteNonQuery();
                DBConnection.conn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Message post successfully')", true);
                txtPost.Text = string.Empty;
            }
        }

        protected void FetchBadWords()
        {
            SqlCommand cmdselect = new SqlCommand("select Word From Directory", DBConnection.conn);
            SqlDataAdapter daselect = new SqlDataAdapter(cmdselect);
            DataTable dt = new DataTable();
            daselect.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    lstBadWords.Add((string)row[0]);
                }
            }
        }


    }
}