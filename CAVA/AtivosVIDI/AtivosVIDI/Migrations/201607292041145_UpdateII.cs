namespace AtivosVIDI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateII : DbMigration
    {
        public override void Up()
        {

            DropTable("dbo.SoftwaresComputadores");
            DropTable("dbo.Softwares");
            DropTable("dbo.Historicos");
            DropTable("dbo.Computadores");
            DropTable("dbo.Chips");
            DropTable("dbo.Celulares");
            DropTable("dbo.Ativos");
            DropTable("dbo.Colaboradores");
            DropTable("dbo.TipoColaboradores");
           



            CreateTable(
                "dbo.Ativos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CelularId = c.Int(),
                        ComputadorId = c.Int(),
                        ChipId = c.Int(),
                        NumeroSerie = c.String(nullable: false, maxLength: 50, unicode: false),
                        Marca = c.String(nullable: false, maxLength: 50, unicode: false),
                        Modelo = c.String(maxLength: 50, unicode: false),
                        ColaboradorId = c.Int(),
                        Origem = c.String(nullable: false, maxLength: 50, unicode: false),
                        Valor = c.Decimal(nullable: false, storeType: "money"),
                        Fornecedor = c.String(nullable: false, maxLength: 50, unicode: false),
                        OrigemCompra = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCompra = c.DateTime(nullable: false, storeType: "date"),
                        NumeroPatrimonio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celulares", t => t.CelularId, cascadeDelete: true)
                .ForeignKey("dbo.Colaboradores", t => t.ColaboradorId)
                .ForeignKey("dbo.Chips", t => t.ChipId, cascadeDelete: true)
                .ForeignKey("dbo.Computadores", t => t.ComputadorId, cascadeDelete: true)
                .Index(t => t.CelularId)
                .Index(t => t.ComputadorId)
                .Index(t => t.ChipId)
                .Index(t => t.ColaboradorId);

            
            CreateTable(
                "dbo.Celulares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(),
                        Modelo = c.String(nullable: false, maxLength: 50),
                        OrigemCelular = c.String(nullable: false, maxLength: 30),
                        NumeroPatrimonio = c.Int(nullable: false),
                        SenhaDesbloqueio = c.Int(nullable: false),
                        NumeroSerie = c.String(nullable: false, maxLength: 40),
                        Imei = c.Long(),
                        LoginLoja = c.String(nullable: false, maxLength: 40),
                        SenhaLoja = c.String(nullable: false, maxLength: 40),
                        Marca = c.String(nullable: false, maxLength: 20),
                        Valor = c.Decimal(nullable: false, storeType: "money"),
                        Fornecedor = c.String(nullable: false, maxLength: 30),
                        OrigemCompra = c.String(nullable: false, maxLength: 30),
                        DataCompra = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaboradores", t => t.ColaboradorId)
                .Index(t => t.ColaboradorId);


            
            CreateTable(
                "dbo.Colaboradores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Email = c.String(nullable: false, maxLength: 200),
                        TelefoneFixo = c.String(maxLength: 15, fixedLength: true, unicode: false),
                        TelefoneCelular = c.String(maxLength: 15, fixedLength: true, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 40, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        NomeCompleto = c.String(nullable: false, maxLength: 100, unicode: false),
                        Genero = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        TipoColaborador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoColaboradores", t => t.TipoColaborador)
                .Index(t => t.TipoColaborador);

           
            CreateTable(
                "dbo.Chips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroChip = c.String(maxLength: 15, fixedLength: true),
                        Conta = c.Int(nullable: false),
                        Ativado = c.Boolean(nullable: false),
                        Plano = c.String(nullable: false, maxLength: 50, unicode: false),
                        ColaboradorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaboradores", t => t.ColaboradorId)
                .Index(t => t.ColaboradorId);

           
            CreateTable(
                "dbo.Historicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AtivoId = c.Int(),
                        ColaboradorIdFinal = c.Int(),
                        AssinouTermoEntrega = c.Boolean(nullable: false),
                        AssinouTermoDevolucao = c.Boolean(nullable: false),
                        DataUserInicio = c.DateTime(nullable: false, storeType: "date"),
                        DataUserFinal = c.DateTime(storeType: "date"),
                        IntermediarioIdAssinouTermo = c.Int(),
                        DataIntermediarioRetirou = c.DateTime(storeType: "date"),
                        IntermediarioIdRecebeu = c.Int(),
                        DataIntermediarioIdRecebeu = c.DateTime(storeType: "date"),
                        Obs = c.String(unicode: false),
                        DataFinalExperiencia = c.DateTime(storeType: "date"),
                        Celulares_Id = c.Int(),
                        Chips_Id = c.Int(),
                        Computadores_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celulares", t => t.Celulares_Id)
                .ForeignKey("dbo.Chips", t => t.Chips_Id)
                .ForeignKey("dbo.Computadores", t => t.Computadores_Id)
                .ForeignKey("dbo.Chips", t => t.ColaboradorIdFinal)
                .ForeignKey("dbo.Colaboradores", t => t.ColaboradorIdFinal)
                .ForeignKey("dbo.Colaboradores", t => t.IntermediarioIdRecebeu)
                .ForeignKey("dbo.Colaboradores", t => t.IntermediarioIdAssinouTermo)
                .ForeignKey("dbo.Ativos", t => t.AtivoId, cascadeDelete: true)
                .Index(t => t.AtivoId)
                .Index(t => t.ColaboradorIdFinal)
                .Index(t => t.IntermediarioIdAssinouTermo)
                .Index(t => t.IntermediarioIdRecebeu)
                .Index(t => t.Celulares_Id)
                .Index(t => t.Chips_Id)
                .Index(t => t.Computadores_Id);


            
            CreateTable(
                "dbo.Computadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceTag = c.String(maxLength: 50),
                        NumeroSerie = c.String(nullable: false, maxLength: 50, unicode: false),
                        NumeroPatrimonio = c.Int(nullable: false),
                        Processador = c.String(nullable: false, maxLength: 50, unicode: false),
                        Marca = c.String(nullable: false, maxLength: 50, unicode: false),
                        Modelo = c.String(nullable: false, maxLength: 50, unicode: false),
                        ColaboradorId = c.Int(),
                        Origem = c.String(nullable: false, maxLength: 50, unicode: false),
                        Obs = c.String(unicode: false),
                        VersaoWindows = c.String(nullable: false, maxLength: 50, unicode: false),
                        Valor = c.Decimal(nullable: false, storeType: "money"),
                        Fornecedor = c.String(nullable: false, maxLength: 50, unicode: false),
                        OrigemCompra = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCompra = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaboradores", t => t.ColaboradorId)
                .Index(t => t.ColaboradorId);

           
            CreateTable(
                "dbo.SoftwaresComputadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SoftwareId = c.Int(nullable: false),
                        ComputadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Softwares", t => t.SoftwareId)
                .ForeignKey("dbo.Computadores", t => t.ComputadorId)
                .Index(t => t.SoftwareId)
                .Index(t => t.ComputadorId);

            
            CreateTable(
                "dbo.Softwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeSoftware = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaximoInstalacoes = c.Byte(nullable: false),
                        KeySoftware = c.String(nullable: false, maxLength: 50, unicode: false),
                        Valor = c.Decimal(nullable: false, storeType: "money"),
                        Fornecedor = c.String(nullable: false, maxLength: 50, unicode: false),
                        OrigemCompra = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCompra = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);

            
            CreateTable(
                "dbo.TipoColaboradores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 10, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historicos", "AtivoId", "dbo.Ativos");
            DropForeignKey("dbo.Colaboradores", "TipoColaborador", "dbo.TipoColaboradores");
            DropForeignKey("dbo.Historicos", "IntermediarioIdAssinouTermo", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "IntermediarioIdRecebeu", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "ColaboradorIdFinal", "dbo.Colaboradores");
            DropForeignKey("dbo.Computadores", "ColaboradorId", "dbo.Colaboradores");
            DropForeignKey("dbo.Chips", "ColaboradorId", "dbo.Colaboradores");
            DropForeignKey("dbo.Historicos", "ColaboradorIdFinal", "dbo.Chips");
            DropForeignKey("dbo.SoftwaresComputadores", "ComputadorId", "dbo.Computadores");
            DropForeignKey("dbo.SoftwaresComputadores", "SoftwareId", "dbo.Softwares");
            DropForeignKey("dbo.Historicos", "Computadores_Id", "dbo.Computadores");
            DropForeignKey("dbo.Ativos", "ComputadorId", "dbo.Computadores");
            DropForeignKey("dbo.Historicos", "Chips_Id", "dbo.Chips");
            DropForeignKey("dbo.Historicos", "Celulares_Id", "dbo.Celulares");
            DropForeignKey("dbo.Ativos", "ChipId", "dbo.Chips");
            DropForeignKey("dbo.Celulares", "ColaboradorId", "dbo.Colaboradores");
            DropForeignKey("dbo.Ativos", "ColaboradorId", "dbo.Colaboradores");
            DropForeignKey("dbo.Ativos", "CelularId", "dbo.Celulares");
            DropIndex("dbo.SoftwaresComputadores", new[] { "ComputadorId" });
            DropIndex("dbo.SoftwaresComputadores", new[] { "SoftwareId" });
            DropIndex("dbo.Computadores", new[] { "ColaboradorId" });
            DropIndex("dbo.Historicos", new[] { "Computadores_Id" });
            DropIndex("dbo.Historicos", new[] { "Chips_Id" });
            DropIndex("dbo.Historicos", new[] { "Celulares_Id" });
            DropIndex("dbo.Historicos", new[] { "IntermediarioIdRecebeu" });
            DropIndex("dbo.Historicos", new[] { "IntermediarioIdAssinouTermo" });
            DropIndex("dbo.Historicos", new[] { "ColaboradorIdFinal" });
            DropIndex("dbo.Historicos", new[] { "AtivoId" });
            DropIndex("dbo.Chips", new[] { "ColaboradorId" });
            DropIndex("dbo.Colaboradores", new[] { "TipoColaborador" });
            DropIndex("dbo.Celulares", new[] { "ColaboradorId" });
            DropIndex("dbo.Ativos", new[] { "ColaboradorId" });
            DropIndex("dbo.Ativos", new[] { "ChipId" });
            DropIndex("dbo.Ativos", new[] { "ComputadorId" });
            DropIndex("dbo.Ativos", new[] { "CelularId" });
            DropTable("dbo.TipoColaboradores");
            DropTable("dbo.Softwares");
            DropTable("dbo.SoftwaresComputadores");
            DropTable("dbo.Computadores");
            DropTable("dbo.Historicos");
            DropTable("dbo.Chips");
            DropTable("dbo.Colaboradores");
            DropTable("dbo.Celulares");
            DropTable("dbo.Ativos");
        }
    }
}
