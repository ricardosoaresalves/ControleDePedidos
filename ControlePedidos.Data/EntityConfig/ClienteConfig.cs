using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Data.EntityConfig
{
    public class ClienteConfig: EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.ClienteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(c => c.Nome)
                .HasMaxLength(70)
                .IsRequired();

            

            Property(c => c.Celular)
                .HasMaxLength(11)
                .HasColumnType("varchar");

            Property(c => c.TelFixo)
                .HasMaxLength(10)
                .HasColumnType("varchar");

            ToTable("Clientes");
        }
    }
}
