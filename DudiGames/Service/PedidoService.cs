using DudiGames.Data;
using DudiGames.Models;
using DudiGames.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    public class PedidoService : IPedido
    {
        private readonly DudiGamesContext _context;
        private readonly EstoqueService _estoqueService;
        private readonly ProdutoService _produtoService;
        private readonly ClienteService _clienteService;

        public PedidoService(DudiGamesContext context, EstoqueService estoqueService, ProdutoService produtoService, ClienteService clienteService)
        {
            _context = context;
            _estoqueService = estoqueService;
            _produtoService = produtoService;
            _clienteService = clienteService;
        }

        public void AdicionarPedido(PedidoViewModel pedidoViewModel)
        {
          
            Pedido pedido = new Pedido();
            
            pedido.DataVenda = pedidoViewModel.DataVenda;
            pedido.Produto = pedidoViewModel.Produto;
            pedido.ProdutoId = pedidoViewModel.ProdutoId;
            pedido.Quantidade = pedidoViewModel.Quantidade;
            pedido.ValorVenda = pedidoViewModel.ValorVenda;
            pedido.Cliente = pedidoViewModel.Cliente;
            pedido.ClienteId = pedidoViewModel.ClienteId;
            _context.Add(pedido);
            
            _context.SaveChanges();
             pedidoViewModel.PedidoId = pedido.Id  ;
        }

        public void EditarPedido(PedidoViewModel pedidoViewModel)
        {
            Pedido pedido = new Pedido();
            pedido.Id = pedidoViewModel.PedidoId;
            pedido.DataVenda = pedidoViewModel.DataVenda;
            pedido.Produto = pedidoViewModel.Produto;
            pedido.ProdutoId = pedidoViewModel.ProdutoId;
            pedido.Quantidade = pedidoViewModel.Quantidade;
            pedido.ValorVenda = pedidoViewModel.ValorVenda;
            pedido.Cliente = pedidoViewModel.Cliente;
            pedido.ClienteId = pedidoViewModel.ClienteId;
            
            _context.Pedido.Update(pedido);
            _context.SaveChanges();
        }

        public List<PedidoViewModel> FindAll()
        {
            List<PedidoViewModel> lista = new List<PedidoViewModel>();
            var listaPedido = _context.Pedido.ToList();
            foreach (var pedido in listaPedido)
            {
                PedidoViewModel p = new PedidoViewModel();
                p.PedidoId = pedido.Id;
                p.DataVenda = pedido.DataVenda;
                p.ProdutoId = pedido.ProdutoId;
                p.NomeProduto = _produtoService.FindById(pedido.ProdutoId).Nome;
                p.Quantidade = pedido.Quantidade;
                p.ValorVenda = pedido.ValorVenda;
                p.ClienteId = pedido.ClienteId;
                p.NomeCliente = _clienteService.FindById(pedido.ClienteId).Nome;
                p.TotalVenda = ValorTotalPedido(pedido.ValorVenda, pedido.Quantidade);
                lista.Add(p);

            }
            return (lista);
        }

        public PedidoViewModel FindById(int PedidoId)
        {
            Pedido pedido = new Pedido();
            pedido = _context.Pedido.Include(obj => obj.Produto).FirstOrDefault(obj => obj.Id == PedidoId);
                    

            PedidoViewModel pedidoViewModel = new PedidoViewModel();
            pedidoViewModel.PedidoId = pedido.Id;
            pedidoViewModel.NomeProduto = _produtoService.FindById(pedido.ProdutoId).Nome;
            pedidoViewModel.DataVenda = pedido.DataVenda;
            pedidoViewModel.ProdutoId = pedido.ProdutoId;
            pedidoViewModel.Quantidade = pedido.Quantidade;
            pedidoViewModel.ValorVenda = pedido.ValorVenda;
            pedidoViewModel.ClienteId = pedido.ClienteId;
            pedidoViewModel.NomeCliente = _clienteService.FindById(pedido.ClienteId).Nome;
            pedidoViewModel.TotalVenda = ValorTotalPedido(pedido.ValorVenda, pedido.Quantidade);
            return pedidoViewModel;
        }

        public void RemoverPedido(int PedidoId)
        {
            var obj = _context.Pedido.Find(PedidoId);
            _context.Pedido.Remove(obj);
            _context.SaveChanges();
        }
        public void RemoverEstoque(PedidoViewModel pedidoViewModel)
        {

            var estoque = _estoqueService.BuscarEstoquePorProduto(pedidoViewModel.ProdutoId);           
            if (estoque.Quantidade>= pedidoViewModel.Quantidade)
            {
                estoque.Quantidade -= pedidoViewModel.Quantidade;

                //var precoUnitarioPosVenda = estoque.PrecoUnitario * pedidoViewModel.Quantidade;
               // estoque.PrecoUnitario -= precoUnitarioPosVenda;


                estoque.ValorTotal = estoque.PrecoUnitario * estoque.Quantidade;
       
            }

            
            
            _context.Update(estoque);
            _context.SaveChanges();

        }

        public double ValorTotalPedido(double valorVenda, int quantidade)
        {
            return valorVenda * quantidade;
        }

        public Estoque BuscarEstoque(int produtoId)
        {
            Estoque estoque= new Estoque();

            estoque = _context.Estoque.Find(produtoId);

            return estoque;
        }
    }
}
