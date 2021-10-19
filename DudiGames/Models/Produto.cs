using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models
{
    public class Produto
    {

        public int Id { get; set; }
        /*[Required(ErrorMessage = "O nome da modalidade é obrigatório")]
        [StringLength(30, ErrorMessage = "Limite máximo de 30 caracteres")]
        [Display(Name = "NOME")]*/

        public string Nome { get; set; }

        public Produto()
        {

        }

        public Produto(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
