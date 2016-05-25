namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotSureWhat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Claims", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.Claims", new[] { "User_Id" });
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            RenameColumn(table: "dbo.Claims", name: "User_Id", newName: "IdentityUser_Id");
            AddColumn("dbo.Claims", "UserId", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Users", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Logins", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserRoles", "IdentityRole_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserRoles", "IdentityUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Claims", "IdentityUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Claims", "IdentityUser_Id");
            CreateIndex("dbo.Logins", "IdentityUser_Id");
            CreateIndex("dbo.UserRoles", "IdentityRole_Id");
            CreateIndex("dbo.UserRoles", "IdentityUser_Id");
            AddForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserRoles", "IdentityRole_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "IdentityRole_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Logins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Claims", new[] { "IdentityUser_Id" });
            AlterColumn("dbo.Claims", "IdentityUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserRoles", "IdentityUser_Id");
            DropColumn("dbo.UserRoles", "IdentityRole_Id");
            DropColumn("dbo.Logins", "IdentityUser_Id");
            DropColumn("dbo.Users", "AccessFailedCount");
            DropColumn("dbo.Users", "LockoutEnabled");
            DropColumn("dbo.Users", "LockoutEndDateUtc");
            DropColumn("dbo.Users", "TwoFactorEnabled");
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Claims", "UserId");
            RenameColumn(table: "dbo.Claims", name: "IdentityUser_Id", newName: "User_Id");
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.Logins", "UserId");
            CreateIndex("dbo.Claims", "User_Id");
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Logins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Claims", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
