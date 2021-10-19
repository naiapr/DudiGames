using DudiGames.Data;
using DudiGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    public class ClienteService : ICliente
    {
        private readonly DudiGamesContext _context;

        public ClienteService(DudiGamesContext context)
        {
            _context = context;
        }

        public void AdicionarCliente(Cliente cliente)
        {
           _context.Cliente.Add(cliente);
           _context.SaveChanges();
        }

        public void EditarCliente(Cliente cliente)
        {
            var obj = _context.Cliente.Find(cliente.Id);
            obj.Nome = cliente.Nome;
            _context.Cliente.Update(obj);
            _context.SaveChanges();
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.OrderBy(x => x.Nome).ToList();
        }

        public Cliente FindById(int IdCliente)
        {
            return _context.Cliente.FirstOrDefault(obj=>obj.Id == IdCliente);
        }

        public void RemoverCliente(Cliente cliente)
        {
            var obj = _context.Cliente.Find(cliente.Id);
            obj.Nome = cliente.Nome;
            _context.Cliente.Remove(obj);
            _context.SaveChanges();
        }


    }
}
