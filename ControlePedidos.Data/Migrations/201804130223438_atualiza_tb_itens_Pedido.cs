namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualiza_tb_itens_Pedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "ItemPedido_ItemPedidoId", "dbo.ItensPedidos");
            DropIndex("dbo.Produtos", new[] { "ItemPedido_ItemPedidoId" });
            DropColumn("dbo.Produtos", "ItemPedido_ItemPedidoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtos", "ItemPedido_ItemPedidoId", c => c.Long());
            CreateIndex("dbo.Produtos", "ItemPedido_ItemPedidoId");
            AddForeignKey("dbo.Produtos", "ItemPedido_ItemPedidoId", "dbo.ItensPedidos", "ItemPedidoId");
        }
    }
}
