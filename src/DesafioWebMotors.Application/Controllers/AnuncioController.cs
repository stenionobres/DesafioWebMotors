using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DesafioWebMotors.Application.Models;
using DesafioWebMotors.Application.Services;

namespace DesafioWebMotors.Application.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly AnuncioService _anuncioService;

        public AnuncioController(AnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        public IActionResult Index()
        {
            var anuncios = _anuncioService.GetAnuncios();

            return View(anuncios);
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new AnuncioWebMotors());
            else
                return View(_anuncioService.GetAnuncio(id));
        }

        public IActionResult Delete(int id)
        {
            _anuncioService.DeleteAnuncio(id);

            return RedirectToAction(nameof(Index));
        }
    }
}