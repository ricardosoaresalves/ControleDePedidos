using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.Interface
{
    public interface IEstadoAppServico: IDisposable
    {
        void Adicionar(EstadoViewModel estadoViewModel);
        EstadoViewModel ObterPorId(Int64 id);
        IEnumerable<EstadoViewModel> ObterTodos();
        void Remover(EstadoViewModel estadoViewModel);
        void Atualizar(EstadoViewModel estadoViewModel);
    }
}
