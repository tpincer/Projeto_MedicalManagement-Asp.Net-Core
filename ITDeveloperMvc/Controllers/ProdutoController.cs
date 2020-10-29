using Microsoft.AspNetCore.Mvc;

namespace ITDeveloperMvc.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            return View();
        }
    }
}
