using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using ControlePedidos.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Servicos
{
    public class ClienteServico : ServicoBase<Cliente>, IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteServico(IClienteRepositorio clienteRepositorio)
            :base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IEnumerable<Cliente> BuscaPorNome(String nomeCliente)
        {
            return _clienteRepositorio.BuscaPorNome(nomeCliente);
        }

        public Cliente Detalhe(long? id)
        {
            return _clienteRepositorio.ObterPorId(id);            
        }

        public void Excluir(Cliente cliente)
        {
            _clienteRepositorio.Excluir(cliente);
        }

        public void ExcluirCliente(int id)
        {
            _clienteRepositorio.ExcluirCliente(id);
        }
    }
}
