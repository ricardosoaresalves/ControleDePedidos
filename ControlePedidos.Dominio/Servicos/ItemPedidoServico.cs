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
    public class ItemPedidoServico : ServicoBase<ItemPedido>, IItemPedidoServico
    {
        public readonly IItemPedidoRepositorio _itemPedidoRepositorio;

        public ItemPedidoServico(IItemPedidoRepositorio itemPedidoRepositorio) 
            : base(itemPedidoRepositorio)
        {
            _itemPedidoRepositorio = itemPedidoRepositorio;
        }

        public void Adicionar(IEnumerable<ItemPedido> ItensPedido)
        {
            _itemPedidoRepositorio.Adicionar(ItensPedido);
        }

        public IEnumerable<ItemPedido> ObterItensPedido(long pedidoId)
        {
            var itens = _itemPedidoRepositorio.ObterItensPedido(pedidoId);
            return itens;
        }
    }
}
