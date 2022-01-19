using FishHoghoghi.Attribute;
using FishHoghoghi.Business.Dal;
using FishHoghoghi.Extentions;
using FishHoghoghi.Models.Contract;
using FishHoghoghi.Utilities;
using MD.PersianDateTime;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
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

        private string _contractTemplateName = "template-public.docx";

        private string _template = $@"{AppDomain.CurrentDomain.BaseDirectory}Template\";

        private static string GetDocPath(string id, bool hostname = true, string extention = "docx", string defaultPath = "")
        {
            if (defaultPath != "")
                return $@"{(hostname ? AppDomain.CurrentDomain.BaseDirectory : "")}GeneratedPdf\{defaultPath}\template{id}.{extention}";
            return $@"{(hostname ? AppDomain.CurrentDomain.BaseDirectory : "")}GeneratedPdf\template{id}.{extention}";
        }

        private static string GetDocDirectoryPath(bool hostname = true)
        {
            return $@"{(hostname ? AppDomain.CurrentDomain.BaseDirectory : "")}GeneratedPdf";
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

                var user = Contract.GetUserContract(username, default(long), out System.Data.DataTable dataSource);

                if (user == null)
                {
                    return Common.SetBadResponse();
                }

                File.Copy(_template + _contractTemplateName, GetDocPath(_id.ToString()));

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
        [Route("Contract/Get/{username}/{projectId}/{startdate}/{enddate}")]
        public HttpResponseMessage Get(string username, long projectId, string startdate, string enddate)
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

                //var user = Contract.GetUserContract(username, projectId, out System.Data.DataTable dataSource, PersianDateTime.Parse(startdate.Replace("-", "/")).ToString("yyyy/MM/dd"), PersianDateTime.Parse(enddate.Replace("-", "/")).ToString("yyyy/MM/dd"), Math.Round(((double)(PersianDateTime.Parse(enddate.Replace("-", "/")) - PersianDateTime.Parse(startdate.Replace("-", "/"))).Days / 30)).ToString());

                var user = Contract.GetUserContract(
                    username,
                    projectId,
                    out System.Data.DataTable dataSource,
                    CommonHelper.ConvertToEnglishNumber(MD.PersianDateTime.PersianDateTime.Parse(startdate.Replace("-", "/")).ToString("yyyy/MM/dd")),
                    CommonHelper.ConvertToEnglishNumber(MD.PersianDateTime.PersianDateTime.Parse(enddate.Replace("-", "/")).ToString("yyyy/MM/dd")),
                    Math.Round(((double)(MD.PersianDateTime.PersianDateTime.Parse(enddate.Replace("-", "/")) - MD.PersianDateTime.PersianDateTime.Parse(startdate.Replace("-", "/"))).Days / 30)).ToString());

                if (user == null)
                {
                    return Common.SetBadResponse();
                }

                File.Copy(_template + Common.GetContractTemplateName(projectId), GetDocPath(_id.ToString()));

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
        [HttpPost]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetAll(ContractListParameters model)
        {
            var tasks = new List<Task>();

            try
            {
                var zipFileName = "AllContracts_" + DateTime.Now.ToString("yyyy-MM-dd hh-mm");

                var zipFilePath = GetDocDirectoryPath(true) + "\\" + zipFileName;

                if (Directory.Exists(zipFilePath))
                {
                    foreach (FileInfo file in new DirectoryInfo(zipFilePath).GetFiles())
                    {
                        file.Delete();
                    }
                    Directory.Delete(zipFilePath);
                }

                Directory.CreateDirectory(zipFilePath);

                foreach (var username in model.usernameList)
                {
                    await System.Threading.Tasks.Task.Run(() =>
                    {
                        _id = Guid.NewGuid();

                        _wordApp = new Application();

                        if (File.Exists(GetDocPath(username.ToString(), true, "pdf", zipFileName)) && File.GetLastWriteTime(GetDocPath(username.ToString(), true, "pdf", zipFileName)).Date < DateTime.Now.Date || ConfigurationManager.AppSettings["Cache"].ToString() == "false")
                        {
                            File.Delete(GetDocPath(username.ToString(), true, "pdf", zipFileName));
                        }
                        else if (File.Exists(GetDocPath(username.ToString(), true, "pdf", zipFileName)) && ConfigurationManager.AppSettings["Cache"].ToString() == "true")
                        {
                            var res = new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new ByteArrayContent(Utility.StreamFile(GetDocPath(username.ToString(), true, "pdf", zipFileName)))
                            };

                            res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                            {
                                FileName = Guid.NewGuid().ToString("N") + ".pdf"
                            };
                        }

                    //Common.Log("Document null => " + $@"Cache failed");

                        var user = Contract.GetUserContract(
                            username,
                            model.projectId,
                            out System.Data.DataTable dataSource,
                            CommonHelper.ConvertToEnglishNumber(MD.PersianDateTime.PersianDateTime.Parse(model.startdate.Replace("-", "/")).ToString("yyyy/MM/dd")),
                            CommonHelper.ConvertToEnglishNumber(MD.PersianDateTime.PersianDateTime.Parse(model.enddate.Replace("-", "/")).ToString("yyyy/MM/dd")),
                            Math.Round(((double)(MD.PersianDateTime.PersianDateTime.Parse(model.enddate.Replace("-", "/")) - MD.PersianDateTime.PersianDateTime.Parse(model.startdate.Replace("-", "/"))).Days / 30)).ToString());

                    if (user == null)
                    {
                        continue;
                    }

                    File.Copy(_template + Common.GetContractTemplateName(model.projectId), GetDocPath(_id.ToString(), true, "docx", zipFileName));

                        PreaperDocument(user, dataSource, zipFileName);

                        ConvertWordToPdf(GetDocPath(_id.ToString(), true, "docx", zipFileName), GetDocPath(username.ToString(), true, "pdf", zipFileName));

                        File.Delete(GetDocPath(_id.ToString(), true, "docx", zipFileName));

                        //File.Delete(GetDocPath(_id.ToString(), true, "pdf"));
                    });
                }
                if (File.Exists(zipFilePath + ".zip"))
                {
                    File.Delete(zipFilePath + ".zip");
                }
                ZipHelper.CreateZipFile(zipFilePath, zipFilePath + ".zip");
                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(Utility.StreamFile(zipFilePath + ".zip"))
                };

                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = zipFileName + ".zip"
                };

                foreach (FileInfo file in new DirectoryInfo(zipFilePath).GetFiles())
                {
                    file.Delete();
                }
                Directory.Delete(zipFilePath);

                File.Delete(zipFilePath + ".zip");

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

                var user = Contract.GetUserContract(username, default(long), out System.Data.DataTable dataSource);

                if (user == null)
                {
                    return Common.SetBadResponse();
                }

                File.Copy(_template + _contractTemplateName, GetDocPath(_id.ToString()));

                PreaperDocument(user, dataSource);

                ConvertWordToPdf(GetDocPath(_id.ToString()), GetDocPath(_id.ToString(), true, "pdf"));

                File.Copy(GetDocPath(_id.ToString(), true, "pdf"), GetPublicDirectory(username + ".pdf"));

                //_wordApp.Documents.Close();

                //_wordApp.Quit();

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

        void PreaperDocument(DataRow user, System.Data.DataTable dataSource, string defaultPath = "")
        {
            var doc = Utility.GetDocument(GetDocPath(_id.ToString(), true, "docx", defaultPath), _wordApp);

            if (doc == null)
            {
                Common.Log("Document null => " + $@"{GetDocPath(_id.ToString(), true, "docx", defaultPath)} ==> ACCESS DENIED !!!!!!!");

                throw new Exception();
            }

            for (int i = 0; i < dataSource.Columns.Count; i++)
            {
                //var data = user.ItemArray[i].ToString().ToPersianNumber();

                if (dataSource.Columns[i].ToString().Contains("تاریخ"))
                {
                    PersianCalendar calendar = new PersianCalendar();

                    DateTime myTime = DateTime.Parse(user.ItemArray[i].ToString());

                    Utility.ReplaceBookMarkText(doc, dataSource.Columns[i].ToString().Replace(' ', '_'), calendar.GetDayOfMonth(myTime).ToString() + "/" + calendar.GetMonth(myTime).ToString() + "/" + calendar.GetYear(myTime).ToString());
                }
                else if (dataSource.Columns[i].ToString().Contains("کد") || dataSource.Columns[i].ToString().Contains("شماره"))
                {
                    Utility.ReplaceBookMarkText(doc, dataSource.Columns[i].ToString().Replace(' ', '_'), user.ItemArray[i].ToString());
                }
                else
                {
                    if (CommonHelper.IsNumeric(user.ItemArray[i].ToString()) && (user.ItemArray[i].ToString().Contains(".") || user.ItemArray[i].ToString().Contains("/")))
                    {
                        Utility.ReplaceBookMarkText(doc, dataSource.Columns[i].ToString().Replace(' ', '_'), Utility.MoneyFormater(user.ItemArray[i].ToString()));
                    }
                    else if (user.ItemArray[i].ToString() != "0" && user.ItemArray[i].ToString() != "" && decimal.TryParse(user.ItemArray[i].ToString(), out var res))
                    {
                        var price = decimal.Parse(user.ItemArray[i].ToString(), System.Globalization.NumberStyles.Currency);

                        Utility.ReplaceBookMarkText(doc, dataSource.Columns[i].ToString().Replace(' ', '_'), price.ToString("#,#"));
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