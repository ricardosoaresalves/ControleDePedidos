using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Data.EntityConfig
{
    public class EstadoConfig:EntityTypeConfiguration<Estado>
    {
        public EstadoConfig()
        {
            HasKey(e => e.EstadoId);
            Property(e => e.EstadoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.UF)
                .HasMaxLength(2)
                .HasColumnType("varchar")
                .IsRequired();
            ToTable("Estados");
        }
    }
}
