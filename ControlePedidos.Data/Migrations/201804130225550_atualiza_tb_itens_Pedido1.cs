namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualiza_tb_itens_Pedido1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ItensPedidos", "ProdutoId");
            AddForeignKey("dbo.ItensPedidos", "ProdutoId", "dbo.Produtos", "ProdutoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensPedidos", "ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItensPedidos", new[] { "ProdutoId" });
        }
    }
}
