using Microsoft.AspNetCore.Mvc;
using AspNetTailwind.Web.ViewModels;
using AspNetTailwind.Web.Filters;

namespace AspNetTailwind.Web.Controllers
{
    public class ContactUsController : Controller
    {
        public ContactUsController()
        {
        }

        [Route("contact-us")]
        public IActionResult Index() => View();
    }
}
