using ControlePedidos.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ControlePedidos.Data.EntityConfig
{
    public class ProdutoConfig: EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.ProdutoId);
            Property(p => p.ProdutoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.NomeProduto)
                .HasColumnType("varchar")
                .HasMaxLength(70)
                .IsRequired();
            Property(p => p.Preco);
            ToTable("Produtos");
        }        
    }
}
