using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace ControlePedidos.Data.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public Cliente Detalhe(long? id)
        {
            var db = contexto;
            var clientedetalhe = (from c in db.Clientes.Include(c => c.Endereco)
                                                       .Include(e => e.Endereco.Cidade)
                                                       .Include(es => es.Endereco.Estado)
                                  where c.ClienteId.Equals(id)
                                  select c).FirstOrDefault();
            return clientedetalhe;
        }


        public override void Atualizar(Cliente obj)
        {
            var db = contexto;
            db.Entry(obj).State = EntityState.Modified;
        }


        public IEnumerable<Cliente> BuscaPorNome(string nomeCliente)
        {
            var db = contexto;
            var clientes = (from c in db.Clientes.Include(c => c.Endereco)
                                                 .Include(e => e.Endereco.Cidade)
                                                 .Include(es => es.Endereco.Estado)
                            where c.Nome.Contains(nomeCliente)
                            && c.Deletado == false
                            select c).OrderBy(c=>c.Nome);
            return clientes;
        }

        public void ExcluirCliente(int id)
        {
            try
            {
                var db = contexto;
                var clienteExcluir = (from c in db.Clientes where c.ClienteId == id select c).FirstOrDefault();
                clienteExcluir.Deletado = true;
                db.Entry(clienteExcluir).State = EntityState.Modified;
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

        public override IEnumerable<Cliente> ObterTodos()
        {
            var db = contexto;
            var clientes = (from c in db.Clientes
                            where c.Deletado == false
                            select c).OrderBy(c => c.Nome);
            return clientes;
        }
    }
}
