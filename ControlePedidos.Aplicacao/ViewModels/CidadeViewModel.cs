using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public Int64 CidadeId { get; set; }
        [MaxLength(70)]
        [DisplayName("Cidade")]
        public String Nome { get; set; }
        public Int64 EstadoId { get; set; }
        public virtual EstadoViewModel Estado { get; set; }
    }
}
