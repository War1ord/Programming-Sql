using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express_Report_Folders.Web.Models
{
	public class ReportQueueJoinClause : ModelBase
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

		[Required, ForeignKey(nameof(ReportQueueJoin))]
		public Guid ReportQueueJoinId { get; set; }

		public virtual ReportQueueJoin ReportQueueJoin { get; set; }

	}
}