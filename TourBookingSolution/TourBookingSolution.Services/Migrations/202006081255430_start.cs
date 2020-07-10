namespace TourBookingSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignPositions",
                c => new
                    {
                        StaffID = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Desc = c.String(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StaffID, t.PositionID, t.DepartmentID });
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Avatar = c.String(),
                        Desc = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 550),
                        Phone = c.String(maxLength: 50),
                        Mail = c.String(maxLength: 150),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Comment = c.String(maxLength: 550),
                        Member = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MemberLevels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Point = c.Double(nullable: false),
                        Rank = c.Int(nullable: false),
                        Name = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 550),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Address = c.String(maxLength: 350),
                        Phone = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Mail = c.String(maxLength: 150),
                        Account = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        DateJoin = c.DateTime(nullable: false),
                        Platform = c.String(),
                        BirthDay = c.DateTime(),
                        AccumulatedPoints = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Avatar = c.String(),
                        Desc = c.String(maxLength: 350),
                        Content = c.String(),
                        ViewNumber = c.Int(nullable: false),
                        MetaTitle = c.String(maxLength: 60),
                        MetaDesc = c.String(maxLength: 160),
                        MetaKeyword = c.String(maxLength: 260),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 16),
                        Tour = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        IsPayment = c.Boolean(nullable: false),
                        Member = c.Int(nullable: false),
                        FileParticipants = c.String(maxLength: 2000),
                        Price = c.Double(nullable: false),
                        Reduce = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 550),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 12),
                        Title = c.String(maxLength: 250),
                        Avatar = c.String(),
                        Desc = c.String(maxLength: 350),
                        Content = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AmountReduced = c.Int(nullable: false),
                        PercentReduced = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Staff = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Address = c.String(maxLength: 350),
                        BirthDay = c.DateTime(),
                        Phone = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Mail = c.String(maxLength: 150),
                        Account = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Place = c.String(maxLength: 350),
                        GuideName = c.String(),
                        Desc = c.String(maxLength: 800),
                        Rank = c.Int(nullable: false),
                        Tour = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Avatar = c.String(maxLength: 350),
                        Title = c.String(maxLength: 350),
                        Desc = c.String(maxLength: 850),
                        PlaceStart = c.String(maxLength: 350),
                        PlaceEnd = c.String(maxLength: 350),
                        Content = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DescTime = c.String(maxLength: 250),
                        Step = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tours");
            DropTable("dbo.Steps");
            DropTable("dbo.Staffs");
            DropTable("dbo.Promotions");
            DropTable("dbo.Positions");
            DropTable("dbo.Orders");
            DropTable("dbo.News");
            DropTable("dbo.Members");
            DropTable("dbo.MemberLevels");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Departments");
            DropTable("dbo.Banners");
            DropTable("dbo.AssignPositions");
        }
    }
}
