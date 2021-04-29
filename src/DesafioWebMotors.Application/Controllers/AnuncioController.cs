using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DesafioWebMotors.Application.Models;
using DesafioWebMotors.Application.Services;
using DesafioWebMotors.ApiServices.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesafioWebMotors.Application.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly AnuncioService _anuncioService;
        private readonly OnlineChallengeApiService _onlineChallengeApiService;

        public AnuncioController(AnuncioService anuncioService, OnlineChallengeApiService onlineChallengeApiService)
        {
            _anuncioService = anuncioService;
            _onlineChallengeApiService = onlineChallengeApiService;
        }

        public IActionResult Index()
        {
            var anuncios = _anuncioService.GetAnuncios();

            return View(anuncios);
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            ViewBag.Marcas = _onlineChallengeApiService.GetMarcas().Select(m => new SelectListItem()
            { Text = m.Name, Value = string.Join("#", m.ID.ToString(), m.Name) });

            ViewBag.Modelos = _onlineChallengeApiService.GetModelos(idDaMarca: 1).Select(m => new SelectListItem()
            { Text = m.Name, Value = string.Join("#", m.ID.ToString(), m.Name) });

            ViewBag.Versoes = _onlineChallengeApiService.GetVersoes(idDoModelo: 1).Select(m => new SelectListItem()
            { Text = m.Name, Value = string.Join("#", m.ID.ToString(), m.Name) });

            if (id == 0)
                return View(new AnuncioWebMotors());
            else
                return View(_anuncioService.GetAnuncio(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(AnuncioWebMotors anuncioWebMotors)
        {
            if (ModelState.IsValid)
            {
                if (anuncioWebMotors.Id == 0)
                    _anuncioService.SaveAnuncio(anuncioWebMotors);
                else
                    _anuncioService.UpdateAnuncio(anuncioWebMotors);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _anuncioService.DeleteAnuncio(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CarregarModelos(int idDaMarca)
        {
            var modelosFromApi = _onlineChallengeApiService.GetModelos(idDaMarca: idDaMarca);
            dynamic modelosForView = modelosFromApi.Select(m => new { Text = m.Name, Value = string.Join("#", m.ID.ToString(), m.Name) });

            return Json(modelosForView);
        }

        public IActionResult CarregarVersoes(int idDoModelo)
        {
            var versoesFromApi = _onlineChallengeApiService.GetVersoes(idDoModelo: idDoModelo);
            dynamic versoesForView = versoesFromApi.Select(m => new { Text = m.Name, Value = string.Join("#", m.ID.ToString(), m.Name) });

            return Json(versoesForView);
        }
    }
}