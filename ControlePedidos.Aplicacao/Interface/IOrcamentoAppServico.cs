using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface IOrcamentoAppServico : IDisposable
    {
        void Adcionar(OrcamentoViewModel OrcamentoViewModel);
        OrcamentoViewModel ObterPorId(Int64 id);
        IEnumerable<OrcamentoViewModel> ObterTodos();
        void Excluir(OrcamentoViewModel OrcamentoViewModel);
        void Atualizar(OrcamentoViewModel OrcamentoViewModel);
    }
}
