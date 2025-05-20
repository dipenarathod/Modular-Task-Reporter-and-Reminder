using Aspose.Email.Clients.Google;
using FinalProject.Common;
using FinalProject.Notifier;
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

namespace FinalProject
{
    public partial class ReminderForm : Form
    {
        private ReminderIF createdReminder;
        private ReminderIF reminderToEdit;
        public ReminderForm(ReminderIF reminderToEdit=null)
        {
            this.reminderToEdit = reminderToEdit;
            InitializeComponent();
            comboBoxReminderString.Items.Clear();
            comboBoxReminderString.Items.Add("BasicReminder");
            comboBoxReminderString.Items.Add("CompositeReminder");
            comboBoxReminderString.SelectedIndex = 0;

            comboBoxReminderRepeatString.Items.AddRange(Enum.GetNames(typeof(RepeatString)));
            comboBoxReminderRepeatString.SelectedItem = comboBoxReminderRepeatString.Items[0];

            var notifiers = NotifierFactory.GetConfiguredNotifierNames();
            checkedListBoxReminderNotifierStrings.Items.Clear();
            foreach (var notifier in notifiers)
            {
                checkedListBoxReminderNotifierStrings.Items.Add(notifier);
            }
            groupBoxReminderRepeatSettings.Enabled = false;
            groupBoxReminderComponents.Enabled = false;

            checkedListBoxReminderComponents.Items.Clear();

            PopulateComponentReminderList();

            if (reminderToEdit != null)
            {
                LoadReminderData(reminderToEdit);
            }
        }

