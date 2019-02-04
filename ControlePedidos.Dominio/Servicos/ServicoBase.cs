using ControlePedidos.Dominio.Interfaces.Repositorio;
using ControlePedidos.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Servicos
{
    public class ServicoBase<TEntit> : IDisposable, IServiceBase<TEntit> where TEntit : class
    {
        private readonly IRepositorioBase<TEntit> _repositorio;

        public ServicoBase(IRepositorioBase<TEntit> repositorio)
        {
            _repositorio = repositorio;
        }
        public virtual void Adicionar(TEntit obj)
        {
            _repositorio.Adicionar(obj);
        }

        public virtual TEntit ObterPorId(Int64 id)
        {
            return _repositorio.ObterPorId(id);
        }

        public virtual IEnumerable<TEntit> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public virtual void Atualizar(TEntit obj)
        {
            _repositorio.Atualizar(obj);
        }

        public virtual void Excluir(TEntit obj)
        {
            _repositorio.Excluir(obj);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
