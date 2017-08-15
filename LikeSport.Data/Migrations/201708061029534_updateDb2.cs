namespace LikeSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IdentityRoles", "Description", c => c.String(maxLength: 250));
            AddColumn("dbo.IdentityRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IdentityRoles", "Discriminator");
            DropColumn("dbo.IdentityRoles", "Description");
        }
    }
}
