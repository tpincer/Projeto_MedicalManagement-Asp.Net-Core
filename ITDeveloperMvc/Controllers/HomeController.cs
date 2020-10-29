using ITDeveloperMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace ITDeveloperMvc.Controllers
{
    [Route("")]
    [Route("gestao-de-pacientes")]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("pagina-inicial")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("sobre/{id}/{paciente}/{categoria?}")]
        [Route("quem-somos")]
        [Route("sobre-nos")]
        public IActionResult Sobre(int id, string pacientes, string categoria)
        {
            return View();
        }

        [Route("privacidade")]
        [Route("politica-de-privacidade")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro")]
        [Route("erro-encontrado")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("icones")]
        public IActionResult Icones()
        {
            return View();
        }
    }
}
