namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizar_produto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidos", "Deletado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produtos", "Descricao", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Produtos", "Deletado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "Deletado");
            DropColumn("dbo.Produtos", "Descricao");
            DropColumn("dbo.Pedidos", "Deletado");
        }
    }
}
