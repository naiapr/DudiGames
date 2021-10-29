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

        public CapitalController(CapitalService capitalService)
        {
            _capitalService = capitalService;
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
    }
}
