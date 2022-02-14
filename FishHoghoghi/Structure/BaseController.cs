using FishHoghoghi.Attribute;
using System.Web.Http;

namespace FishHoghoghi.Structure
{
    [LockFilter]
    public abstract class BaseController : ApiController
    {
        public string GetToken()
        {
            return Request.Headers.Authorization?.Scheme;
        }
    }
}