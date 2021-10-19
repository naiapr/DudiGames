using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models
{
    public class Capital
    {
        public int Id { get; set; }
        public double CapitaldeGiro { get; set; }

        public Capital()
        {

        }

        public Capital(int id, double capitaldeGiro)
        {
            Id = id;
            CapitaldeGiro = capitaldeGiro;
        }
    }


}
