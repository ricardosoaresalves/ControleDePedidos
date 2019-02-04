namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualiza_tbClientes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "DataExpedicao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "DataExpedicao", c => c.DateTime(nullable: false));
        }
    }
}
