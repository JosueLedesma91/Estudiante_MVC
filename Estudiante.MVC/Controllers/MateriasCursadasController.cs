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
    public class MateriasCursadasController : Controller
    {
        private readonly ILogger<MateriasCursadasController> _logger;

        public MateriasCursadasController(ILogger<MateriasCursadasController> logger)
        {
            _logger = logger;
        }
  public IActionResult Listado()
        {
            return View();
        }


        public IActionResult Registro()
        {
            return View("MateriaCursada");
        }

        public IActionResult Editar()
        {
            return View("MateriaCursada");
        }

        public IActionResult Consultar()
        {
            return View("MateriaCursada");
        }

       

    }
}
