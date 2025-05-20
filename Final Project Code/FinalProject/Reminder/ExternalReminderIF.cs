using FinalProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject
{
    public interface ExternalReminderIF:UniversalReminderIF, ConfigurablePluginIF
    {
        void SetExternalReminderManager(ExternalReminderManagerIF externalReminderManager);
        ExternalReminderManagerIF GetExternalReminderManager();
        String GetSource();
        Task Sync();
    }
}
