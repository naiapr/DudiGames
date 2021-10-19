using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models.ViewModel
{
    public class EstoqueViewModel
    {
        public int Id { get; set; }
        public Compra Compra { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProdutoComprado { get; set; }
        public int QuantidadeProduto { get; set; }
        public double PreçoTotalProduto { get; set; }
        public double ValorTotalEstoque { get; set; }
        public int TotalProdutosEstoque { get; set; }
        public double PrecoUnitario { get; set; }
        public ICollection<Compra> Compras { get; set; }
    }
}
