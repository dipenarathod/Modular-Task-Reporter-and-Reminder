using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Common
{
    public static class ReminderFactory
    {
        public static ReminderIF CreateReminder(String type, String title, String description, DateTime triggerTime, RepeatSchedule schedule, List<ReminderIF> subReminders = null)
        {
            if (type.ToLower().Contains("basic"))
            {
                return new BasicReminder(title, description, triggerTime, schedule);
            }
            else if (type.ToLower().Contains("composite"))
            {
                CompositeReminder composite = new CompositeReminder(title, description, triggerTime, schedule);
                if (subReminders != null)
                {
                    foreach (var r in subReminders)
                        composite.AddReminder(r);
                }
                return composite;
            }
            else
            {
                throw new Exception("Invalid reminder String: " + type);
            }
        }
    }
}
