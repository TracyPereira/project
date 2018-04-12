using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

namespace FilterUnwantedMSG_OSN
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmdcheck = new SqlCommand("select User_id,(Fname+' '+ Mname+' '+Lname)as Name,Photo from Users where Username=@Username and Password=@Password", DBConnection.conn);
            cmdcheck.CommandType = CommandType.Text;
            cmdcheck.Parameters.AddWithValue("@Username",txtUsername.Text);
            cmdcheck.Parameters.AddWithValue("@Password", txtPassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmdcheck);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["ID"] = dt.Rows[0]["User_id"].ToString();
                Session["Name"] = dt.Rows[0]["Name"].ToString();
                Session["ProfilePic"] = dt.Rows[0]["Photo"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Messege", "alert('Invalid Username and Password')", true);
            }
        }
        public void course1()
        {

         //   string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    //Save file path 
                    string path=Directory.GetFiles(@"H:\Project_2017_18\facebook recommendation", "Web_Development.xlsx").Single();
                    //string path = string.Concat(Server.MapPath("~/TempFiles/"), FileUpload1.FileName);
                    //Save File as Temp then you can delete it if you want 
                   // FileUpload1.SaveAs(path);
                    //string path = @"C:\Users\Johnney\Desktop\ExcelData.xls"; 
                    //For Office Excel 2010  please take a look to the followng link  http://social.msdn.microsoft.com/Forums/en-US/exceldev/thread/0f03c2de-3ee2-475f-b6a2-f4efb97de302/#ae1e6748-297d-4c6e-8f1e-8108f438e62e 
                    string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);

                    // Create Connection to Excel Workbook 
                    using (OleDbConnection connection1 =
                                 new OleDbConnection(excelConnectionString))
                    {
                        OleDbCommand command = new OleDbCommand("Select * FROM [Sheet1$]", connection1);

                        connection1.Open();
                        DataSet ds = new DataSet();
                        OleDbDataAdapter oda = new OleDbDataAdapter(command);
                        connection1.Close();
                        oda.Fill(ds);
                        DataTable Exceldt = ds.Tables[0];
                        
                        SqlBulkCopy objbulk = new SqlBulkCopy(DBConnection.conn);
                        //assigning Destination table name    
                        objbulk.DestinationTableName = "coursetype_master";
                        //Mapping Table column    
                        objbulk.ColumnMappings.Add("cid", "cid");
                        objbulk.ColumnMappings.Add("website", "website");
                        objbulk.ColumnMappings.Add("course_name", "course_name");
                        objbulk.ColumnMappings.Add("url", "url");  
                        objbulk.ColumnMappings.Add("time", "time");
                        //inserting Datatable Records to DataBase    
                        DBConnection.conn.Open();
                        objbulk.WriteToServer(Exceldt);
                        DBConnection.conn.Close();
                    }
                
            
        }
        public void course2()
        {

          //  string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
  
                    //Save file path
                    string path=Directory.GetFiles(@"H:\Project_2017_18\facebook recommendation", "AWS.xlsx").Single();
                    //string path = string.Concat(Server.MapPath("~/TempFiles/"), FileUpload1.FileName);
                    //Save File as Temp then you can delete it if you want 
                  //  FileUpload1.SaveAs(path);
                    //string path = @"C:\Users\Johnney\Desktop\ExcelData.xls"; 
                    //For Office Excel 2010  please take a look to the followng link  http://social.msdn.microsoft.com/Forums/en-US/exceldev/thread/0f03c2de-3ee2-475f-b6a2-f4efb97de302/#ae1e6748-297d-4c6e-8f1e-8108f438e62e 
                    string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);

                    // Create Connection to Excel Workbook 
                    using (OleDbConnection connection1 =
                                 new OleDbConnection(excelConnectionString))
                    {
                        OleDbCommand command = new OleDbCommand("Select *  FROM [Sheet1$]", connection1);

                        connection1.Open();
                        DataSet ds = new DataSet();
                        OleDbDataAdapter oda = new OleDbDataAdapter(command);
                        connection1.Close();
                        oda.Fill(ds);
                        DataTable Exceldt = ds.Tables[0];
                       
                        SqlBulkCopy objbulk = new SqlBulkCopy(DBConnection.conn);
                        //assigning Destination table name    
                        objbulk.DestinationTableName = "coursetype_master";
                        //Mapping Table column    
                        objbulk.ColumnMappings.Add("cid", "cid");
                        objbulk.ColumnMappings.Add("website", "website");
                        objbulk.ColumnMappings.Add("course_name", "course_name");
                        objbulk.ColumnMappings.Add("url", "url");
                        objbulk.ColumnMappings.Add("time", "time");
                        //inserting Datatable Records to DataBase    
                        DBConnection.conn.Open();
                        objbulk.WriteToServer(Exceldt);
                        DBConnection.conn.Close();
                    }
           
        }
    }
  

}