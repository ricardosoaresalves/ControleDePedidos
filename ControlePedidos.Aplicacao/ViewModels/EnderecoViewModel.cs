using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Int64 EnderecoId { get; set; }
        public String Rua { get; set; }
        public String Complemento { get; set; }
        public String Cep { get; set; }
        public String Bairro { get; set; }
        public String Estado { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public Int64 CidadeId { get; set; }
    }
}
