using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Data.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public IEnumerable<Produto> ObterProdutoPorNome(string nome)
        {
            var produtos = (from p in contexto.Produtos
                            where p.NomeProduto.Contains(nome)
                            && p.Deletado == false
                            select p).OrderBy(p => p.NomeProduto);
            return produtos;
        }

        public void ExcluirProduto(long id)
        {
            try
            {
                var db = contexto;
                var produtoExcluir = (from p in db.Produtos where p.ProdutoId == id select p).FirstOrDefault();
                produtoExcluir.Deletado = true;
                db.Entry(produtoExcluir).State = EntityState.Modified;
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

        public override IEnumerable<Produto> ObterTodos()
        {
            var db = contexto;
            var lista = (from p in db.Produtos
                         where p.Deletado == false
                         select p).OrderBy(p => p.NomeProduto);
            return lista;
        }


    }
}
