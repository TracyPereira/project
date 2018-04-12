using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace FilterUnwantedMSG_OSN
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBConnection.conn.Close();
            if (!IsPostBack)
            {
                // conn = new SqlConnection(cs);
                DBConnection.conn.Open();
                SqlCommand comm = new SqlCommand("truncate table coursetype_master ", DBConnection.conn);
                comm.ExecuteNonQuery();
                DBConnection.conn.Close();
                course1();
                course2();
            } 
        }
        public void course1()
        {

            //   string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            //Save file path 
            string path = Directory.GetFiles(@"H:\Project_2017_18\facebook recommendation", "Web_Development.xlsx").Single();
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
            string path = Directory.GetFiles(@"H:\Project_2017_18\facebook recommendation", "AWS.xlsx").Single();
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