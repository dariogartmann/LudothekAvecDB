using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Ludothek.App.Controllers.Base
{
    public class BaseController : System.Web.Mvc.Controller {

        public Guid GetCurrentUserId() {
            var user = HttpContext.User.Identity;
            if (user != null) {
                return new Guid(user.GetUserId());
            }
            return Guid.Empty;
        }
    }
}
