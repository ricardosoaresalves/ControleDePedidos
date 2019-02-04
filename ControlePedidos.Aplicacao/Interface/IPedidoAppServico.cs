using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface IPedidoAppServico:IDisposable
    {
        void Adicionar(PedidoViewModel PedidoViewModel);
        PedidoViewModel ObterPorId(Int64 id);
        IEnumerable<PedidoViewModel> ObterTodos();
        IEnumerable<PedidoViewModel> ListarTodos();
        void Excluir(PedidoViewModel itemPedidoViewModel);
        void ExcluirPedido(long id);
        void Atualizar(PedidoViewModel itemPedidoViewModel);
    }
}
