using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Data.Repositorios
{
    public class OrcamentoRepositorio : RepositorioBase<Orcamento>, IOrcamentoRepositorio
    {

        IEnumerable<Orcamento> IOrcamentoRepositorio.ObterOrcamentoClienteNome(string nomeCliente)
        {
            var Orcamentos = (from o in contexto.Orcamentos
                              where o.NomeCliente.Contains(nomeCliente)
                              select o);
            return Orcamentos;
        }
    }
}
