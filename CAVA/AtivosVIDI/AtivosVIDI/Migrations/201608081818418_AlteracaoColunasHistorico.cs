namespace AtivosVIDI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AlteracaoColunasHistorico : DbMigration
    {
        public override void Up()
        {
            //DropColumn("Historicos", "Celulares_Id");
            //DropColumn("Historicos", "Chips_Id");
            //DropColumn("Historicos", "Computadores_Id");
            DropColumn("Historicos", "Chips_Id1");
            DropColumn("Historicos", "Colaboradores_Id");
            DropColumn("Historicos", "Colaboradores_Id1");
            DropColumn("Historicos", "Colaboradores_Id2");
            DropColumn("Historicos", "Ativos_Id");
        }

        public override void Down()
        {

            //DropColumn("Historicos", "Celulares_Id");
            //DropColumn("Historicos", "Chips_Id");
            //DropColumn("Historicos", "Computadores_Id");
            DropColumn("Historicos", "Chips_Id1");
            DropColumn("Historicos", "Colaboradores_Id");
            DropColumn("Historicos", "Colaboradores_Id1");
            DropColumn("Historicos", "Colaboradores_Id2");
            DropColumn("Historicos", "Ativos_Id");
        }
    }
}
