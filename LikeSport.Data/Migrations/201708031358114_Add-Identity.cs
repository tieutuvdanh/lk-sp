namespace LikeSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Rates", "Point", c => c.Int(nullable: false));
            AddColumn("dbo.Rates", "Account", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "Gender", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Accounts", "Hobby", c => c.String());
            AlterColumn("dbo.Accounts", "PhoneNumber", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "LoginType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "Photo", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Accounts", "FacebookId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Accounts", "TwitterId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Accounts", "GoogleId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Accounts", "TypeAccount", c => c.String(maxLength: 100));
            AlterColumn("dbo.Accounts", "BusinessName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Accounts", "ContactName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Accounts", "PhoneNumberOrganization", c => c.String(maxLength: 50));
            AlterColumn("dbo.Accounts", "PhotoOrganization", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Accounts", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Accounts", "CreatedBy", c => c.String());
            AlterColumn("dbo.Accounts", "ModifiedBy", c => c.String());
            AlterColumn("dbo.ActivityInformations", "Image", c => c.String(maxLength: 1000));
            AlterColumn("dbo.ActivityInformations", "TagName", c => c.String());
            AlterColumn("dbo.ActivityInformations", "WhatWeDo", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.ActivityInformations", "Views", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.ActivityInformations", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.ActivityInformations", "Status", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ActivityInformations", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ActivityInformations", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Activity", "ActivityName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Activity", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Activity", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.ActivityGroups", "ActivityGroupName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ActivityGroups", "State", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ActivityGroups", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ActivityGroups", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Addresses", "MapInfor", c => c.String());
            AlterColumn("dbo.Addresses", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Promotions", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Promotions", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Promotions", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Rates", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Rates", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Reviews", "Account", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reviews", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reviews", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Services", "NameType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Services", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Services", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Feebacks", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Feebacks", "Reply", c => c.String());
            AlterColumn("dbo.Feebacks", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Feebacks", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Notifications", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Notifications", "Image", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Notifications", "SenderName", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Notifications", "ReceiverName", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Notifications", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Notifications", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Device", "BrowserType", c => c.String(maxLength: 50));
            AlterColumn("dbo.Device", "OS", c => c.String(maxLength: 50));
            AlterColumn("dbo.Device", "Location", c => c.String(maxLength: 500));
            DropColumn("dbo.Rates", "Rated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rates", "Rated", c => c.String(nullable: false));
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            AlterColumn("dbo.Device", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Device", "OS", c => c.String(nullable: false));
            AlterColumn("dbo.Device", "BrowserType", c => c.String(nullable: false));
            AlterColumn("dbo.Notifications", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Notifications", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Notifications", "ReceiverName", c => c.String(nullable: false));
            AlterColumn("dbo.Notifications", "SenderName", c => c.String(nullable: false));
            AlterColumn("dbo.Notifications", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Notifications", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Feebacks", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Feebacks", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Feebacks", "Reply", c => c.String(nullable: false));
            AlterColumn("dbo.Feebacks", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "NameType", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Account", c => c.String(nullable: false));
            AlterColumn("dbo.Rates", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Rates", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Promotions", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Promotions", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Promotions", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "MapInfor", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityGroups", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityGroups", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityGroups", "State", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityGroups", "ActivityGroupName", c => c.String(nullable: false));
            AlterColumn("dbo.Activity", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Activity", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Activity", "ActivityName", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityInformations", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityInformations", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityInformations", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityInformations", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityInformations", "Views", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityInformations", "WhatWeDo", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityInformations", "TagName", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityInformations", "Image", c => c.String());
            AlterColumn("dbo.Accounts", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "PhotoOrganization", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "PhoneNumberOrganization", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "ContactName", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "BusinessName", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "TypeAccount", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "GoogleId", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "TwitterId", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "FacebookId", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Photo", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "LoginType", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Hobby", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Rates", "Account");
            DropColumn("dbo.Rates", "Point");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
        }
    }
}
