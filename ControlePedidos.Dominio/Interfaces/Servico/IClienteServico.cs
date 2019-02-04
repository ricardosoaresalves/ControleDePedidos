using ControlePedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Interfaces.Servico
{
    public interface IClienteServico : IServiceBase<Cliente>
    {
        Cliente Detalhe(long? id);
        IEnumerable<Cliente> BuscaPorNome(String nomeCliente);
        void ExcluirCliente(int id);

    }
}
