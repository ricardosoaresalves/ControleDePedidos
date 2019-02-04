namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop_Pedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedidos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ItensPedidos", "PedidoId", "dbo.Pedidos");
            DropIndex("dbo.Pedidos", new[] { "ClienteId" });
            DropIndex("dbo.ItensPedidos", new[] { "PedidoId" });
            DropTable("dbo.Pedidos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidoId = c.Long(nullable: false, identity: true),
                        ClienteId = c.Long(nullable: false),
                        DataEntrega = c.DateTime(nullable: false),
                        DataCompra = c.DateTime(),
                        Deletado = c.Boolean(),
                        Frete = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PedidoId);
            
            CreateIndex("dbo.ItensPedidos", "PedidoId");
            CreateIndex("dbo.Pedidos", "ClienteId");
            AddForeignKey("dbo.ItensPedidos", "PedidoId", "dbo.Pedidos", "PedidoId");
            AddForeignKey("dbo.Pedidos", "ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
