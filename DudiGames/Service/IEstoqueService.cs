using DudiGames.Models;
using DudiGames.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    interface IEstoqueService
    {
        public List<EstoqueViewModel> FindAll();
        
      //  public void RemoverEstoque(int Compra compra);
        public double ValorTotalEstoque();
        public int TotalProdutosEstoque();
        //public double PrecoUnitario(int estoqueId);

        //public void SalvarNoEstoque(Compra compra);

        public Estoque BuscarEstoquePorProduto(int id);

    }
}
