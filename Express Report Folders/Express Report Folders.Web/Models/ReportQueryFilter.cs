using System.ComponentModel.DataAnnotations;

namespace Express_Report_Folders.Web.Models
{
	public class ReportQueryFilter : ReportModelBase
	{
		[Required]
		public int Sequence { get; set; }
		[Required]
		public ReportQueryFilterType Type { get; set; }
		[Required]
		public string Name { get; set; }
	}
}