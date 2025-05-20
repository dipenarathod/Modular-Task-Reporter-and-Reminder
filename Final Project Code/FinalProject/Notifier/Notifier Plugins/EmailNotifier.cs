using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Notifier.Notifier_Plugins
{
    public class EmailNotifier : AbsNotifier
    {
        public EmailNotifier() : base("Email Notifier")
        {

            this.SetParameters(new Dictionary<string, string> {
                { "From address","string" },
                { "Password","string" },
                { "To address","string" }
            },
            new Dictionary<string, string>
            {
                {"Port","String"},
                {"Enable SSL","String"},
                {"SMTP Server","String"}
            });
        }

        public async override Task SendNotification()
        {
            //try
            //{
                var configParams = GetRequiredParameters();
                var optionalConfigParams= GetOptionalParameters();
                if (configParams != null)
                {
                    var fromEmailAddress = configParams["From address"].Trim();
                    var fromEmailPassword=configParams["Password"].Trim();
                    var toEmailAddress=configParams["To address"].Trim();
                //Console.WriteLine("Unable to use user-defined smtp server. Defaulting to smtp.gmail.com");
                //Console.WriteLine("From: " + fromEmailAddress);
                //Console.WriteLine("From Password: " + fromEmailPassword);
                //Console.WriteLine("To: " + toEmailAddress);
                
                int port = 587;
                    bool SSL=true;
                    if (optionalConfigParams != null)
                    {
                        int tryPort = -1;
                        if(int.TryParse(optionalConfigParams["Port"], out tryPort))
                        {
                            port = tryPort;
                        }
                        bool trySSL=false;
                        if (bool.TryParse(optionalConfigParams["Enable SSL"],out trySSL)){
                            SSL = trySSL;
                        }
                    }
                    MailMessage email = new MailMessage(fromEmailAddress, toEmailAddress);
                    email.Subject=GetTitle();
                    email.Body=GetContent();
                //Console.WriteLine(email);
                try
                    {
                        var smtpClient = new SmtpClient(optionalConfigParams["SMTP Server"])
                        {
                            UseDefaultCredentials = false,
                            Port = port,
                            Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword),
                            EnableSsl = true,
                        };
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        await smtpClient.SendMailAsync(email);
                    }
                    catch {
                        
                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            UseDefaultCredentials = false,
                            Port = port,
                            Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword),
                            EnableSsl = true,
                        };
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        try
                        {
                            await smtpClient.SendMailAsync(email);

                        }
                        catch
                        {
                            Console.WriteLine("Email could not be sent");
                        }
                    }

                }
                else
                {
                    throw new Exception("Required parameters absent");
                }
            //}
            //catch(Exception ex) {
            //    Console.WriteLine("Error encountered while sending Email: ", ex.ToString());
            //}
        }
    }
}
