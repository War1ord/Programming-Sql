using System.ComponentModel.DataAnnotations;

namespace Express_Report_Folders.Web.Models
{
	public enum ReportQueryFilterType : byte
	{
		[Display(Name = "Text Exact")]
		TextExact = 10,
		[Display(Name = "Text Like")]
		TextLike = 20,
		[Display(Name = "Text Start With")]
		TextStartWith = 30,
		[Display(Name = "Text End With")]
		TextEndWith = 40,
		[Display(Name = "Number")]
		Number = 50,
		[Display(Name = "Number Range")]
		NumberRange = 60,
		[Display(Name = "Date")]
		Date = 70,
		[Display(Name = "Date and Time")]
		DateTime = 80,
		[Display(Name = "Date Range")]
		DateRange = 90,
		[Display(Name = "Date and Time Range")]
		DateTimeRange = 100,

	}
}