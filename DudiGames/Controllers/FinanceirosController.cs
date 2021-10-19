using DudiGames.Models;
using DudiGames.Models.ViewModel;
using DudiGames.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Controllers
{
    public class FinanceirosController : Controller
    {
        private readonly FinanceiroService _financeiroService;
        private readonly CompraService _compraService;
        private readonly PedidoService _pedidoService;

        public FinanceirosController(FinanceiroService financeiroService, CompraService compraService, PedidoService pedidoService)
        {
            _financeiroService = financeiroService;
            _compraService = compraService;
            _pedidoService = pedidoService;
        }

        public IActionResult Index()
        {
            var list = _financeiroService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FinanceiroViewModel financeiroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(financeiroViewModel);
            }

            //_financeiroService.AdicionarCapital(financeiroViewModel);
         
            return RedirectToAction(nameof(Index));
        }
    }
}
