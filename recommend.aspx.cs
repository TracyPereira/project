using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FilterUnwantedMSG_OSN
{
    public partial class recommend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlCommand cmdSelect = new SqlCommand("select TOP 100 c.cid,co.course_name,co.url  from cour as c left join dbo.coursetype_master as co On c.cid = co.cid where c.uid = @user", DBConnection.conn);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}