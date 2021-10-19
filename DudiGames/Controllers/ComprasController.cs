using DudiGames.Models.ViewModel;
using DudiGames.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Controllers
{
    public class ComprasController : Controller
    {
        private readonly CompraService _compraService;
        private readonly ProdutoService _produtoService;
        private readonly EstoqueService _estoqueService;
        private readonly FinanceiroService _financeiroService;

        public ComprasController(CompraService compraService, ProdutoService produtoService, EstoqueService estoqueService, FinanceiroService financeiroService)
        {
            _compraService = compraService;
            _produtoService = produtoService;
            _estoqueService = estoqueService;
            _financeiroService = financeiroService;
        }

        public IActionResult Index(string Retorno)
        {
            ViewBag.Retorno = Retorno;
            var list = _compraService.FindAll();
            return View(list);
        }

        public IActionResult Create( string Retorno)
        {
            ViewBag.Retorno = Retorno;
            ViewBag.ProdutoId = _produtoService.FindAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompraViewModel compraViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //ViewBag.ProdutoId = _produtoService.FindAll();
                    _compraService.AdicionarCompra(compraViewModel);
                    var compra = _compraService.BuscarPorId(compraViewModel.Id);
                    //_compraService.AdicionarEstoque(compraViewModel);
                    
               
                    _estoqueService.SalvarNoEstoque(compra);
                    //_financeiroService.Saida(compra);

                    return RedirectToAction("Index", "Compras", new { Retorno = "Deu Certo" });
                }
                catch (Exception e)
                {

                    var erro = e.Message;

                    return RedirectToAction("Index", "Compras", new { Retorno = erro });

                }

            }
            return View();
        }

       public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _compraService.FindById(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit (int? Id)
        {
            if (Id == null)
            {
                return NotFound();
                
            }
            var obj = _compraService.FindById(Id.Value);
            ViewBag.ProdutoId = _produtoService.FindAll();
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CompraViewModel compraViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProdutoId = _produtoService.FindAll();
                return View(compraViewModel);
            }
            _compraService.EditarCompra(compraViewModel);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete (int? id)
        {
            
             if(id == null)
             {
                 return NotFound();
             }
                var obj = _compraService.FindById(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            return View(obj);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id)
        {
            var compra = _compraService.BuscarPorId(id);
            _compraService.RemoverCompra(id);
            return RedirectToAction(nameof(Index));
            
        }

        
    }
}
