using MailKit.Net.Smtp;
using MimeKit;

namespace JC.Samples.MailKitConsoleDemo
{
	/// <summary>
	/// Simple wrapper class around the MailKit SmtpClient.
	/// </summary>
	public class MailKitSmtpClient
    {
		#region Methods

		/// <summary>
		/// Sends a test email, using the configured app settings.
		/// </summary>
		public void SendEmail()
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Linh Huynh", "lhuynh@okuma.com"));
			message.To.Add(new MailboxAddress("hulinning2", "hulinning2@yahoo.com"));
			message.Subject = "MailKit Test " + System.DateTime.Now  ;
			message.Body    = new TextPart("plain") { Text = "Hi from MailKit!" };

			using (var client = new SmtpClient())
			{
				client.Connect("us-smtp-outbound-1.mimecast.com", 587);
				client.Authenticate("ENGSMTP@okuma.com", "Cr38t!ve");
				client.Send(message);
				client.Disconnect(true);
			}
		}

		#endregion
	}
}