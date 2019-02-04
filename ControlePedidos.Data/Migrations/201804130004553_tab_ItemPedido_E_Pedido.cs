namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tab_ItemPedido_E_Pedido : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clientes", new[] { "EnderecoId" });
            AddColumn("dbo.Produtos", "ItemPedido_ItemPedidoId", c => c.Long());
            AddColumn("dbo.ItensPedidos", "Valor", c => c.Long(nullable: false));
            AddColumn("dbo.Pedidos", "DataEntrega", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pedidos", "DataCompra", c => c.DateTime());
            AddColumn("dbo.Pedidos", "Frete", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Pedidos", "Deletado", c => c.Boolean());
            CreateIndex("dbo.Enderecos", "EnderecoId");
            CreateIndex("dbo.Produtos", "ItemPedido_ItemPedidoId");
            AddForeignKey("dbo.Produtos", "ItemPedido_ItemPedidoId", "dbo.ItensPedidos", "ItemPedidoId");
            DropColumn("dbo.ItensPedidos", "ValorUnit");
            DropColumn("dbo.ItensPedidos", "ValorTotal");
            DropColumn("dbo.Pedidos", "ValorPedido");
            DropColumn("dbo.Pedidos", "DataPedido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidos", "DataPedido", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pedidos", "ValorPedido", c => c.Long(nullable: false));
            AddColumn("dbo.ItensPedidos", "ValorTotal", c => c.Long(nullable: false));
            AddColumn("dbo.ItensPedidos", "ValorUnit", c => c.Long(nullable: false));
            DropForeignKey("dbo.Produtos", "ItemPedido_ItemPedidoId", "dbo.ItensPedidos");
            DropIndex("dbo.Produtos", new[] { "ItemPedido_ItemPedidoId" });
            DropIndex("dbo.Enderecos", new[] { "EnderecoId" });
            AlterColumn("dbo.Pedidos", "Deletado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Pedidos", "Frete");
            DropColumn("dbo.Pedidos", "DataCompra");
            DropColumn("dbo.Pedidos", "DataEntrega");
            DropColumn("dbo.ItensPedidos", "Valor");
            DropColumn("dbo.Produtos", "ItemPedido_ItemPedidoId");
            CreateIndex("dbo.Clientes", "EnderecoId");
        }
    }
}
