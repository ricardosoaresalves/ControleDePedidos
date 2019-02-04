using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity>:IDisposable where TEntity:class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(long? id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
    }
}
