namespace ProduceExchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordersadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        orderClient = c.Int(nullable: false),
                        orderType = c.Int(nullable: false),
                        orderCategory = c.Int(nullable: false),
                        orderVariety = c.Int(nullable: false),
                        orderQuantity = c.Int(nullable: false),
                        orderDollars = c.Decimal(nullable: false, precision: 18, scale: 2),
                        orderDate = c.DateTime(nullable: false),
                        orderComment = c.String(),
                        orderStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderModels");
        }
    }
}
