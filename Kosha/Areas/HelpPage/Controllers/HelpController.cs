//namespace FishHoghoghi.Areas.HelpPage.Controllers
//{
//    using Microsoft.CSharp.RuntimeBinder;
//    using System;
//    using System.Runtime.CompilerServices;
//    using System.Web.Http;
//    using System.Web.Mvc;

//    public class HelpController : Controller
//    {
//        private const string ErrorViewName = "Error";

//        public HelpController()
//        {
//        }

//        public HelpController(HttpConfiguration config)
//        {
//            Configuration = config;
//        }

//        public ActionResult Api(string apiId)
//        {
//            if (!string.IsNullOrEmpty(apiId))
//            {
//                HelpPageApiModel helpPageApiModel = Configuration.GetHelpPageApiModel(apiId);
//                if (helpPageApiModel > null)
//                {
//                    return base.View(helpPageApiModel);
//                }
//            }
//            return View("Error");
//        }

//        public ActionResult Index()
//        {
//            if (<> o__7.<> p__0 == null)
//            {
//                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) };
//                <> o__7.<> p__0 = CallSite<Func<CallSite, object, IDocumentationProvider, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DocumentationProvider", typeof(HelpController), argumentInfo));
//            }
//            <> o__7.<> p__0.Target(<> o__7.<> p__0, base.get_ViewBag(), Configuration.get_Services().GetDocumentationProvider());
//            return View(Configuration.get_Services().GetApiExplorer().get_ApiDescriptions());
//        }

//        public ActionResult ResourceModel(string modelName)
//        {
//            if (!string.IsNullOrEmpty(modelName) && Configuration.GetModelDescriptionGenerator().GeneratedModels.TryGetValue(modelName, out ModelDescription description))
//            {
//                return base.View(description);
//            }
//            return View("Error");
//        }

//        public HttpConfiguration Configuration { get; private set; }
//}
//}

