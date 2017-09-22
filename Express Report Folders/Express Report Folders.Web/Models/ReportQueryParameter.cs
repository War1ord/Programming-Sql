using System.ComponentModel.DataAnnotations;

namespace Express_Report_Folders.Web.Models
{
	public class ReportQueryParameter : ReportModelBase
	{
		[Required]
		public string Identifier { get; set; }
		[Required]
		public string ValueString { get; set; }
		[Required]
		public string ValueType { get; set; }
	}
}