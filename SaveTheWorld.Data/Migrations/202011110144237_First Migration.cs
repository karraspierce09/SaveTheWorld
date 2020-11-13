namespace SaveTheWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approval",
                c => new
                    {
                        ApprovalId = c.Int(nullable: false, identity: true),
                        Approvaled_OwnerId = c.Guid(nullable: false),
                        ApprovaledTip_TipId = c.Int(),
                    })
                .PrimaryKey(t => t.ApprovalId)
                .ForeignKey("dbo.Owner", t => t.Approvaled_OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Tip", t => t.ApprovaledTip_TipId)
                .Index(t => t.Approvaled_OwnerId)
                .Index(t => t.ApprovaledTip_TipId);
            
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        OwnerEmail = c.String(nullable: false),
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
                        Id = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Owner_OwnerId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owner", t => t.Owner_OwnerId)
                .Index(t => t.Owner_OwnerId);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Owner_OwnerId = c.Guid(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Owner", t => t.Owner_OwnerId)
                .Index(t => t.Owner_OwnerId);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        Owner_OwnerId = c.Guid(),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Owner", t => t.Owner_OwnerId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.Owner_OwnerId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Tip",
                c => new
                    {
                        TipId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        TipText = c.String(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.TipId)
                .ForeignKey("dbo.Owner", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CommentText = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        ReplyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Reply", t => t.ReplyId, cascadeDelete: true)
                .Index(t => t.ReplyId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        TipId = c.Int(nullable: false),
                        ReplyText = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Owner", t => t.OwnerId, cascadeDelete: false)
                .ForeignKey("dbo.Tip", t => t.TipId, cascadeDelete: false)
                .Index(t => t.TipId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Disapproval",
                c => new
                    {
                        DisapprovalId = c.Int(nullable: false, identity: true),
                        Disapprovaled_OwnerId = c.Guid(nullable: false),
                        DisapprovalTip_TipId = c.Int(),
                    })
                .PrimaryKey(t => t.DisapprovalId)
                .ForeignKey("dbo.Owner", t => t.Disapprovaled_OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Tip", t => t.DisapprovalTip_TipId)
                .Index(t => t.Disapprovaled_OwnerId)
                .Index(t => t.DisapprovalTip_TipId);
            
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
            DropForeignKey("dbo.Disapproval", "DisapprovalTip_TipId", "dbo.Tip");
            DropForeignKey("dbo.Disapproval", "Disapprovaled_OwnerId", "dbo.Owner");
            DropForeignKey("dbo.Comment", "ReplyId", "dbo.Reply");
            DropForeignKey("dbo.Reply", "TipId", "dbo.Tip");
            DropForeignKey("dbo.Reply", "OwnerId", "dbo.Owner");
            DropForeignKey("dbo.Approval", "ApprovaledTip_TipId", "dbo.Tip");
            DropForeignKey("dbo.Tip", "OwnerId", "dbo.Owner");
            DropForeignKey("dbo.Approval", "Approvaled_OwnerId", "dbo.Owner");
            DropForeignKey("dbo.IdentityUserRole", "Owner_OwnerId", "dbo.Owner");
            DropForeignKey("dbo.IdentityUserLogin", "Owner_OwnerId", "dbo.Owner");
            DropForeignKey("dbo.IdentityUserClaim", "Owner_OwnerId", "dbo.Owner");
            DropIndex("dbo.Disapproval", new[] { "DisapprovalTip_TipId" });
            DropIndex("dbo.Disapproval", new[] { "Disapprovaled_OwnerId" });
            DropIndex("dbo.Reply", new[] { "OwnerId" });
            DropIndex("dbo.Reply", new[] { "TipId" });
            DropIndex("dbo.Comment", new[] { "ReplyId" });
            DropIndex("dbo.Tip", new[] { "OwnerId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "Owner_OwnerId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "Owner_OwnerId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "Owner_OwnerId" });
            DropIndex("dbo.Approval", new[] { "ApprovaledTip_TipId" });
            DropIndex("dbo.Approval", new[] { "Approvaled_OwnerId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Disapproval");
            DropTable("dbo.Reply");
            DropTable("dbo.Comment");
            DropTable("dbo.Tip");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.Owner");
            DropTable("dbo.Approval");
        }
    }
}
