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
    public class EnderecoRepositorio : RepositorioBase<Endereco>, IEnderecoRepositorio
    {
        public Endereco ObterCep(string Cep)
        {
            var endereco = (from e in contexto.Enderecos where e.CEP.Equals(Cep) select e).FirstOrDefault();
            return endereco;
        }

        public override void Atualizar(Endereco obj)
        {
            var db = contexto;
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}
