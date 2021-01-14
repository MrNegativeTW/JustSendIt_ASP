using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

namespace JustSendIt_ASP {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.Default;
        }

        protected void Upload_File_Click(object sender, EventArgs e) {
            if (FileUpload.HasFile) {
                StringBuilder sb = new StringBuilder();
                MD5 md5 = MD5.Create();
                foreach (byte b in md5.ComputeHash(FileUpload.FileBytes)) {
                    sb.Append(b.ToString("x2").ToLower());
                }
                sb.ToString();

                // System.Text.Encoding encode = System.Text.Encoding.GetEncoding("big5");
                // StreamReader sr = new StreamReader(FileUpload.FileName, encode);

                string fileName = FileUpload.FileName;
                string fileNameMD5 = sb.ToString();
                string fileCode = sb.ToString(0, 6);
                string filePath = "~/Storage/" + FileUpload.FileName;
                if (Insert_Data_To_Sql(fileName, fileNameMD5, fileCode, filePath)) {
                    FileUpload.SaveAs(Server.MapPath(filePath));
                    FileUploadSuccessMessage.Visible = true;
                    //FileUploadSuccessMessage.Text = fileName + " | " + fileNameMD5 + " | " + fileCode;
                    FileUploadSuccessFileCode.Visible = true;
                    //FileUploadSuccessFileCode.Text = FileUpload.FileName;
                    FileUploadSuccessFileCode.Text = fileCode;
                } else {
                    FileUploadSuccessFileCode.Visible = true;
                    FileUploadSuccessFileCode.Text = "Shit, here we go again.";
                }
            }
        }

        protected void Receive_File_Click(object sender, EventArgs e) {
            if (TextBox1.Text.Length == 6) { 
                Response.Redirect("~/DownloadFile.ashx?fileCode=" + TextBox1.Text);
            }
        }

        private Boolean Insert_Data_To_Sql(string fileName, string fileNameMD5, string fileCode, string filePath) {
            SqlConnection objCon;
            SqlCommand objCmd;
            string strDbCon, strSQL;
            int count;

            // Database connect string
            strDbCon = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                       "AttachDbFilename=" +
                       Server.MapPath("App_Data\\justsendit.mdf") +
                       ";Integrated Security=True";

            // SQL Query
            strSQL = "INSERT INTO [dbo].[Table] (fileName, fileNameMD5, fileCode, filePath) VALUES ('";
            strSQL += fileName + "','";
            strSQL += fileNameMD5 + "','";
            strSQL += fileCode + "','";
            strSQL += filePath + "')";

            // Create SQL Connection object
            objCon = new SqlConnection(strDbCon);
            objCon.Open();

            objCmd = new SqlCommand(strSQL, objCon);

            // Excute SQL Query
            count = objCmd.ExecuteNonQuery();

            // Close connection
            objCon.Close();

            if (count == 1) {
                return true;
            } else {
                return false;
            }
        }

    }
}