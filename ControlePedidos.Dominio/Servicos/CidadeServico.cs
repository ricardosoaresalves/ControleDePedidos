using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using ControlePedidos.Dominio.Interfaces.Servico;

namespace ControlePedidos.Dominio.Servicos
{
    public class CidadeServico : ServicoBase<Cidade>, ICidadeServico
    {
        public CidadeServico(IRepositorioBase<Cidade> repositorio) : base(repositorio)
        {
        }

        public Cidade ObterCidadeNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
