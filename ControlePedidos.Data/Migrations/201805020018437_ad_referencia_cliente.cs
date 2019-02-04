namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad_referencia_cliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Referencia", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Referencia");
        }
    }
}
