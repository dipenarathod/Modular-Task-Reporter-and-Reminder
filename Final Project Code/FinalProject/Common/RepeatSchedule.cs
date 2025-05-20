using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Common
{
    public enum RepeatString
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public class RepeatSchedule
    {
        [JsonProperty]
        RepeatString repeatString;
        [JsonProperty]
        TimeSpan timeOfDay;
        [JsonProperty]
        List<DayOfWeek> daysOfWeek;
        [JsonProperty]
        DateTime? startDate;
        [JsonProperty]
        DateTime? endDate;

        [JsonConstructor]
        public RepeatSchedule(
            RepeatString repeatString,
            TimeSpan timeOfDay,
            List<DayOfWeek> daysOfWeek = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            this.repeatString = repeatString;
            this.timeOfDay = timeOfDay;
            if (daysOfWeek == null)
            {
                this.daysOfWeek = new List<DayOfWeek>();
            }
            else
            {
                this.daysOfWeek = daysOfWeek;
            }
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public override String ToString()
        {
            String toReturn = repeatString.ToString();
            toReturn +=" " + timeOfDay.ToString();
            toReturn +=" " + daysOfWeek.ToString();
            toReturn +=" " + startDate.ToString();
            toReturn +=" " + endDate.ToString();
            return toReturn;
        }

        public RepeatString GetRepeatString()
        {
            return repeatString;
        }
        public TimeSpan GetTimeOfDay()
        {
            return timeOfDay;
        }
        public List<DayOfWeek> GetDaysOfWeek()
        {
            return daysOfWeek;
        }
        public DateTime? GetStartDate()
        {
            return startDate;
        }
        public DateTime? GetEndDate()
        {
            return endDate;
        }
        public bool ShouldTriggerNow(DateTime currentTime)
        {
            if (startDate.HasValue && currentTime.Date < startDate.Value.Date)
                return false;
            if (endDate.HasValue && currentTime.Date > endDate.Value.Date)
                return false;

            switch (repeatString)
            {
                case RepeatString.None:
                    if (!startDate.HasValue)
                    {
                        return false;
                    }
                    DateTime triggerTime = startDate.Value.Date + timeOfDay;
                    return Math.Abs((currentTime - triggerTime).TotalMinutes) < 1;

                case RepeatString.Daily:
                    return Math.Abs((currentTime.TimeOfDay - timeOfDay).TotalMinutes) < 1;

                case RepeatString.Weekly:
                    return daysOfWeek.Contains(currentTime.DayOfWeek) &&
                           Math.Abs((currentTime.TimeOfDay - timeOfDay).TotalMinutes) < 1;

                case RepeatString.Monthly:
                    return currentTime.Day == startDate?.Day &&
                           Math.Abs((currentTime.TimeOfDay - timeOfDay).TotalMinutes) < 1;

                case RepeatString.Yearly:
                    return currentTime.Month == startDate?.Month &&
                           currentTime.Day == startDate?.Day &&
                           Math.Abs((currentTime.TimeOfDay - timeOfDay).TotalMinutes) < 1;
                default:
                    return false;
            }
        }
    }

}
