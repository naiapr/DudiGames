using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models.ViewModel
{
    public class FinanceiroViewModel
    {
        public int Id { get; set; }
        public Compra Compra { get; set; }
        [Display(Name = "Produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Preço Unitário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double PrecoUnitario { get; set; }
        public Pedido Pedido { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVenda { get; set; }
        [Display(Name = "Preço Venda")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double PrecoVenda { get; set; }

        public Estoque Estoque { get; set; }
        [Display(Name = "Lucro")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Lucro{ get; set; }
       
    }
}
