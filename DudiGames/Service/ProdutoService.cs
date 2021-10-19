using DudiGames.Data;
using DudiGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly DudiGamesContext _context;

        public ProdutoService(DudiGamesContext context)
        {
            _context = context;
        }

        public void AdicionarProduto(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public void EditarProduto(Produto produto)
        {
            
            var obj = _context.Produto.Find(produto.Id);
            obj.Nome = produto.Nome;
            _context.Update(obj);
            _context.SaveChanges();
        }

        public List<Produto> FindAll()
        {
            return  _context.Produto.OrderBy(x => x.Nome).ToList();
            
        }

        public Produto FindById(int IdProduto)
        {
            return _context.Produto.FirstOrDefault(obj => obj.Id == IdProduto);
        }

        public void RemoverProduto(Produto produto)
        {
            var obj = _context.Produto.Find(produto.Id);
            obj.Nome = produto.Nome;
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
}
