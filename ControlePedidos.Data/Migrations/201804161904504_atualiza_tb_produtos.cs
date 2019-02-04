namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualiza_tb_produtos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "ValorCusto", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Produtos", "DespesasAcessorias", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Produtos", "OutrasDespesas", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Produtos", "LucroSugerido", c => c.Int());
            AddColumn("dbo.Produtos", "ValorVendaSugerido", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Produtos", "ValorVendaUtilizado", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Produtos", "Deletado", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Deletado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Produtos", "ValorVendaUtilizado");
            DropColumn("dbo.Produtos", "ValorVendaSugerido");
            DropColumn("dbo.Produtos", "LucroSugerido");
            DropColumn("dbo.Produtos", "OutrasDespesas");
            DropColumn("dbo.Produtos", "DespesasAcessorias");
            DropColumn("dbo.Produtos", "ValorCusto");
        }
    }
}
