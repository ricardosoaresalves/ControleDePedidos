using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface IItemOrcamentoAppServico: IDisposable
    {
        void Adcionar(ItemOrcamentoViewModel ItemOrcamentoViewModel);
        void Adicionar(IEnumerable<ItemOrcamentoViewModel>ItensOrcamentoViewModel);
        ItemOrcamentoViewModel ObterPorId(Int64 id);
        IEnumerable<ItemOrcamentoViewModel> ObterTodos();
        IEnumerable<ItemOrcamentoViewModel> ObterItensOrcamento(Int64 orcamentoId);
        void Excluir(ItemOrcamentoViewModel ItemOrcamentoViewModel);
        void Atualizar(ItemOrcamentoViewModel ItemOrcamentoViewModel);
    }
}
