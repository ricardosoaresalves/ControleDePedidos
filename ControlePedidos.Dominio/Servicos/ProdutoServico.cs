using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Dominio.Interfaces.Repositorio;

namespace ControlePedidos.Dominio.Servicos
{
    public class ProdutoServico : ServicoBase<Produto>, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio) : 
            base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public void ExcluirProduto(long id)
        {
            _produtoRepositorio.ExcluirProduto(id);
        }

        public IEnumerable<Produto> ObterProdutoPorNome(string nome)
        {
            return _produtoRepositorio.ObterProdutoPorNome(nome);
        }
    }
}
