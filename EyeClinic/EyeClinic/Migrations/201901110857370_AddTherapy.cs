namespace EyeClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTherapy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Therapies", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Therapies", new[] { "Patient_Id" });
            CreateTable(
                "dbo.Schemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchemeName = c.String(nullable: false),
                        PriceScheme = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TherapySchemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TherapyId = c.Int(nullable: false),
                        SchemeId = c.Int(nullable: false),
                        SchemePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schemes", t => t.SchemeId, cascadeDelete: true)
                .ForeignKey("dbo.Therapies", t => t.TherapyId, cascadeDelete: true)
                .Index(t => t.TherapyId)
                .Index(t => t.SchemeId);
            
            AddColumn("dbo.Therapies", "TherapyName", c => c.String(nullable: false));
            AddColumn("dbo.Therapies", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Therapies", "Name");
            DropColumn("dbo.Therapies", "Patient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Therapies", "Patient_Id", c => c.Int());
            AddColumn("dbo.Therapies", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.TherapySchemes", "TherapyId", "dbo.Therapies");
            DropForeignKey("dbo.TherapySchemes", "SchemeId", "dbo.Schemes");
            DropIndex("dbo.TherapySchemes", new[] { "SchemeId" });
            DropIndex("dbo.TherapySchemes", new[] { "TherapyId" });
            DropColumn("dbo.Therapies", "Price");
            DropColumn("dbo.Therapies", "TherapyName");
            DropTable("dbo.TherapySchemes");
            DropTable("dbo.Schemes");
            CreateIndex("dbo.Therapies", "Patient_Id");
            AddForeignKey("dbo.Therapies", "Patient_Id", "dbo.Patients", "Id");
        }
    }
}
