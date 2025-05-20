using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

//Checked
namespace FinalProject.Notifier
{
    public class DesktopNotifier: AbsNotifier
    {
        public DesktopNotifier() : base("Desktop Notifier")
        {
        }
        public override async Task SendNotification()
        {
            string title = GetTitle();
            string content = GetContent();
            Console.WriteLine("Sending notification");
            new ToastContentBuilder().AddText(title).AddText(content).Show();
        }
    }
}
