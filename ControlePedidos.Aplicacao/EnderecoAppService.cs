using ControlePedidos.Aplicacao.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Aplicacao.ViewModels;
using AutoMapper;
using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Servico;

namespace ControlePedidos.Aplicacao
{
    public class EnderecoAppService : AppServiceBase, IEnderecoAppServico
    {
        private readonly IEnderecoServico _enderecoServico;

        public EnderecoAppService(IEnderecoServico enderecoServico)
        {
            _enderecoServico = enderecoServico;
        }

        public void Adcionar(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            BeginTransaction();
            _enderecoServico.Adicionar(endereco);
            Commit();
        }

        public EnderecoViewModel ObterPorId(long id)
        {
            var endereco = _enderecoServico.ObterPorId(id);
            return Mapper.Map<Endereco, EnderecoViewModel>(endereco);
        }

        public IEnumerable<EnderecoViewModel> ObterTodos()
        {
            var enderecos = _enderecoServico.ObterTodos();
            return Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewModel>>(enderecos);
        }

        public void Excluir(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            BeginTransaction();
            _enderecoServico.Excluir(endereco);
            Commit();
        }

        public void Atualizar(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            BeginTransaction();
            _enderecoServico.Atualizar(endereco);
            Commit();
        }

        public void Dispose()
        {
            _enderecoServico.Dispose();
        }
    }
}
