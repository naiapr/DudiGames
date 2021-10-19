using DudiGames.Models;
using DudiGames.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    interface IPedido
    {
        public List<PedidoViewModel> FindAll();
        public void AdicionarPedido(PedidoViewModel pedidoViewModel);
        public PedidoViewModel FindById(int PedidoId);
       
        public void EditarPedido(PedidoViewModel pedidoViewModel);
        public void RemoverPedido(int PedidoId);

        public double ValorTotalPedido(double valorVenda, int quantidade);

       public void RemoverEstoque(PedidoViewModel pedidoViewModel);
        //public Pedido BuscarPorId(int id);


    }
}
