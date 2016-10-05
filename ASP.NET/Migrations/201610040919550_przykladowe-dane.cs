namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przykladowedane : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Nazwa = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Nazwa = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Nazwa = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Nazwa = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
