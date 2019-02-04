using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Interfaces.Servico
{
    public interface IProdutoServico:IServiceBase<Produto>
    {
        IEnumerable<Produto> ObterProdutoPorNome(string nome);
        void ExcluirProduto(long id);
    }
}
