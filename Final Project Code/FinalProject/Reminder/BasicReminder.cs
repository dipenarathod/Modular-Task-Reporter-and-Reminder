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
    public class BasicReminder : AbsReminder
    {
        [JsonConstructor]
        public BasicReminder(String title, String description, DateTime time, RepeatSchedule schedule,String ID=null) : base(title, description, time, schedule)
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
        }
        public override List<ReminderIF> ToReminderList()
        {
            return new List<ReminderIF> { this };
        }

        
    }
}
