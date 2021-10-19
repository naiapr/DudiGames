using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DudiGames.Models;

namespace DudiGames.Data
{
    public class DudiGamesContext : DbContext
    {
        public DudiGamesContext (DbContextOptions<DudiGamesContext> options)
            : base(options)
        {
        }

        public DbSet<DudiGames.Models.Produto> Produto { get; set; }

        public DbSet<DudiGames.Models.Capital> Capital { get; set; }
        public DbSet<DudiGames.Models.Cliente> Cliente{ get; set; }
        public DbSet<DudiGames.Models.Compra> Compra { get; set; }
        public DbSet<DudiGames.Models.Estoque> Estoque { get; set; }
        public DbSet<DudiGames.Models.Financeiro> Financeiro { get; set; }
        public DbSet<DudiGames.Models.Pedido> Pedido { get; set; }
    }
}
