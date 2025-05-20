using FinalProject.Common;
using FinalProject.Notifier;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject
{
    public class CompositeReminder: AbsReminder
    {
        [JsonProperty]
        private List<ReminderIF> reminders;
        [JsonConstructor]
        public CompositeReminder(String title, String description, DateTime time, RepeatSchedule schedule, String ID=null) : base(title, description, time, schedule)
        {
            if (ID != null)
            {
                this.ID = ID;
            }
            else
            {
                this.ID = Guid.NewGuid().ToString();
            }
            this.notifiers = new List<NotifierIF>();
            reminders = new List<ReminderIF>();
        }

        public override bool ContainsReminder(ReminderIF target)
        {
            foreach (var reminder in reminders)
            {
                if (reminder == target)
                    return true;

                if (reminder is CompositeReminder composite)
                {
                    if (composite.ContainsReminder(target))
                        return true;
                }
            }
            return false;
        }
        public void AddReminder(ReminderIF child)
        {
            if (child == this || child.ContainsReminder(this))
            {
                throw new Exception("Adding this reminder would create a circular reference.");
            }
            reminders.Add(child);
        }
        public void RemoveReminder(ReminderIF reminder)
        {
            reminders.Remove(reminder);
        }
        public void ClearReminders()
        {
            reminders.Clear();
        }
        public void SetReminders(List<ReminderIF> reminders)
        {
            this.reminders = reminders;
        }
        public override List<ReminderIF> ToReminderList()
        {
            return reminders;
        }
        public override async Task TriggerNotifications()
        {
            var notificationTasks = new List<Task>();
            foreach (var reminder in ToReminderList())
            {
                notificationTasks.Add(reminder.TriggerNotifications());
            }
            await Task.WhenAll(notificationTasks);

            foreach (var notifier in GetNotifiers())
            {
                try
                {
                    notifier.SetTitle(GetTitle());
                    notifier.SetContent(GetContent());
                    notificationTasks.Add(notifier.SendNotification());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in "+notifier.GetName()+": "+ex);
                }
            }
            await Task.WhenAll(notificationTasks);

        }
    }
}
