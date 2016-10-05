namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poprawkiwmodeluczlonkowstwo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Nazwa", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Nazwa", c => c.String());
        }
    }
}
