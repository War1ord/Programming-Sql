using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Express_Report_Folders.Web.Startup))]
namespace Express_Report_Folders.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			Models.ApplicationDbContext.Intialize();
			ConfigureAuth(app);
		}
	}
}
