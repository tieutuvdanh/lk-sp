namespace LikeSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityInformations", "Image", c => c.String());
            DropColumn("dbo.Activity", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activity", "Image", c => c.String(nullable: false));
            DropColumn("dbo.ActivityInformations", "Image");
        }
    }
}
