using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Data.EntityConfig
{
    public class CidadeConfig: EntityTypeConfiguration<Cidade>
    {
        public CidadeConfig()
        {
            HasKey(c => c.CidadeId);
            Property(c => c.CidadeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.CidadeNome)
                .HasMaxLength(70)
                .IsRequired();
            ToTable("Cidades");
        }
    }
}
