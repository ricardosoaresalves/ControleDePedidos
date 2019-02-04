using ControlePedidos.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ControlePedidos.Data.EntityConfig
{
    public class EnderecoConfig: EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.EnderecoId);
            Property(e => e.EnderecoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Bairro)
                .HasMaxLength(70).IsOptional();
            Property(e => e.CEP)
                .HasMaxLength(9)
                .HasColumnType("varchar"); 
            Property(e => e.Rua)
                .HasMaxLength(70)
                .HasColumnType("varchar");

            Property(e => e.Complemento)
                .HasMaxLength(100)
                .HasColumnType("varchar");
            Property(e => e.Numero)
                .HasMaxLength(7)
                .HasColumnType("varchar");

            ToTable("Enderecos");

        }

    }
}
