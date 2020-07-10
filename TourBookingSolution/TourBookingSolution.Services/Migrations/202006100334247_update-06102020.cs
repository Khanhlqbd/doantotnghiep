namespace TourBookingSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update06102020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Long(nullable: false),
                        StepID = c.Long(nullable: false),
                        Rank = c.Int(nullable: false),
                        IsLastStep = c.Boolean(nullable: false),
                        IsAccomplish = c.Boolean(nullable: false),
                        StepName = c.String(),
                    })
                .PrimaryKey(t => new { t.OrderID, t.StepID });
            
            AddColumn("dbo.Orders", "Step", c => c.Int(nullable: false));
            AddColumn("dbo.Promotions", "TourApply", c => c.String());
            AddColumn("dbo.Steps", "Name", c => c.String(maxLength: 250));
            DropColumn("dbo.Steps", "StartTime");
            DropColumn("dbo.Steps", "EndTime");
            DropColumn("dbo.Tours", "Step");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tours", "Step", c => c.Int(nullable: false));
            AddColumn("dbo.Steps", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Steps", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Steps", "Name");
            DropColumn("dbo.Promotions", "TourApply");
            DropColumn("dbo.Orders", "Step");
            DropTable("dbo.OrderDetails");
        }
    }
}
