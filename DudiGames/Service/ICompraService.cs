using DudiGames.Models;
using DudiGames.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    interface ICompraService
    {
        public List<CompraViewModel> FindAll();
        public void AdicionarCompra(CompraViewModel compraViewModel);
        public CompraViewModel FindById(int CompraId);
        public Compra BuscarPorId(int id);
        public void EditarCompra(CompraViewModel compraViewModel);
        public void RemoverCompra(int CompraId);

        public double ValorTotalCompra(double valorCompra, int quantidade);

        public void AdicionarEstoque(CompraViewModel compraViewModel);


    }
}
