using System.ComponentModel.DataAnnotations;

namespace Express_Report_Folders.Web.Models
{
	public class ReportQueryWhere : ReportModelBase
	{
		[Required]
		public int Sequence { get; set; }
		[Required]
		public string Type { get; set; }
		public string LeftAlias { get; set; }
		[Required]
		public string LeftName { get; set; }
		public string RightAlias { get; set; }
		[Required]
		public string RightName { get; set; }
	}
}