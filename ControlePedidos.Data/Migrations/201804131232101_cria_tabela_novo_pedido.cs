namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cria_tabela_novo_pedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NovoPedido",
                c => new
                    {
                        NovoPedidoId = c.Long(nullable: false, identity: true),
                        DataEntrega = c.DateTime(),
                        DataCompra = c.DateTime(),
                        Deletado = c.Boolean(),
                        Frete = c.Decimal(precision: 18, scale: 2),
                        Cliente_ClienteId = c.Long(),
                    })
                .PrimaryKey(t => t.NovoPedidoId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId)
                .Index(t => t.Cliente_ClienteId);
            
            AddColumn("dbo.ItensPedidos", "Pedido_NovoPedidoId", c => c.Long());
            CreateIndex("dbo.ItensPedidos", "Pedido_NovoPedidoId");
            AddForeignKey("dbo.ItensPedidos", "Pedido_NovoPedidoId", "dbo.NovoPedido", "NovoPedidoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensPedidos", "Pedido_NovoPedidoId", "dbo.NovoPedido");
            DropForeignKey("dbo.NovoPedido", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.NovoPedido", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.ItensPedidos", new[] { "Pedido_NovoPedidoId" });
            DropColumn("dbo.ItensPedidos", "Pedido_NovoPedidoId");
            DropTable("dbo.NovoPedido");
        }
    }
}
