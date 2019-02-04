using ControlePedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Interfaces.Repositorio
{
    public interface IEstadoRepositorio: IRepositorioBase<Estado>
    {
        Estado ObterPorNome(String nome);
    }
}
