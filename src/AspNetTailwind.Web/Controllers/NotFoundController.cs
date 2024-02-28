using Microsoft.AspNetCore.Mvc;
using AspNetTailwind.Web.Filters;

namespace AspNetTailwind.Web.Controllers
{
    // [ServiceFilter(typeof(AuditLogActionFilter))]
    public class NotFoundController : Controller
    {
        public IActionResult Index() => View();
    }
}