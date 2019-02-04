using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface IProdutoAppServico : IDisposable
    {
        void Adicionar(ProdutoViewModel produtoViewModel);
        ProdutoViewModel ObterPorId(Int64 id);
        IEnumerable<ProdutoViewModel> ObterProdutoPorNome(string nome);
        IEnumerable<ProdutoViewModel> ObterTodos();
        void Excluir(ProdutoViewModel produtoViewModel);
        void ExcluirProduto(long id);
        void Atualizar(ProdutoViewModel produtoViewModel);

    }
}
