namespace EyeClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Group", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Group");
        }
    }
}
