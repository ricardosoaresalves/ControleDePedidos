using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class Produto
    {
        public Int64 ProdutoId { get; set; }
        public String NomeProduto { get; set; }
        public String Descricao { get; set; }
        public Decimal? Preco { get; set; }
        public Boolean? Deletado { get; set; }
        public Decimal? ValorCusto { get; set; }
        public Decimal? DespesasAcessorias { get; set; }
        public Decimal? OutrasDespesas { get; set; }
        public Int32? LucroSugerido { get; set; } 
        public Decimal? ValorVendaSugerido { get; set; }
        public Decimal? ValorVendaUtilizado { get; set; }
    }
}
