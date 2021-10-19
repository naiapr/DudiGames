using DudiGames.Models;
using DudiGames.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    interface IFinanceiroService
    {
        //public void AdicionarCapital(FinanceiroViewModel financeiroViewModel);
        public List<FinanceiroViewModel> FindAll();
        public double Lucro();
        public double SaldoCapital();
        public void SalvarFinanceiro(PedidoViewModel pedidoViewModel);

    }
}
