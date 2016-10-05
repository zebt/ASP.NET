namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Movies", newName: "Ksiazkas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Ksiazkas", newName: "Movies");
        }
    }
}
