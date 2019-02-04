using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class PedidoViewModel
    {
        public long PedidoId { get; set; }
        public long ProdutoId { get; set; }
        public long ClienteId { get; set; }
                    
        [DisplayName("Data da compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataCompra { get; set; }

        [DisplayName("Data da entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime? DataEntrega { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal? Frete { get; set; }
        public Decimal? Desconto { get; set; }

        [DisplayName("Cliente")]
        public string NomeCliente { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public IEnumerable<ItemPedidoViewModel> ItensPedido { get; set; }


    }
}
