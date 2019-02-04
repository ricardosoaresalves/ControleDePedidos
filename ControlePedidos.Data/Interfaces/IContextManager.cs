using ControlePedidos.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        ControlePedidoContexto GetContext();
    }
}
