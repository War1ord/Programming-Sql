using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express_Report_Folders.Web.Models
{
	public class Report : ModelBase
	{
		[Required]
		public string Name { get; set; }
		[Required, ForeignKey(nameof(DbConnection)), Display(Name = "Db Connection")]
		public Guid DbConnectionId { get; set; }

		public virtual DbConnection DbConnection { get; set; }
		public virtual List<ReportQueryParameter> ReportQueryParameters { get; set; }
		public virtual List<ReportQueueJoin> ReportQueueJoins { get; set; }
		public virtual List<ReportQuerySelect> ReportQuerySelects { get; set; }
		public virtual List<ReportQueryWhere> ReportQueryWhere { get; set; }

	}
}