namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieNumeruDoModelu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Numer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Numer");
        }
    }
}
