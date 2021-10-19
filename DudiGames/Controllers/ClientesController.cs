using DudiGames.Models;
using DudiGames.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var list = _clienteService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            _clienteService.AdicionarCliente(cliente);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? Id)
        {
            var obj = _clienteService.FindById(Id.Value);
            if(Id == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult  Edit (Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            _clienteService.EditarCliente(cliente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? Id)
        {
            var obj = _clienteService.FindById(Id.Value);
            if(Id == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult Delete (int? Id)
        {
            var obj = _clienteService.FindById(Id.Value);
            if (Id == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (Cliente cliente)
        {
            _clienteService.RemoverCliente(cliente);
            return RedirectToAction(nameof(Index));
        }
    }
}
