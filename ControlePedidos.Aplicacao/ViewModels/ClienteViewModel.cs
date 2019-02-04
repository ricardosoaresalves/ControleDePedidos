using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ControlePedidos.Aplicacao.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {

        }

        [Key]
        public Int64 ClienteId { get; set; }

        [Required(ErrorMessage = "Nome do cliente é obrigatório ")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        public String Nome { get; set; }        
        public int DDDCelular { get; set; }
        public int DDDTelefoneFixo { get; set; }
        [MaxLength(10, ErrorMessage = " maximo 10 digitos")]
        public String Telefone { get; set; }
        [MaxLength(9, ErrorMessage = " maximo 9 digitos")]
        public String Celular { get; set; }
        public Int64? EnderecoId { get; set; }
        public Int64? EstadoId { get; set; }
        public Int64? CidadeId { get; set; }
        public String Rua { get; set; }
        public String Cep { get; set; }
        [DisplayName("Cidade")]
        public String CidadeNome { get; set; }
        public String Bairro { get; set; }
        public String UF { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Referencia { get; set; }        
    }
}
