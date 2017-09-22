namespace Express_Report_Folders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbConnections",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ConnectionString = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbConnections");
        }
    }
}
