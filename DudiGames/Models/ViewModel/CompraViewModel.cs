using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models.ViewModel
{
    public class CompraViewModel
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        [Display(Name = "Valor Produto")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorUnitarioProduto { get; set; }
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorCompra { get; set; }
        [Display(Name = "Quantidade")]
        [Range(1,100)]
        public int Quantidade { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataCompra { get; set; }
        public int ProdutoId{ get; set; }
        
        [Display(Name = "Produto")]
        public string NomeProduto { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        [Display(Name = "Total da Compra")]
        public double ValorTotalCompra { get; set; }
       
    }
}
