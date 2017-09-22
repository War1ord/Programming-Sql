namespace Express_Report_Folders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v001002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        DbConnectionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbConnections", t => t.DbConnectionId, cascadeDelete: true)
                .Index(t => t.DbConnectionId);
            
            CreateTable(
                "dbo.ReportQueryParameters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Identifier = c.String(),
                        ValueString = c.String(),
                        ValueType = c.String(),
                        Report_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.ReportQuerySelects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sequence = c.Int(nullable: false),
                        Alias = c.String(),
                        Name = c.String(),
                        Report_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.ReportQueryWheres",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sequence = c.Int(nullable: false),
                        Type = c.String(),
                        LeftAlias = c.String(),
                        LeftName = c.String(),
                        RightAlias = c.String(),
                        RightName = c.String(),
                        Report_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.ReportQueueJoins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(),
                        Alias = c.String(),
                        Report_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.ReportQueueJoinClauses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sequence = c.Int(nullable: false),
                        Type = c.String(),
                        LeftAlias = c.String(),
                        LeftName = c.String(),
                        RightAlias = c.String(),
                        RightName = c.String(),
                        ReportQueueJoin_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReportQueueJoins", t => t.ReportQueueJoin_Id)
                .Index(t => t.ReportQueueJoin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportQueueJoins", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.ReportQueueJoinClauses", "ReportQueueJoin_Id", "dbo.ReportQueueJoins");
            DropForeignKey("dbo.ReportQueryWheres", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.ReportQuerySelects", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.ReportQueryParameters", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.Reports", "DbConnectionId", "dbo.DbConnections");
            DropIndex("dbo.ReportQueueJoinClauses", new[] { "ReportQueueJoin_Id" });
            DropIndex("dbo.ReportQueueJoins", new[] { "Report_Id" });
            DropIndex("dbo.ReportQueryWheres", new[] { "Report_Id" });
            DropIndex("dbo.ReportQuerySelects", new[] { "Report_Id" });
            DropIndex("dbo.ReportQueryParameters", new[] { "Report_Id" });
            DropIndex("dbo.Reports", new[] { "DbConnectionId" });
            DropTable("dbo.ReportQueueJoinClauses");
            DropTable("dbo.ReportQueueJoins");
            DropTable("dbo.ReportQueryWheres");
            DropTable("dbo.ReportQuerySelects");
            DropTable("dbo.ReportQueryParameters");
            DropTable("dbo.Reports");
        }
    }
}
