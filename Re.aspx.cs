using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using FilterUnwantedMSG_OSN;

public partial class Re : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmdSelect = new SqlCommand("select c.cid,co.course_name from dbo.cour as c join dbo.coursetype_master as co On c.cid = co.cid where c.uid = @user", DBConnection.conn);
        cmdSelect.CommandType = CommandType.Text;
        cmdSelect.Parameters.AddWithValue("@user", Session["ID"].ToString());
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