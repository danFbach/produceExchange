namespace ProduceExchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clienttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        clientFName = c.String(nullable: false),
                        clientLName = c.String(nullable: false),
                        businessName = c.String(),
                        clientPhoneNumber = c.String(),
                        clientEmail = c.String(),
                        clientAddress = c.String(),
                        clientZipcode = c.Int(nullable: false),
                        moneySpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        clientComments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientModels");
        }
    }
}
