namespace EyeClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        TherapyId = c.Int(nullable: false),
                        IllnessId = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Illnesses", t => t.IllnessId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Therapies", t => t.TherapyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.UserId)
                .Index(t => t.StatusId)
                .Index(t => t.TherapyId)
                .Index(t => t.IllnessId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.MedicalHistories", "TherapyId", "dbo.Therapies");
            DropForeignKey("dbo.MedicalHistories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.MedicalHistories", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicalHistories", "IllnessId", "dbo.Illnesses");
            DropIndex("dbo.MedicalHistories", new[] { "IllnessId" });
            DropIndex("dbo.MedicalHistories", new[] { "TherapyId" });
            DropIndex("dbo.MedicalHistories", new[] { "StatusId" });
            DropIndex("dbo.MedicalHistories", new[] { "UserId" });
            DropIndex("dbo.MedicalHistories", new[] { "PatientId" });
            DropTable("dbo.MedicalHistories");
        }
    }
}
