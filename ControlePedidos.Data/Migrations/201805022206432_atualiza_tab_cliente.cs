namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualiza_tab_cliente : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Email");
            DropColumn("dbo.Clientes", "Cpf");
            DropColumn("dbo.Clientes", "Rg");
            DropColumn("dbo.Clientes", "Orgao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Orgao", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Clientes", "Rg", c => c.String(maxLength: 11, unicode: false));
            AddColumn("dbo.Clientes", "Cpf", c => c.String(nullable: false, maxLength: 12, unicode: false));
            AddColumn("dbo.Clientes", "Email", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
