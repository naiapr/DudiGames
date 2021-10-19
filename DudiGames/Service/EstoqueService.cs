using DudiGames.Data;
using DudiGames.Models;
using DudiGames.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    public class EstoqueService : IEstoqueService
    {
        private readonly DudiGamesContext _context;
        private readonly CompraService _compraService;
        private readonly ProdutoService _produtoService;
        //private readonly PedidoService _pedidoService;

        public EstoqueService(DudiGamesContext context, CompraService compraService, ProdutoService produtoService)
        {
            _context = context;
            _compraService = compraService;
            _produtoService = produtoService;
            //_pedidoService = pedidoService;
        }

        public Estoque BuscarEstoquePorProduto(int id)
        {
            return _context.Estoque.FirstOrDefault(x => x.ProdutoId==id);
        }

        public List<EstoqueViewModel> FindAll()
        {

           List<EstoqueViewModel> lista = new List<EstoqueViewModel>();
            var listaEstoque = _context.Estoque.ToList();
           
            
            foreach (var estoque in listaEstoque)
            {
               EstoqueViewModel e = new EstoqueViewModel();
                e.Id = estoque.Id;
                e.ProdutoId = estoque.ProdutoId;
                e.NomeProdutoComprado = _produtoService.FindById(estoque.ProdutoId).Nome;

                e.QuantidadeProduto = estoque.Quantidade;
                e.PreçoTotalProduto = estoque.ValorTotal;
                e.PrecoUnitario = e.PreçoTotalProduto / e.QuantidadeProduto;
                    //estoque.ValorTotal / estoque.Quantidade;

              

                lista.Add(e);     
            }

           

            return (lista); 
        }

        
        public double PrecoUnitario(int produtoId)
        {
            Estoque estoque = new Estoque();
            estoque = _context.Estoque.FirstOrDefault(x => x.Id == produtoId);
  
            estoque.PrecoUnitario = estoque.ValorTotal / estoque.Quantidade;
            var preco = estoque.PrecoUnitario;
            return preco;
            
            
            
        }

        public int QuantidadeProduto(int quantidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverEstoque(Estoque estoque)
        {
            var tirarEstoque = _context.Estoque.FirstOrDefault(x => x.Quantidade == estoque.Quantidade);
            tirarEstoque.Quantidade -= estoque.Quantidade;
            tirarEstoque.PrecoUnitario -= estoque.PrecoUnitario;
            
            _context.Estoque.Update(tirarEstoque);
            _context.SaveChanges();
        }

        public  void SalvarNoEstoque(Compra compra)
        {
            Estoque estoque = new Estoque();
            var existeNoEstoque = _context.Estoque.FirstOrDefault(x => x.ProdutoId == compra.ProdutoId);


            //verifica se ja existe no estoque
            if (existeNoEstoque != null)
            {
                existeNoEstoque.Quantidade += compra.Quantidade;
                existeNoEstoque.ValorTotal += compra.ValorCompra;
                existeNoEstoque.PrecoUnitario = existeNoEstoque.ValorTotal / existeNoEstoque.Quantidade;
                _context.Estoque.Update(existeNoEstoque);
                _context.SaveChanges();

            }
            else if(existeNoEstoque == null){
                estoque.ProdutoId = compra.ProdutoId;
                //estoque.Produto.Nome = compra.Produto.Nome;
                estoque.Quantidade = compra.Quantidade;
                estoque.ValorTotal = compra.ValorCompra;
                estoque.PrecoUnitario = estoque.ValorTotal / estoque.Quantidade;
                // estoque.P= compra.ValorCompra / compra.Quantidade;


                _context.Estoque.Add(estoque);
                _context.SaveChanges();
            }
                


        }

        public int TotalProdutosEstoque()
        {
            List<Estoque> listaEstoque = _context.Estoque.ToList();
            var totalProdutos = 0;
            foreach (var item in listaEstoque)
            {
                totalProdutos += item.Quantidade;
            }
            return totalProdutos; 
        }

        public double ValorTotalEstoque()
        {
            List<Estoque> listaEstoque = _context.Estoque.ToList();
            double totalEstoque =0.0;
            foreach (var item in listaEstoque)
            {
                totalEstoque += item.ValorTotal;
            }
            return totalEstoque;
        }
    }
}
