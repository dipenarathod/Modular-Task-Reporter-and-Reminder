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
    public class BasicReport : AbsReport
    {
        [JsonConstructor]
        public BasicReport(string title, string content, DateTime time, RepeatSchedule schedule, String ID=null) : base(title, content, time, schedule)
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
    }
}
