using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FinalProject.Notifier;

//Checked
namespace FinalProject.Common
{
    public class NotificationManager
    {
        public delegate List<SchedulableIF> SchedulableProvider();
        private SchedulableProvider getSchedulables;

        private object lockObject = new object();
        private HashSet<string> triggered = new HashSet<string>();
        private Timer timer;
        private Timer resetTimer;
        private TimeSpan checkInterval;
        private TimeSpan resetInterval = TimeSpan.FromHours(12);

        public NotificationManager()
        {
            checkInterval = TimeSpan.FromSeconds(30);
            timer = new Timer(CheckAndTriggerAll, null, TimeSpan.Zero, checkInterval);
            resetTimer = new Timer(ClearTriggered, null, resetInterval, resetInterval);
        }

        public NotificationManager(TimeSpan checkInterval)
        {
            this.checkInterval = checkInterval;
            timer = new Timer(CheckAndTriggerAll, null, TimeSpan.Zero, checkInterval);
            resetTimer = new Timer(ClearTriggered, null, resetInterval, resetInterval);
        }

        public void SetSchedulableProvider(SchedulableProvider provider)
        {
            lock (lockObject)
            {
                getSchedulables = provider;
            }
        }

        public void SetCheckInterval(TimeSpan interval)
        {
            lock (lockObject)
            {
                checkInterval = interval;
                timer.Change(TimeSpan.Zero, checkInterval);
            }
        }

        public TimeSpan GetCheckInterval()
        {
            lock (lockObject)
            {
                return checkInterval;
            }
        }

        private async void CheckAndTriggerAll(object state)
        {
            DateTime now = DateTime.Now;

            List<SchedulableIF> itemsToTrigger;
            lock (lockObject)
            {
                List<SchedulableIF> items = getSchedulables?.Invoke();
                if(items == null)
                {
                    itemsToTrigger= new List<SchedulableIF>();
                }
                else
                {
                    itemsToTrigger = items;
                }
            }

            List<Task> tasks = new List<Task>();

            foreach (SchedulableIF schedulable in itemsToTrigger)
            {
                string uniqueKey = schedulable.GetID();
                bool shouldTrigger = false;

                var schedule = schedulable.GetSchedule();
                if (schedule == null || schedule.GetRepeatString() == RepeatString.None)
                {
                    DateTime oneTime = schedulable.GetTime();
                    if (Math.Abs((now - oneTime).TotalMinutes) < 1)
                    {
                        shouldTrigger = true;
                    }
                }
                else if (schedule.ShouldTriggerNow(now))
                {
                    shouldTrigger = true;
                }

                if (!shouldTrigger)
                    continue;

                bool alreadyTriggered = false;
                lock (lockObject)
                {
                    alreadyTriggered = triggered.Contains(uniqueKey);
                    if (!alreadyTriggered)
                    {
                        triggered.Add(uniqueKey);
                    }
                }

                if (!alreadyTriggered)
                {
                    tasks.Add(schedulable.TriggerNotifications());
                }
            }

            await Task.WhenAll(tasks);
        }

        private void ClearTriggered(object state)
        {
            lock (lockObject)
            {
                triggered.Clear();
                Console.WriteLine("Triggered hash set cleared at " + DateTime.Now);
            }
        }

        public void StopTimer()
        {
            lock (lockObject)
            {
                timer.Dispose();
                resetTimer.Dispose();
            }
        }
    }
}
