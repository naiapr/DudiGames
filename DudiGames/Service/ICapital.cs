using DudiGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    interface ICapital
    {
        public List<Capital> FindAll();
        public void AdicionarCapital(Capital capital);
        public Capital FindById(int IdCapital);
        public void EditarCapital(Capital capital);
        public void RemoverCapital(Capital capital);
    }
}
