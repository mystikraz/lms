namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixesgeneralissues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Loans", "DateReturned", c => c.DateTime());
            DropColumn("dbo.Authors", "LasttName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "LasttName", c => c.String());
            AlterColumn("dbo.Loans", "DateReturned", c => c.DateTime(nullable: false));
            DropColumn("dbo.Authors", "LastName");
        }
    }
}
