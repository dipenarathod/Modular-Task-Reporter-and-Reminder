using FinalProject.Information_Collector;
using FinalProject.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//Checked
namespace FinalProject.Common
{
    public static class AppDataStore
    {
        static ReaderWriterLockSlim reminderLock = new ReaderWriterLockSlim();
        static ReaderWriterLockSlim reportLock = new ReaderWriterLockSlim();
        static ReaderWriterLockSlim externalReminderConfigLock = new ReaderWriterLockSlim();

        static List<ReminderIF> reminders;
        static List<ReportIF> reports;

        static String RemindersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage", "Reminders.json");
        static String ReportsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage", "Reports.json");
        static String ExternalRemindersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "External Reminder Plugins", "Configured External Reminder Plugins.json");
        static String ExternalReminderIDsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "External Reminder Plugins", "Imported External Reminder IDs.json");

        static Dictionary<String, List<String>> externalReminderIDs = new Dictionary<String, List<String>>();
        static Dictionary<String, List<ReminderIF>> externalReminders = new Dictionary<String, List<ReminderIF>>();
        static Dictionary<String, Dictionary<String, String>> externalReminderConfigurations = new Dictionary<String, Dictionary<String, String>>();
        static ExternalReminderManager externalReminderManager;
        


        static NotificationManager notificationManager = new NotificationManager();
        static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };
        static AppDataStore()
        {
            LoadAll();
            AppDataStore.notificationManager.SetSchedulableProvider(AppDataStore.GetAllSchedulables);
        }
        private static void LoadAll()
        {
            LoadRemindersFromFile();
            LoadReportsFromFile();
            LoadExternalRemindersFile();
            LoadExternalReminderIDsFile();
            externalReminderManager = new ExternalReminderManager(
                externalReminderIDs,
                externalReminderConfigurations,
                externalReminders
            );
        }
        private static List<SchedulableIF> GetAllSchedulables()
        {
            return reminders.Cast<SchedulableIF>().Concat(reports).ToList();
        }

        //public static NotificationManager GetNotificationManager()
        //{
        //    return notificationManager;
        //}
        private static ExternalReminderManagerIF GetExternalReminderManager()
        {
            return externalReminderManager;
        }
        public static List<ReminderIF> GetReminders()
        {
            reminderLock.EnterReadLock();
            try
            {
                return reminders.ToList();
            }
            finally
            {
                reminderLock.ExitReadLock();
            }
        }

        public static void SetReminders(List<ReminderIF> newReminders)
        {
            reminderLock.EnterWriteLock();
            try
            {
                reminders = newReminders.ToList();
                SaveRemindersToFile();
            }
            finally
            {
                reminderLock.ExitWriteLock();
            }
        }

        public static void AddReminder(ReminderIF reminder)
        {
            reminderLock.EnterWriteLock();
            try
            {
                reminders.Add(reminder);
                SaveRemindersToFile();
            }
            finally
            {
                reminderLock.ExitWriteLock();
            }
        }

        public static void RemoveReminder(ReminderIF reminder)
        {
            reminderLock.EnterWriteLock();
            try
            {
                reminders.Remove(reminder);
                SaveRemindersToFile();
            }
            finally
            {
                reminderLock.ExitWriteLock();
            }
        }

        public static void UpdateReminder(ReminderIF originalReminder, ReminderIF updatedReminder)
        {
            reminderLock.EnterWriteLock();
            try
            {
                int index = -1;
                for (int i = 0; i < reminders.Count; i++)
                {
                    if (reminders[i].GetID() == originalReminder.GetID())
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    reminders[index].SetTitle(updatedReminder.GetTitle());
                    reminders[index].SetContent(updatedReminder.GetContent());
                    reminders[index].SetTime(updatedReminder.GetTime());
                    reminders[index].SetSchedule(updatedReminder.GetSchedule());
                    reminders[index].SetNotifiers(updatedReminder.GetNotifiers());

                    if (reminders[index].GetType() != updatedReminder.GetType())
                    {
                        if (reminders[index] is CompositeReminder originalComposite && updatedReminder is BasicReminder)
                        {
                            originalComposite.ClearReminders();
                        }
                    }
                    else if (reminders[index] is CompositeReminder compositeReminder && updatedReminder is CompositeReminder updatedComposite)
                    {
                        compositeReminder.SetReminders(updatedComposite.ToReminderList());
                    }

                    //reminders[index] = updatedReminder;
                    SaveRemindersToFile();
                }
            }
            finally
            {
                reminderLock.ExitWriteLock();
            }
        }

        private static void SaveRemindersToFile()
        {
            try
            {
                File.WriteAllText(RemindersFile, JsonConvert.SerializeObject(reminders, jsonSerializerSettings));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void LoadRemindersFromFile()
        {
            if (!File.Exists(RemindersFile)) return;
            reminderLock.EnterWriteLock();
            try
            {
                String json = File.ReadAllText(RemindersFile);
                if (JsonConvert.DeserializeObject<List<ReminderIF>>(json, jsonSerializerSettings) != null)
                {
                    reminders = JsonConvert.DeserializeObject<List<ReminderIF>>(json, jsonSerializerSettings);
                }
                else
                {
                    reminders = new List<ReminderIF>();
                }
            }
            finally
            {
                reminderLock.ExitWriteLock();
            }
        }
        public static List<ReportIF> GetReports()
        {
            reportLock.EnterReadLock();
            try
            {
                return reports.ToList();
            }
            finally
            {
                reportLock.ExitReadLock();
            }
        }

        public static void SetReports(List<ReportIF> newReports)
        {
            reportLock.EnterWriteLock();
            try
            {
                reports = newReports.ToList();
                SaveReportsToFile();
            }
            finally
            {
                reportLock.ExitWriteLock();
            }
        }

        public static void AddReport(ReportIF report)
        {
            reportLock.EnterWriteLock();
            try
            {
                reports.Add(report);
                SaveReportsToFile();
            }
            finally
            {
                reportLock.ExitWriteLock();
            }
        }

        public static void RemoveReport(ReportIF report)
        {
            reportLock.EnterWriteLock();
            try
            {
                reports.Remove(report);
                SaveReportsToFile();
            }
            finally
            {
                reportLock.ExitWriteLock();
            }
        }

        public static void UpdateReport(ReportIF originalReport, ReportIF updatedReport)
        {
            reportLock.EnterWriteLock();
            try
            {
                int index = -1;
                for (int i = 0; i < reports.Count; i++)
                {
                    if (reports[i].GetID() == originalReport.GetID())
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    reports[index].SetTitle(updatedReport.GetTitle());
                    reports[index].SetContent(updatedReport.GetContent());
                    reports[index].SetTime(updatedReport.GetTime());
                    reports[index].SetSchedule(updatedReport.GetSchedule());
                    reports[index].SetNotifiers(updatedReport.GetNotifiers());
                    if (reports[index].GetType() != updatedReport.GetType())
                    {
                        if (reports[index] is CompositeReport originalComposite && updatedReport is BasicReport)
                        {
                            originalComposite.ClearReports();
                        }
                    }
                    else if (reports[index] is CompositeReport compositeReport && updatedReport is CompositeReport updatedComposite)
                    {
                        compositeReport.SetReports(updatedComposite.ToReportList());
                    }
                    reports[index].SetPlugins(updatedReport.GetPlugins());
                    // Console.WriteLine("Updating report:" + reports[index].GetID() + " with " + updatedReport.GetID());
                    // reports[index] = updatedReport;
                    SaveReportsToFile();
                }
            }
            finally
            {
                reportLock.ExitWriteLock();
            }
        }
        private static void SaveReportsToFile()
        {
            try
            {
                File.WriteAllText(ReportsFile, JsonConvert.SerializeObject(reports, jsonSerializerSettings));
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());   
            }
        }

        private static void LoadReportsFromFile()
        {
            if (!File.Exists(ReportsFile)) return;
            reportLock.EnterWriteLock();
            try
            {
                String json = File.ReadAllText(ReportsFile);
                if (JsonConvert.DeserializeObject<List<ReportIF>>(json, jsonSerializerSettings) != null)
                {
                    reports = JsonConvert.DeserializeObject<List<ReportIF>>(json, jsonSerializerSettings);
                }
                else
                {
                    reports = new List<ReportIF>();
                }
                foreach (var report in reports)
                {
                    foreach (var plugin in report.GetPlugins())
                    {
                        String name = plugin.GetName();
                        if (InformationCollectorFactory.GetConfiguredPluginNames().Contains(name))
                        {
                            var required = plugin.GetRequiredParameters().Keys;
                            var optional = plugin.GetOptionalParameters().Keys;
                            var fullConfig = InformationCollectorFactory.GetConfiguration(name);

                            var requiredParams = new Dictionary<String, String>();
                            var optionalParams = new Dictionary<String, String>();

                            foreach (var kv in fullConfig)
                            {
                                if (required.Contains(kv.Key))
                                    requiredParams[kv.Key] = kv.Value;
                                else if (optional.Contains(kv.Key))
                                    optionalParams[kv.Key] = kv.Value;
                            }

                            plugin.SetParameters(requiredParams, optionalParams);
                        }
                    }
                }

            }
            finally
            {
                reportLock.ExitWriteLock();
            }
        }

        //private static void SaveExternalReminderConfiguration(ExternalReminderIF externalReminder)
        //{
        //    externalReminderConfigLock.EnterWriteLock();
        //    try
        //    {
        //        var name = externalReminder.GetName();

        //        var combined = new Dictionary<String, String>(externalReminder.GetRequiredParameters());
        //        foreach (var kvp in externalReminder.GetOptionalParameters())
        //        {
        //            combined[kvp.Key] = kvp.Value;
        //        }

        //        externalReminderConfigurations[name] = combined;
        //        SaveExternalRemindersFile();
        //    }
        //    finally
        //    {
        //        externalReminderConfigLock.ExitWriteLock();
        //    }
            
        //}
        private static void LoadExternalRemindersFile()
        {
            externalReminderConfigLock.EnterWriteLock();
            try
            {
                if (File.Exists(ExternalRemindersFile))
                {
                    var json = File.ReadAllText(ExternalRemindersFile);
                    if (JsonConvert.DeserializeObject<Dictionary<String, Dictionary<String, String>>>(json) != null)
                    {
                        externalReminderConfigurations = JsonConvert.DeserializeObject<Dictionary<String, Dictionary<String, String>>>(json);
                    }
                    else
                    {
                        externalReminderConfigurations = new Dictionary<String, Dictionary<String, String>>();
                    }
                }
            }
            finally
            {
                externalReminderConfigLock.ExitWriteLock();
            }
        }
        private static void LoadExternalReminderIDsFile()
        {
            externalReminderConfigLock.EnterWriteLock();
            try
            {
                if (File.Exists(ExternalReminderIDsFile))
                {
                    var json = File.ReadAllText(ExternalReminderIDsFile);
                    var deserialized = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
                    if (deserialized != null)
                    {
                        externalReminderIDs = deserialized;
                    }
                }
            }
            finally
            {
                externalReminderConfigLock.ExitWriteLock();
            }
        }
        private static void SaveExternalReminderIDsFile()
        {
            LoadExternalReminderIDsFile();
            externalReminderConfigLock.EnterReadLock();
            try
            {
                var externalReminderIDs=externalReminderManager.GetExternalReminderIDsDictionary();
                var json = JsonConvert.SerializeObject(externalReminderIDs, Formatting.Indented);
                File.WriteAllText(ExternalReminderIDsFile, json);
            }
            finally
            {
                externalReminderConfigLock.ExitReadLock();
            }
        }

        //private static void SaveExternalRemindersFile()
        //{
        //    externalReminderConfigLock.EnterWriteLock();
        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(externalReminderConfigurations, Formatting.Indented);
        //        File.WriteAllText(ExternalRemindersFile, json);
        //    }
        //    finally
        //    {
        //        externalReminderConfigLock.ExitWriteLock();
        //    }

        //}
        public static async Task<List<ReminderIF>> ImportExternalReminders()
        {
            var importedReminders = new List<ReminderIF>();

            foreach (var kvp in externalReminderConfigurations)
            {
                String name = kvp.Key;
                var config = kvp.Value;

                var plugin = ExternalReminderFactory.CreatePlugin(name);

                plugin.SetExternalReminderManager(GetExternalReminderManager());


                await plugin.Sync();

                var reminders = plugin.ToReminderList();

                if (reminders != null && reminders.Count > 0)
                {
                    foreach (var reminder in reminders)
                    {
                        externalReminderManager.AddExternalReminder(name, reminder);
                        AddReminder(reminder);
                        importedReminders.Add(reminder);
                    }
                }
            }

            SaveExternalReminderIDsFile();
            return importedReminders;
        }
    }
    internal class ExternalReminderManager : ExternalReminderManagerIF
    {
        private Dictionary<String, List<String>> externalReminderIDs;
        private Dictionary<String, Dictionary<String, String>> externalReminderConfigurations;
        private Dictionary<String, List<ReminderIF>> externalReminders;

        public ExternalReminderManager(Dictionary<String, List<String>> ids,Dictionary<String, Dictionary<String, String>> configs,Dictionary<String, List<ReminderIF>> reminders)
        {
            this.externalReminderIDs = ids;
            this.externalReminderConfigurations = configs;
            this.externalReminders = reminders;
        }

        public Dictionary<String, List<String>> GetExternalReminderIDsDictionary()
        {
            return new Dictionary<String, List<String>>(externalReminderIDs);
        }

        public List<String> GetExternalReminderIDs(String source)
        {
            if (externalReminderIDs.TryGetValue(source, out var ids))
            {
                return new List<String>(ids);
            }
            else
            {
                return new List<String>();
            }
        }

        public void AddExternalReminderIDs(String source, List<String> IDs)
        {
            if (!externalReminderIDs.ContainsKey(source))
            {
                externalReminderIDs[source] = new List<String>();
            }

            foreach (var id in IDs)
            {
                if (!externalReminderIDs[source].Contains(id))
                {
                    externalReminderIDs[source].Add(id);
                }
            }
        }

        public void RemoveExternalReminderIDs(String source, List<String> IDs)
        {
            if (!externalReminderIDs.ContainsKey(source))
            {
                return;
            }

            List<string> idsToRemove = new List<string>();
            foreach (string id in externalReminderIDs[source])
            {
                if (IDs.Contains(id))
                {
                    idsToRemove.Add(id);
                }
            }
            foreach (string idToRemove in idsToRemove)
            {
                externalReminderIDs[source].Remove(idToRemove);
            }
        }

        public bool ContainsExternalReminderIDs(String source, List<String> IDs)
        {
            if (!externalReminderIDs.ContainsKey(source))
            {
                return false;
            }

            bool contains = true;
            foreach (string id in IDs)
            {
                if (!externalReminderIDs[source].Contains(id))
                {
                    contains = false;
                    break;
                }
            }
            return contains;
        }

        public Dictionary<String, String> GetExternalReminderConfiguration(String source)
        {
            if (externalReminderConfigurations.TryGetValue(source, out var config))
            {
                return new Dictionary<String, String>(config);
            }
            else
            {
                return new Dictionary<String, String>();
            }
        }

        public void SaveExternalReminderConfiguration(ExternalReminderIF externalReminder)
        {
            var name = externalReminder.GetName();
            var combined = new Dictionary<String, String>(externalReminder.GetRequiredParameters());

            foreach (var pair in externalReminder.GetOptionalParameters())
            {
                combined[pair.Key] = pair.Value;
            }

            externalReminderConfigurations[name] = combined;
        }

        public void AddExternalReminders(String source, List<ReminderIF> reminders)
        {
            if (!externalReminders.ContainsKey(source))
            {
                externalReminders[source] = new List<ReminderIF>();
            }
            externalReminders[source].AddRange(reminders);
        }

        public List<ReminderIF> GetExternalReminders(String source)
        {
            if (externalReminders.TryGetValue(source, out var reminders))
            {
                return new List<ReminderIF>(reminders);
            }
            else
            {
                return new List<ReminderIF>();
            }
        }

        public List<ReminderIF> GetExternalReminders()
        {
            List<ReminderIF> allReminders = new List<ReminderIF>();

            foreach (List<ReminderIF> reminderList in externalReminders.Values)
            {
                foreach (ReminderIF reminder in reminderList)
                {
                    allReminders.Add(reminder);
                }
            }

            return allReminders;
        }
        public void AddExternalReminder(String source, ReminderIF reminder)
        {
            if (!externalReminders.ContainsKey(source))
            {
                externalReminders[source] = new List<ReminderIF>();
            }

            externalReminders[source].Add(reminder);
        }
    }
}
