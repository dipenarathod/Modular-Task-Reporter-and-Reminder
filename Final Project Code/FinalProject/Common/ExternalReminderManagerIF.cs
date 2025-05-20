using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Common
{
    public interface ExternalReminderManagerIF
    {
        List<String> GetExternalReminderIDs(string source);
        void AddExternalReminderIDs(string source, List<string> IDs);
        void RemoveExternalReminderIDs(string source, List<string> IDs);
        bool ContainsExternalReminderIDs(string source, List<string> ID);
        Dictionary<string, string> GetExternalReminderConfiguration(string source);
        void SaveExternalReminderConfiguration(ExternalReminderIF externalReminder);
        void AddExternalReminders(String source, List<ReminderIF> reminders);
        List<ReminderIF> GetExternalReminders();
        List<ReminderIF> GetExternalReminders(string source);
    }
}
