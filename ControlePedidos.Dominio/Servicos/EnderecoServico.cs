using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Servico;
using ControlePedidos.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlePedidos.Dominio.Interfaces.Repositorio;

namespace ControlePedidos.Dominio.Servicos
{
    public class EnderecoServico : ServicoBase<Endereco>, IEnderecoServico
    {
        public EnderecoServico(IRepositorioBase<Endereco> repositorio) : base(repositorio)
        {
        }

        public Endereco obterCep(string cep)
        {
            throw new NotImplementedException();
        }
    }
}
