using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System;

namespace ControlePedidos.Data.Repositorios
{
    public class PedidoRepositorio : RepositorioBase<NovoPedido>, IPedidoRepositorio
    {
        public IEnumerable<NovoPedido> ListarTodos()
        {
            var db = contexto;
            var pedidos = (from p in db.NovosPedidos.Include(c => c.Cliente)
                           where p.Deletado != true
                           select p);
            return pedidos;
        }

        public override NovoPedido ObterPorId(long? id)
        {
            var db = contexto;
            var pedidos = (from p in db.NovosPedidos.Include(p => p.Cliente)
                           where p.NovoPedidoId.Equals(id.Value)
                           select p).FirstOrDefault();
            return pedidos;

        }

        public override void Excluir(NovoPedido obj)
        {
            try
            {
                var db = contexto;
                var pedidoExcluir = (from p in db.NovosPedidos where p.NovoPedidoId.Equals(obj.NovoPedidoId) select p).FirstOrDefault();
                pedidoExcluir.Deletado = true;
                db.Entry(pedidoExcluir).State = EntityState.Modified;
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

        public void ExcluirPedido(long id)
        {
            try
            {
                var db = contexto;
                var pedidoExcluir = (from p in db.NovosPedidos where p.NovoPedidoId.Equals(id) select p).FirstOrDefault();
                pedidoExcluir.Deletado = true;
                db.Entry(pedidoExcluir).State = EntityState.Modified;
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
    }
}
