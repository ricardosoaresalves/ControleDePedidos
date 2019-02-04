using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface IItemPedidoAppServico:IDisposable
    {
        void Adicionar(ItemPedidoViewModel itemPedidoViewModel);
        ItemPedidoViewModel ObterPorId(Int64 id);
        IEnumerable<ItemPedidoViewModel> ObterItensPedido(long pedidoId);
        IEnumerable<ItemPedidoViewModel> ObterTodos();
        void Excluir(ItemPedidoViewModel itemPedidoViewModel);
        void Atualizar(ItemPedidoViewModel itemPedidoViewModel);
    }
}
