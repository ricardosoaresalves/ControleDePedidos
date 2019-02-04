using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using ControlePedidos.Dominio.Interfaces.Servico;

namespace ControlePedidos.Dominio.Servicos
{
    public class ItemOrcamentoServico : ServicoBase<ItemDoOrcamento>, IItemOrcamentoServico
    {
        private readonly IItemOrcamentoRepositorio _itemOrcamentoRepositorio;

        public ItemOrcamentoServico(IItemOrcamentoRepositorio itemOrcamentoRepositorio) 
            : base(itemOrcamentoRepositorio)
        {
            _itemOrcamentoRepositorio = itemOrcamentoRepositorio;
        }

        public void Adicionar(IEnumerable<ItemDoOrcamento> ItensOrcamento)
        {
            _itemOrcamentoRepositorio.Adicionar(ItensOrcamento);
        }

        public IEnumerable<ItemDoOrcamento> ObterItensOrcamento(long orcamentoId)
        {
            return _itemOrcamentoRepositorio.ObterItensOrcamento(orcamentoId);
        }
    }
}
