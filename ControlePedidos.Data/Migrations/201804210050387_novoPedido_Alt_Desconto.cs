namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novoPedido_Alt_Desconto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NovoPedido", "Desconto", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NovoPedido", "Desconto", c => c.Int());
        }
    }
}
