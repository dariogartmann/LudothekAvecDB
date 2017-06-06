using System.Web.Mvc;

namespace Ludothek.App.Controllers.Base
{
    [Authorize(Roles = "Admin")]
    public class SecureBaseController : BaseController {
    }
}
