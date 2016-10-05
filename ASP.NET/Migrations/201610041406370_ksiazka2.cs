namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ksiazka2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gatuneks",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ksiazkas", "GatunekId", c => c.Byte(nullable: false));
            AddColumn("dbo.Ksiazkas", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ksiazkas", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Ksiazkas", "GatunekId");
            AddForeignKey("dbo.Ksiazkas", "GatunekId", "dbo.Gatuneks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ksiazkas", "GatunekId", "dbo.Gatuneks");
            DropIndex("dbo.Ksiazkas", new[] { "GatunekId" });
            AlterColumn("dbo.Ksiazkas", "Name", c => c.String());
            DropColumn("dbo.Ksiazkas", "DateAdded");
            DropColumn("dbo.Ksiazkas", "GatunekId");
            DropTable("dbo.Gatuneks");
        }
    }
}
