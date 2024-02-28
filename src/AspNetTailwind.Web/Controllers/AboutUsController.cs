using Microsoft.AspNetCore.Mvc;

namespace AspNetTailwind.Web.Controllers
{
    public class AboutUsController : Controller
    {
        [Route("about-us")]
        public IActionResult Index() => View();
    }
}
