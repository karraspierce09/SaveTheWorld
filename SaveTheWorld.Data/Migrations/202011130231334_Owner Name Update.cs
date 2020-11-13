namespace SaveTheWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnerNameUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Owner", "OwnerEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Owner", "OwnerEmail", c => c.String(nullable: false));
        }
    }
}
