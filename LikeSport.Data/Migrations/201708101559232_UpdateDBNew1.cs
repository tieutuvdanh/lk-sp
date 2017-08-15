namespace LikeSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBNew1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityInformations", "UserProfile_Id", "dbo.Accounts");
            DropForeignKey("dbo.Addresses", "UserProfile_Id", "dbo.Accounts");
            DropForeignKey("dbo.ChatInformations", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Feebacks", "UserProfile_Id", "dbo.Accounts");
            DropForeignKey("dbo.Notifications", "UserProfile_Id", "dbo.Accounts");
            DropIndex("dbo.ActivityInformations", new[] { "UserProfile_Id" });
            DropIndex("dbo.Addresses", new[] { "UserProfile_Id" });
            DropIndex("dbo.ChatInformations", new[] { "Account_Id" });
            DropIndex("dbo.Feebacks", new[] { "UserProfile_Id" });
            DropIndex("dbo.Notifications", new[] { "UserProfile_Id" });
            AddColumn("dbo.ActivityInformations", "Account_Id", c => c.Int());
            AddColumn("dbo.Addresses", "Account_Id", c => c.Int());
            AddColumn("dbo.ChatInformations", "Account_Id1", c => c.Int());
            AddColumn("dbo.Feebacks", "Account_Id", c => c.Int());
            AddColumn("dbo.Notifications", "Account_Id", c => c.Int());
            AlterColumn("dbo.ActivityInformations", "UserProfile_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Addresses", "UserProfile_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ChatInformations", "Account_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Feebacks", "UserProfile_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Notifications", "UserProfile_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ActivityInformations", "UserProfile_Id");
            CreateIndex("dbo.ActivityInformations", "Account_Id");
            CreateIndex("dbo.Addresses", "UserProfile_Id");
            CreateIndex("dbo.Addresses", "Account_Id");
            CreateIndex("dbo.ChatInformations", "Account_Id");
            CreateIndex("dbo.ChatInformations", "Account_Id1");
            CreateIndex("dbo.Feebacks", "UserProfile_Id");
            CreateIndex("dbo.Feebacks", "Account_Id");
            CreateIndex("dbo.Notifications", "UserProfile_Id");
            CreateIndex("dbo.Notifications", "Account_Id");
            AddForeignKey("dbo.ActivityInformations", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Addresses", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.ChatInformations", "Account_Id1", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Feebacks", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Notifications", "Account_Id", "dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Feebacks", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.ChatInformations", "Account_Id1", "dbo.Accounts");
            DropForeignKey("dbo.Addresses", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.ActivityInformations", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Notifications", new[] { "Account_Id" });
            DropIndex("dbo.Notifications", new[] { "UserProfile_Id" });
            DropIndex("dbo.Feebacks", new[] { "Account_Id" });
            DropIndex("dbo.Feebacks", new[] { "UserProfile_Id" });
            DropIndex("dbo.ChatInformations", new[] { "Account_Id1" });
            DropIndex("dbo.ChatInformations", new[] { "Account_Id" });
            DropIndex("dbo.Addresses", new[] { "Account_Id" });
            DropIndex("dbo.Addresses", new[] { "UserProfile_Id" });
            DropIndex("dbo.ActivityInformations", new[] { "Account_Id" });
            DropIndex("dbo.ActivityInformations", new[] { "UserProfile_Id" });
            AlterColumn("dbo.Notifications", "UserProfile_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Feebacks", "UserProfile_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatInformations", "Account_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "UserProfile_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ActivityInformations", "UserProfile_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Notifications", "Account_Id");
            DropColumn("dbo.Feebacks", "Account_Id");
            DropColumn("dbo.ChatInformations", "Account_Id1");
            DropColumn("dbo.Addresses", "Account_Id");
            DropColumn("dbo.ActivityInformations", "Account_Id");
            CreateIndex("dbo.Notifications", "UserProfile_Id");
            CreateIndex("dbo.Feebacks", "UserProfile_Id");
            CreateIndex("dbo.ChatInformations", "Account_Id");
            CreateIndex("dbo.Addresses", "UserProfile_Id");
            CreateIndex("dbo.ActivityInformations", "UserProfile_Id");
            AddForeignKey("dbo.Notifications", "UserProfile_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Feebacks", "UserProfile_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.ChatInformations", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Addresses", "UserProfile_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.ActivityInformations", "UserProfile_Id", "dbo.Accounts", "Id");
        }
    }
}
