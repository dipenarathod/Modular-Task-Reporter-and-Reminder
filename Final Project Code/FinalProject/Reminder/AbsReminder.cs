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
    public abstract class AbsReminder: ReminderIF
    {
        [JsonProperty]
        private String title;
        [JsonProperty]
        private String content;
        [JsonProperty]
        private DateTime time;
        [JsonProperty]
        protected string ID;
        [JsonProperty]
        protected List<NotifierIF> notifiers;
        [JsonProperty]
        RepeatSchedule schedule = null;
        public AbsReminder(String title, String content, DateTime time, RepeatSchedule schedule)
        {
            this.title = title;
            this.content = content;
            this.time = time;
            this.schedule = schedule;
        }
        public override string ToString()
        {
            return title;
        }
        public String GetTitle()
        {
            return title;
        }
        public String GetContent()
        {
            return content;
        }
        public DateTime GetTime()
        {
            return time;
        }

        public String GetID()
        {
            return ID;
        }   

        public RepeatSchedule GetSchedule()
        {
            return schedule;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void SetContent(string content)
        {
            this.content = content;
        }
        public void SetTime(DateTime time)
        {
            this.time = time;
        }

        public void SetSchedule(RepeatSchedule schedule)
        {
            this.schedule = schedule;
        }

        public abstract List<ReminderIF> ToReminderList();

        public void AddNotifier(NotifierIF notifier)
        {
            notifiers.Add(notifier);
        }
        public void RemoveNotifier(NotifierIF notifier)
        {
            notifiers.Remove(notifier);
        }
        public List<NotifierIF> GetNotifiers()
        {
            return notifiers;
        }
        public void SetNotifiers(List<NotifierIF> notifiers)
        {
            this.notifiers = notifiers;
        }

        public virtual async Task TriggerNotifications()
        {
            var notificationTasks = new List<Task>();
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
                    Console.WriteLine("Error preparing " + notifier.GetName() + " :" + ex);
                }
            }

            await Task.WhenAll(notificationTasks);
            Console.WriteLine("All notifications triggered at " + DateTime.Now);
        }

        public virtual bool ContainsReminder(ReminderIF target)
        {
            return false;
        }
    }
}
