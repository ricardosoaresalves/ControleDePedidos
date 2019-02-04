namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualiza_tab_orcamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orcamentos", "ProdutoId", c => c.Int(nullable: false));
            DropColumn("dbo.Orcamentos", "Produto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orcamentos", "Produto", c => c.String(maxLength: 300, unicode: false));
            DropColumn("dbo.Orcamentos", "ProdutoId");
        }
    }
}
