namespace EyeClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Otchestvo = c.String(),
                        Insurance = c.String(nullable: false),
                        Illness = c.String(nullable: false),
                        Therapy = c.String(),
                        Status = c.String(),
                        Day = c.String(),
                        Month = c.String(),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Therapies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Therapies", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Therapies", new[] { "Patient_Id" });
            DropTable("dbo.Therapies");
            DropTable("dbo.Patients");
        }
    }
}
