using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double ValorCompra { get; set; }
      
        public DateTime DataCompra { get; set; }

        public Compra()
        {

        }

        public Compra(int id, Produto produto, int produtoId, int quantidade, double valorCompra, DateTime dataCompra)
        {
            Id = id;
            Produto = produto;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorCompra = valorCompra;
            DataCompra = dataCompra;
        }

        public double ValorTotalCompra(double valorCompra, int quantidade)
        {
            var vtc = valorCompra * quantidade;
            return vtc;
        }

       
    }
}
