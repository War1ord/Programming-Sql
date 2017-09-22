using System.ComponentModel.DataAnnotations;

namespace Express_Report_Folders.Web.Models
{
	public class DbConnection : ModelBase
	{
		[Required]
		public string Name { get; set; }
		[Required, Display(Name = "Connection")]
		public string ConnectionString { get; set; }
	}
}