using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface ICidadeAppServico: IDisposable
    {
        void Adicionar(CidadeViewModel cidadeViewModel);
        CidadeViewModel ObterPorId(Int64 id);
        IEnumerable<CidadeViewModel> ObterTodos();
        void Excluir(CidadeViewModel cidadeViewModel);
        void Atualizar(CidadeViewModel cidadeViewModel);
    }
}
