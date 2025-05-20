using FinalProject.Notifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Common
{
    public interface SchedulableIF
    {
        DateTime GetTime();
        String GetTitle();
        String GetContent();
        String GetID();
        RepeatSchedule GetSchedule();
        List<NotifierIF> GetNotifiers();
        void SetTitle(string title);
        void SetContent(string content);
        void SetTime(DateTime time);
        void SetSchedule(RepeatSchedule schedule);

        void AddNotifier(NotifierIF notifier);
        void RemoveNotifier(NotifierIF notifier);

        void SetNotifiers(List<NotifierIF> notifiers);
        Task TriggerNotifications();
    }
}
