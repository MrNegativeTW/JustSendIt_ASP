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


    public class DownloadFile : IHttpHandler {
        public void ProcessRequest(HttpContext context) {
            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            string fileCode = request.QueryString["fileCode"];

            Dictionary<string, string> FileInfoDict = Find_File_Info(context, fileCode);

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition",
                               "attachment; filename=" + FileInfoDict["fileName"] + ";");
            response.TransmitFile(context.Server.MapPath(FileInfoDict["filePath"]));
            response.Flush();
            response.End();
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        private Dictionary<string, string> Find_File_Info(HttpContext context, string fileCode) {
            SqlConnection objCon;
            SqlCommand objCmd;
            SqlDataReader objDR;
            string strDbCon, strSQL;
            Dictionary<string, string> FileInfoDict = new Dictionary<string, string>();

            // SQL Query
            strSQL = "SELECT fileName, filePath FROM [dbo].[Table] WHERE CONVERT(VARCHAR, fileCode) = '";
            strSQL += fileCode + "'";

            // Connect to database
            strDbCon = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                       "AttachDbFilename=" +
                       context.Server.MapPath("App_Data\\justsendit.mdf") +
                       ";Integrated Security=True";

            objCon = new SqlConnection(strDbCon);
            objCon.Open();

            objCmd = new SqlCommand(strSQL, objCon);

            // Excute SQL Query
            objDR = objCmd.ExecuteReader();

            // Close connection
            

            // 1c9c1b
            if (objDR.HasRows == true) {
                while (objDR.Read()) {
                    FileInfoDict.Add("fileName", objDR["fileName"].ToString());
                    FileInfoDict.Add("filePath", objDR["filePath"].ToString());
                }
                
            }
            objCon.Close();
            objDR.Close();
            return FileInfoDict;
        }
    }
}