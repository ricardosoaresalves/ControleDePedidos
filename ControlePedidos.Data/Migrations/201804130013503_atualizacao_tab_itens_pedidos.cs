namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacao_tab_itens_pedidos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItensPedidos", "PedidoId", c => c.Long(nullable: false));
            CreateIndex("dbo.ItensPedidos", "PedidoId");
            AddForeignKey("dbo.ItensPedidos", "PedidoId", "dbo.Pedidos", "PedidoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensPedidos", "PedidoId", "dbo.Pedidos");
            DropIndex("dbo.ItensPedidos", new[] { "PedidoId" });
            DropColumn("dbo.ItensPedidos", "PedidoId");
        }
    }
}
