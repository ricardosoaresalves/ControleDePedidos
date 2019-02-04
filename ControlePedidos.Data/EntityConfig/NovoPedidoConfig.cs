using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Data.EntityConfig
{
    public class NovoPedidoConfig : EntityTypeConfiguration<NovoPedido>
    {
        public NovoPedidoConfig()
        {
            HasKey(n => n.NovoPedidoId);  
            Property(n => n.NovoPedidoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

            
    }
}
