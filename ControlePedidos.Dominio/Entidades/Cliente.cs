using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class Cliente
    {
        public Int64 ClienteId { get; set; }
        public String Nome { get; set; }
        public string Referencia { get; set; }
        public String TelFixo { get; set; }
        public String Celular { get; set; }
        public Int64 EnderecoId { get; set; }
        public Boolean Deletado { get; set; }

        public virtual Endereco Endereco { get; set; }

    }
}
