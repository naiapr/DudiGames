using DudiGames.Data;
using DudiGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    public class CapitalService : ICapital
    {
        private readonly DudiGamesContext _context;

        public CapitalService(DudiGamesContext context)
        {
            _context = context;
        }

        public void AdicionarCapital(Capital capital)
        {
            
            _context.Add(capital);

            _context.SaveChanges();
        }

        public void EditarCapital(Capital capital)
        {
            var obj = _context.Capital.Find(capital.Id);
            obj.CapitaldeGiro = capital.CapitaldeGiro;
            _context.Update(capital);
            _context.SaveChanges();
        }

        public List<Capital> FindAll()
        {
            return _context.Capital.OrderBy(x => x.CapitaldeGiro).ToList();
        }

        public Capital FindById(int IdCapital)
        {
            return _context.Capital.FirstOrDefault(obj => obj.Id == IdCapital);
        }

        public void RemoverCapital(Capital capital)
        {
            var obj = _context.Capital.Find(capital.Id);
            obj.CapitaldeGiro = capital.CapitaldeGiro;
            _context.Capital.Remove(obj);
            _context.SaveChanges();
        }


       
    }
}
