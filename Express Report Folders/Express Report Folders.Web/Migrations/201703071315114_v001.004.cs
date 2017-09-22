namespace Express_Report_Folders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v001004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbConnections", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.DbConnections", "ConnectionString", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbConnections", "ConnectionString", c => c.String());
            DropColumn("dbo.DbConnections", "Name");
        }
    }
}
