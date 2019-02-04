namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovoPedido_Desconto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NovoPedido", "Desconto", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NovoPedido", "Desconto");
        }
    }
}
