namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova_Tabela_Item_Orcamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemsDoOrcamento",
                c => new
                    {
                        ItemDoOrcamentoId = c.Long(nullable: false, identity: true),
                        NomeItem = c.String(nullable: false, maxLength: 200, unicode: false),
                        Valor = c.Decimal(precision: 18, scale: 2),
                        Qtd = c.Int(),
                        ProdutoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ItemDoOrcamentoId);
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemsDoOrcamento");
        }
    }
}
