using FinalProject.Common;
using FinalProject.Notifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject
{
    public interface ReminderIF:UniversalReminderIF,SchedulableIF
    {

        bool ContainsReminder(ReminderIF target);

    }
}
