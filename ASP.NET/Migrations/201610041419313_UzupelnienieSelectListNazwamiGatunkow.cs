namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UzupelnienieSelectListNazwamiGatunkow : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Gatuneks (Id, Name) VALUES (1, 'Detektywistyczne')");
            Sql("INSERT INTO Gatuneks (Id, Name) VALUES (2, 'Dzienniki')");
            Sql("INSERT INTO Gatuneks (Id, Name) VALUES (3, 'Fantasy')");
            Sql("INSERT INTO Gatuneks (Id, Name) VALUES (4, 'Horrory')");
            Sql("INSERT INTO Gatuneks (Id, Name) VALUES (5, 'Hobbistyczne')");
            Sql("INSERT INTO Gatuneks (Id, Name) VALUES (6, 'Komedia')");
            Sql("INSERT INTO Gatuneks (Id, Name) VALUES (7, 'Naukowa')");
        }
        
        public override void Down()
        {
        }
    }
}
