using System;


namespace DudiGames.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
       // public double CapitalGiro { get; set; }
       // public Estoque Estoque { get; set; }
        public int ProdutoId { get; set; }
        //public Capital capital { get; set; }
        //public int CapitalId { get; set; }
        public double PrecoUnitario { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public DateTime DataVenda { get; set; }
        public double PrecoVenda { get; set; }
       
       


        public Financeiro()
        {

        }

        public Financeiro(int id, int produtoId, double precoUnitario, Pedido pedido, int pedidoId, DateTime dataVenda, double precoVenda)
        {
            Id = id;
            ProdutoId = produtoId;
            PrecoUnitario = precoUnitario;
            Pedido = pedido;
            PedidoId = pedidoId;
            DataVenda = dataVenda;
            PrecoVenda = precoVenda;
        }

        public double Lucro(double precoVenda, double precoUnitario) 
        {
            return precoVenda - precoUnitario;
        }
       /* public double SaldoCapital(double capitalGiro, double preçoUnitario)
        {
            return capitalGiro - preçoUnitario;
        }*/
    }
}
