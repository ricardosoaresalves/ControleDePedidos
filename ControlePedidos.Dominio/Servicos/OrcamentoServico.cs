using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Dominio.Interfaces.Repositorio;

namespace ControlePedidos.Dominio.Servicos
{
    public class OrcamentoServico : ServicoBase<Orcamento>, IOrcamentoServico
    {
        private readonly IOrcamentoRepositorio _orcamentoRepositorio;


        public OrcamentoServico(IOrcamentoRepositorio orcamentoRepositorio)
        :base(orcamentoRepositorio)
        {
            _orcamentoRepositorio = orcamentoRepositorio;
        }

        public IEnumerable<Orcamento> ObterOrcamentoClienteNome(string nomeCliente)
        {
            throw new NotImplementedException();
        }
    }
}
