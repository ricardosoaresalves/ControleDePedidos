using ControlePedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Interfaces.Servico
{
    public interface IItemPedidoServico: IServiceBase<ItemPedido>
    {
        void Adicionar(IEnumerable<ItemPedido> ItensPedido);
        IEnumerable<ItemPedido> ObterItensPedido(Int64 pedidoId);

        
    }
}
