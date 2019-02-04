using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class ItemDoOrcamento
    {
        public long ItemDoOrcamentoId { get; set; }
        public string NomeItem { get; set; }
        public decimal? Valor { get; set; }
        public int? Qtd { get; set; }
        public long ProdutoId { get; set; }
        public long OrcamentoId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Orcamento Orcamento { get; set; }

    }
}
