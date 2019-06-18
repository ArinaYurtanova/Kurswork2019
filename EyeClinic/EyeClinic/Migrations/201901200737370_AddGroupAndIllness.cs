namespace EyeClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupAndIllness : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Illnesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IllnessName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Illnesses");
            DropTable("dbo.Groups");
        }
    }
}
