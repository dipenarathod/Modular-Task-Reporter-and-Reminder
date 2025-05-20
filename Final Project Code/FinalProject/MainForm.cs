using Aspose.Email.Clients.Google;
using FinalProject.Common;
using FinalProject.Information_Collector;
using FinalProject.Notifier;
using FinalProject.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Checked
namespace FinalProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadReminders();
            LoadReports();
            LoadInformationcollectorSettingsUI();
            LoadNotifierSettingsUI();
            LoadExternalReminderSettingsUI();
        }

        private void buttonAddReminder_Click(object sender, EventArgs e)
        {
            using (var reminderForm = new ReminderForm())
            {
                if (reminderForm.ShowDialog() == DialogResult.OK)
                {
                    ReminderIF newReminder = reminderForm.GetReminder();
                    if (newReminder != null)
                    {
                        AppDataStore.AddReminder(newReminder);
                        AddReminderToListView(newReminder);
                    }
                }
            }
        }
        private void AddReminderToListView(ReminderIF reminder)
        {
            var item = new ListViewItem(reminder.GetTitle());
            item.SubItems.Add(reminder.GetContent());
            item.SubItems.Add(reminder.GetTime().ToString());
            if (reminder.GetSchedule() != null)
            {
                item.SubItems.Add(reminder.GetSchedule().GetRepeatString().ToString());
            }
            else
            {
                item.SubItems.Add("None");
            }
            item.SubItems.Add(reminder.GetType().Name);
            item.Tag = reminder;
            listViewReminders.Items.Add(item);
        }
        private void LoadNotifierSettingsUI()
        {
            comboBoxNotifierSelect.Items.Clear();
            comboBoxNotifierSelect.Items.AddRange(NotifierFactory.GetAvailableNotifierNames().ToArray());

            if (File.Exists(NotifierFactory.ConfiguredPluginsDirectory()))
            {
                string json = File.ReadAllText(NotifierFactory.ConfiguredPluginsDirectory());
                var configured = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                if (configured == null || configured.Keys.ToList() == null)
                {
                    return;
                }
                else
                {
                    listBoxConfiguredNotifiers.Items.Clear();
                    foreach (var key in configured.Keys)
                    {
                        listBoxConfiguredNotifiers.Items.Add(key);
                    }
                }
            }
        }

        private void LoadInformationcollectorSettingsUI()
        {
            comboBoxInformationCollectorSelect.Items.Clear();
            comboBoxInformationCollectorSelect.Items.AddRange(InformationCollectorFactory.GetAvailablePluginNames().ToArray());

            if (File.Exists(InformationCollectorFactory.ConfiguredPluginsDirectory()))
            {
                string json = File.ReadAllText(InformationCollectorFactory.ConfiguredPluginsDirectory());
                var configured = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                if(configured == null || configured.Keys.ToList() == null)
                {
                    return;
                }
                else
                {
                    listBoxConfiguredInformationCollectors.Items.Clear();
                    foreach (var key in configured.Keys)
                    {
                        listBoxConfiguredInformationCollectors.Items.Add(key);
                    }
                }
                
            }
        }
        private void LoadExternalReminderSettingsUI()
        {
            comboBoxExternalReminderSelect.Items.Clear();
            comboBoxExternalReminderSelect.Items.AddRange(ExternalReminderFactory.GetAvailablePluginNames().ToArray());
            if (File.Exists(ExternalReminderFactory.ConfiguredPluginsDirectory()))
            {
                string json = File.ReadAllText(ExternalReminderFactory.ConfiguredPluginsDirectory());
                var configured = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                if (configured == null || configured.Keys.ToList() == null)
                {
                    return;
                }
                else
                {
                    listBoxConfiguredExternalReminders.Items.Clear();
                    foreach (var key in configured.Keys)
                    {
                        listBoxConfiguredExternalReminders.Items.Add(key);
                    }
                }
            }
        }
        private void LoadReminders()
        {
            listViewReminders.Items.Clear();
            var reminders = AppDataStore.GetReminders();
            foreach (var reminder in reminders)
            {
                AddReminderToListView(reminder);
            }
        }

        private void LoadReports()
        {
            listViewReports.Items.Clear();
            var reports = AppDataStore.GetReports();
            foreach (var report in reports)
            {
                AddReportToListView(report);
            }
        }

        private void AddReportToListView(ReportIF report)
        {
            var item = new ListViewItem(report.GetTitle());
            item.SubItems.Add(report.GetContent());
            item.SubItems.Add(report.GetTime().ToString());
            if (report.GetSchedule() != null)
            {
                item.SubItems.Add(report.GetSchedule().GetRepeatString().ToString());
            }
            else
            {
                item.SubItems.Add("None");
            }
            item.SubItems.Add(report.GetType().Name);
            item.Tag = report;
            listViewReports.Items.Add(item);
        }

        private void buttonConfigureNotifier_Click(object sender, EventArgs e)
        {
            string selectedNotifier = comboBoxNotifierSelect.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedNotifier))
            {
                MessageBox.Show("Please select a notifier.");
                return;
            }

            try
            {
                NotifierIF notifier = NotifierFactory.CreateNotifier(selectedNotifier);

                
                Dictionary<string, Dictionary<string, string>> existingConfigs = new Dictionary<string, Dictionary<string, string>>();
                string configuredNotifiersPath = NotifierFactory.ConfiguredPluginsDirectory();

                if (File.Exists(configuredNotifiersPath))
                {
                    string json = File.ReadAllText(configuredNotifiersPath);
                    if(JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json) == null)
                    {
                        existingConfigs = new Dictionary<string, Dictionary<string, string>>();
                    }
                    else
                    {
                        existingConfigs = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                    }
                }

                Dictionary<string, string> currentConfig = null;
                if (existingConfigs.TryGetValue(selectedNotifier, out var storedConfig))
                {
                    currentConfig = storedConfig;
                }

                
                using (var configForm = new PluginConfigForm(notifier, currentConfig))
                {
                    if (configForm.ShowDialog() == DialogResult.OK)
                    {
                        
                        Dictionary<string, string> newConfig = configForm.GetConfiguredParameters();
                        existingConfigs[selectedNotifier] = newConfig;

                        string updatedJson = JsonConvert.SerializeObject(existingConfigs, Formatting.Indented);
                        File.WriteAllText(configuredNotifiersPath, updatedJson);

                        NotifierFactory.ReloadPlugins();
                        RefreshConfiguredNotifierList(existingConfigs.Keys.ToList());
                        MessageBox.Show("Notifier configured successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error configuring notifier: " + ex.Message);
            }
        }
        private void RefreshConfiguredNotifierList(List<string> notifierNames)
        {
            listBoxConfiguredNotifiers.Items.Clear();
            foreach (var name in notifierNames)
            {
                listBoxConfiguredNotifiers.Items.Add(name);
            }
        }

        private void buttonDeleteReminder_Click(object sender, EventArgs e)
        {
            if (listViewReminders.SelectedItems.Count > 0)
            {
                var selectedItems = listViewReminders.SelectedItems;
                var result = MessageBox.Show("Are you sure you want to delete these reminders?",
                                                 "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem selectedItem in selectedItems)
                    {
                        if (selectedItem.Tag is ReminderIF selectedReminder)
                        {
                            listViewReminders.Items.Remove(selectedItem);
                            AppDataStore.RemoveReminder(selectedReminder);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reminder to delete.");
            }
        }

        private void buttonEditReminder_Click(object sender, EventArgs e)
        {
            if (listViewReminders.SelectedItems.Count > 0)
            {
                var selectedItem = listViewReminders.SelectedItems[0];
                if (selectedItem.Tag is ReminderIF selectedReminder)
                {
                    using (var reminderForm = new ReminderForm(selectedReminder))
                    {
                        if (reminderForm.ShowDialog() == DialogResult.OK)
                        {
                            ReminderIF updatedReminder = reminderForm.GetReminder();
                            if (updatedReminder != null)
                            {
                                selectedItem.SubItems[0].Text = updatedReminder.GetTitle();
                                selectedItem.SubItems[1].Text = updatedReminder.GetContent();
                                selectedItem.SubItems[2].Text = updatedReminder.GetTime().ToString();
                                selectedItem.SubItems[3].Text = updatedReminder.GetSchedule()?.GetRepeatString().ToString();
                                selectedItem.SubItems[4].Text = updatedReminder.GetType().Name;
                                
                                AppDataStore.UpdateReminder(selectedReminder,updatedReminder);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reminder to edit.");
            }
        }

        private void buttonConfigureInformationCollector_Click(object sender, EventArgs e)
        {
            string selectedInformationCollector = comboBoxInformationCollectorSelect.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedInformationCollector))
            {
                MessageBox.Show("Please select an Information collector.");
                return;
            }

            try
            {

                InformationCollectorIF collector = InformationCollectorFactory.CreatePlugin(selectedInformationCollector);

                
                Dictionary<string, Dictionary<string, string>> existingConfigs = new Dictionary<string, Dictionary<string, string>>();
                string configuredPluginsPath = InformationCollectorFactory.ConfiguredPluginsDirectory();

                if (File.Exists(configuredPluginsPath))
                {
                    string json = File.ReadAllText(configuredPluginsPath);
                    if (JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json) == null)
                    {
                        existingConfigs = new Dictionary<string, Dictionary<string, string>>();
                    }
                    else
                    {
                        existingConfigs = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                    }
                }

                Dictionary<string, string> currentConfig = null;
                if (existingConfigs.TryGetValue(selectedInformationCollector, out var storedConfig))
                {
                    currentConfig = storedConfig;
                }

                
                using (var configForm = new PluginConfigForm(collector, currentConfig))
                {
                    if (configForm.ShowDialog() == DialogResult.OK)
                    {
                        
                        Dictionary<string, string> newConfig = configForm.GetConfiguredParameters();
                        existingConfigs[selectedInformationCollector] = newConfig;

                        string updatedJson = JsonConvert.SerializeObject(existingConfigs, Formatting.Indented);
                        File.WriteAllText(configuredPluginsPath, updatedJson);

                        InformationCollectorFactory.ReloadPlugins();
                        RefreshConfiguredInformationCollectorList(existingConfigs.Keys.ToList());
                        MessageBox.Show("Information Collector configured successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error configuring Information Collector: " + ex.Message);
            }
        }
        private void RefreshConfiguredInformationCollectorList(List<string> informationCollectorNames)
        {
            listBoxConfiguredInformationCollectors.Items.Clear();
            foreach (var name in informationCollectorNames)
            {
                listBoxConfiguredInformationCollectors.Items.Add(name);
            }
        }

        private void buttonAddReport_Click(object sender, EventArgs e)
        {
            using (var reportForm = new ReportForm())
            {
                if (reportForm.ShowDialog() == DialogResult.OK)
                {
                    ReportIF newReport = reportForm.GetReport();
                    if (newReport != null)
                    {
                        AppDataStore.AddReport(newReport); 
                        AddReportToListView(newReport);
                    }
                }
            }
        }

        private void buttonDeleteReport_Click(object sender, EventArgs e)
        {

            if (listViewReports.SelectedItems.Count > 0)
            {
                //var selectedItem = listViewReports.SelectedItems[0];
                //if (selectedItem.Tag is ReportIF selectedReport)
                //{
                //    var result = MessageBox.Show("Are you sure you want to delete this report?",
                //                                 "Confirm Delete", MessageBoxButtons.YesNo);
                //    if (result == DialogResult.Yes)
                //    {
                //        //Remove from ListView
                //        listViewReports.Items.Remove(selectedItem);

                //        AppDataStore.RemoveReport(selectedReport);
                //        MessageBox.Show("Report deleted.");
                //    }
                //}
                var selectedItems = listViewReports.SelectedItems;
                var result = MessageBox.Show("Are you sure you want to delete these reports?",
                                                 "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem selectedItem in selectedItems)
                    {
                        if (selectedItem.Tag is ReportIF selectedReport)
                        {
                            listViewReports.Items.Remove(selectedItem);
                            AppDataStore.RemoveReport(selectedReport);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a report to delete.");
            }
        }

        private void buttonEditReport_Click(object sender, EventArgs e)
        {
            if (listViewReports.SelectedItems.Count > 0)
            {
                var selectedItem = listViewReports.SelectedItems[0];
                if (selectedItem.Tag is ReportIF selectedReport)
                {
                    using (var reportForm = new ReportForm(selectedReport))
                    {
                        if (reportForm.ShowDialog() == DialogResult.OK)
                        {
                            ReportIF updatedReport = reportForm.GetReport();
                            if (updatedReport != null)
                            {
                                selectedItem.SubItems[0].Text = updatedReport.GetTitle();
                                selectedItem.SubItems[1].Text = updatedReport.GetContent();
                                selectedItem.SubItems[2].Text = updatedReport.GetTime().ToString();
                                selectedItem.SubItems[3].Text = updatedReport.GetSchedule().GetRepeatString().ToString();
                                selectedItem.SubItems[4].Text = updatedReport.GetType().Name;
                                
                                AppDataStore.UpdateReport(selectedReport, updatedReport);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reminder to edit.");
            }
        }

        private void buttonConfigureExternalReminder_Click(object sender, EventArgs e)
        {
            string selectedExternalReminder = comboBoxExternalReminderSelect.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedExternalReminder))
            {
                MessageBox.Show("Please select an External Reminder.");
                return;
            }

            try
            {
                ExternalReminderIF externalReminder = ExternalReminderFactory.CreatePlugin(selectedExternalReminder);

                Dictionary<string, Dictionary<string, string>> existingConfigs = new Dictionary<string, Dictionary<string, string>>();
                string configuredPluginsPath = ExternalReminderFactory.ConfiguredPluginsDirectory();
                if (File.Exists(configuredPluginsPath))
                {
                    string json = File.ReadAllText(configuredPluginsPath);
                    if (JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json) == null)
                    {
                        existingConfigs = new Dictionary<string, Dictionary<string, string>>();
                    }
                    else
                    {
                        existingConfigs = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                    }
                }

                Dictionary<string, string> currentConfig = null;
                if (existingConfigs.TryGetValue(selectedExternalReminder, out var storedConfig))
                {
                    currentConfig = storedConfig;
                }

                
                using (var configForm = new PluginConfigForm(externalReminder, currentConfig))
                {
                    if (configForm.ShowDialog() == DialogResult.OK)
                    {
                        
                        Dictionary<string, string> newConfig = configForm.GetConfiguredParameters();
                        existingConfigs[selectedExternalReminder] = newConfig;

                        string updatedJson = JsonConvert.SerializeObject(existingConfigs, Formatting.Indented);
                        File.WriteAllText(configuredPluginsPath, updatedJson);
                        ExternalReminderFactory.ReloadPlugins();
                        RefreshConfiguredExternalreminderList(existingConfigs.Keys.ToList());
                        MessageBox.Show("External Reminder configured successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error configuring External Reminder: " + ex.Message);
            }
        }
        private void RefreshConfiguredExternalreminderList(List<string> externalReminderNames)
        {
            listBoxConfiguredExternalReminders.Items.Clear();
            foreach (var name in externalReminderNames)
            {
                listBoxConfiguredExternalReminders.Items.Add(name);
            }
        }
        private async void buttonImportExternal_Click(object sender, EventArgs e)
        {
            var imported = await AppDataStore.ImportExternalReminders();
            foreach (var reminder in imported)
            {
                AddReminderToListView(reminder);
            }

            MessageBox.Show(imported.Count+" reminders imported.", "Import Complete");
        }
    }
}
