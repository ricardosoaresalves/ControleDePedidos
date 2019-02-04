using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface IClienteAppServico : IDisposable
    {
        long Adicionar(ClienteViewModel clienteViewModel);
        ClienteViewModel ObterPorId(long id);
        ClienteViewModel Detalhe(long? id);
        bool ExcluirAtualizar(int id);
        IEnumerable<ClienteViewModel> ObterTodos();
        IEnumerable<ClienteViewModel> BuscaPorNome(String nomeCliente);
        void Excluir(ClienteViewModel clienteViewModel);
        void Atualizar(ClienteViewModel clienteViewModel);
        void ExcluirCliente(int id);
    }
}
