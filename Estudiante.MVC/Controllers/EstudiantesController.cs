using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Estudiante.MVC.Models;

namespace Estudiante.MVC.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly ILogger<EstudiantesController> _logger;

        public EstudiantesController(ILogger<EstudiantesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
         
            return View();
        }

  public IActionResult Listado()
        {
            return View();
        }


        public IActionResult Registro()
        {
            return View("Estudiante");
        }

        public IActionResult Editar()
        {
            return View("Estudiante");
        }

        public IActionResult Consultar()
        {
            return View("Estudiante");
        }

       

    }
}
