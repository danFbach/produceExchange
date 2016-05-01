namespace ProduceExchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetocategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.categoryModels", "productType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.categoryModels", "productType");
        }
    }
}
