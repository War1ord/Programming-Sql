using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Express_Report_Folders.Web.Models
{
	public abstract class ModelBase
	{
		private Guid? _id;

		public Guid Id
		{
			get
			{
				if (_id.HasValue)
					return _id.Value;
				else
					return (_id = Guid.NewGuid()).Value;
			}
			set { _id = value; }
		}
	}
	public abstract class ReportModelBase : ModelBase
	{
		[Required, ForeignKey(nameof(Report))]
		public Guid ReportId { get; set; }

		public virtual Report Report { get; set; }

	}
}