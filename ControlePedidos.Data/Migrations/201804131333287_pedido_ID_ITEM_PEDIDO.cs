namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedido_ID_ITEM_PEDIDO : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ItensPedidos", new[] { "Pedido_NovoPedidoId" });
            RenameColumn(table: "dbo.ItensPedidos", name: "Pedido_NovoPedidoId", newName: "NovoPedidoId");
            AlterColumn("dbo.ItensPedidos", "NovoPedidoId", c => c.Long(nullable: false));
            CreateIndex("dbo.ItensPedidos", "NovoPedidoId");
            DropColumn("dbo.ItensPedidos", "PedidoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItensPedidos", "PedidoId", c => c.Long(nullable: false));
            DropIndex("dbo.ItensPedidos", new[] { "NovoPedidoId" });
            AlterColumn("dbo.ItensPedidos", "NovoPedidoId", c => c.Long());
            RenameColumn(table: "dbo.ItensPedidos", name: "NovoPedidoId", newName: "Pedido_NovoPedidoId");
            CreateIndex("dbo.ItensPedidos", "Pedido_NovoPedidoId");
        }
    }
}
