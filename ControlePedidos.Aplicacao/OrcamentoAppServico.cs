using ControlePedidos.Aplicacao.Interface;
using System;
using System.Collections.Generic;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Interfaces.Servico;
using AutoMapper;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Aplicacao
{
    public class OrcamentoAppServico : AppServiceBase, IOrcamentoAppServico
    {
        private readonly IOrcamentoServico _orcamentoServico;
        private readonly IItemOrcamentoServico _itemOrcamentoServico;

        public OrcamentoAppServico(IOrcamentoServico orcamentoServico,
                                   IItemOrcamentoServico itemOrcamentoServico
                                   )
        {
            _orcamentoServico = orcamentoServico;
            _itemOrcamentoServico = itemOrcamentoServico;
        }

        public void Adcionar(OrcamentoViewModel OrcamentoViewModel)
        {
            var orcamento = Mapper.Map<OrcamentoViewModel, Orcamento>(OrcamentoViewModel);
            var itensOrcamento = Mapper.Map<IEnumerable<ItemOrcamentoViewModel>, IEnumerable<ItemDoOrcamento>>(OrcamentoViewModel.ItensOrcamento);
            BeginTransaction();
            _orcamentoServico.Adicionar(orcamento);
            _itemOrcamentoServico.Adicionar(itensOrcamento);
            Commit();
        }

        public void Atualizar(OrcamentoViewModel OrcamentoViewModel)
        {
            var orcamento = Mapper.Map<OrcamentoViewModel, Orcamento>(OrcamentoViewModel);
            BeginTransaction();
            _orcamentoServico.Atualizar(orcamento);
            Commit();
        }

        public void Dispose()
        {
            _orcamentoServico.Dispose();
        }

        public void Excluir(OrcamentoViewModel OrcamentoViewModel)
        {
            var orcamento = Mapper.Map<OrcamentoViewModel, Orcamento>(OrcamentoViewModel);
            BeginTransaction();
            _orcamentoServico.Excluir(orcamento);
            Commit();
        }

        public OrcamentoViewModel ObterPorId(long id)
        {

            var orcamento = _orcamentoServico.ObterPorId(id);
            return Mapper.Map<Orcamento, OrcamentoViewModel>(orcamento);
        }

        public IEnumerable<OrcamentoViewModel> ObterTodos()
        {
            var orcamento = _orcamentoServico.ObterTodos();
            return Mapper.Map<IEnumerable<Orcamento>, IEnumerable<OrcamentoViewModel>>(orcamento);
        }
    }
}
