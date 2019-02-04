namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colun_clienteId_NovoPedido : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.NovoPedido", new[] { "Cliente_ClienteId" });
            RenameColumn(table: "dbo.NovoPedido", name: "Cliente_ClienteId", newName: "ClienteId");
            AlterColumn("dbo.NovoPedido", "ClienteId", c => c.Long(nullable: false));
            CreateIndex("dbo.NovoPedido", "ClienteId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.NovoPedido", new[] { "ClienteId" });
            AlterColumn("dbo.NovoPedido", "ClienteId", c => c.Long());
            RenameColumn(table: "dbo.NovoPedido", name: "ClienteId", newName: "Cliente_ClienteId");
            CreateIndex("dbo.NovoPedido", "Cliente_ClienteId");
        }
    }
}
