namespace LikeSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        BirthOfDate = c.DateTime(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Hobby = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        LoginType = c.String(nullable: false),
                        Photo = c.String(nullable: false),
                        FacebookId = c.String(nullable: false),
                        TwitterId = c.String(nullable: false),
                        GoogleId = c.String(nullable: false),
                        TypeAccount = c.String(nullable: false),
                        BusinessName = c.String(nullable: false),
                        ContactName = c.String(nullable: false),
                        PhoneNumberOrganization = c.String(nullable: false),
                        PhotoOrganization = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActivityInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TagName = c.String(nullable: false),
                        WhatWeDo = c.String(nullable: false),
                        Views = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        Activity_Id = c.Int(nullable: false),
                        Service_Id = c.Int(nullable: false),
                        UserProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activity", t => t.Activity_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.Accounts", t => t.UserProfile_Id)
                .Index(t => t.Activity_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        State = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ActivityGroup_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityGroups", t => t.ActivityGroup_Id)
                .Index(t => t.ActivityGroup_Id);
            
            CreateTable(
                "dbo.ActivityGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityGroupName = c.String(nullable: false),
                        State = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        MapInfor = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        UserProfile_Id = c.Int(nullable: false),
                        ActivityInformations_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityInformations", t => t.ActivityInformations_Id)
                .ForeignKey("dbo.Accounts", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.ActivityInformations_Id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Percent = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ActivityInformation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityInformations", t => t.ActivityInformation_Id)
                .Index(t => t.ActivityInformation_Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rated = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ActivityInformation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityInformations", t => t.ActivityInformation_Id)
                .Index(t => t.ActivityInformation_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comments = c.String(nullable: false),
                        Account = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ActivityInformation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityInformations", t => t.ActivityInformation_Id)
                .Index(t => t.ActivityInformation_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(nullable: false),
                        State = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChatInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Feebacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Reply = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        UserProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        SenderName = c.String(nullable: false),
                        ReceiverName = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        UserProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.Device",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IP = c.String(nullable: false),
                        BrowserType = c.String(nullable: false),
                        OS = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "UserProfile_Id", "dbo.Accounts");
            DropForeignKey("dbo.Feebacks", "UserProfile_Id", "dbo.Accounts");
            DropForeignKey("dbo.ChatInformations", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Addresses", "UserProfile_Id", "dbo.Accounts");
            DropForeignKey("dbo.ActivityInformations", "UserProfile_Id", "dbo.Accounts");
            DropForeignKey("dbo.ActivityInformations", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Reviews", "ActivityInformation_Id", "dbo.ActivityInformations");
            DropForeignKey("dbo.Rates", "ActivityInformation_Id", "dbo.ActivityInformations");
            DropForeignKey("dbo.Promotions", "ActivityInformation_Id", "dbo.ActivityInformations");
            DropForeignKey("dbo.Addresses", "ActivityInformations_Id", "dbo.ActivityInformations");
            DropForeignKey("dbo.ActivityInformations", "Activity_Id", "dbo.Activity");
            DropForeignKey("dbo.Activity", "ActivityGroup_Id", "dbo.ActivityGroups");
            DropIndex("dbo.Notifications", new[] { "UserProfile_Id" });
            DropIndex("dbo.Feebacks", new[] { "UserProfile_Id" });
            DropIndex("dbo.ChatInformations", new[] { "Account_Id" });
            DropIndex("dbo.Reviews", new[] { "ActivityInformation_Id" });
            DropIndex("dbo.Rates", new[] { "ActivityInformation_Id" });
            DropIndex("dbo.Promotions", new[] { "ActivityInformation_Id" });
            DropIndex("dbo.Addresses", new[] { "ActivityInformations_Id" });
            DropIndex("dbo.Addresses", new[] { "UserProfile_Id" });
            DropIndex("dbo.Activity", new[] { "ActivityGroup_Id" });
            DropIndex("dbo.ActivityInformations", new[] { "UserProfile_Id" });
            DropIndex("dbo.ActivityInformations", new[] { "Service_Id" });
            DropIndex("dbo.ActivityInformations", new[] { "Activity_Id" });
            DropTable("dbo.Device");
            DropTable("dbo.Notifications");
            DropTable("dbo.Feebacks");
            DropTable("dbo.ChatInformations");
            DropTable("dbo.Services");
            DropTable("dbo.Reviews");
            DropTable("dbo.Rates");
            DropTable("dbo.Promotions");
            DropTable("dbo.Addresses");
            DropTable("dbo.ActivityGroups");
            DropTable("dbo.Activity");
            DropTable("dbo.ActivityInformations");
            DropTable("dbo.Accounts");
        }
    }
}
