namespace LikeSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "FisrtName", c => c.String(maxLength: 256));
            AddColumn("dbo.ApplicationUsers", "LastName", c => c.String(maxLength: 256));
            AddColumn("dbo.ApplicationUsers", "Gender", c => c.String(maxLength: 10));
            AddColumn("dbo.ApplicationUsers", "Hobby", c => c.String(maxLength: 500));
            AddColumn("dbo.ApplicationUsers", "Image", c => c.String());
            AddColumn("dbo.ApplicationUsers", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "BirthDay");
            DropColumn("dbo.ApplicationUsers", "Image");
            DropColumn("dbo.ApplicationUsers", "Hobby");
            DropColumn("dbo.ApplicationUsers", "Gender");
            DropColumn("dbo.ApplicationUsers", "LastName");
            DropColumn("dbo.ApplicationUsers", "FisrtName");
        }
    }
}
