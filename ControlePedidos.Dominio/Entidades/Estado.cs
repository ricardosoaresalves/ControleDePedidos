using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class Estado
    {
        public Int64 EstadoId { get; set; }
        public String UF { get; set; }
        public virtual IEnumerable<Cidade> Cidades { get; set; }
    }
}
