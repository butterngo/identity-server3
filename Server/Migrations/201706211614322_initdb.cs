namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.AllowedScopes",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Scope = c.String(),
            //            CustomClientId = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CustomClients", t => t.CustomClientId)
            //    .Index(t => t.CustomClientId);
            
            //CreateTable(
            //    "dbo.CustomClients",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(),
            //            Flow = c.Int(nullable: false),
            //            RequireConsent = c.Boolean(nullable: false),
            //            AllowRememberConsent = c.Boolean(nullable: false),
            //            AccessTokenType = c.Int(nullable: false),
            //            RefreshTokenUsage = c.Int(nullable: false),
            //            IdentityTokenLifetime = c.Int(nullable: false),
            //            AccessTokenLifetime = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ClientSecrets",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Secret = c.String(),
            //            HeaderValue = c.String(),
            //            Expiration = c.DateTimeOffset(precision: 7),
            //            CustomClientId = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CustomClients", t => t.CustomClientId)
            //    .Index(t => t.CustomClientId);
            
            //CreateTable(
            //    "dbo.RedirectUris",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Url = c.String(),
            //            CustomClientId = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CustomClients", t => t.CustomClientId)
            //    .Index(t => t.CustomClientId);
            
            //CreateTable(
            //    "dbo.CustomScopes",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Enabled = c.Boolean(nullable: false),
            //            Name = c.String(),
            //            DisplayName = c.String(),
            //            Type = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.DbScopeClaims",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(),
            //            CustomScopeId = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CustomScopes", t => t.CustomScopeId)
            //    .Index(t => t.CustomScopeId);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DbScopeClaims", "CustomScopeId", "dbo.CustomScopes");
            DropForeignKey("dbo.RedirectUris", "CustomClientId", "dbo.CustomClients");
            DropForeignKey("dbo.ClientSecrets", "CustomClientId", "dbo.CustomClients");
            DropForeignKey("dbo.AllowedScopes", "CustomClientId", "dbo.CustomClients");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.DbScopeClaims", new[] { "CustomScopeId" });
            DropIndex("dbo.RedirectUris", new[] { "CustomClientId" });
            DropIndex("dbo.ClientSecrets", new[] { "CustomClientId" });
            DropIndex("dbo.AllowedScopes", new[] { "CustomClientId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DbScopeClaims");
            DropTable("dbo.CustomScopes");
            DropTable("dbo.RedirectUris");
            DropTable("dbo.ClientSecrets");
            DropTable("dbo.CustomClients");
            DropTable("dbo.AllowedScopes");
        }
    }
}
