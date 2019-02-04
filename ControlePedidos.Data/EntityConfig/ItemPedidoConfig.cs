using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Data.EntityConfig
{
    public class ItemPedidoConfig : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoConfig()
        {
            HasKey(i => i.ItemPedidoId);
            Property(i => i.ItemPedidoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.ProdutoId);

            Property(i => i.Qtd)
                .IsRequired();

            Property(i => i.Valor)
                .IsRequired();

            Property(i => i.nomeProduto)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            ToTable("ItensPedidos");
        }
    }
}
