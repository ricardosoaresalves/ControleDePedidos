using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public Int64 EstadoId { get; set; }
        [MaxLength(2)]
        public String Nome { get; set; }
    }
}
