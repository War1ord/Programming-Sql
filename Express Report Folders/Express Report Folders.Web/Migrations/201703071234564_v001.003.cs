namespace Express_Report_Folders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v001003 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReportQueryParameters", "Identifier", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueryParameters", "ValueString", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueryParameters", "ValueType", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQuerySelects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueryWheres", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueryWheres", "LeftName", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueryWheres", "RightName", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueueJoins", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueueJoinClauses", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueueJoinClauses", "LeftName", c => c.String(nullable: false));
            AlterColumn("dbo.ReportQueueJoinClauses", "RightName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReportQueueJoinClauses", "RightName", c => c.String());
            AlterColumn("dbo.ReportQueueJoinClauses", "LeftName", c => c.String());
            AlterColumn("dbo.ReportQueueJoinClauses", "Type", c => c.String());
            AlterColumn("dbo.ReportQueueJoins", "Name", c => c.String());
            AlterColumn("dbo.ReportQueryWheres", "RightName", c => c.String());
            AlterColumn("dbo.ReportQueryWheres", "LeftName", c => c.String());
            AlterColumn("dbo.ReportQueryWheres", "Type", c => c.String());
            AlterColumn("dbo.ReportQuerySelects", "Name", c => c.String());
            AlterColumn("dbo.ReportQueryParameters", "ValueType", c => c.String());
            AlterColumn("dbo.ReportQueryParameters", "ValueString", c => c.String());
            AlterColumn("dbo.ReportQueryParameters", "Identifier", c => c.String());
        }
    }
}
