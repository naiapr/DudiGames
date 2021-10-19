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
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        private readonly EstoqueService _estoqueService;
        private readonly ProdutoService _produtoService;
        private readonly ClienteService _clienteService;
        private readonly FinanceiroService _financeiroService;

        public PedidosController(PedidoService pedidoService, EstoqueService estoqueService, ProdutoService produtoService, ClienteService clienteService, FinanceiroService financeiroService)
        {
            _pedidoService = pedidoService;
            _estoqueService = estoqueService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _financeiroService = financeiroService;
        }

        public IActionResult Index()
        {
            var list = _pedidoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.ProdutoId = _produtoService.FindAll();
            ViewBag.ClienteId = _clienteService.FindAll();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProdutoId = _produtoService.FindAll();
                ViewBag.ClienteId = _clienteService.FindAll();
                return View(pedidoViewModel);
            }

            
            _pedidoService.AdicionarPedido(pedidoViewModel);
            var estoque = _pedidoService.BuscarEstoque(pedidoViewModel.ProdutoId);
            _pedidoService.RemoverEstoque(pedidoViewModel);
           
            _financeiroService.SalvarFinanceiro(pedidoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _pedidoService.FindById(id.Value);
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _pedidoService.FindById(id.Value);
            ViewBag.ProdutoId = _produtoService.FindAll();
            ViewBag.ClienteId = _clienteService.FindAll();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProdutoId = _produtoService.FindAll();
                ViewBag.ClienteId = _clienteService.FindAll();
                return View(pedidoViewModel);
            }
            _pedidoService.EditarPedido(pedidoViewModel);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var obj = _pedidoService.FindById(id.Value);
            
            
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var compra = _pedidoService.FindById(id);
            _pedidoService.RemoverPedido(id);
            //_estoqueService.RemoverEstoque(compra);
            return RedirectToAction(nameof(Index));

        }
    }
}
