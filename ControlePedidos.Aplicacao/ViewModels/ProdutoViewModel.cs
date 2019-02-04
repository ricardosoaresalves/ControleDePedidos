using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Int64 ProdutoId { get; set; }
        public String NomeProduto { get; set; }
        public String Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal? Preco { get; set; }
        public Boolean Deletado { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal? ValorCusto { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Int32? LucroSugerido { get; set; }

    }
}
