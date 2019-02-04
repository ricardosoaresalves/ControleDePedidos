using ControlePedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Interfaces.Servico
{
    public interface IPedidoServico:IServiceBase<NovoPedido>
    {
        IEnumerable<NovoPedido> ListarTodos();
        void ExcluirPedido(long id);
    }
}
