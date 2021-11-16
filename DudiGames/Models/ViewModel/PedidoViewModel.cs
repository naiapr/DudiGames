using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models.ViewModel
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVenda { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        [Display(Name = "Nome")]
        public string NomeProduto { get; set; }
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorVenda { get; set; }
        [Display(Name = "Quantidade")]
        [Range(1, 100)]
        public int Quantidade { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        [Display(Name = "Cliente")]
        public string NomeCliente { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        [Display(Name = "Total Venda")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TotalVenda { get; set; }
        [Display(Name = "Valor Unitário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorUnitario { get; set; }

    }
}
