using DudiGames.Data;
using DudiGames.Models;
using DudiGames.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    public class FinanceiroService : IFinanceiroService
    {
        private readonly DudiGamesContext _context;
        private readonly CompraService _estoqueService;
        private readonly PedidoService _pedidoService;
        private readonly ProdutoService _produtoService;
        private readonly CapitalService _capitalService;

        public FinanceiroService(DudiGamesContext context, CompraService estoqueService, PedidoService pedidoService, ProdutoService produtoService, CapitalService capitalService)
        {
            _context = context;
            _estoqueService = estoqueService;
            _pedidoService = pedidoService;
            _produtoService = produtoService;
            _capitalService = capitalService;
        }

        public List<FinanceiroViewModel> FindAll()
        {
            List<FinanceiroViewModel> lista = new List<FinanceiroViewModel>();
            var listaFinanceiro = _context.Financeiro.ToList();
            foreach (var financeiro in listaFinanceiro)
            {
                Capital capital = new Capital();
                FinanceiroViewModel f = new FinanceiroViewModel();
                f.Id = financeiro.Id;
                f.CapitalGiro = _capitalService.FindById(capital.Id).CapitaldeGiro;
                f.NomeProduto = _produtoService.FindById(financeiro.ProdutoId).Nome;
                f.PrecoUnitario = financeiro.PrecoUnitario;
                f.DataVenda = financeiro.DataVenda;
                f.PrecoVenda = financeiro.PrecoVenda;
                f.Lucro = financeiro.Lucro(financeiro.PrecoVenda, financeiro.PrecoUnitario);
                f.SaldoCapital = financeiro.SaldoCapital(financeiro.CapitalGiro, financeiro.PrecoUnitario);
                lista.Add(f);

            }
            return lista;
        }

        public double Lucro(double precoUnitario, double precoVenda)
        {
            return precoVenda - precoUnitario;
        }

        public double Lucro()
        {
            throw new NotImplementedException();
        }

        

        public double SaldoCapital(double capitalGiro, double precoUnitario)
        {
            return capitalGiro - precoUnitario;
        }

        public double SaldoCapital()
        {
            throw new NotImplementedException();
        }

        public void SalvarFinanceiro(PedidoViewModel pedidoViewModel)

        {
            Capital capital = new Capital();
            Financeiro financeiro = new Financeiro();
            financeiro.PedidoId = pedidoViewModel.PedidoId;
            financeiro.ProdutoId = pedidoViewModel.ProdutoId;
            financeiro.PrecoUnitario = _context.Estoque.FirstOrDefault(x => x.ProdutoId == pedidoViewModel.ProdutoId).PrecoUnitario;
            financeiro.DataVenda = pedidoViewModel.DataVenda;
            financeiro.PrecoVenda = pedidoViewModel.ValorVenda;
           
            var valorCusto = _context.Estoque.FirstOrDefault(x => x.ProdutoId == pedidoViewModel.ProdutoId).PrecoUnitario;
            var lucro = pedidoViewModel.ValorVenda - valorCusto;

            //var capital = financeiro.CapitalGiro - financeiro.PrecoUnitario;
          
            financeiro.CapitalGiro = capital.CapitaldeGiro;
            _context.Update(financeiro);

            _context.SaveChanges();

        }
    }
}
