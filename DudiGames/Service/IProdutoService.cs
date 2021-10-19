using DudiGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    interface IProdutoService
    {
        public List<Produto> FindAll();
        public void AdicionarProduto(Produto produto);
        public Produto FindById(int IdProduto);
        public void EditarProduto(Produto produto);
        public void RemoverProduto(Produto produto);
    }
}
