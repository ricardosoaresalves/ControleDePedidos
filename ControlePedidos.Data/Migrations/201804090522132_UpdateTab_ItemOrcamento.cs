namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTab_ItemOrcamento : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ItemsDoOrcamento", "ProdutoId");
            CreateIndex("dbo.ItemsDoOrcamento", "OrcamentoId");
            AddForeignKey("dbo.ItemsDoOrcamento", "OrcamentoId", "dbo.Orcamentos", "OrcamentoId");
            AddForeignKey("dbo.ItemsDoOrcamento", "ProdutoId", "dbo.Produtos", "ProdutoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemsDoOrcamento", "ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.ItemsDoOrcamento", "OrcamentoId", "dbo.Orcamentos");
            DropIndex("dbo.ItemsDoOrcamento", new[] { "OrcamentoId" });
            DropIndex("dbo.ItemsDoOrcamento", new[] { "ProdutoId" });
        }
    }
}
