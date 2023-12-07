using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos _repositorioProyectos;

        public HomeController(IRepositorioProyectos repositorioProyectos)
        {
            _repositorioProyectos = repositorioProyectos;
        }

        public IActionResult Index()
        {
            var proyectos = _repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            
            var modelo = new HomeIndexViewModel() 
            { 
                Proyectos = proyectos
            };
            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}