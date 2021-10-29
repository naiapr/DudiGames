using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models.ViewModel
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        public DateTime DataVenda { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public double ValorVenda { get; set; }
        public int Quantidade { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }

        public Capital Capital { get; set; }
        public int CapitalId { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public double TotalVenda { get; set; }
        public double ValorUnitario { get; set; }

    }
}