        private void LoadReminderData(ReminderIF reminderToEdit)
        {
            textBoxReminderTitle.Text = reminderToEdit.GetTitle();
            textBoxReminderDescription.Text = reminderToEdit.GetContent();
            dateTimePickerReminderTime.Value = reminderToEdit.GetTime();
            foreach (var item in comboBoxReminderString.Items)
            {
                if (item.ToString() == reminderToEdit.GetType().Name)
                {
                    //Console.WriteLine(item.ToString() + " == " + reminderToEdit.GetString().Name);
                    comboBoxReminderString.SelectedItem = item;
                    comboBoxReminderString.SelectedIndex = comboBoxReminderString.Items.IndexOf(item);
                    break;
                }
            }
            checkBoxReminderRepeat.Checked = reminderToEdit.GetSchedule() != null;
            if (reminderToEdit.GetSchedule() != null)
            {
                groupBoxReminderRepeatSettings.Enabled = true;
                var schedule = reminderToEdit.GetSchedule();
                checkBoxReminderRepeat.Checked = true;
                comboBoxReminderRepeatString.SelectedItem = schedule.GetRepeatString().ToString();
                if (schedule.GetStartDate() == null)
                {
                    dateTimePickerReminderStartDate.Value = DateTime.Now;
                }
                else
                {
                    dateTimePickerReminderStartDate.Value = (DateTime)schedule.GetStartDate();
                }
                if (schedule.GetEndDate() == null)
                {
                    dateTimePickerReminderEndDate.Value = DateTime.Now;
                }
                else
                {
                    dateTimePickerReminderEndDate.Value = (DateTime)schedule.GetEndDate();
                }
                foreach (var day in schedule.GetDaysOfWeek())
                {
                    for (int i = 0; i < checkedListBoxReminderRepeatDays.Items.Count; i++)
                    {
                        if (checkedListBoxReminderRepeatDays.Items[i].ToString() == day.ToString())
                            checkedListBoxReminderRepeatDays.SetItemChecked(i, true);
                    }
                }
            }
            for (int i = 0; i < checkedListBoxReminderNotifierStrings.Items.Count; i++)
            {
                checkedListBoxReminderNotifierStrings.SetItemChecked(i, false);
            }

            foreach (NotifierIF notifier in reminderToEdit.GetNotifiers())
            {
                string notifierName = notifier.GetName();

                for (int i = 0; i < checkedListBoxReminderNotifierStrings.Items.Count; i++)
                {
                    if (checkedListBoxReminderNotifierStrings.Items[i].ToString() == notifierName)
                    {
                        checkedListBoxReminderNotifierStrings.SetItemChecked(i, true);
                    }
                }
            }
            if (reminderToEdit is CompositeReminder)
            {
                groupBoxReminderComponents.Enabled = true;

                foreach (ReminderIF item in reminderToEdit.ToReminderList())
                {
                    for (int i = 0; i < checkedListBoxReminderComponents.Items.Count; i++)
                    {
                        if (checkedListBoxReminderComponents.Items[i] is ReminderIF)
                        {
                            ReminderIF castedItem = (ReminderIF)checkedListBoxReminderComponents.Items[i];
                            if(castedItem.GetID()==item.GetID()){
                                checkedListBoxReminderComponents.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
            else
            {
                groupBoxReminderComponents.Enabled = false;
            }
        }

        public ReminderIF GetReminder()
        {
            return createdReminder;
        }

        private void buttonSaveReminder_Click(object sender, EventArgs e)
        {
            try
            {
                createdReminder = GenerateReminderFromInputs();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ReminderForm_Load(object sender, EventArgs e)
        {
        }
        private void PopulateComponentReminderList()
        {
            checkedListBoxReminderComponents.Items.Clear();
            foreach (var reminder in AppDataStore.GetReminders())
            {
                if (reminderToEdit==null || reminder.GetID()!=reminderToEdit.GetID())
                {
                    checkedListBoxReminderComponents.Items.Add(reminder);
                }
            }
        }
        private void comboBoxReminderString_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxReminderString.SelectedItem.ToString() == "CompositeReminder")
            {
                groupBoxReminderComponents.Enabled = true;
            }
            else
            {
                groupBoxReminderComponents.Enabled = false;
            }
        }
        private RepeatSchedule GenerateRepeatScheduleFromInputs()
        {
            if (!checkBoxReminderRepeat.Checked)
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
            if (!Enum.TryParse(comboBoxReminderRepeatString.SelectedItem?.ToString(), out repeatString))
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

            TimeSpan timeOfDay = dateTimePickerReminderTime.Value.TimeOfDay;

            List<DayOfWeek> selectedDays = new List<DayOfWeek>();
            foreach (object item in checkedListBoxReminderRepeatDays.CheckedItems)
            {
                if (Enum.TryParse(item.ToString(), out DayOfWeek parsedDay))
                {
                    selectedDays.Add(parsedDay);
                }
            }

            DateTime? startDate = dateTimePickerReminderStartDate.Value.Date;
            DateTime? endDate = dateTimePickerReminderEndDate.Value.Date;

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

        private void checkBoxReminderRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReminderRepeat.Checked)
            {
                groupBoxReminderRepeatSettings.Enabled = true;
            }
            else
            {
                groupBoxReminderRepeatSettings.Enabled = false;
            }
        }

        private ReminderIF GenerateReminderFromInputs()
        {
            string title = textBoxReminderTitle.Text.Trim();
            string description = textBoxReminderDescription.Text.Trim();
            DateTime triggerTime = dateTimePickerReminderTime.Value;
            String SelectedType = comboBoxReminderString.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Reminder title is required.");

            RepeatSchedule schedule = GenerateRepeatScheduleFromInputs();

            List<ReminderIF> subReminders = new List<ReminderIF>();
            if (comboBoxReminderString.SelectedItem.ToString() == "CompositeReminder")
            {
                foreach (var item in checkedListBoxReminderComponents.CheckedItems)
                {
                    if (item is ReminderIF)
                        subReminders.Add((ReminderIF)item);
                    Console.WriteLine("Adding subreminder: " + item.ToString());
                }
            }

            var reminder = ReminderFactory.CreateReminder(SelectedType, title, description, triggerTime, schedule, subReminders);

            foreach (var item in checkedListBoxReminderNotifierStrings.CheckedItems)
            {
                string notifierName = item.ToString();
                var notifier = NotifierFactory.CreateNotifier(notifierName);
                reminder.AddNotifier(notifier);
            }

            return reminder;
        }

        private void buttonCancelReminder_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
