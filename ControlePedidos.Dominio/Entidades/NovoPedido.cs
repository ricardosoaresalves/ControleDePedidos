using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class NovoPedido
    {
        public long NovoPedidoId { get; set; }
        public long ClienteId { get; set; }
        public DateTime? DataEntrega { get; set; }
        public DateTime? DataCompra { get; set; }
        public bool? Deletado { get; set; }
        public decimal? Frete { get; set; }
        public decimal? Desconto { get; set; }

        public virtual IEnumerable<ItemPedido> ItensPedido { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
