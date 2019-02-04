using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Dominio.Entidades
{
    public class Orcamento
    {
        public long OrcamentoId { get; set; }
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Celular { get; set; }
        public string TelFixo { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int ProdutoId { get; set; }        
        public decimal Frete { get; set; }
        public decimal ValorProduto { get; set; }
        public int Quantidade { get; set; }        
        public virtual IEnumerable<ItemDoOrcamento> ItensOrcamento { get; set; }
    }
}
