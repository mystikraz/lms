namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removesloandurationfrombookmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "LoanDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "LoanDuration", c => c.Int(nullable: false));
        }
    }
}
