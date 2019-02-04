using ControlePedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Data.EntityConfig
{
    class ItemDoOrcamentoConfig : EntityTypeConfiguration<ItemDoOrcamento>
    {
        public ItemDoOrcamentoConfig()
        {
            HasKey(i => i.ItemDoOrcamentoId);
            Property(i => i.ItemDoOrcamentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.NomeItem)
                .HasMaxLength(200)
                .HasColumnType("varchar")
                .IsRequired();
            Property(i => i.ProdutoId);
            Property(i => i.Qtd);
            Property(i => i.Valor);
            ToTable("ItemsDoOrcamento");
        }
    }
}
