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
    public class EstadoServico : ServicoBase<Estado>, IEstadoServico
    {
        public EstadoServico(IRepositorioBase<Estado> repositorio) : base(repositorio)
        {
        }

        public Estado ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
