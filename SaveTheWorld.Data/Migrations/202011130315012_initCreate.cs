namespace SaveTheWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approval",
                c => new
                    {
                        ApprovalId = c.Int(nullable: false, identity: true),
                        TipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApprovalId)
                .ForeignKey("dbo.Tip", t => t.TipId, cascadeDelete: false)
                .Index(t => t.TipId);
            
            CreateTable(
                "dbo.Tip",
                c => new
                    {
                        TipId = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false),
                        TipText = c.String(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.TipId)
                .ForeignKey("dbo.Owner", t => t.Id, cascadeDelete: false)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
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
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owner", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Owner", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        Owner_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Owner", t => t.Owner_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false),
                        CommentText = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        ReplyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Reply", t => t.ReplyId, cascadeDelete: false)
                .Index(t => t.ReplyId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        TipId = c.Int(nullable: false),
                        ReplyText = c.String(nullable: false),
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Owner", t => t.Id, cascadeDelete: false)
                .ForeignKey("dbo.Tip", t => t.TipId, cascadeDelete: false)
                .Index(t => t.TipId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Disapproval",
                c => new
                    {
                        DisapprovalId = c.Int(nullable: false, identity: true),
                        TipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DisapprovalId)
                .ForeignKey("dbo.Tip", t => t.TipId, cascadeDelete: false)
                .Index(t => t.TipId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Disapproval", "TipId", "dbo.Tip");
            DropForeignKey("dbo.Comment", "ReplyId", "dbo.Reply");
            DropForeignKey("dbo.Reply", "TipId", "dbo.Tip");
            DropForeignKey("dbo.Reply", "Id", "dbo.Owner");
            DropForeignKey("dbo.Approval", "TipId", "dbo.Tip");
            DropForeignKey("dbo.Tip", "Id", "dbo.Owner");
            DropForeignKey("dbo.IdentityUserRole", "Owner_Id", "dbo.Owner");
            DropForeignKey("dbo.IdentityUserLogin", "Owner_Id", "dbo.Owner");
            DropForeignKey("dbo.IdentityUserClaim", "Owner_Id", "dbo.Owner");
            DropIndex("dbo.Disapproval", new[] { "TipId" });
            DropIndex("dbo.Reply", new[] { "Id" });
            DropIndex("dbo.Reply", new[] { "TipId" });
            DropIndex("dbo.Comment", new[] { "ReplyId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "Owner_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "Owner_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "Owner_Id" });
            DropIndex("dbo.Tip", new[] { "Id" });
            DropIndex("dbo.Approval", new[] { "TipId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Disapproval");
            DropTable("dbo.Reply");
            DropTable("dbo.Comment");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.Owner");
            DropTable("dbo.Tip");
            DropTable("dbo.Approval");
        }
    }
}
