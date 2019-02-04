using ControlePedidos.Infra.Data.Contexto;
using ControlePedidos.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ControlePedidoContexto _contexto;
        private readonly GerenciadorContexto _gerenciadorContexto = ServiceLocator.Current.GetInstance<IContextManager>() as GerenciadorContexto;
        private bool _disposed;

        public UnitOfWork()
        {
            _contexto = _gerenciadorContexto.GetContext();
        }


        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            try
            {
                _contexto.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
