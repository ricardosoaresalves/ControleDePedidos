using ControlePedidos.Aplicacao.Interface;
using System;
using System.Collections.Generic;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Interfaces.Servico;
using AutoMapper;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Aplicacao
{
    public class ItemPedidoAppServico : AppServiceBase, IItemPedidoAppServico
    {
        private readonly IItemPedidoServico _itemPedidoServico;

        public ItemPedidoAppServico(IItemPedidoServico itemPedidoServico)
        {
            _itemPedidoServico = itemPedidoServico;
        }

        public void Adicionar(ItemPedidoViewModel itemPedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ItemPedidoViewModel itemPedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(ItemPedidoViewModel itemPedidoViewModel)
        {
            var itemPedido = Mapper.Map<ItemPedidoViewModel, ItemPedido>(itemPedidoViewModel);
            _itemPedidoServico.Excluir(itemPedido);
        }

        public IEnumerable<ItemPedidoViewModel> ObterItensPedido(long pedidoId)
        {
            var viewModel =  Mapper.Map<IEnumerable<ItemPedido>, 
            IEnumerable<ItemPedidoViewModel>>(_itemPedidoServico.ObterItensPedido(pedidoId));
            return viewModel;            
        }

        public ItemPedidoViewModel ObterPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemPedidoViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
