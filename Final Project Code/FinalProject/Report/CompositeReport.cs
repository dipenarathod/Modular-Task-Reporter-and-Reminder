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
    public class CompositeReport:AbsReport
    {
        [JsonProperty]
        List<ReportIF> reports = new List<ReportIF>();

        [JsonConstructor]
        public CompositeReport(string title, string content, DateTime time, RepeatSchedule schedule, String ID = null) : base(title, content, time, schedule)
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
            this.plugins = new List<InformationCollectorIF>();
        }
        public override bool ContainsReport(ReportIF target)
        {
            foreach (var report in reports)
            {
                if (report == target)
                    return true;

                if (report is CompositeReport composite)
                {
                    if (composite.ContainsReport(target))
                        return true;
                }
            }
            return false;
        }
        public void AddReport(ReportIF report)
        {
            if (report == this || report.ContainsReport(this))
            {
                throw new Exception("Adding this report would create a circular reference.");
            }
            reports.Add(report);
        }
        public void RemoveReport(ReportIF report)
        {
            reports.Remove(report);
        }

        public void ClearReports()
        {
            reports.Clear();
        }
        public void SetReports(List<ReportIF> reports)
        {
            this.reports = reports;
        }

        public override string GetContent()
        {
            string combinedContent = base.GetContent();

            foreach (var report in reports)
            {
                combinedContent += "\n\n--- Sub Report ---\n";
                combinedContent += report.GetContent();
            }

            return combinedContent;
        }
        public override List<ReportIF> ToReportList()
        {
            var list = new List<ReportIF>();
            foreach (var report in reports)
            {
                list.AddRange(report.ToReportList());
            }
            return list;
        }

        public override async Task CollectData()
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
                    Console.WriteLine("Error collecting info from " + plugin.GetName());
                }
            }

            await Task.WhenAll(tasks);
            foreach (var report in reports)
            {
                try
                {
                    await report.CollectData();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error collecting from subreport: "+ex);
                }
            }
        }

        public override async Task TriggerNotifications()
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error preparing " + notifier.GetName() + " :" + ex);
                }
            }

            await Task.WhenAll(notificationTasks);
            Console.WriteLine("Composite report notification sent at " + DateTime.Now);
        }
    }
}
