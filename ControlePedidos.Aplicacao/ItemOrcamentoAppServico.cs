using ControlePedidos.Aplicacao.Interface;
using System;
using System.Collections.Generic;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Interfaces.Servico;
using AutoMapper;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Aplicacao
{
    public class ItemOrcamentoAppServico : AppServiceBase, IItemOrcamentoAppServico
    {
        private readonly IItemOrcamentoServico _itemOrcamentoServico;

        public ItemOrcamentoAppServico(IItemOrcamentoServico ItemOrcamentoServico)
        {
            _itemOrcamentoServico = ItemOrcamentoServico;
        }

        public void Adcionar(ItemOrcamentoViewModel ItemOrcamentoViewModel)
        {

            throw new NotImplementedException();
        }

        public void Adicionar(IEnumerable<ItemOrcamentoViewModel> ItensOrcamentoViewModel)
        {
            var item = Mapper.Map<IEnumerable<ItemOrcamentoViewModel>, IEnumerable<ItemDoOrcamento>>(ItensOrcamentoViewModel);
            BeginTransaction();
            _itemOrcamentoServico.Adicionar(item);
            Commit();
        }

        public void Atualizar(ItemOrcamentoViewModel ItemOrcamentoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(ItemOrcamentoViewModel ItemOrcamentoViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemOrcamentoViewModel> ObterItensOrcamento(long orcamentoId)
        {
            var itensOrcamento = _itemOrcamentoServico.ObterItensOrcamento(orcamentoId);
            var itensViewModel = Mapper.Map<IEnumerable<ItemDoOrcamento>, IEnumerable<ItemOrcamentoViewModel>>(itensOrcamento);
            return itensViewModel;
        }

        public ItemOrcamentoViewModel ObterPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemOrcamentoViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
