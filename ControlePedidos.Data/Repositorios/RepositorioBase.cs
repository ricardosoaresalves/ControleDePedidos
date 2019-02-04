using System;
using System.Collections.Generic;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System.Data.Entity;
using System.Web.Configuration;
using Microsoft.Practices.ServiceLocation;
using ControlePedidos.Infra.Data.Contexto;
using ControlePedidos.Infra.Data.Interfaces;
using System.Linq;

namespace ControlePedidos.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly GerenciadorContexto _gerenciadorContexto = ServiceLocator.Current.GetInstance<IContextManager>() as GerenciadorContexto;
        protected readonly ControlePedidoContexto contexto;
        protected DbSet<TEntity> DbSet;

        public RepositorioBase()
        {
            contexto = _gerenciadorContexto.GetContext();
            DbSet = contexto.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity ObterPorId(long? id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = contexto.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Excluir(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual void SaveChanges()
        {
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
