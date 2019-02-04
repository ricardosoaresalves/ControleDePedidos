namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabela_Orcamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orcamentos",
                c => new
                    {
                        OrcamentoId = c.Long(nullable: false, identity: true),
                        NomeCliente = c.String(maxLength: 150, unicode: false),
                        CPF = c.String(maxLength: 11, unicode: false),
                        RG = c.String(maxLength: 10, unicode: false),
                        Celular = c.String(maxLength: 11, unicode: false),
                        TelFixo = c.String(maxLength: 10, unicode: false),
                        Email = c.String(maxLength: 80, unicode: false),
                        Rua = c.String(maxLength: 80, unicode: false),
                        Bairro = c.String(maxLength: 80, unicode: false),
                        Cidade = c.String(maxLength: 60, unicode: false),
                        Estado = c.String(maxLength: 2, unicode: false),
                        Numero = c.String(maxLength: 8, unicode: false),
                        Complemento = c.String(maxLength: 15, unicode: false),
                        Cep = c.String(maxLength: 8, unicode: false),
                        Produto = c.String(maxLength: 300, unicode: false),
                        Frete = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorProduto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrcamentoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orcamentos");
        }
    }
}
