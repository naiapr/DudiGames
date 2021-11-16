using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models
{
    public class Capital
    {
        public int Id { get; set; }
        
        [Display(Name = "Capital de Giro")]
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
