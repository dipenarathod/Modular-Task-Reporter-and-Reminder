using FinalProject.Common;
using FinalProject.Information_Collector;
using FinalProject.Notifier;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Report
{
    public class AbsReport:ReportIF
    {
        [JsonProperty]
        String title;
        [JsonProperty]
        String content;
        [JsonProperty]
        protected String ID;
        [JsonProperty]
        DateTime time;
        [JsonProperty]
        RepeatSchedule schedule=null;
        [JsonProperty]
        protected List<NotifierIF> notifiers;
        [JsonProperty]
        protected List<InformationCollectorIF> plugins;
        public AbsReport(String title, String content, DateTime time, RepeatSchedule schedule)
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
        public virtual String GetContent()
        {
            String finalContent = content;
            foreach (var plugin in plugins)
            {
                try
                {
                    finalContent += "\n" + plugin.GetDescription();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error preparing " + plugin.GetName() + " :" + ex);
                }
            }
            return finalContent;
        }
        public String GetID()
        {
            return ID;
        }
        public virtual List<ReportIF> ToReportList()
        {
            return new List<ReportIF> { this };
        }
        public RepeatSchedule GetSchedule()
        {
            return schedule;
        }
        public void SetTitle(String title)
        {
            this.title = title;
        }
        public void SetContent(String content)
        {
            this.content = content;
        }
        public void SetSchedule(RepeatSchedule schedule)
        {
            this.schedule = schedule;
        }

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

        public void AddPlugin(InformationCollectorIF plugin)
        {
            plugins.Add(plugin);
        }

        public void RemovePlugin(InformationCollectorIF plugin)
        {
            plugins.Remove(plugin);
        }

        public virtual async Task TriggerNotifications()
        {
            await CollectData();

            var notificationTasks = new List<Task>();
            foreach (var notifier in GetNotifiers())
            {
                try
                {
                    notifier.SetTitle(GetTitle());
                    notifier.SetContent(GetContent());
                    notificationTasks.Add(notifier.SendNotification());
                    Console.WriteLine("Starting to send Report notification");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error preparing " + notifier.GetName() + " :" + ex);
                }
            }

            await Task.WhenAll(notificationTasks);
            Console.WriteLine("All notifications triggered at " + DateTime.Now);
        }

        public virtual async Task CollectData()
        {
            var tasks = new List<Task>();
            foreach (var plugin in plugins)
            {
                try
                {
                    tasks.Add(plugin.CollectInformation());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error collecting info from "+plugin.GetName());
                }
            }

            await Task.WhenAll(tasks);
        }
        public virtual bool ContainsReport(ReportIF target)
        {
            return false;
        }

        public DateTime GetTime()
        {
            return time;
        }

        public List<InformationCollectorIF> GetPlugins()
        {
            return plugins;
        }

        public void SetTime(DateTime time)
        {
            this.time = time;
        }

        public void SetNotifiers(List<NotifierIF> notifiers)
        {
            this.notifiers = notifiers;
        }

        public void SetPlugins(List<InformationCollectorIF> plugins)
        {
            this.plugins = plugins;
        }
    }
}
