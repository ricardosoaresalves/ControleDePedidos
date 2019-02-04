using AutoMapper;
using ControlePedidos.Aplicacao.Interface;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao
{
    public class CidadeAppServico : AppServiceBase, ICidadeAppServico
    {
        private readonly ICidadeServico _cidadeServico;
        public CidadeAppServico(ICidadeServico cidadeServico)
        {
            _cidadeServico = cidadeServico;
        }

        public void Adicionar(ViewModels.CidadeViewModel cidadeViewModel)
        {
            var cidade = Mapper.Map<CidadeViewModel, Cidade>(cidadeViewModel);
            BeginTransaction();
            _cidadeServico.Adicionar(cidade);
            Commit();

        }

        public void Atualizar(CidadeViewModel cidadeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CidadeViewModel ObterPorId(long id)
        {
            var cidade = _cidadeServico.ObterPorId(id);
            return Mapper.Map<Cidade, CidadeViewModel>(cidade);
        }

        public IEnumerable<CidadeViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(CidadeViewModel cidadeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
