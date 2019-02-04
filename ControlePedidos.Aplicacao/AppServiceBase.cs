using ControlePedidos.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao
{
    public class AppServiceBase
    {
        private IUnitOfWork _uow;

        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }
}
