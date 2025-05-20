using FinalProject.Common;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ical.Net;
using Newtonsoft.Json;

//Checked
namespace FinalProject
{
    public class GoogleCalendarReminders : AbsExternalReminder
    {
        
        private CalendarService service;
        List<ReminderIF> reminders;
        private Task<CalendarService> serviceTask;
        
        [JsonConstructor]
        public GoogleCalendarReminders() : base("Google Calendar") 
        {
            this.source = "Google Calendar";
            Dictionary<string, string> required = GetRequiredParameters();
            Dictionary<string, string> optional = GetOptionalParameters();
            required["Client Secret Path"] = "String";
            this.SetParameters(required, optional);
            
        }

        public override async Task Sync()
        {
            serviceTask = AuthenticateGoogleCalendar();
            service = await serviceTask;
            reminders = await GetEvents();
        }

        private async Task<CalendarService> AuthenticateGoogleCalendar()
        {
            string[] scopes = { CalendarService.Scope.CalendarReadonly };

            UserCredential credential;
            String clientSecretPath = this.GetRequiredParameters()["Client Secret Path"];
            using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore("GoogleOAuth", true));
            }

            return new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Reminder Import App",
            });
        }

        private async Task<List<ReminderIF>> GetEvents()
        {
            if (GetExternalReminderManager() == null)
            {
                throw new Exception("ExternalReminderManager has not been set for" + GetName());
            }
            var existingIDs = GetExternalReminderManager().GetExternalReminderIDs(GetName());
            var newIDs = new List<string>();
            var request = service.Events.List("primary");
            request.TimeMin = DateTime.UtcNow;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            var events = await request.ExecuteAsync();
            var list = new List<ReminderIF>();

            if (events.Items != null)
            {
                foreach (var item in events.Items)
                {
                    if (existingIDs.Contains(item.Id))
                        continue;
                    newIDs.Add(item.Id);
                    String summary;
                    String description;
                    DateTime startTime;
                    if (item.Summary == null)
                        summary = "No Title";
                    else
                    {
                        summary = item.Summary;
                    }
                    if (item.Description==null)
                    {
                        description = "";
                    }
                    else
                    {
                        description = item.Description;
                    }


                    if (item.Start.DateTimeDateTimeOffset.HasValue)
                    {
                        startTime = item.Start.DateTimeDateTimeOffset.Value.DateTime;
                    }
                    else
                    {
                        startTime = DateTime.Parse(item.Start.Date);
                    }
                    string rrule;
                    if(item.Recurrence == null)
                    {
                        rrule = null;
                    }
                    else
                    {
                        rrule = item.Recurrence.FirstOrDefault();
                    }
                    RepeatSchedule schedule = RecurrenceRuleToRepeatSchedule(rrule);
                    BasicReminder reminder = new BasicReminder(summary, description, startTime,schedule);
                    list.Add(reminder);
                }
            }
            GetExternalReminderManager().AddExternalReminderIDs(GetName(), newIDs);
            GetExternalReminderManager().AddExternalReminders(GetName(), list);
            return list;
        }

        public override List<ReminderIF> ToReminderList()
        {
            return reminders;
        }
        private RepeatSchedule RecurrenceRuleToRepeatSchedule(string rrule)
        {
            RepeatSchedule schedule = null;
            RepeatString String = RepeatString.None;
            TimeSpan timeOfDay = TimeSpan.Zero;
            List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();
            DateTime? startDate = null;
            DateTime? endDate = null;

            if (string.IsNullOrWhiteSpace(rrule))
                return new RepeatSchedule(
                    RepeatString.None,
                    TimeSpan.Zero,
                    new List<DayOfWeek>(),
                    null,
                    null
                );

            string ruleBody = rrule.StartsWith("RRULE:") ? rrule.Substring(6) : rrule;
            string[] parts = ruleBody.Split(';');

            foreach (var part in parts)
            {
                string[] keyValue = part.Split('=');
                if (keyValue.Length != 2)
                    continue;

                string key = keyValue[0].Trim().ToUpper();
                string value = keyValue[1].Trim().ToUpper();

                switch (key)
                {
                    case "FREQ":
                        if (value == "DAILY")
                        {
                            String = RepeatString.Daily;
                        }
                        else if (value == "WEEKLY")
                        {
                            String = RepeatString.Weekly;
                        }
                        else if (value == "MONTHLY")
                        {
                            String = RepeatString.Monthly;
                        }
                        else if (value == "YEARLY")
                        {
                            String = RepeatString.Yearly;
                        }
                        else
                        {
                            String = RepeatString.None;
                        }
                        break;

                    case "INTERVAL":
                        break;

                    case "BYDAY":
                        string[] days = value.Split(',');
                        foreach (string day in days)
                        {
                            switch (day)
                            {
                                case "MO": daysOfWeek.Add(DayOfWeek.Monday); break;
                                case "TU": daysOfWeek.Add(DayOfWeek.Tuesday); break;
                                case "WE": daysOfWeek.Add(DayOfWeek.Wednesday); break;
                                case "TH": daysOfWeek.Add(DayOfWeek.Thursday); break;
                                case "FR": daysOfWeek.Add(DayOfWeek.Friday); break;
                                case "SA": daysOfWeek.Add(DayOfWeek.Saturday); break;
                                case "SU": daysOfWeek.Add(DayOfWeek.Sunday); break;
                            }
                        }
                        break;

                    case "UNTIL":
                        if (DateTime.TryParseExact(value, "yyyyMMdd'T'HHmmss'Z'",System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.AssumeUniversal,out DateTime until))
                        {
                            endDate = until;
                        }
                        else if (DateTime.TryParseExact(value, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime untilDate))
                        {
                            endDate = untilDate;
                        }
                        else
                        {
                            endDate = null;
                        }
                        break;
                }
            }
            schedule = new RepeatSchedule(String, timeOfDay, daysOfWeek, startDate, endDate);

            return schedule;
        }
    }
}
