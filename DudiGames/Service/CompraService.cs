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
    public class CompraService : ICompraService
    {
        private readonly DudiGamesContext _context;
        private readonly ProdutoService _produtoService;
        

        public CompraService(DudiGamesContext context, ProdutoService produtoService)
        {
            _context = context;
            _produtoService = produtoService;
          
        }

        public void AdicionarCompra(CompraViewModel compraViewModel)
        {
            Compra compra = new Compra();
           
            compra.DataCompra = compraViewModel.DataCompra;
            compra.Produto = compraViewModel.Produto;
            compra.ProdutoId = compraViewModel.ProdutoId;
            compra.Quantidade = compraViewModel.Quantidade;
            compra.ValorCompra = compraViewModel.ValorUnitarioProduto*compraViewModel.Quantidade;
            _context.Add(compra);
            
            _context.SaveChanges();
            compraViewModel.Id = compra.Id;
        }

        public void EditarCompra(CompraViewModel compraViewModel)
        {
            Compra compra = new Compra();
            compra.Id = compraViewModel.Id;
            compra.DataCompra = compraViewModel.DataCompra;
            compra.Produto = compraViewModel.Produto;
            compra.ProdutoId = compraViewModel.ProdutoId;
            compra.Quantidade = compraViewModel.Quantidade;
            compra.ValorCompra = compraViewModel.ValorCompra;
            _context.Compra.Update(compra);
            _context.SaveChanges();
        }

        public List<CompraViewModel> FindAll()
        {
            List<CompraViewModel> lista = new List<CompraViewModel>();
            var listaCompra = _context.Compra.ToList();
            foreach (var compra in listaCompra)
            {
                CompraViewModel c = new CompraViewModel();
                c.Id = compra.Id;
                c.ProdutoId = compra.ProdutoId;
                c.DataCompra = compra.DataCompra;
                c.NomeProduto = _produtoService.FindById(compra.ProdutoId).Nome;
                c.Quantidade = compra.Quantidade;
                c.ValorCompra = compra.ValorCompra;
                c.ValorTotalCompra = ValorTotalCompra(compra.ValorCompra, compra.Quantidade);
                lista.Add(c);

            }

            return (lista);
        }

        public CompraViewModel FindById(int Id)
        {
            Compra compra = new Compra();
            compra =_context.Compra.Include(obj => obj.Produto).FirstOrDefault(obj => obj.Id == Id);
            

            CompraViewModel compraViewModel = new CompraViewModel();
            compraViewModel.Id = compra.Id;
            compraViewModel.DataCompra = compra.DataCompra;
            compraViewModel.ProdutoId= compra.ProdutoId;
            compraViewModel.NomeProduto = compra.Produto.Nome;
            compraViewModel.ValorCompra = compra.ValorCompra;
            compraViewModel.Quantidade = compra.Quantidade;
            compraViewModel.ValorTotalCompra = ValorTotalCompra(compra.ValorCompra, compra.Quantidade);
            return compraViewModel;
        }

        public void RemoverCompra(int CompraId)
        {
            var obj = _context.Compra.Find(CompraId);
            _context.Compra.Remove(obj);
            _context.SaveChanges();
        }

        public double ValorTotalCompra(double preçoUnitario, int quantidade)
        {
            var vtc = preçoUnitario * quantidade;
            return vtc;
        }


        public void AdicionarEstoque(CompraViewModel compraViewModel)
          {

            Compra compra = new Compra();
            
            compraViewModel.Id = compra.Id;
            compraViewModel.ProdutoId = compra.ProdutoId;
            compraViewModel.NomeProduto = compra.Produto.Nome;
            compraViewModel.Quantidade = compra.Quantidade;
            compraViewModel.ValorTotalCompra = compra.ValorCompra;
            
            _context.Add(compra);
            _context.SaveChanges();   

          }
        public void AdicionarSaida(CompraViewModel compraViewModel)
        {

            Compra compra = new Compra();

            compraViewModel.Id = compra.Id;
            compraViewModel.DataCompra = compra.DataCompra;
            compraViewModel.ValorTotalCompra = compra.ValorCompra;

            _context.Add(compra);
            _context.SaveChanges();

        }

        public Compra BuscarPorId(int id)
        {
            Compra compra = new Compra();

            compra = _context.Compra.FirstOrDefault(x => x.Id == id);

            return compra;
        }
    }
}
