namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacao_tb_item_pedidos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItensPedidos", "nomeProduto", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.ItensPedidos", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItensPedidos", "Valor", c => c.Long(nullable: false));
            DropColumn("dbo.ItensPedidos", "nomeProduto");
        }
    }
}
