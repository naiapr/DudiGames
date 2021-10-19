using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models
{
    public class Estoque
    {
        public int Id { get; set; }

        public Compra Compra { get; set; }

        public Produto Produto { get; set; }
        public double PrecoUnitario { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }


        public Estoque()
        {

        }

        public Estoque(int id, Compra compra, Produto produto, double precoUnitario, int produtoId, int quantidade, double valorTotal)
        {
            Id = id;
            Compra = compra;
            Produto = produto;
            PrecoUnitario = precoUnitario;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorTotal = valorTotal;
        }
    }
}
