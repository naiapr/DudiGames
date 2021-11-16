using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Produto")]
        public string NomeProdutoComprado { get; set; }
        [Display(Name = "Quantidade")]
        public int QuantidadeProduto { get; set; }
        [Display(Name = "Total Produtos")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double PreçoTotalProduto { get; set; }
        [Display(Name = "Valor Total Estoque ")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorTotalEstoque { get; set; }
        [Display(Name = "Total Produtos Estoque")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public int TotalProdutosEstoque { get; set; }
        [Display(Name = "Preço Unitário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double PrecoUnitario { get; set; }
        public ICollection<Compra> Compras { get; set; }
    }
}
