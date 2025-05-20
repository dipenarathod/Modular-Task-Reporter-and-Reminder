namespace FinalProject
{
    partial class ReportForm
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
            this.buttonReportCancel = new System.Windows.Forms.Button();
            this.buttonSaveReport = new System.Windows.Forms.Button();
            this.groupBoxReportRepeatSettings = new System.Windows.Forms.GroupBox();
            this.dateTimePickerReportEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerReportStartDate = new System.Windows.Forms.DateTimePicker();
            this.checkedListBoxReportRepeatDays = new System.Windows.Forms.CheckedListBox();
            this.comboBoxReportRepeatString = new System.Windows.Forms.ComboBox();
            this.checkBoxReportRepeat = new System.Windows.Forms.CheckBox();
            this.dateTimePickerReportTime = new System.Windows.Forms.DateTimePicker();
            this.textBoxReportDescription = new System.Windows.Forms.TextBox();
            this.textBoxReportTitle = new System.Windows.Forms.TextBox();
            this.checkedListBoxReportInfoSources = new System.Windows.Forms.CheckedListBox();
            this.groupBoxReportComponents = new System.Windows.Forms.GroupBox();
            this.checkedListBoxReportComponents = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxReportNotifierStrings = new System.Windows.Forms.CheckedListBox();
            this.comboBoxReportString = new System.Windows.Forms.ComboBox();
            this.groupBoxReportRepeatSettings.SuspendLayout();
            this.groupBoxReportComponents.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReportCancel
            // 
            this.buttonReportCancel.Location = new System.Drawing.Point(147, 380);
            this.buttonReportCancel.Name = "buttonReportCancel";
            this.buttonReportCancel.Size = new System.Drawing.Size(151, 69);
            this.buttonReportCancel.TabIndex = 21;
            this.buttonReportCancel.Text = "Cancel";
            this.buttonReportCancel.UseVisualStyleBackColor = true;
            this.buttonReportCancel.Click += new System.EventHandler(this.buttonReportCancel_Click);
            // 
            // buttonSaveReport
            // 
            this.buttonSaveReport.Location = new System.Drawing.Point(3, 380);
            this.buttonSaveReport.Name = "buttonSaveReport";
            this.buttonSaveReport.Size = new System.Drawing.Size(138, 69);
            this.buttonSaveReport.TabIndex = 20;
            this.buttonSaveReport.Text = "Save";
            this.buttonSaveReport.UseVisualStyleBackColor = true;
            this.buttonSaveReport.Click += new System.EventHandler(this.buttonSaveReport_Click);
            // 
            // groupBoxReportRepeatSettings
            // 
            this.groupBoxReportRepeatSettings.Controls.Add(this.dateTimePickerReportEndDate);
            this.groupBoxReportRepeatSettings.Controls.Add(this.dateTimePickerReportStartDate);
            this.groupBoxReportRepeatSettings.Controls.Add(this.checkedListBoxReportRepeatDays);
            this.groupBoxReportRepeatSettings.Controls.Add(this.comboBoxReportRepeatString);
            this.groupBoxReportRepeatSettings.Location = new System.Drawing.Point(304, 24);
            this.groupBoxReportRepeatSettings.Name = "groupBoxReportRepeatSettings";
            this.groupBoxReportRepeatSettings.Size = new System.Drawing.Size(214, 211);
            this.groupBoxReportRepeatSettings.TabIndex = 16;
            this.groupBoxReportRepeatSettings.TabStop = false;
            this.groupBoxReportRepeatSettings.Text = "Repeat Settings";
            // 
            // dateTimePickerReportEndDate
            // 
            this.dateTimePickerReportEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerReportEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReportEndDate.Location = new System.Drawing.Point(7, 188);
            this.dateTimePickerReportEndDate.Name = "dateTimePickerReportEndDate";
            this.dateTimePickerReportEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerReportEndDate.TabIndex = 3;
            // 
            // dateTimePickerReportStartDate
            // 
            this.dateTimePickerReportStartDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerReportStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReportStartDate.Location = new System.Drawing.Point(7, 163);
            this.dateTimePickerReportStartDate.Name = "dateTimePickerReportStartDate";
            this.dateTimePickerReportStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerReportStartDate.TabIndex = 2;
            // 
            // checkedListBoxReportRepeatDays
            // 
            this.checkedListBoxReportRepeatDays.FormattingEnabled = true;
            this.checkedListBoxReportRepeatDays.Items.AddRange(new object[] {
            "M",
            "T",
            "W",
            "TR",
            "F",
            "S",
            "SU"});
            this.checkedListBoxReportRepeatDays.Location = new System.Drawing.Point(7, 48);
            this.checkedListBoxReportRepeatDays.Name = "checkedListBoxReportRepeatDays";
            this.checkedListBoxReportRepeatDays.Size = new System.Drawing.Size(200, 109);
            this.checkedListBoxReportRepeatDays.TabIndex = 1;
            // 
            // comboBoxReportRepeatString
            // 
            this.comboBoxReportRepeatString.FormattingEnabled = true;
            this.comboBoxReportRepeatString.Location = new System.Drawing.Point(7, 20);
            this.comboBoxReportRepeatString.Name = "comboBoxReportRepeatString";
            this.comboBoxReportRepeatString.Size = new System.Drawing.Size(121, 21);
            this.comboBoxReportRepeatString.TabIndex = 0;
            // 
            // checkBoxReportRepeat
            // 
            this.checkBoxReportRepeat.AutoSize = true;
            this.checkBoxReportRepeat.Location = new System.Drawing.Point(304, 3);
            this.checkBoxReportRepeat.Name = "checkBoxReportRepeat";
            this.checkBoxReportRepeat.Size = new System.Drawing.Size(67, 17);
            this.checkBoxReportRepeat.TabIndex = 15;
            this.checkBoxReportRepeat.Text = "Repeat?";
            this.checkBoxReportRepeat.UseVisualStyleBackColor = true;
            this.checkBoxReportRepeat.CheckedChanged += new System.EventHandler(this.checkBoxReportRepeat_CheckedChanged);
            // 
            // dateTimePickerReportTime
            // 
            this.dateTimePickerReportTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerReportTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReportTime.Location = new System.Drawing.Point(3, 167);
            this.dateTimePickerReportTime.Name = "dateTimePickerReportTime";
            this.dateTimePickerReportTime.Size = new System.Drawing.Size(295, 20);
            this.dateTimePickerReportTime.TabIndex = 13;
            // 
            // textBoxReportDescription
            // 
            this.textBoxReportDescription.Location = new System.Drawing.Point(3, 31);
            this.textBoxReportDescription.Multiline = true;
            this.textBoxReportDescription.Name = "textBoxReportDescription";
            this.textBoxReportDescription.Size = new System.Drawing.Size(295, 130);
            this.textBoxReportDescription.TabIndex = 12;
            // 
            // textBoxReportTitle
            // 
            this.textBoxReportTitle.Location = new System.Drawing.Point(3, 4);
            this.textBoxReportTitle.Name = "textBoxReportTitle";
            this.textBoxReportTitle.Size = new System.Drawing.Size(295, 20);
            this.textBoxReportTitle.TabIndex = 11;
            // 
            // checkedListBoxReportInfoSources
            // 
            this.checkedListBoxReportInfoSources.FormattingEnabled = true;
            this.checkedListBoxReportInfoSources.Location = new System.Drawing.Point(304, 241);
            this.checkedListBoxReportInfoSources.Name = "checkedListBoxReportInfoSources";
            this.checkedListBoxReportInfoSources.Size = new System.Drawing.Size(207, 94);
            this.checkedListBoxReportInfoSources.TabIndex = 22;
            this.checkedListBoxReportInfoSources.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxReportInfoSources_ItemCheck);
            // 
            // groupBoxReportComponents
            // 
            this.groupBoxReportComponents.Controls.Add(this.checkedListBoxReportComponents);
            this.groupBoxReportComponents.Location = new System.Drawing.Point(304, 335);
            this.groupBoxReportComponents.Name = "groupBoxReportComponents";
            this.groupBoxReportComponents.Size = new System.Drawing.Size(216, 116);
            this.groupBoxReportComponents.TabIndex = 25;
            this.groupBoxReportComponents.TabStop = false;
            this.groupBoxReportComponents.Text = "Report Components";
            // 
            // checkedListBoxReportComponents
            // 
            this.checkedListBoxReportComponents.FormattingEnabled = true;
            this.checkedListBoxReportComponents.Location = new System.Drawing.Point(1, 20);
            this.checkedListBoxReportComponents.Name = "checkedListBoxReportComponents";
            this.checkedListBoxReportComponents.Size = new System.Drawing.Size(206, 79);
            this.checkedListBoxReportComponents.TabIndex = 0;
            // 
            // checkedListBoxReportNotifierStrings
            // 
            this.checkedListBoxReportNotifierStrings.FormattingEnabled = true;
            this.checkedListBoxReportNotifierStrings.Location = new System.Drawing.Point(3, 221);
            this.checkedListBoxReportNotifierStrings.Name = "checkedListBoxReportNotifierStrings";
            this.checkedListBoxReportNotifierStrings.Size = new System.Drawing.Size(295, 154);
            this.checkedListBoxReportNotifierStrings.TabIndex = 29;
            // 
            // comboBoxReportString
            // 
            this.comboBoxReportString.FormattingEnabled = true;
            this.comboBoxReportString.Items.AddRange(new object[] {
            "Basic",
            "Composite"});
            this.comboBoxReportString.Location = new System.Drawing.Point(2, 194);
            this.comboBoxReportString.Name = "comboBoxReportString";
            this.comboBoxReportString.Size = new System.Drawing.Size(296, 21);
            this.comboBoxReportString.TabIndex = 14;
            this.comboBoxReportString.SelectedIndexChanged += new System.EventHandler(this.comboBoxReportString_SelectedIndexChanged);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 467);
            this.Controls.Add(this.checkedListBoxReportNotifierStrings);
            this.Controls.Add(this.groupBoxReportComponents);
            this.Controls.Add(this.checkedListBoxReportInfoSources);
            this.Controls.Add(this.buttonReportCancel);
            this.Controls.Add(this.buttonSaveReport);
            this.Controls.Add(this.groupBoxReportRepeatSettings);
            this.Controls.Add(this.checkBoxReportRepeat);
            this.Controls.Add(this.comboBoxReportString);
            this.Controls.Add(this.dateTimePickerReportTime);
            this.Controls.Add(this.textBoxReportDescription);
            this.Controls.Add(this.textBoxReportTitle);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.groupBoxReportRepeatSettings.ResumeLayout(false);
            this.groupBoxReportComponents.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReportCancel;
        private System.Windows.Forms.Button buttonSaveReport;
        private System.Windows.Forms.GroupBox groupBoxReportRepeatSettings;
        private System.Windows.Forms.DateTimePicker dateTimePickerReportStartDate;
        private System.Windows.Forms.CheckedListBox checkedListBoxReportRepeatDays;
        private System.Windows.Forms.ComboBox comboBoxReportRepeatString;
        private System.Windows.Forms.CheckBox checkBoxReportRepeat;
        private System.Windows.Forms.DateTimePicker dateTimePickerReportTime;
        private System.Windows.Forms.TextBox textBoxReportDescription;
        private System.Windows.Forms.TextBox textBoxReportTitle;
        private System.Windows.Forms.CheckedListBox checkedListBoxReportInfoSources;
        private System.Windows.Forms.GroupBox groupBoxReportComponents;
        private System.Windows.Forms.DateTimePicker dateTimePickerReportEndDate;
        private System.Windows.Forms.CheckedListBox checkedListBoxReportNotifierStrings;
        private System.Windows.Forms.ComboBox comboBoxReportString;
        private System.Windows.Forms.CheckedListBox checkedListBoxReportComponents;
    }
}