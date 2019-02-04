using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class OrcamentoViewModel
    {
        public long OrcamentoId { get; set; }
        public string NomeCliente { get; set; }
        public string Celular { get; set; }
        public string TelFixo { get; set; }
        public string Email { get; set; }        
        public virtual IEnumerable<ItemOrcamentoViewModel> ItensOrcamento { get; set; }
    }
}
