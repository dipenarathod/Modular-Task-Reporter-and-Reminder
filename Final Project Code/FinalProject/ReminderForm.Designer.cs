namespace FinalProject
{
    partial class ReminderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxReminderTitle = new System.Windows.Forms.TextBox();
            this.textBoxReminderDescription = new System.Windows.Forms.TextBox();
            this.dateTimePickerReminderTime = new System.Windows.Forms.DateTimePicker();
            this.comboBoxReminderString = new System.Windows.Forms.ComboBox();
            this.checkBoxReminderRepeat = new System.Windows.Forms.CheckBox();
            this.groupBoxReminderRepeatSettings = new System.Windows.Forms.GroupBox();
            this.dateTimePickerReminderEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerReminderStartDate = new System.Windows.Forms.DateTimePicker();
            this.checkedListBoxReminderRepeatDays = new System.Windows.Forms.CheckedListBox();
            this.comboBoxReminderRepeatString = new System.Windows.Forms.ComboBox();
            this.buttonSaveReminder = new System.Windows.Forms.Button();
            this.buttonCancelReminder = new System.Windows.Forms.Button();
            this.groupBoxReminderComponents = new System.Windows.Forms.GroupBox();
            this.checkedListBoxReminderComponents = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxReminderNotifierStrings = new System.Windows.Forms.CheckedListBox();
            this.groupBoxReminderRepeatSettings.SuspendLayout();
            this.groupBoxReminderComponents.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxReminderTitle
            // 
            this.textBoxReminderTitle.Location = new System.Drawing.Point(13, 13);
            this.textBoxReminderTitle.Name = "textBoxReminderTitle";
            this.textBoxReminderTitle.Size = new System.Drawing.Size(295, 20);
            this.textBoxReminderTitle.TabIndex = 0;
            // 
            // textBoxReminderDescription
            // 
            this.textBoxReminderDescription.Location = new System.Drawing.Point(13, 40);
            this.textBoxReminderDescription.Multiline = true;
            this.textBoxReminderDescription.Name = "textBoxReminderDescription";
            this.textBoxReminderDescription.Size = new System.Drawing.Size(295, 130);
            this.textBoxReminderDescription.TabIndex = 1;
            // 
            // dateTimePickerReminderTime
            // 
            this.dateTimePickerReminderTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerReminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReminderTime.Location = new System.Drawing.Point(13, 176);
            this.dateTimePickerReminderTime.Name = "dateTimePickerReminderTime";
            this.dateTimePickerReminderTime.ShowUpDown = true;
            this.dateTimePickerReminderTime.Size = new System.Drawing.Size(295, 20);
            this.dateTimePickerReminderTime.TabIndex = 2;
            // 
            // comboBoxReminderString
            // 
            this.comboBoxReminderString.FormattingEnabled = true;
            this.comboBoxReminderString.Items.AddRange(new object[] {
            "Basic",
            "Composite"});
            this.comboBoxReminderString.Location = new System.Drawing.Point(12, 203);
            this.comboBoxReminderString.Name = "comboBoxReminderString";
            this.comboBoxReminderString.Size = new System.Drawing.Size(296, 21);
            this.comboBoxReminderString.TabIndex = 3;
            this.comboBoxReminderString.SelectedIndexChanged += new System.EventHandler(this.comboBoxReminderString_SelectedIndexChanged);
            // 
            // checkBoxReminderRepeat
            // 
            this.checkBoxReminderRepeat.AutoSize = true;
            this.checkBoxReminderRepeat.Location = new System.Drawing.Point(314, 12);
            this.checkBoxReminderRepeat.Name = "checkBoxReminderRepeat";
            this.checkBoxReminderRepeat.Size = new System.Drawing.Size(67, 17);
            this.checkBoxReminderRepeat.TabIndex = 4;
            this.checkBoxReminderRepeat.Text = "Repeat?";
            this.checkBoxReminderRepeat.UseVisualStyleBackColor = true;
            this.checkBoxReminderRepeat.CheckedChanged += new System.EventHandler(this.checkBoxReminderRepeat_CheckedChanged);
            // 
            // groupBoxReminderRepeatSettings
            // 
            this.groupBoxReminderRepeatSettings.Controls.Add(this.dateTimePickerReminderEndDate);
            this.groupBoxReminderRepeatSettings.Controls.Add(this.dateTimePickerReminderStartDate);
            this.groupBoxReminderRepeatSettings.Controls.Add(this.checkedListBoxReminderRepeatDays);
            this.groupBoxReminderRepeatSettings.Controls.Add(this.comboBoxReminderRepeatString);
            this.groupBoxReminderRepeatSettings.Location = new System.Drawing.Point(314, 40);
            this.groupBoxReminderRepeatSettings.Name = "groupBoxReminderRepeatSettings";
            this.groupBoxReminderRepeatSettings.Size = new System.Drawing.Size(214, 210);
            this.groupBoxReminderRepeatSettings.TabIndex = 5;
            this.groupBoxReminderRepeatSettings.TabStop = false;
            this.groupBoxReminderRepeatSettings.Text = "Repeat Settings";
            // 
            // dateTimePickerReminderEndDate
            // 
            this.dateTimePickerReminderEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerReminderEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReminderEndDate.Location = new System.Drawing.Point(6, 184);
            this.dateTimePickerReminderEndDate.Name = "dateTimePickerReminderEndDate";
            this.dateTimePickerReminderEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerReminderEndDate.TabIndex = 3;
            // 
            // dateTimePickerReminderStartDate
            // 
            this.dateTimePickerReminderStartDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerReminderStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReminderStartDate.Location = new System.Drawing.Point(7, 163);
            this.dateTimePickerReminderStartDate.Name = "dateTimePickerReminderStartDate";
            this.dateTimePickerReminderStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerReminderStartDate.TabIndex = 2;
            // 
            // checkedListBoxReminderRepeatDays
            // 
            this.checkedListBoxReminderRepeatDays.FormattingEnabled = true;
            this.checkedListBoxReminderRepeatDays.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.checkedListBoxReminderRepeatDays.Location = new System.Drawing.Point(7, 48);
            this.checkedListBoxReminderRepeatDays.Name = "checkedListBoxReminderRepeatDays";
            this.checkedListBoxReminderRepeatDays.Size = new System.Drawing.Size(200, 109);
            this.checkedListBoxReminderRepeatDays.TabIndex = 1;
            // 
            // comboBoxReminderRepeatString
            // 
            this.comboBoxReminderRepeatString.FormattingEnabled = true;
            this.comboBoxReminderRepeatString.Location = new System.Drawing.Point(7, 20);
            this.comboBoxReminderRepeatString.Name = "comboBoxReminderRepeatString";
            this.comboBoxReminderRepeatString.Size = new System.Drawing.Size(121, 21);
            this.comboBoxReminderRepeatString.TabIndex = 0;
            // 
            // buttonSaveReminder
            // 
            this.buttonSaveReminder.Location = new System.Drawing.Point(12, 412);
            this.buttonSaveReminder.Name = "buttonSaveReminder";
            this.buttonSaveReminder.Size = new System.Drawing.Size(150, 52);
            this.buttonSaveReminder.TabIndex = 9;
            this.buttonSaveReminder.Text = "Save";
            this.buttonSaveReminder.UseVisualStyleBackColor = true;
            this.buttonSaveReminder.Click += new System.EventHandler(this.buttonSaveReminder_Click);
            // 
            // buttonCancelReminder
            // 
            this.buttonCancelReminder.Location = new System.Drawing.Point(168, 412);
            this.buttonCancelReminder.Name = "buttonCancelReminder";
            this.buttonCancelReminder.Size = new System.Drawing.Size(139, 52);
            this.buttonCancelReminder.TabIndex = 10;
            this.buttonCancelReminder.Text = "Cancel";
            this.buttonCancelReminder.UseVisualStyleBackColor = true;
            this.buttonCancelReminder.Click += new System.EventHandler(this.buttonCancelReminder_Click);
            // 
            // groupBoxReminderComponents
            // 
            this.groupBoxReminderComponents.Controls.Add(this.checkedListBoxReminderComponents);
            this.groupBoxReminderComponents.Location = new System.Drawing.Point(314, 256);
            this.groupBoxReminderComponents.Name = "groupBoxReminderComponents";
            this.groupBoxReminderComponents.Size = new System.Drawing.Size(216, 208);
            this.groupBoxReminderComponents.TabIndex = 26;
            this.groupBoxReminderComponents.TabStop = false;
            this.groupBoxReminderComponents.Text = "Reminder Components";
            // 
            // checkedListBoxReminderComponents
            // 
            this.checkedListBoxReminderComponents.FormattingEnabled = true;
            this.checkedListBoxReminderComponents.Location = new System.Drawing.Point(6, 19);
            this.checkedListBoxReminderComponents.Name = "checkedListBoxReminderComponents";
            this.checkedListBoxReminderComponents.Size = new System.Drawing.Size(200, 184);
            this.checkedListBoxReminderComponents.TabIndex = 26;
            // 
            // checkedListBoxReminderNotifierStrings
            // 
            this.checkedListBoxReminderNotifierStrings.FormattingEnabled = true;
            this.checkedListBoxReminderNotifierStrings.Location = new System.Drawing.Point(12, 240);
            this.checkedListBoxReminderNotifierStrings.Name = "checkedListBoxReminderNotifierStrings";
            this.checkedListBoxReminderNotifierStrings.Size = new System.Drawing.Size(295, 169);
            this.checkedListBoxReminderNotifierStrings.TabIndex = 28;
            // 
            // ReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 485);
            this.Controls.Add(this.checkedListBoxReminderNotifierStrings);
            this.Controls.Add(this.groupBoxReminderComponents);
            this.Controls.Add(this.buttonCancelReminder);
            this.Controls.Add(this.buttonSaveReminder);
            this.Controls.Add(this.groupBoxReminderRepeatSettings);
            this.Controls.Add(this.checkBoxReminderRepeat);
            this.Controls.Add(this.comboBoxReminderString);
            this.Controls.Add(this.dateTimePickerReminderTime);
            this.Controls.Add(this.textBoxReminderDescription);
            this.Controls.Add(this.textBoxReminderTitle);
            this.Name = "ReminderForm";
            this.Text = "Reminder Form";
            this.Load += new System.EventHandler(this.ReminderForm_Load);
            this.groupBoxReminderRepeatSettings.ResumeLayout(false);
            this.groupBoxReminderComponents.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxReminderTitle;
        private System.Windows.Forms.TextBox textBoxReminderDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerReminderTime;
        private System.Windows.Forms.ComboBox comboBoxReminderString;
        private System.Windows.Forms.CheckBox checkBoxReminderRepeat;
        private System.Windows.Forms.GroupBox groupBoxReminderRepeatSettings;
        private System.Windows.Forms.ComboBox comboBoxReminderRepeatString;
        private System.Windows.Forms.CheckedListBox checkedListBoxReminderRepeatDays;
        private System.Windows.Forms.DateTimePicker dateTimePickerReminderStartDate;
        private System.Windows.Forms.Button buttonSaveReminder;
        private System.Windows.Forms.Button buttonCancelReminder;
        private System.Windows.Forms.GroupBox groupBoxReminderComponents;
        private System.Windows.Forms.DateTimePicker dateTimePickerReminderEndDate;
        private System.Windows.Forms.CheckedListBox checkedListBoxReminderNotifierStrings;
        private System.Windows.Forms.CheckedListBox checkedListBoxReminderComponents;
    }
}