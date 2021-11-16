using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(60, MinimumLength = 3)]
        [Display (Name = "Nome")]
        public string Nome { get; set; }

        public Cliente()
        {

        }

        public Cliente(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
