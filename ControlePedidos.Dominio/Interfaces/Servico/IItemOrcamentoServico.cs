using ControlePedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Interfaces.Servico
{
    public interface IItemOrcamentoServico : IServiceBase<ItemDoOrcamento>
    {
        void Adicionar(IEnumerable<ItemDoOrcamento> ItensOrcamento);
        IEnumerable<ItemDoOrcamento> ObterItensOrcamento(Int64 orcamentoId);
    }
}
