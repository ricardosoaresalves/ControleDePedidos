namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcao_relacionamento_clienteendereco : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Enderecos", new[] { "EnderecoId" });
            CreateIndex("dbo.Clientes", "EnderecoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "EnderecoId" });
            CreateIndex("dbo.Enderecos", "EnderecoId");
        }
    }
}
