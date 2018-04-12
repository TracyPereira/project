using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace FilterUnwantedMSG_OSN
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            if (FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/ProfilePic/") + txtUsername.Text + filename);

                string FilePath = "/ProfilePic/" + txtUsername.Text + filename;

                SqlCommand cmdInsert = new SqlCommand("RegisterUser", DBConnection.conn);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmdInsert.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmdInsert.Parameters.AddWithValue("@Fname", txtFirst.Text);
                cmdInsert.Parameters.AddWithValue("@Mname", txtMiddle.Text);
                cmdInsert.Parameters.AddWithValue("@Lname", txtLast.Text);
                cmdInsert.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmdInsert.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdInsert.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmdInsert.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmdInsert.Parameters.AddWithValue("@State", txtState.Text);
                cmdInsert.Parameters.AddWithValue("@City", txtCity.Text);
                cmdInsert.Parameters.AddWithValue("@Photo", FilePath);
                cmdInsert.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                DBConnection.conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmdInsert);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string id = dt.Rows[0]["trans_id"].ToString();
                DBConnection.conn.Close();
                foreach (ListItem item in CheckBoxList1.Items)//chkInterest.Items)
                {
                    using (SqlCommand cmd1 = new SqlCommand("insert into dbo.cour(cid,uid) values(@cid,@uid)", DBConnection.conn))
                    {

                        string i1 = string.Empty;

                        if (item.Selected)
                        {
                            cmd1.Parameters.AddWithValue("@uid", id);
                            cmd1.Parameters.AddWithValue("@cid", item.Value);
                            DBConnection.conn.Open();
                            cmd1.ExecuteNonQuery(); DBConnection.conn.Close();
                        }

                    }
                    string msg = Convert.ToString(cmdInsert.Parameters["@ErrorMsg"].Value);
                    if (msg == "User Insert Successfully")
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        lblShow.Text = msg;
                    }
                }

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtAddress.Text = txtCity.Text = txtDOB.Text = txtEmail.Text = txtFirst.Text = txtLast.Text = txtMiddle.Text = txtPassword.Text = txtPhone.Text = txtState.Text = txtUsername.Text = string.Empty;
        }
    }
}