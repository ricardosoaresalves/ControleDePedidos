using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System.Data.Entity;
using System.Linq;

namespace ControlePedidos.Data.Repositorios
{
    public class EstadoRepositorio : RepositorioBase<Estado>, IEstadoRepositorio
    {
        public Estado ObterPorNome(string nome)
        {
            var busca = (from e in contexto.Estados
                        where e.UF.Equals(nome)
                        select e).FirstOrDefault();
            return busca;
        }

        public override void Atualizar(Estado obj)
        {
            var db = contexto;
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}
