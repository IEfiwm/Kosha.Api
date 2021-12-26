using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Dal;
using Microsoft.Office.Interop.Word;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WordToPDF;
using Common = FishHoghoghi.Utilities.Utility;
using Utility = FishHoghoghi.Models.Utility;

namespace FishHoghoghi.Controllers
{
    [LockFilter]
    public class ContractController : ApiController
    {
        #region Initialization

        private Application _wordApp;

        private Guid _id;

        private string _template = $@"{AppDomain.CurrentDomain.BaseDirectory}Template\template.docx";

        private static string GetDocPath(string id, bool hostname = true, string extention = "docx")
        {
            return $@"{(hostname ? AppDomain.CurrentDomain.BaseDirectory : "")}GeneratedPdf\template{id}.{extention}";
        }

        private static string GetPublicDirectory(string filename = "")
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}Content\Files\{filename}";
        }

        public ContractController()
        {
            _id = Guid.NewGuid();

            _wordApp = new Application();
        }

        #endregion

        [NoCache]
        public HttpResponseMessage Get(string username)
        {
            try
            {
                if (File.Exists(GetDocPath(username.ToString(), true, "pdf")) && File.GetLastWriteTime(GetDocPath(username.ToString(), true, "pdf")).Date < DateTime.Now.Date || ConfigurationManager.AppSettings["Cache"].ToString() == "false")
                {
                    File.Delete(GetDocPath(username.ToString(), true, "pdf"));
                }
                else if (File.Exists(GetDocPath(username.ToString(), true, "pdf")) && ConfigurationManager.AppSettings["Cache"].ToString() == "true")
                {
                    var res = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(Utility.StreamFile(GetDocPath(username.ToString(), true, "pdf")))
                    };

                    res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = Guid.NewGuid().ToString("N") + ".pdf"
                    };

                    return res;
                }

                Common.Log("Document null => " + $@"Cache failed");

                var user = Contract.GetUserContract(username, out System.Data.DataTable dataSource);

                if (user == null)
                {
                    return Common.SetBadResponse();
                }

                File.Copy(_template, GetDocPath(_id.ToString()));

                PreaperDocument(user, dataSource);

                ConvertWordToPdf(GetDocPath(_id.ToString()), GetDocPath(username.ToString(), true, "pdf"));

                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(Utility.StreamFile(GetDocPath(username.ToString(), true, "pdf")))
                };

                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = Guid.NewGuid().ToString("N") + ".pdf"
                };

                File.Delete(GetDocPath(_id.ToString()));

                //File.Delete(GetDocPath(_id.ToString(), true, "pdf"));

                return result;
            }
            catch (Exception exp)
            {
                Common.Log(exp);

                return Common.SetIntervalErrorResponse();
            }
        }

        [NoCache]
        [HttpGet]
        [Route("Contract/GetLink/{username}")]
        public HttpResponseMessage GetLink(string username)
        {
            try
            {
                if (File.Exists(GetPublicDirectory(username + ".pdf")) && File.GetLastWriteTime(GetPublicDirectory(username + ".pdf")).Date < DateTime.Now.Date || ConfigurationManager.AppSettings["Cache"].ToString() == "false")
                {
                    File.Delete(GetPublicDirectory(username + ".pdf"));
                }
                else if (File.Exists(GetPublicDirectory(username + ".pdf")) && ConfigurationManager.AppSettings["Cache"].ToString() == "true")
                {
                    return Common.Response(new { link = ConfigurationManager.AppSettings["HostName"].ToString() + "/Content/Files/" + username + ".pdf" });
                }

                var user = Contract.GetUserContract(username, out System.Data.DataTable dataSource);

                if (user == null)
                {
                    return Common.SetBadResponse();
                }

                File.Copy(_template, GetDocPath(_id.ToString()));

                PreaperDocument(user, dataSource);

                ConvertWordToPdf(GetDocPath(_id.ToString()), GetDocPath(_id.ToString(), true, "pdf"));

                File.Copy(GetDocPath(_id.ToString(), true, "pdf"), GetPublicDirectory(username + ".pdf"));

                File.Delete(GetDocPath(_id.ToString()));

                File.Delete(GetDocPath(_id.ToString(), true, "pdf"));

                return Common.Response(new { link = ConfigurationManager.AppSettings["HostName"].ToString() + "/Content/Files/" + username + ".pdf" });
            }
            catch (Exception exp)
            {
                Common.Log(exp);

                return Common.SetIntervalErrorResponse();
            }
        }

        void PreaperDocument(DataRow user, System.Data.DataTable dataSource)
        {
            var doc = Utility.GetDocument(GetDocPath(_id.ToString()), _wordApp);

            if (doc == null)
            {
                Common.Log("Document null => " + $@"{GetDocPath(_id.ToString())} ==> ACCESS DENIED !!!!!!!");

                throw new Exception();
            }

            for (int i = 0; i < dataSource.Columns.Count; i++)
            {
                Common.Log(dataSource.Columns[i].ToString());

                if (dataSource.Columns[i].ToString().Contains("تاریخ"))
                {
                    PersianCalendar calendar = new PersianCalendar();

                    DateTime myTime = DateTime.Parse(user.ItemArray[i].ToString());

                    Utility.ReplaceBookMarkText(doc, dataSource.Columns[i].ToString().Replace(' ', '_'), calendar.GetDayOfMonth(myTime).ToString() + "/" + calendar.GetMonth(myTime).ToString() + "/" + calendar.GetYear(myTime).ToString());
                }
                else
                {
                    if (user.ItemArray[i].ToString().Contains(".") || user.ItemArray[i].ToString().Contains("/"))
                    {
                        Utility.ReplaceBookMarkText(doc, dataSource.Columns[i].ToString().Replace(' ', '_'), Utility.MoneyFormater(user.ItemArray[i].ToString()));
                    }
                    else
                    {
                        Utility.ReplaceBookMarkText(doc, dataSource.Columns[i].ToString().Replace(' ', '_'), user.ItemArray[i].ToString());
                    }
                }
            }

            _wordApp.Documents.Close();

            _wordApp.Quit();
        }

        void ConvertWordToPdf(string sourcePath, string destinationPath)
        {
            var objWorPdf = new Word2Pdf();

            objWorPdf.InputLocation = sourcePath;

            objWorPdf.OutputLocation = (object)destinationPath;

            objWorPdf.Word2PdfCOnversion();
        }
    }
}