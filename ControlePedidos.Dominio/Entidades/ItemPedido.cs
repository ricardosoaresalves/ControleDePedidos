using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class ItemPedido
    {
        public long ItemPedidoId { get; set; }
        public long NovoPedidoId { get; set; }
        public long ProdutoId { get; set; }
        public decimal Valor { get; set; }
        public long Qtd { get; set; }
        public string nomeProduto { get; set; }

        public virtual Produto Produto{get;set;}
        public virtual NovoPedido Pedido { get; set; }
        

    }
}
