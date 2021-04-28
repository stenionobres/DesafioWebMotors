using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DesafioWebMotors.Application.Models;

namespace DesafioWebMotors.Application.Controllers
{
    public class AnuncioController : Controller
    {
        public IActionResult Index()
        {
            var anuncios = new List<AnuncioWebMotors>();

            return View(anuncios);
        }
    }
}