using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ControlePedidos.Aplicacao.Interface;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Servico;

namespace ControlePedidos.Aplicacao
{
    public class EstadoAppServico : AppServiceBase, IEstadoAppServico
    {
        private readonly IEstadoServico _estadoServico;

        public EstadoAppServico(IEstadoServico estadoServico)
        {
            _estadoServico = estadoServico;
        }
        public void Adicionar(EstadoViewModel estadoViewModel)
        {
            var estado = Mapper.Map<EstadoViewModel, Estado>(estadoViewModel);
            BeginTransaction();
            _estadoServico.Adicionar(estado);
            Commit();
        }

        public EstadoViewModel ObterPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(ViewModels.EstadoViewModel estadoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ViewModels.EstadoViewModel estadoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
