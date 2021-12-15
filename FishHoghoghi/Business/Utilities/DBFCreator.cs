using FishHoghoghi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FishHoghoghi.Business.Utilities
{
    public static class DBFCreator
    {
        public static HttpResponseMessage DataSetIntoDBF(string fileName,  DataSet dataSet)
        {
            ArrayList list = new ArrayList();
            var Path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/DBF/");
            if (File.Exists(Path + fileName + ".dbf"))
            {
                File.Delete(Path + fileName + ".dbf");
            }

            string createSql = "create table " + fileName + " (";

            foreach (DataColumn dc in dataSet.Tables[0].Columns)
            {
                string fieldName = dc.ColumnName;

                string type = dc.DataType.ToString();

                switch (type)
                {
                    case "System.String":
                        type = "varchar(100)";
                        break;

                    case "System.Boolean":
                        type = "varchar(10)";
                        break;

                    case "System.Int32":
                        type = "int";
                        break;

                    case "System.Double":
                        type = "Double";
                        break;

                    case "System.DateTime":
                        type = "varchar(100)";
                        break;

                    case "System.Decimal":
                        type = "decimal";
                        break;
                }

                createSql = createSql + "[" + fieldName + "]" + " " + type + ",";

                list.Add(fieldName);
            }

            createSql = createSql.Substring(0, createSql.Length - 1) + ")";

            OleDbConnection con = new OleDbConnection(GetConnection(Path));

            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = con;

            con.Open();

            cmd.CommandText = createSql;

            cmd.ExecuteNonQuery();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string insertSql = "insert into " + fileName + " values(";

                for (int i = 0; i < list.Count; i++)
                {
                    insertSql = insertSql + "'" + ReplaceEscape(row[list[i].ToString()].ToString()) + "',";
                }

                insertSql = insertSql.Substring(0, insertSql.Length - 1) + ")";

                cmd.CommandText = insertSql;

                cmd.ExecuteNonQuery();
            }

            con.Close();
            Stream file = new MemoryStream();
            FileStream fs = System.IO.File.OpenRead(Path + fileName + ".dbf");
            byte[] buffer = new byte[1024];

            int byteRead = 0;

            do
            {
                byteRead = fs.Read(buffer, 0, 1024);

                file.Write(buffer, 0, byteRead);

            }
            while (byteRead != 0);

            fs.Close();
            file.Close();
            

            HttpResponseMessage response = new HttpResponseMessage();

            response.StatusCode = HttpStatusCode.Moved;

            response.Content = new StreamContent(file);

            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "DBF_" + Guid.NewGuid().ToString("N").Remove(6) + ".dbf"
            };

            var res = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(Utility.StreamFile(Path + fileName + ".dbf"))
            };

            res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName + ".dbf"
            };

            File.Delete(Path + fileName + ".dbf");

            return res;
        }

        private static string GetConnection(string path)
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=dBASE IV;";
        }

        public static string ReplaceEscape(string str)
        {
            str = str.Replace("'", "''");
            return str;
        }

    }
}