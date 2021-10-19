using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorVenda { get; set; }
        public Cliente Cliente { get; set; }
        public int ProdutoId { get; set; }
        public int ClienteId { get; set; }

        public Pedido()
        {

        }

        public Pedido(int id, DateTime dataVenda, Produto produto, int quantidade, double valorVenda, Cliente cliente, int produtoId, int clienteId)
        {
            Id = id;
            DataVenda = dataVenda;
            Produto = produto;
            Quantidade = quantidade;
            ValorVenda = valorVenda;
            Cliente = cliente;
            ProdutoId = produtoId;
            ClienteId = clienteId;
        }

        public double TotalVenda(double valorVenda, int quantidade)
        {
            return valorVenda * quantidade;
        }
    }
}
