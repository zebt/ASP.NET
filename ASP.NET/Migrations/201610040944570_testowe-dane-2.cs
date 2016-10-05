namespace ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testowedane2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, Nazwa, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 'Nowy czytelnik', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, Nazwa, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 'Sta³y czytelnik', 30, 1, 10)");
          

        }
        
        public override void Down()
        {
        }
    }
}
