using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Data.EntityConfig;

namespace ControlePedidos.Infra.Data.Contexto
{
    public class ControlePedidoContexto : DbContext
    {
        public ControlePedidoContexto()
            : base("ControlePedido") { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<NovoPedido> NovosPedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<ItemDoOrcamento> ItemDoOrcamento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<String>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new CidadeConfig());
            modelBuilder.Configurations.Add(new EstadoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new ItemPedidoConfig());
            modelBuilder.Configurations.Add(new OrcamentoConfig());
            modelBuilder.Configurations.Add(new NovoPedidoConfig());
            modelBuilder.Configurations.Add(new ItemDoOrcamentoConfig());
            base.OnModelCreating(modelBuilder);
        }

    }
}
