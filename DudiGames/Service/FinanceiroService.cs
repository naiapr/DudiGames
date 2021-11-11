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
               // Capital capital = new Capital();
                FinanceiroViewModel f = new FinanceiroViewModel();
                f.Id = financeiro.Id;
                //f.CapitalGiro = _capitalService.FindById(financeiro.CapitalId).CapitaldeGiro;
                f.NomeProduto = _produtoService.FindById(financeiro.ProdutoId).Nome;
                f.PrecoUnitario = financeiro.PrecoUnitario;
                f.DataVenda = financeiro.DataVenda;
                f.PrecoVenda = financeiro.PrecoVenda;
                f.Lucro = financeiro.Lucro(financeiro.PrecoVenda, financeiro.PrecoUnitario);
                //f.SaldoCapital = financeiro.SaldoCapital(financeiro.CapitalGiro, financeiro.PrecoUnitario);
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

       /* public void CapitalAdicionado(Capital capital)
        {
            Financeiro financeiro = new Financeiro();
            financeiro.CapitalId = capital.Id;
            financeiro.CapitalGiro = capital.CapitaldeGiro;
            _context.Add(financeiro);

            _context.SaveChanges();
        }*/

        public void SalvarFinanceiro(PedidoViewModel pedidoViewModel)

        {
            
            Financeiro financeiro = new Financeiro();
            //Capital capital = new Capital();
            //capital = _context.Capital.FirstOrDefault(x => x.Id == financeiro.CapitalId);

            financeiro.PedidoId = pedidoViewModel.PedidoId;
            financeiro.ProdutoId = pedidoViewModel.ProdutoId;
            //financeiro.CapitalId = _capitalService.FindById(financeiro.CapitalId).Id;
            //financeiro.CapitalGiro = _capitalService.FindById(financeiro.CapitalGiro).CapitaldeGiro.ToString();
            financeiro.PrecoUnitario = _context.Estoque.FirstOrDefault(x => x.ProdutoId == pedidoViewModel.ProdutoId).PrecoUnitario;
            financeiro.DataVenda = pedidoViewModel.DataVenda;
            financeiro.PrecoVenda = pedidoViewModel.ValorVenda;
         

           
            var valorCusto = _context.Estoque.FirstOrDefault(x => x.ProdutoId == pedidoViewModel.ProdutoId).PrecoUnitario;
            var lucro = pedidoViewModel.ValorVenda - valorCusto;

            Capital capital = new Capital();
            //capital = _context.Capital.FirstOrDefault(x => x.Id == financeiro.CapitalId);
            //var capital = financeiro.CapitalGiro - financeiro.PrecoUnitario;
           // financeiro.CapitalId = capital.Id;
           // financeiro.CapitalGiro = capital.CapitaldeGiro;
            _context.Update(financeiro);

            _context.SaveChanges();

        }

       
    }
}
