using Kosha.Core.Contract.AuthenticationCode;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Unity;

namespace Kosha.Core.Common.Helper
{
    public class KoshaAuthorizeAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        private IUserContract _userContract;

        public override void OnActionExecuting(HttpActionContext context)
        {
            _userContract = (IUserContract)context.Request.GetDependencyScope().GetService(typeof(IUserContract));

            string token = context.Request.Headers.Authorization?.Parameter;

            if (string.IsNullOrEmpty(token))
            {
                var response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.Unauthorized;
                context.Response = response;
                return;
            }

            var res = _userContract.AuthorizeUserByToken(token);

            if (res == false)
            {
                var response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.Unauthorized;
                context.Response = response;
            }

            base.OnActionExecuting(context);

        }
    }
}
