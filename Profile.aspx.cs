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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirm.Enabled = false;
                SqlCommand cmdSelect = new SqlCommand("select Username, Password, Fname, Mname, Lname, Address, Email, Phone, DOB, State, City, Photo from Users where User_id=@user_id", DBConnection.conn);
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.Parameters.AddWithValue("@User_id", Session["ID"].ToString());
                SqlDataAdapter daselect = new SqlDataAdapter(cmdSelect);
                DataTable dtSelect = new DataTable();
                daselect.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    Image1.ImageUrl = dtSelect.Rows[0]["Photo"].ToString();
                    txtUsername.Text = dtSelect.Rows[0]["Username"].ToString();
                    txtFirst.Text = dtSelect.Rows[0]["Fname"].ToString();
                    txtMiddle.Text = dtSelect.Rows[0]["Mname"].ToString();
                    txtLast.Text = dtSelect.Rows[0]["Lname"].ToString();
                    txtAddress.Text = dtSelect.Rows[0]["Address"].ToString();
                    txtEmail.Text = dtSelect.Rows[0]["Email"].ToString();
                    txtContact.Text = dtSelect.Rows[0]["Phone"].ToString();
                    txtDOB.Text = dtSelect.Rows[0]["DOB"].ToString();
                    txtState.Text = dtSelect.Rows[0]["State"].ToString();
                    txtCity.Text = dtSelect.Rows[0]["City"].ToString();

                }
            }
        }

        protected void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked == true)
            {
                txtPassword.Enabled = true;
                txtConfirm.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                txtPassword.Enabled = false;
                txtConfirm.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            SqlCommand cmdUpdate = new SqlCommand("Update Users set password=@Password where user_id=@User_id", DBConnection.conn);
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.Parameters.AddWithValue("@Password", txtConfirm.Text);
            cmdUpdate.Parameters.AddWithValue("@User_id", Session["ID"].ToString());
            DBConnection.conn.Open();
            cmdUpdate.ExecuteNonQuery();
            DBConnection.conn.Close();
            lblShow.Text = "Password Update Successfully";
            txtPassword.Enabled = false;
            txtConfirm.Enabled = false;
            chkPassword.Checked = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/ProfilePic/") + txtUsername.Text + filename);

                string FilePath = "/ProfilePic/" + txtUsername.Text + filename;

                SqlCommand cmdUpdate = new SqlCommand("Update Users set  Fname=@Fname, Mname=@Mname, Lname=@Lname, Address=@Address, Email=@Email, Phone=@Phone, DOB=@DOB, State=@State, City=@City, Photo=@Photo where User_id=@User_id", DBConnection.conn);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Parameters.AddWithValue("@Fname", txtFirst.Text);
                cmdUpdate.Parameters.AddWithValue("@Mname", txtMiddle.Text);
                cmdUpdate.Parameters.AddWithValue("@Lname", txtLast.Text);
                cmdUpdate.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmdUpdate.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdUpdate.Parameters.AddWithValue("@Phone", txtContact.Text);
                cmdUpdate.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmdUpdate.Parameters.AddWithValue("@State", txtState.Text);
                cmdUpdate.Parameters.AddWithValue("@City", txtCity.Text);
                cmdUpdate.Parameters.AddWithValue("@Photo", FilePath);
                cmdUpdate.Parameters.AddWithValue("@User_id", Session["ID"].ToString());
                DBConnection.conn.Open();
                cmdUpdate.ExecuteNonQuery();
                DBConnection.conn.Close();
                lblShow.Text = "Record Update Successfully";

            }
            else
            {
                SqlCommand cmdUpdate = new SqlCommand("Update Users set  Fname=@Fname, Mname=@Mname, Lname=@Lname, Address=@Address, Email=@Email, Phone=@Phone, DOB=@DOB, State=@State, City=@City where User_id=@User_id", DBConnection.conn);
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Parameters.AddWithValue("@Fname", txtFirst.Text);
                cmdUpdate.Parameters.AddWithValue("@Mname", txtMiddle.Text);
                cmdUpdate.Parameters.AddWithValue("@Lname", txtLast.Text);
                cmdUpdate.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmdUpdate.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdUpdate.Parameters.AddWithValue("@Phone", txtContact.Text);
                cmdUpdate.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmdUpdate.Parameters.AddWithValue("@State", txtState.Text);
                cmdUpdate.Parameters.AddWithValue("@City", txtCity.Text);

                cmdUpdate.Parameters.AddWithValue("@User_id", Session["ID"].ToString());
                DBConnection.conn.Open();
                cmdUpdate.ExecuteNonQuery();
                DBConnection.conn.Close();
                lblShow.Text = "Record Update Successfully";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}