using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DudiGames.Service;
using DudiGames.Models;

namespace DudiGames.Controllers
{
    public class CapitalController : Controller

    {
        private readonly CapitalService _capitalService;
        private readonly FinanceiroService _financeiroService;

        public CapitalController(CapitalService capitalService, FinanceiroService financeiroService)
        {
            _capitalService = capitalService;
            _financeiroService = financeiroService;
        }

        public IActionResult Index()
        {
            var list = _capitalService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Capital capital)
         {
            if (!ModelState.IsValid)
            {
                return View(capital);
            }


           _capitalService.AdicionarCapital(capital);
   
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? Id)
        {
            var obj = _capitalService.FindById(Id.Value);
            if (Id == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Capital capital)
        {
            if (!ModelState.IsValid)
            {
                return View(capital);
            }

            _capitalService.EditarCapital(capital);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? Id)
        {
            var obj = _capitalService.FindById(Id.Value);
            if (Id == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult Delete(int? Id)
        {
            var obj = _capitalService.FindById(Id.Value);
            if (Id == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Capital capital)
        {
            _capitalService.RemoverCapital(capital);
            return RedirectToAction(nameof(Index));
        }
    }
}
