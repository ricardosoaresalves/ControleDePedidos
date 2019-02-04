using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class ItemPedidoViewModel
    {
        public long ItemPedidoId { get; set; }
        public long ProdutoId { get; set; }
        public long PedidoId { get; set; }
        public Decimal? Valor { get; set; }
        public long QTD { get; set; }
        public string NomeProduto { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
