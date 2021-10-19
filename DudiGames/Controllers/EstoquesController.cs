using DudiGames.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Controllers
{
    public class EstoquesController : Controller
    {
        private readonly EstoqueService _estoqueService;
        private readonly CompraService _compraService;

        public EstoquesController(EstoqueService estoqueService, CompraService compraService)
        {
            _estoqueService = estoqueService;
            _compraService = compraService;
        }

        public IActionResult Index()
        {
            var lista = _estoqueService.FindAll();
            ViewBag.ValorTotal = _estoqueService.ValorTotalEstoque();
            ViewBag.TotalProdutos = _estoqueService.TotalProdutosEstoque();
            
            return View(lista);
        }
    }
}
