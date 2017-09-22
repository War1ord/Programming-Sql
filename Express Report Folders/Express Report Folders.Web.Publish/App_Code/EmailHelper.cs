using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace Express_Report_Folders.Web.App_Code
{
	public static class EmailHelper
	{
		private static void SendConfirmationEMail(MailMessage message, string SmtpHost, string SmtpUserName, string SmtpPassword)
		{
			#region formatter
			string text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
			string html = "Please confirm your account by clicking this link: <a href=\"" + message.Body + "\">link</a><br/>";

			html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + message.Body);
			#endregion

			if (message == null) message = new MailMessage();

			message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
			message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

			new SmtpClient(SmtpHost)
			{
				Credentials = new NetworkCredential(SmtpUserName, SmtpPassword),
			}.Send(message);
		}
	}
}