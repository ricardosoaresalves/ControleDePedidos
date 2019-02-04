namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcao_tab_endereco : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Enderecos", new[] { "CidadeId" });
            DropIndex("dbo.Enderecos", new[] { "EstadoId" });
            AlterColumn("dbo.Enderecos", "CidadeId", c => c.Long(nullable: false));
            AlterColumn("dbo.Enderecos", "EstadoId", c => c.Long(nullable: false));
            CreateIndex("dbo.Enderecos", "CidadeId");
            CreateIndex("dbo.Enderecos", "EstadoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Enderecos", new[] { "EstadoId" });
            DropIndex("dbo.Enderecos", new[] { "CidadeId" });
            AlterColumn("dbo.Enderecos", "EstadoId", c => c.Long());
            AlterColumn("dbo.Enderecos", "CidadeId", c => c.Long());
            CreateIndex("dbo.Enderecos", "EstadoId");
            CreateIndex("dbo.Enderecos", "CidadeId");
        }
    }
}
