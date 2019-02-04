using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class Endereco
    {
        public Int64 EnderecoId { get; set; }
        public Int64 CidadeId { get; set; }
        public Int64 EstadoId { get; set; }
        public String Rua { get; set; }
        public String Complemento { get; set; }
        public String CEP { get; set; }
        public String Bairro { get; set; }
        public String Numero { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
