namespace EindwerkCarParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eigenaars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EigenaarNaam = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parkings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParkingNaam = c.String(nullable: false),
                        Totaal = c.Int(nullable: false),
                        Bezet = c.Int(nullable: false),
                        EigenaarId = c.Int(nullable: false),
                        SoortId = c.Int(nullable: false),
                        LocatieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eigenaars", t => t.EigenaarId, cascadeDelete: true)
                .ForeignKey("dbo.Locaties", t => t.LocatieId, cascadeDelete: true)
                .ForeignKey("dbo.Soorts", t => t.SoortId, cascadeDelete: true)
                .Index(t => t.EigenaarId)
                .Index(t => t.SoortId)
                .Index(t => t.LocatieId);
            
            CreateTable(
                "dbo.Locaties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Straat = c.String(nullable: false),
                        Nr = c.String(),
                        LandId = c.Int(nullable: false),
                        GemeenteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gemeentes", t => t.GemeenteId, cascadeDelete: true)
                .ForeignKey("dbo.Lands", t => t.LandId, cascadeDelete: true)
                .Index(t => t.LandId)
                .Index(t => t.GemeenteId);
            
            CreateTable(
                "dbo.Gemeentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GemeenteNaam = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandNaam = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Soorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SoortNaam = c.String(nullable: false),
                        TotaalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Totaals", t => t.TotaalId, cascadeDelete: true)
                .Index(t => t.TotaalId);
            
            CreateTable(
                "dbo.Totaals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxParkings = c.Int(nullable: false),
                        BezetteParkings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Soorts", "TotaalId", "dbo.Totaals");
            DropForeignKey("dbo.Parkings", "SoortId", "dbo.Soorts");
            DropForeignKey("dbo.Parkings", "LocatieId", "dbo.Locaties");
            DropForeignKey("dbo.Locaties", "LandId", "dbo.Lands");
            DropForeignKey("dbo.Locaties", "GemeenteId", "dbo.Gemeentes");
            DropForeignKey("dbo.Parkings", "EigenaarId", "dbo.Eigenaars");
            DropIndex("dbo.Soorts", new[] { "TotaalId" });
            DropIndex("dbo.Locaties", new[] { "GemeenteId" });
            DropIndex("dbo.Locaties", new[] { "LandId" });
            DropIndex("dbo.Parkings", new[] { "LocatieId" });
            DropIndex("dbo.Parkings", new[] { "SoortId" });
            DropIndex("dbo.Parkings", new[] { "EigenaarId" });
            DropTable("dbo.Totaals");
            DropTable("dbo.Soorts");
            DropTable("dbo.Lands");
            DropTable("dbo.Gemeentes");
            DropTable("dbo.Locaties");
            DropTable("dbo.Parkings");
            DropTable("dbo.Eigenaars");
        }
    }
}
