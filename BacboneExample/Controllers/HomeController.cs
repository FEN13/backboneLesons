using System.Web.Mvc;

namespace BacboneExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/app/views/index.html");
        }
    }
}
