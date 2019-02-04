using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Dominio.Interfaces.Repositorio;

namespace ControlePedidos.Dominio.Servicos
{
    public class PedidoServico : ServicoBase<NovoPedido>, IPedidoServico
    {
        public readonly IPedidoRepositorio _iPedidoRepsoitorio;
        public PedidoServico(IPedidoRepositorio pedidoRepositorio) : base(pedidoRepositorio)
        {
            _iPedidoRepsoitorio = pedidoRepositorio;
        }

        public void ExcluirPedido(long id)
        {
            _iPedidoRepsoitorio.ExcluirPedido(id);
        }

        public IEnumerable<NovoPedido> ListarTodos()
        {
            return _iPedidoRepsoitorio.ListarTodos();
        }
    }
}
