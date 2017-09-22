using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Express_Report_Folders.Web.Models
{
	public class ReportQueueJoin : ReportModelBase
	{
		[Required]
		public int Sequence { get; set; }
		public string Alias { get; set; }
		[Required]
		public string Name { get; set; }
		public List<ReportQueueJoinClause> ReportQueueJoinClauses { get; set; }
	}
}