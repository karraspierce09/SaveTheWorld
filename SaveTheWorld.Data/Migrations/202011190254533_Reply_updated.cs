namespace SaveTheWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reply_updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reply", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reply", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
