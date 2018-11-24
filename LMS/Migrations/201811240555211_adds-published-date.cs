namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspublisheddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PublishedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "PublishedOn");
        }
    }
}
