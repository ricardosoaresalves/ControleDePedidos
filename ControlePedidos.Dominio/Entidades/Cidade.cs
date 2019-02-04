using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class Cidade
    {
        public Int64 CidadeId { get; set; }
        public String CidadeNome { get; set; }
        public Int64? EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
