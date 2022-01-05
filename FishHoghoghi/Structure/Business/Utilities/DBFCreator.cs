using clbModels;
using FishHoghoghi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using zarkiaclb;

namespace FishHoghoghi.Business.Utilities
{
    public static class DBFCreator
    {
        public static HttpResponseMessage DataSetIntoDBF(string fileName, DataSet dataSet, TypeOfDBFFile typeOfDBFFile = TypeOfDBFFile.All)
        {
            ArrayList list = new ArrayList();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Reports/DBF/");

            if (File.Exists(path + fileName + ".dbf"))
            {
                File.Delete(path + fileName + ".dbf");
            }

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

                list.Add(fieldName);
            }

            if (typeOfDBFFile == TypeOfDBFFile.All)
            {
                clsSalInsurenceDisk cls = new clsSalInsurenceDisk();

                // اطلاعات پرسنل که قرار است برای ساخت دیسکت بیمه، به تابع ساخت دیسکت، ارسال شوند در این لیست ذخیره می شوند
                List<SalInsurenceDiskPersonal> PersonalsDiskList = new List<SalInsurenceDiskPersonal>() { };

                // قرار دادن اطلاعات پرسنل در لیست مربوطه
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    SalInsurenceDiskPersonal sidp = new SalInsurenceDiskPersonal()
                    {
                        DSW_ID = row[0].ToString(),
                        DSW_YY = Convert.ToInt32(row[1].ToString()),
                        DSW_MM = Convert.ToInt32(row[2].ToString()),
                        DSW_LISTNO = row[3].ToString(),
                        DSW_ID1 = row[4].ToString(),
                        DSW_FNAME = row[5].ToString(),
                        DSW_LNAME = row[6].ToString(),
                        DSW_DNAME = row[7].ToString(),
                        DSW_IDNO = row[8].ToString(),
                        DSW_IDPLC = row[9].ToString(),
                        DSW_IDATE = row[10].ToString(),
                        DSW_BDATE = row[11].ToString(),
                        DSW_SEX = row[12].ToString(),
                        DSW_NAT = row[13].ToString(),
                        DSW_OCP = row[14].ToString(),
                        DSW_SDATE = row[15].ToString(),
                        DSW_EDATE = row[16].ToString(),
                        DSW_DD = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[17].ToString()))),
                        DSW_ROOZ = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[18].ToString()))),
                        DSW_MAH = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[19].ToString()))),
                        DSW_MAZ = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[20].ToString()))),
                        DSW_MASH = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[21].ToString()))),
                        DSW_TOTL = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[22].ToString()))),
                        DSW_BIME = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[23].ToString()))),
                        DSW_PRATE = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[24].ToString()))),
                        DSW_JOB = row[25].ToString(),
                        PER_NATCOD = row[26].ToString(),

                    };
                    PersonalsDiskList.Add(sidp);
                }

                cls.CreateDBFPersonal(PersonalsDiskList, path);
            }
            else
            {
                clsSalInsurenceDisk cls = new clsSalInsurenceDisk();

                var row = dataSet.Tables[0].Rows[0];

                cls.CreateDBFFactory(new SalInsurenceDiskFactory
                {
                    DSK_ID = row[0].ToString(),
                    DSK_NAME = row[1].ToString(),
                    DSK_FARM = row[2].ToString(),
                    DSK_ADRS = row[3].ToString(),
                    DSK_KIND = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[4].ToString()))),
                    DSK_YY = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[5].ToString()))),
                    DSK_MM = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[6].ToString()))),
                    DSK_LISTNO = row[7].ToString(),
                    DSK_DISC = row[8].ToString(),
                    DSK_NUM = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[9].ToString()))),
                    DSK_TDD = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[10].ToString()))),
                    DSK_TROOZ = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[11].ToString()))),
                    DSK_TMAH = Convert.ToInt64(Math.Round(Convert.ToDecimal(row[12].ToString()))),////
                    DSK_TMAZ = Convert.ToInt64(Math.Round(Convert.ToDecimal(row[13].ToString()))),
                    DSK_TMASH = Convert.ToInt64(Math.Round(Convert.ToDecimal(row[14].ToString()))),
                    DSK_TTOTL = Convert.ToInt64(Math.Round(Convert.ToDecimal(row[15].ToString()))),
                    DSK_TBIME = Convert.ToInt64(Math.Round(Convert.ToDecimal(row[16].ToString()))),
                    DSK_TKOSO = Convert.ToInt64(Math.Round(Convert.ToDecimal(row[17].ToString()))),
                    DSK_BIC = Convert.ToInt64(Math.Round(Convert.ToDecimal(row[18].ToString()))),
                    DSK_RATE = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[19].ToString()))),
                    DSK_PRATE = Convert.ToInt32(Math.Round(Convert.ToDecimal(row[20].ToString()))),
                    DSK_BIMH = Convert.ToInt64(Math.Round(Convert.ToDecimal(row[21].ToString()))),
                    MON_PYM = row[22].ToString()
                }, path);
            }

            Stream stream = new MemoryStream();

            StreamWriter file = new StreamWriter(stream, new UTF8Encoding(false));

            FileStream fs = System.IO.File.OpenRead(path + fileName + ".dbf");

            byte[] buffer = new byte[1024];

            int byteRead = 0;

            do
            {
                byteRead = fs.Read(buffer, 0, 1024);

                file.Write(buffer);
            }
            while (byteRead != 0);

            fs.Close();

            file.Close();

            var res = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(FishHoghoghi.Models.Utility.StreamFile(path + fileName + ".dbf"))
            };

            res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName + ".dbf"
            };

            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/dbase");

            //File.Delete(Path + fileName + ".dbf");

            return res;
        }

        public static string ReplaceEscape(string str)
        {
            str = str.Replace("'", "''");
            return str;
        }
    }
}