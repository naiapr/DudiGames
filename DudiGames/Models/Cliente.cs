using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Models
{
    public class Cliente
    {
        public int Id { get; set; }
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
