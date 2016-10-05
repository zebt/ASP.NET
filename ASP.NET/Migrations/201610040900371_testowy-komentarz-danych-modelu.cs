namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testowykomentarzdanychmodelu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Numer");
            DropColumn("dbo.Customers", "Miasto");
            DropColumn("dbo.Customers", "Kod_pocztowy");
            DropColumn("dbo.Customers", "Ulica");
            DropColumn("dbo.Customers", "Dom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Dom", c => c.String());
            AddColumn("dbo.Customers", "Ulica", c => c.String());
            AddColumn("dbo.Customers", "Kod_pocztowy", c => c.String());
            AddColumn("dbo.Customers", "Miasto", c => c.String());
            AddColumn("dbo.Customers", "Numer", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
        }
    }
}
