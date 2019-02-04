using ControlePedidos.Aplicacao.Interface;
using ControlePedidos.Dominio.Interfaces.Servico;
using ControlePedidos.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Aplicacao.ViewModels;
using AutoMapper;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Aplicacao
{
    public class ProdutoAppServico : AppServiceBase, IProdutoAppServico
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoAppServico(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        public void Adicionar(ProdutoViewModel ProdutoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(ProdutoViewModel);
            BeginTransaction();
            _produtoServico.Adicionar(produto);
            Commit();
        }

        public void Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
            BeginTransaction();
            _produtoServico.Atualizar(produto);
            Commit();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public void ExcluirProduto(long id)
        {
            BeginTransaction();
            _produtoServico.ExcluirProduto(id);
            Commit();
        }

        public ProdutoViewModel ObterPorId(long id)
        {
            var produto = _produtoServico.ObterPorId(id);
            return Mapper.Map<Produto, ProdutoViewModel>(produto);

        }

        public IEnumerable<ProdutoViewModel> ObterProdutoPorNome(string nome)
        {
            var produtos = _produtoServico.ObterProdutoPorNome(nome);
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            var produtos = _produtoServico.ObterTodos();
            var produtosViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);
            return produtosViewModel;
        }
    }
}
