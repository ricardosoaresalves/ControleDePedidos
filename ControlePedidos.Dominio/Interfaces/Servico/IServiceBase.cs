using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Interfaces.Servico
{
    public interface IServiceBase<TEntity> where TEntity: class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(Int64 id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        void Dispose();
    }
}
