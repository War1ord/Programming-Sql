using Express_Report_Folders.Web.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Express_Report_Folders.Web.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public static void Intialize()
		{
			using (var db = new ApplicationDbContext())
			{
				new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>().InitializeDatabase(db);
			}
		}

		public DbSet<DbConnection> DbConnections { get; set; }
		public DbSet<Report> Reports { get; set; }

		public System.Data.Entity.DbSet<Express_Report_Folders.Web.Models.ReportQueryParameter> ReportQueryParameters { get; set; }

		public System.Data.Entity.DbSet<Express_Report_Folders.Web.Models.ReportQuerySelect> ReportQuerySelects { get; set; }

		public System.Data.Entity.DbSet<Express_Report_Folders.Web.Models.ReportQueryWhere> ReportQueryWheres { get; set; }

		public System.Data.Entity.DbSet<Express_Report_Folders.Web.Models.ReportQueueJoin> ReportQueueJoins { get; set; }

		public System.Data.Entity.DbSet<Express_Report_Folders.Web.Models.ReportQueueJoinClause> ReportQueueJoinClauses { get; set; }
	}
}