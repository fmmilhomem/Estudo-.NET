namespace AtivosVIDI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoColunasDeAtivos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ativos", "NumeroSerie");
            DropColumn("dbo.Ativos", "Marca");
            DropColumn("dbo.Ativos", "Origem");
            DropColumn("dbo.Ativos", "Fornecedor");
            DropColumn("dbo.Ativos", "OrigemCompra");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ativos", "OrigemCompra", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Ativos", "Fornecedor", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Ativos", "Origem", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Ativos", "Marca", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Ativos", "NumeroSerie", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
