using System.ComponentModel.DataAnnotations;

namespace Express_Report_Folders.Web.Models
{
	public class ReportQuerySelect : ReportModelBase
	{
		[Required]
		public int Sequence { get; set; }
		public string Alias { get; set; }
		[Required]
		public string Name { get; set; }
	}
}