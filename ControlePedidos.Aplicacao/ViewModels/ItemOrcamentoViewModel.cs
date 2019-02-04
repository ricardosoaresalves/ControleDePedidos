using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class ItemOrcamentoViewModel
    {
        public long ItemDoOrcamentoId { get; set; }
        public string NomeItem { get; set; }
        public decimal? Valor { get; set; }
        public int? Qtd { get; set; }
        public long ProdutoId { get; set; }
        public long OrcamentoId { get; set; }
        public ProdutoViewModel Produto { get; set; }
        public OrcamentoViewModel Orcamento { get; set; }
    }
}
