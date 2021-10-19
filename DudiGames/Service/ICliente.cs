using DudiGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudiGames.Service
{
    interface ICliente
    {
        public List<Cliente> FindAll();
        public void AdicionarCliente(Cliente cliente);
        public Cliente FindById(int IdCliente);
        public void EditarCliente(Cliente cliente);
        public void RemoverCliente(Cliente cliente);
    }
}
