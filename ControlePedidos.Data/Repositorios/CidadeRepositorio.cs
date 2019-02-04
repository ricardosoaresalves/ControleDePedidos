using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Data.Repositorios
{
    public class CidadeRepositorio : RepositorioBase<Cidade>, ICidadeRepositorio
    {
        public Cidade ObterCidadeNome(string nome)
        {
            var cidade = (from c in contexto.Cidades
                          where c.CidadeNome.Equals(nome)
                          select c).FirstOrDefault();
            return cidade;
        }

        public override void Atualizar(Cidade obj)
        {
            var db = contexto;
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}
