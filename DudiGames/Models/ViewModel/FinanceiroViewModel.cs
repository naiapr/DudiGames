using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models.ViewModel
{
    public class FinanceiroViewModel
    {
        public int Id { get; set; }
        public double CapitalGiro { get; set; }
        public Compra Compra { get; set; }
        public string NomeProduto { get; set; }
        
        public double PrecoUnitario { get; set; }
        public Pedido Pedido { get; set; }
        public DateTime DataVenda { get; set; }
        public double PrecoVenda { get; set; }

        public Estoque Estoque { get; set; }
        public double Lucro{ get; set; }
        public double SaldoCapital { get; set; }
    }
}
