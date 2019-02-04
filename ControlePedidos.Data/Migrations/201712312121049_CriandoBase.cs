namespace ControlePedidos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        CidadeId = c.Long(nullable: false, identity: true),
                        CidadeNome = c.String(nullable: false, maxLength: 70, unicode: false),
                        EstadoId = c.Long(),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estados", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        EstadoId = c.Long(nullable: false, identity: true),
                        UF = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 70, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 12, unicode: false),
                        Rg = c.String(maxLength: 11, unicode: false),
                        Orgao = c.String(maxLength: 50, unicode: false),
                        DataExpedicao = c.DateTime(nullable: false),
                        TelFixo = c.String(maxLength: 10, unicode: false),
                        Celular = c.String(maxLength: 11, unicode: false),
                        EnderecoId = c.Long(nullable: false),
                        Deletado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        EnderecoId = c.Long(nullable: false, identity: true),
                        CidadeId = c.Long(),
                        EstadoId = c.Long(),
                        Rua = c.String(maxLength: 70, unicode: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                        CEP = c.String(maxLength: 9, unicode: false),
                        Bairro = c.String(maxLength: 70, unicode: false),
                        Numero = c.String(maxLength: 7, unicode: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Cidades", t => t.CidadeId)
                .ForeignKey("dbo.Estados", t => t.EstadoId)
                .Index(t => t.CidadeId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidoId = c.Long(nullable: false),
                        ProdutoId = c.Long(nullable: false, identity: true),
                        ClienteId = c.Long(nullable: false),
                        ValorPedido = c.Long(nullable: false),
                        DataPedido = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Long(nullable: false, identity: true),
                        NomeProduto = c.String(nullable: false, maxLength: 70, unicode: false),
                        Preco = c.Long(),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "EnderecoId", "dbo.Enderecos");
            DropForeignKey("dbo.Enderecos", "EstadoId", "dbo.Estados");
            DropForeignKey("dbo.Enderecos", "CidadeId", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "EstadoId", "dbo.Estados");
            DropIndex("dbo.Pedidos", new[] { "ClienteId" });
            DropIndex("dbo.Enderecos", new[] { "EstadoId" });
            DropIndex("dbo.Enderecos", new[] { "CidadeId" });
            DropIndex("dbo.Clientes", new[] { "EnderecoId" });
            DropIndex("dbo.Cidades", new[] { "EstadoId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Estados");
            DropTable("dbo.Cidades");
        }
    }
}
