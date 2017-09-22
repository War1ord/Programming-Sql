using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express_Report_Folders.Web.App_Code
{
	public static class ControllerExtentions
	{
		public static string GetControllerName(this string name) { return name.Replace("Controller", ""); }
	}
}