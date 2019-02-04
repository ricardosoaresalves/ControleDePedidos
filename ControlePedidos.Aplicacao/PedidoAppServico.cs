using ControlePedidos.Aplicacao.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Interfaces.Servico;
using AutoMapper;
using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Servicos;

namespace ControlePedidos.Aplicacao
{
    public class PedidoAppServico : AppServiceBase, IPedidoAppServico
    {
        private readonly IPedidoServico _pedidoServico;
        private readonly IItemPedidoServico _itemPedidoServico;

        public PedidoAppServico(IPedidoServico pedidoServico,
                                IItemPedidoServico itemPedidoServico)
        {
            _pedidoServico = pedidoServico;
            _itemPedidoServico = itemPedidoServico;
        }

        public void Adicionar(PedidoViewModel PedidoViewModel)
        {
            var pedido = Mapper.Map<PedidoViewModel, NovoPedido>(PedidoViewModel);
            var itensPedidos = Mapper.Map<IEnumerable<ItemPedidoViewModel>, IEnumerable<ItemPedido>>(PedidoViewModel.ItensPedido);
            
            BeginTransaction();
            _pedidoServico.Adicionar(pedido);
            _itemPedidoServico.Adicionar(itensPedidos);
            Commit();
        }

        public void Atualizar(PedidoViewModel itemPedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(PedidoViewModel viewModel)
        {
            var pedido = Mapper.Map<PedidoViewModel, NovoPedido>(viewModel);
            _pedidoServico.Excluir(pedido);
        }

        public PedidoViewModel ObterPorId(long id)
        {
            var Pedido = Mapper.Map<NovoPedido, PedidoViewModel>
                (_pedidoServico.ObterPorId(id));
            return Pedido;
        }

        public IEnumerable<PedidoViewModel> ObterTodos()
        {
            var pedidos = _pedidoServico.ObterTodos();
            return Mapper.Map<IEnumerable<NovoPedido>, 
                   IEnumerable<PedidoViewModel>>(pedidos);
        }

        public IEnumerable<PedidoViewModel> ListarTodos()
        {
            var pedidos = _pedidoServico.ListarTodos();
            var lista = Mapper.Map<IEnumerable<NovoPedido>,
                   IEnumerable<PedidoViewModel>>(pedidos);
            
            return lista;

        }

        public void ExcluirPedido(long id)
        {
            _pedidoServico.ExcluirPedido(id);
        }
    }
}
