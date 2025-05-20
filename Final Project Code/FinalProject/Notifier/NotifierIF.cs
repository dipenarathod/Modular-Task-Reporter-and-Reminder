using FinalProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Notifier
{
    public interface NotifierIF:ConfigurablePluginIF
    {
        
        String GetTitle();
        String GetContent();
        
        void SetTitle(string title);
        void SetContent(string content);
        Task SendNotification();

    }
}
