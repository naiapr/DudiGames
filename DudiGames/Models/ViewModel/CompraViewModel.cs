using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models.ViewModel
{
    public class CompraViewModel
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public double ValorUnitarioProduto { get; set; }
      
        public double ValorCompra { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        public int ProdutoId{ get; set; }
        public string NomeProduto { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public double ValorTotalCompra { get; set; }
       
    }
}
