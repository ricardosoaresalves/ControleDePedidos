using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface IEnderecoAppServico: IDisposable
    {
        void Adcionar(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel ObterPorId(Int64 id);
        IEnumerable<EnderecoViewModel> ObterTodos();
        void Excluir(EnderecoViewModel enderecoViewModel);
        void Atualizar(EnderecoViewModel enderecoViewModel);
    }
}
