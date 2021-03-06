﻿using System.Data.Entity;
using LikeSport.Model;
using Microsoft.AspNet.Identity.EntityFramework;
namespace LikeSport.Data
{
    public class ActivitySportDbContext : IdentityDbContext<ApplicationUser>
    {
        public ActivitySportDbContext() : base("name=ActivitySport")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public static ActivitySportDbContext Create()
        {
            return new ActivitySportDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                 .HasMany(e => e.ChatInformations)
                 .WithRequired(e => e.Account)
                 .HasForeignKey(e => e.Account_Id)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.ActivityInformations)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.UserProfile_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.UserProfile_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Feebacks)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.UserProfile_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.UserProfile_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ActivityInformations)
                .WithRequired(e => e.Activity)
                .HasForeignKey(e => e.Activity_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityGroup>()
                .HasMany(e => e.Activities)
                .WithRequired(e => e.ActivityGroup)
                .HasForeignKey(e => e.ActivityGroup_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityInformation>()
                .HasMany(e => e.Promotions)
                .WithRequired(e => e.ActivityInformation)
                .HasForeignKey(e => e.ActivityInformation_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityInformation>()
                .HasMany(e => e.Rates)
                .WithRequired(e => e.ActivityInformation)
                .HasForeignKey(e => e.ActivityInformation_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityInformation>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.ActivityInformation)
                .HasForeignKey(e => e.ActivityInformation_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityInformation>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.ActivityInformation)
                .HasForeignKey(e => e.ActivityInformations_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ActivityInformations)
                .WithRequired(e => e.Service)
                .HasForeignKey(e => e.Service_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }


        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityGroup> ActivityGroups { get; set; }
        public virtual DbSet<ActivityInformation> ActivityInformations { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ChatInformation> ChatInformations { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Feeback> Feebacks { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Service> Services { get; set; }
    }
}
