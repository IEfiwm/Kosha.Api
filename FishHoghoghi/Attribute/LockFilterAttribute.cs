using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FishHoghoghi.Attribute
{
    public class LockFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (DateTime.Now.Month != 1)
            {
                var response = new HttpResponseMessage();

                response.StatusCode = System.Net.HttpStatusCode.Unauthorized;

                //response.Content = new StringContent("{message: \"احراز هویت تایید نشد.\"}");

                //response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                actionContext.Response = response;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}