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
    public partial class ReportForm : Form
    {
        bool inEditMode = false;
        ReportIF createdReport;
        ReportIF reportToEdit;  
        public ReportForm(ReportIF reportToEdit=null)
        {
            this.reportToEdit = reportToEdit;
            InitializeComponent();
            comboBoxReportString.Items.Clear();
            comboBoxReportString.Items.Add("BasicReport");
            comboBoxReportString.Items.Add("CompositeReport");
            comboBoxReportString.SelectedIndex = 0;

            comboBoxReportRepeatString.Items.AddRange(Enum.GetNames(typeof(RepeatString)));
            comboBoxReportRepeatString.SelectedItem = comboBoxReportRepeatString.Items[0];

            var notifiers = NotifierFactory.GetConfiguredNotifierNames();
            checkedListBoxReportNotifierStrings.Items.Clear();
            foreach (var notifier in notifiers)
            {
                checkedListBoxReportNotifierStrings.Items.Add(notifier);
            }
            groupBoxReportRepeatSettings.Enabled = false;
            groupBoxReportComponents.Enabled = false;
            checkedListBoxReportInfoSources.Enabled = true;
            checkedListBoxReportComponents.Items.Clear();

            PopulateComponentReportList();
            PopulateInfoSourceList();
            if (this.reportToEdit != null)
            {
                LoadReportData(this.reportToEdit);
            }
        }
        public ReportIF GetReport()
        {
            return createdReport;
        }
        private void PopulateComponentReportList()
        {
            checkedListBoxReportComponents.Items.Clear();
            foreach (var Report in AppDataStore.GetReports())
            {
                if (reportToEdit == null || Report.GetID() != reportToEdit.GetID())
                {
                    checkedListBoxReportComponents.Items.Add(Report);
                }
            }
        }
        private void PopulateInfoSourceList()
        {
            checkedListBoxReportInfoSources.Items.Clear();
            var pluginNames = InformationCollectorFactory.GetConfiguredPluginNames();
            foreach (var name in InformationCollectorFactory.GetConfiguredPluginNames())
            {
                var plugin = InformationCollectorFactory.CreatePlugin(name);
                checkedListBoxReportInfoSources.Items.Add(plugin);
            }
        }
        private void LoadReportData(ReportIF ReportToEdit)
        {
            inEditMode = true;
            textBoxReportTitle.Text = ReportToEdit.GetTitle();
            textBoxReportDescription.Text = ReportToEdit.GetContent();
            dateTimePickerReportTime.Value = ReportToEdit.GetTime();
            foreach (var item in comboBoxReportString.Items)
            {
                if (item.ToString() == ReportToEdit.GetType().Name)
                {
                    //Console.WriteLine(item.ToString() + " == " + ReportToEdit.GetString().Name);
                    comboBoxReportString.SelectedItem = item;
                    comboBoxReportString.SelectedIndex = comboBoxReportString.Items.IndexOf(item);
                    break;
                }
            }
            checkBoxReportRepeat.Checked = ReportToEdit.GetSchedule() != null;
            if (ReportToEdit.GetSchedule() != null)
            {
                groupBoxReportRepeatSettings.Enabled = true;
                var schedule = ReportToEdit.GetSchedule();
                checkBoxReportRepeat.Checked = true;
                comboBoxReportRepeatString.SelectedItem = schedule.GetRepeatString().ToString();
                if (schedule.GetStartDate() == null)
                {
                    dateTimePickerReportStartDate.Value = DateTime.Now;
                }
                else
                {
                    dateTimePickerReportStartDate.Value = (DateTime)schedule.GetStartDate();
                }
                if (schedule.GetEndDate() == null)
                {
                    dateTimePickerReportEndDate.Value = DateTime.Now;
                }
                else
                {
                    dateTimePickerReportEndDate.Value = (DateTime)schedule.GetEndDate();
                }
                foreach (var day in schedule.GetDaysOfWeek())
                {
                    for (int i = 0; i < checkedListBoxReportRepeatDays.Items.Count; i++)
                    {
                        if (checkedListBoxReportRepeatDays.Items[i].ToString() == day.ToString())
                            checkedListBoxReportRepeatDays.SetItemChecked(i, true);
                    }
                }
            }
            for (int i = 0; i < checkedListBoxReportNotifierStrings.Items.Count; i++)
            {
                checkedListBoxReportNotifierStrings.SetItemChecked(i, false);
            }

            foreach (NotifierIF notifier in ReportToEdit.GetNotifiers())
            {
                string notifierName = notifier.GetName();

                for (int i = 0; i < checkedListBoxReportNotifierStrings.Items.Count; i++)
                {
                    if (checkedListBoxReportNotifierStrings.Items[i].ToString() == notifierName)
                    {
                        checkedListBoxReportNotifierStrings.SetItemChecked(i, true);
                    }
                }
            }
            if (ReportToEdit is CompositeReport)
            {
                groupBoxReportComponents.Enabled = true;

                foreach (ReportIF item in ReportToEdit.ToReportList())
                {
                    for (int i = 0; i < checkedListBoxReportComponents.Items.Count; i++)
                    {
                        if (checkedListBoxReportComponents.Items[i] is ReportIF)
                        {
                            ReportIF castedItem = (ReportIF)checkedListBoxReportComponents.Items[i];
                            if (castedItem.GetID() == item.GetID())
                            {
                                checkedListBoxReportComponents.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
            else
            {
                groupBoxReportComponents.Enabled = false;
            }
            foreach (var infoCollector in ReportToEdit.GetPlugins())
            {
                for (int i = 0; i < checkedListBoxReportInfoSources.Items.Count; i++)
                {
                    var item = checkedListBoxReportInfoSources.Items[i];
                    if (item is InformationCollectorIF plugin)
                    {
                        if (plugin.GetName() == infoCollector.GetName())
                        {
                            checkedListBoxReportInfoSources.SetItemChecked(i, true);
                            var savedRequiredParams = infoCollector.GetRunTimeRequiredParameters();
                            var savedOptionalParams = infoCollector.GetRunTimeOptionalParameters();
                            plugin.SetRunTimeParameters(savedRequiredParams,savedOptionalParams);
                        }
                    }
                }
            }
            inEditMode = false;
        }

        private void buttonSaveReport_Click(object sender, EventArgs e)
        {
            try
            {
                createdReport = GenerateReportFromInputs();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private ReportIF GenerateReportFromInputs()
        {
            string title = textBoxReportTitle.Text.Trim();
            string description = textBoxReportDescription.Text.Trim();
            DateTime triggerTime = dateTimePickerReportTime.Value;
            String SelectedType = comboBoxReportString.SelectedItem as string;
            RepeatSchedule schedule = GenerateRepeatScheduleFromInputs();

            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Report title is required.");
            if (SelectedType == null)
                throw new Exception("Please select a report String.");

            List<ReportIF> subReports = new List<ReportIF>();
            if(SelectedType == "CompositeReport")
            {
                foreach (var item in checkedListBoxReportComponents.CheckedItems)
                {
                    if (item is ReportIF r)
                        subReports.Add(r);
                }
            }


            List<InformationCollectorIF> sources = new List<InformationCollectorIF>();
            foreach (var item in checkedListBoxReportInfoSources.CheckedItems)
            {
                if (item is InformationCollectorIF plugin)
                {
                    sources.Add(plugin);
                }
            }
            Console.WriteLine("New date time: "+triggerTime);
            createdReport = ReportFactory.CreateReport(SelectedType, title, description, triggerTime, schedule, subReports, sources);
            foreach (var item in checkedListBoxReportNotifierStrings.CheckedItems)
            {
                string notifierName = item.ToString();
                var notifier = NotifierFactory.CreateNotifier(notifierName);
                createdReport.AddNotifier(notifier);
            }
            return createdReport;
        }

        private RepeatSchedule GenerateRepeatScheduleFromInputs()
        {
            if (!checkBoxReportRepeat.Checked)
            {
                return new RepeatSchedule(
                    RepeatString.None,
                    TimeSpan.Zero,
                    new List<DayOfWeek>(),
                    null,
                    null
                );
            }

            RepeatString repeatString;
            if (!Enum.TryParse(comboBoxReportRepeatString.SelectedItem?.ToString(), out repeatString))
            {
                MessageBox.Show("Invalid repeat String selected.");
                return new RepeatSchedule(
                    RepeatString.None,
                    TimeSpan.Zero,
                    new List<DayOfWeek>(),
                    null,
                    null
                );
            }

            TimeSpan timeOfDay = dateTimePickerReportTime.Value.TimeOfDay;

            List<DayOfWeek> selectedDays = new List<DayOfWeek>();
            foreach (object item in checkedListBoxReportRepeatDays.CheckedItems)
            {
                if (Enum.TryParse(item.ToString(), out DayOfWeek parsedDay))
                {
                    selectedDays.Add(parsedDay);
                }
            }

            DateTime? startDate = dateTimePickerReportStartDate.Value.Date;
            DateTime? endDate = dateTimePickerReportEndDate.Value.Date;

            if (startDate == DateTime.MinValue)
                startDate = null;

            if (endDate == DateTime.MinValue)
                endDate = null;

            return new RepeatSchedule(
                repeatString,
                timeOfDay,
                selectedDays,
                startDate,
                endDate
            );
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
        }



        private void comboBoxReportString_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxReportString.SelectedItem.ToString() == "CompositeReport")
            {
                groupBoxReportComponents.Enabled = true;
            }
            else
            {
                groupBoxReportComponents.Enabled = false;
            }
        }


        private void CancelCheck(int index)
        {
            checkedListBoxReportInfoSources.SetItemChecked(index, false);
        }

        private void checkedListBoxReportInfoSources_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var plugin = checkedListBoxReportInfoSources.Items[e.Index] as ConfigurablePluginIF;

            if (!inEditMode && plugin != null && e.CurrentValue==CheckState.Unchecked && e.NewValue == CheckState.Checked)
            {
                var required = plugin.GetRunTimeRequiredParameters();
                var optional = plugin.GetRunTimeOptionalParameters();

                if (required.Count > 0 || optional.Count > 0)
                {
                    using (var form = new DynamicPluginForm(plugin))
                    {
                        if (form.ShowDialog() != DialogResult.OK)
                        {
                            BeginInvoke(new MethodInvoker(delegate { CancelCheck(e.Index); }));
                        }
                    }
                }
            }
        }

        private void checkBoxReportRepeat_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxReportRepeatSettings.Enabled = checkBoxReportRepeat.Checked;
        }

        private void buttonReportCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
