using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace FilterUnwantedMSG_OSN
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlCommand cmdSelect = new SqlCommand("FriendList", DBConnection.conn);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@id",Session["ID"].ToString());
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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SqlCommand cmd = new SqlCommand("select Photo from Users where User_id=@User_id", DBConnection.conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@User_id", e.Row.Cells[0].Text);
                DBConnection.conn.Open();
                var ImagePath = cmd.ExecuteScalar();
                DBConnection.conn.Close();

                Image obj = (Image)(e.Row.Cells[2].FindControl("Image1"));
                obj.ImageUrl = (String)ImagePath;
            }
        }
    }
}