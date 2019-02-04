using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Data.EntityConfig
{
    public class OrcamentoConfig : EntityTypeConfiguration<Orcamento>
    {
        public OrcamentoConfig()
        {
            HasKey(o => o.OrcamentoId);
            Property(o => o.OrcamentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.NomeCliente).HasMaxLength(220);
            Property(o => o.Bairro).HasMaxLength(80).HasColumnType("varchar"); 
            Property(o => o.Celular).HasMaxLength(11).HasColumnType("varchar");
            Property(o => o.Cep).HasMaxLength(8).HasColumnType("varchar"); 
            Property(o => o.Cidade).HasMaxLength(60).HasColumnType("varchar"); 
            Property(o => o.Complemento).HasMaxLength(15).HasColumnType("varchar"); 
            Property(o => o.CPF).HasMaxLength(11).HasColumnType("varchar"); 
            Property(o => o.Email).HasMaxLength(80).HasColumnType("varchar"); 
            Property(o => o.Estado).HasMaxLength(2).HasColumnType("varchar"); 
            Property(o => o.NomeCliente).HasMaxLength(150).HasColumnType("varchar"); 
            Property(o => o.Numero).HasMaxLength(8).HasColumnType("varchar");              
            Property(o => o.Quantidade);
            Property(o => o.RG).HasMaxLength(10).HasColumnType("varchar"); 
            Property(o => o.Rua).HasMaxLength(80);
            Property(o => o.TelFixo).HasMaxLength(10);
            Property(o => o.ValorProduto);
            Property(o => o.ProdutoId);
            ToTable("Orcamentos");
        }
    }
}
