namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanienowychpolcustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "Numer", c => c.String());
            AddColumn("dbo.Customers", "Miasto", c => c.String());
            AddColumn("dbo.Customers", "Kod_pocztowy", c => c.String());
            AddColumn("dbo.Customers", "Ulica", c => c.String());
            AddColumn("dbo.Customers", "Dom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Dom");
            DropColumn("dbo.Customers", "Ulica");
            DropColumn("dbo.Customers", "Kod_pocztowy");
            DropColumn("dbo.Customers", "Miasto");
            DropColumn("dbo.Customers", "Numer");
            DropColumn("dbo.Customers", "Email");
        }
    }
}
