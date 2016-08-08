namespace AtivosVIDI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletandoColunasHistorico : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Historicos", "AtivoId", "dbo.Ativos");
            DropForeignKey("dbo.Historicos", "ColaboradorIdFinal", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "IntermediarioIdRecebeu", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "IntermediarioIdAssinouTermo", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "ColaboradorIdFinal", "dbo.Chips");
            DropIndex("dbo.Historicos", new[] { "AtivoId" });
            DropIndex("dbo.Historicos", new[] { "ColaboradorIdFinal" });
            DropIndex("dbo.Historicos", new[] { "IntermediarioIdAssinouTermo" });
            DropIndex("dbo.Historicos", new[] { "IntermediarioIdRecebeu" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historicos", "Chips_Id1", "dbo.Chips");
            DropForeignKey("dbo.Historicos", "Colaboradores_Id2", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "Colaboradores_Id1", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "Colaboradores_Id", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "Ativos_Id", "dbo.Ativos");
            DropIndex("dbo.Historicos", new[] { "Ativos_Id" });
            DropIndex("dbo.Historicos", new[] { "Colaboradores_Id2" });
            DropIndex("dbo.Historicos", new[] { "Colaboradores_Id1" });
            DropIndex("dbo.Historicos", new[] { "Colaboradores_Id" });
            DropIndex("dbo.Historicos", new[] { "Chips_Id1" });
            DropColumn("dbo.Historicos", "Ativos_Id");
            DropColumn("dbo.Historicos", "Colaboradores_Id2");
            DropColumn("dbo.Historicos", "Colaboradores_Id1");
            DropColumn("dbo.Historicos", "Colaboradores_Id");
            DropColumn("dbo.Historicos", "Chips_Id1");
            CreateIndex("dbo.Historicos", "IntermediarioIdRecebeu");
            CreateIndex("dbo.Historicos", "IntermediarioIdAssinouTermo");
            CreateIndex("dbo.Historicos", "ColaboradorIdFinal");
            CreateIndex("dbo.Historicos", "AtivoId");
            AddForeignKey("dbo.Historicos", "ColaboradorIdFinal", "dbo.Chips", "Id");
            AddForeignKey("dbo.Historicos", "IntermediarioIdAssinouTermo", "dbo.Colaboradores", "Id");
            AddForeignKey("dbo.Historicos", "IntermediarioIdRecebeu", "dbo.Colaboradores", "Id");
            AddForeignKey("dbo.Historicos", "ColaboradorIdFinal", "dbo.Colaboradores", "Id");
            AddForeignKey("dbo.Historicos", "AtivoId", "dbo.Ativos", "Id", cascadeDelete: true);
        }
    }
}
