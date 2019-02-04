namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remodelagem_da_base_tabela_item_pedido : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Pedidos");
            CreateTable(
                "dbo.ItensPedidos",
                c => new
                    {
                        ItemPedidoId = c.Long(nullable: false, identity: true),
                        ProdutoId = c.Long(nullable: false),
                        ValorUnit = c.Long(nullable: false),
                        Qtd = c.Long(nullable: false),
                        ValorTotal = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ItemPedidoId);
            
            AlterColumn("dbo.Pedidos", "PedidoId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pedidos", "PedidoId");
            DropColumn("dbo.Pedidos", "ProdutoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidos", "ProdutoId", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.Pedidos");
            AlterColumn("dbo.Pedidos", "PedidoId", c => c.Long(nullable: false));
            DropTable("dbo.ItensPedidos");
            AddPrimaryKey("dbo.Pedidos", "PedidoId");
        }
    }
}
