using ControlePedidos.Aplicacao.Interface;
using System;
using System.Collections.Generic;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Interfaces.Servico;
using AutoMapper;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Aplicacao
{
    public class ClienteAppServico : AppServiceBase, IClienteAppServico
    {
        private readonly IClienteServico _clienteServico;

        public ClienteAppServico(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        public long Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = MapeaParaCliente(clienteViewModel);
            BeginTransaction();
            _clienteServico.Adicionar(cliente);
            Commit();
            return cliente.ClienteId;
        }

        public void Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = MapeaParaCliente(clienteViewModel);
            BeginTransaction();
            _clienteServico.Atualizar(cliente);
            Commit();
        }

        public IEnumerable<ClienteViewModel> BuscaPorNome(string nomeCliente)
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>
                                        (_clienteServico.BuscaPorNome(nomeCliente));
        }

        public ClienteViewModel Detalhe(long? id)
        {
            var cliente  = _clienteServico.Detalhe(id);
            return Mapper.Map<Cliente, ClienteViewModel>(cliente);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool ExcluirAtualizar(int id)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel ObterPorId(long id)
        {
            var cliente = _clienteServico.ObterPorId(id);
            return Mapper.Map<Cliente, ClienteViewModel>(cliente);
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            var clientes = _clienteServico.ObterTodos();
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientes);
        }

        public void Excluir(ClienteViewModel clienteViewModel)
        {
            _clienteServico.Excluir(MapeaParaCliente(clienteViewModel));
        }
        private Cliente MapeaParaCliente(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
            var endereco = Mapper.Map<ClienteViewModel, Endereco>(clienteViewModel);
            var cidade = Mapper.Map<ClienteViewModel, Cidade>(clienteViewModel);
            var estado = Mapper.Map<ClienteViewModel, Estado>(clienteViewModel);

            cliente.Endereco = endereco;
            cliente.Endereco.Cidade = cidade;
            cliente.Endereco.Cidade.Estado = estado;
            cliente.Endereco.Estado = estado;
            return cliente;
        }

        public void ExcluirCliente(int id)
        {
            BeginTransaction();
            _clienteServico.ExcluirCliente(id);
            Commit();
        }
    }
}
