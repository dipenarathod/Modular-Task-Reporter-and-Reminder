namespace FinalProject
{
    partial class MainForm
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabReminders = new System.Windows.Forms.TabPage();
            this.panelRemiderButtons = new System.Windows.Forms.Panel();
            this.buttonImportExternal = new System.Windows.Forms.Button();
            this.buttonDeleteReminder = new System.Windows.Forms.Button();
            this.buttonEditReminder = new System.Windows.Forms.Button();
            this.buttonAddReminder = new System.Windows.Forms.Button();
            this.listViewReminders = new System.Windows.Forms.ListView();
            this.columnReminderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReminderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReminderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReminderRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReminderString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabReports = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDeleteReport = new System.Windows.Forms.Button();
            this.buttonEditReport = new System.Windows.Forms.Button();
            this.buttonAddReport = new System.Windows.Forms.Button();
            this.listViewReports = new System.Windows.Forms.ListView();
            this.columnReportTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReportDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReportTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReportRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReportString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBoxExternalReminderConfiguration = new System.Windows.Forms.GroupBox();
            this.comboBoxExternalReminderSelect = new System.Windows.Forms.ComboBox();
            this.listBoxConfiguredExternalReminders = new System.Windows.Forms.ListBox();
            this.buttonConfigureExternalReminder = new System.Windows.Forms.Button();
            this.groupBoxInformationCollectorConfiguration = new System.Windows.Forms.GroupBox();
            this.comboBoxInformationCollectorSelect = new System.Windows.Forms.ComboBox();
            this.listBoxConfiguredInformationCollectors = new System.Windows.Forms.ListBox();
            this.buttonConfigureInformationCollector = new System.Windows.Forms.Button();
            this.groupBoxDataManagement = new System.Windows.Forms.GroupBox();
            this.buttonClearData = new System.Windows.Forms.Button();
            this.buttonImportData = new System.Windows.Forms.Button();
            this.buttonExportData = new System.Windows.Forms.Button();
            this.groupBoxNotificationConfiguration = new System.Windows.Forms.GroupBox();
            this.comboBoxNotifierSelect = new System.Windows.Forms.ComboBox();
            this.listBoxConfiguredNotifiers = new System.Windows.Forms.ListBox();
            this.buttonConfigureNotifier = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabReminders.SuspendLayout();
            this.panelRemiderButtons.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBoxExternalReminderConfiguration.SuspendLayout();
            this.groupBoxInformationCollectorConfiguration.SuspendLayout();
            this.groupBoxDataManagement.SuspendLayout();
            this.groupBoxNotificationConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabReminders);
            this.tabControlMain.Controls.Add(this.tabReports);
            this.tabControlMain.Controls.Add(this.tabSettings);
            this.tabControlMain.Location = new System.Drawing.Point(6, 6);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Padding = new System.Drawing.Point(0, 0);
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 460);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabReminders
            // 
            this.tabReminders.Controls.Add(this.panelRemiderButtons);
            this.tabReminders.Controls.Add(this.listViewReminders);
            this.tabReminders.Location = new System.Drawing.Point(4, 22);
            this.tabReminders.Margin = new System.Windows.Forms.Padding(0);
            this.tabReminders.Name = "tabReminders";
            this.tabReminders.Size = new System.Drawing.Size(792, 434);
            this.tabReminders.TabIndex = 0;
            this.tabReminders.Text = "Reminders";
            this.tabReminders.UseVisualStyleBackColor = true;
            // 
            // panelRemiderButtons
            // 
            this.panelRemiderButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRemiderButtons.Controls.Add(this.buttonImportExternal);
            this.panelRemiderButtons.Controls.Add(this.buttonDeleteReminder);
            this.panelRemiderButtons.Controls.Add(this.buttonEditReminder);
            this.panelRemiderButtons.Controls.Add(this.buttonAddReminder);
            this.panelRemiderButtons.Location = new System.Drawing.Point(4, 310);
            this.panelRemiderButtons.Name = "panelRemiderButtons";
            this.panelRemiderButtons.Size = new System.Drawing.Size(785, 121);
            this.panelRemiderButtons.TabIndex = 1;
            // 
            // buttonImportExternal
            // 
            this.buttonImportExternal.Location = new System.Drawing.Point(4, 94);
            this.buttonImportExternal.Name = "buttonImportExternal";
            this.buttonImportExternal.Size = new System.Drawing.Size(94, 23);
            this.buttonImportExternal.TabIndex = 3;
            this.buttonImportExternal.Text = "Import External";
            this.buttonImportExternal.UseVisualStyleBackColor = true;
            this.buttonImportExternal.Click += new System.EventHandler(this.buttonImportExternal_Click);
            // 
            // buttonDeleteReminder
            // 
            this.buttonDeleteReminder.Location = new System.Drawing.Point(4, 64);
            this.buttonDeleteReminder.Name = "buttonDeleteReminder";
            this.buttonDeleteReminder.Size = new System.Drawing.Size(94, 23);
            this.buttonDeleteReminder.TabIndex = 2;
            this.buttonDeleteReminder.Text = "Delete Reminder";
            this.buttonDeleteReminder.UseVisualStyleBackColor = true;
            this.buttonDeleteReminder.Click += new System.EventHandler(this.buttonDeleteReminder_Click);
            // 
            // buttonEditReminder
            // 
            this.buttonEditReminder.Location = new System.Drawing.Point(4, 34);
            this.buttonEditReminder.Name = "buttonEditReminder";
            this.buttonEditReminder.Size = new System.Drawing.Size(94, 23);
            this.buttonEditReminder.TabIndex = 1;
            this.buttonEditReminder.Text = "Edit Reminder";
            this.buttonEditReminder.UseVisualStyleBackColor = true;
            this.buttonEditReminder.Click += new System.EventHandler(this.buttonEditReminder_Click);
            // 
            // buttonAddReminder
            // 
            this.buttonAddReminder.Location = new System.Drawing.Point(4, 4);
            this.buttonAddReminder.Name = "buttonAddReminder";
            this.buttonAddReminder.Size = new System.Drawing.Size(94, 23);
            this.buttonAddReminder.TabIndex = 0;
            this.buttonAddReminder.Text = "Add Reminder";
            this.buttonAddReminder.UseVisualStyleBackColor = true;
            this.buttonAddReminder.Click += new System.EventHandler(this.buttonAddReminder_Click);
            // 
            // listViewReminders
            // 
            this.listViewReminders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewReminders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnReminderTitle,
            this.columnReminderDescription,
            this.columnReminderTime,
            this.columnReminderRepeat,
            this.columnReminderString});
            this.listViewReminders.FullRowSelect = true;
            this.listViewReminders.HideSelection = false;
            this.listViewReminders.Location = new System.Drawing.Point(4, 4);
            this.listViewReminders.Name = "listViewReminders";
            this.listViewReminders.Size = new System.Drawing.Size(785, 304);
            this.listViewReminders.TabIndex = 0;
            this.listViewReminders.UseCompatibleStateImageBehavior = false;
            this.listViewReminders.View = System.Windows.Forms.View.Details;
            // 
            // columnReminderTitle
            // 
            this.columnReminderTitle.Text = "Title";
            // 
            // columnReminderDescription
            // 
            this.columnReminderDescription.Text = "Description";
            // 
            // columnReminderTime
            // 
            this.columnReminderTime.Text = "Time";
            // 
            // columnReminderRepeat
            // 
            this.columnReminderRepeat.Text = "Repeat";
            // 
            // columnReminderString
            // 
            this.columnReminderString.Text = "String";
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.panel1);
            this.tabReports.Controls.Add(this.listViewReports);
            this.tabReports.Location = new System.Drawing.Point(4, 22);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(792, 434);
            this.tabReports.TabIndex = 1;
            this.tabReports.Text = "Reports";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonDeleteReport);
            this.panel1.Controls.Add(this.buttonEditReport);
            this.panel1.Controls.Add(this.buttonAddReport);
            this.panel1.Location = new System.Drawing.Point(4, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 121);
            this.panel1.TabIndex = 3;
            // 
            // buttonDeleteReport
            // 
            this.buttonDeleteReport.Location = new System.Drawing.Point(4, 64);
            this.buttonDeleteReport.Name = "buttonDeleteReport";
            this.buttonDeleteReport.Size = new System.Drawing.Size(94, 23);
            this.buttonDeleteReport.TabIndex = 2;
            this.buttonDeleteReport.Text = "Delete Report";
            this.buttonDeleteReport.UseVisualStyleBackColor = true;
            this.buttonDeleteReport.Click += new System.EventHandler(this.buttonDeleteReport_Click);
            // 
            // buttonEditReport
            // 
            this.buttonEditReport.Location = new System.Drawing.Point(4, 34);
            this.buttonEditReport.Name = "buttonEditReport";
            this.buttonEditReport.Size = new System.Drawing.Size(94, 23);
            this.buttonEditReport.TabIndex = 1;
            this.buttonEditReport.Text = "Edit Report";
            this.buttonEditReport.UseVisualStyleBackColor = true;
            this.buttonEditReport.Click += new System.EventHandler(this.buttonEditReport_Click);
            // 
            // buttonAddReport
            // 
            this.buttonAddReport.Location = new System.Drawing.Point(4, 4);
            this.buttonAddReport.Name = "buttonAddReport";
            this.buttonAddReport.Size = new System.Drawing.Size(94, 23);
            this.buttonAddReport.TabIndex = 0;
            this.buttonAddReport.Text = "Add Report";
            this.buttonAddReport.UseVisualStyleBackColor = true;
            this.buttonAddReport.Click += new System.EventHandler(this.buttonAddReport_Click);
            // 
            // listViewReports
            // 
            this.listViewReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnReportTitle,
            this.columnReportDescription,
            this.columnReportTime,
            this.columnReportRepeat,
            this.columnReportString});
            this.listViewReports.FullRowSelect = true;
            this.listViewReports.HideSelection = false;
            this.listViewReports.Location = new System.Drawing.Point(4, 4);
            this.listViewReports.Name = "listViewReports";
            this.listViewReports.Size = new System.Drawing.Size(785, 304);
            this.listViewReports.TabIndex = 2;
            this.listViewReports.UseCompatibleStateImageBehavior = false;
            this.listViewReports.View = System.Windows.Forms.View.Details;
            // 
            // columnReportTitle
            // 
            this.columnReportTitle.Text = "Title";
            // 
            // columnReportDescription
            // 
            this.columnReportDescription.Text = "Description";
            // 
            // columnReportTime
            // 
            this.columnReportTime.Text = "Time";
            // 
            // columnReportRepeat
            // 
            this.columnReportRepeat.Text = "Repeat";
            // 
            // columnReportString
            // 
            this.columnReportString.Text = "String";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBoxExternalReminderConfiguration);
            this.tabSettings.Controls.Add(this.groupBoxInformationCollectorConfiguration);
            this.tabSettings.Controls.Add(this.groupBoxDataManagement);
            this.tabSettings.Controls.Add(this.groupBoxNotificationConfiguration);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(792, 434);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBoxExternalReminderConfiguration
            // 
            this.groupBoxExternalReminderConfiguration.Controls.Add(this.comboBoxExternalReminderSelect);
            this.groupBoxExternalReminderConfiguration.Controls.Add(this.listBoxConfiguredExternalReminders);
            this.groupBoxExternalReminderConfiguration.Controls.Add(this.buttonConfigureExternalReminder);
            this.groupBoxExternalReminderConfiguration.Location = new System.Drawing.Point(282, 168);
            this.groupBoxExternalReminderConfiguration.Name = "groupBoxExternalReminderConfiguration";
            this.groupBoxExternalReminderConfiguration.Size = new System.Drawing.Size(269, 156);
            this.groupBoxExternalReminderConfiguration.TabIndex = 6;
            this.groupBoxExternalReminderConfiguration.TabStop = false;
            this.groupBoxExternalReminderConfiguration.Text = "External Reminder Configuration";
            // 
            // comboBoxExternalReminderSelect
            // 
            this.comboBoxExternalReminderSelect.FormattingEnabled = true;
            this.comboBoxExternalReminderSelect.Location = new System.Drawing.Point(6, 19);
            this.comboBoxExternalReminderSelect.Name = "comboBoxExternalReminderSelect";
            this.comboBoxExternalReminderSelect.Size = new System.Drawing.Size(129, 21);
            this.comboBoxExternalReminderSelect.TabIndex = 0;
            // 
            // listBoxConfiguredExternalReminders
            // 
            this.listBoxConfiguredExternalReminders.FormattingEnabled = true;
            this.listBoxConfiguredExternalReminders.Location = new System.Drawing.Point(6, 55);
            this.listBoxConfiguredExternalReminders.Name = "listBoxConfiguredExternalReminders";
            this.listBoxConfiguredExternalReminders.Size = new System.Drawing.Size(129, 95);
            this.listBoxConfiguredExternalReminders.TabIndex = 2;
            // 
            // buttonConfigureExternalReminder
            // 
            this.buttonConfigureExternalReminder.Location = new System.Drawing.Point(141, 19);
            this.buttonConfigureExternalReminder.Name = "buttonConfigureExternalReminder";
            this.buttonConfigureExternalReminder.Size = new System.Drawing.Size(105, 51);
            this.buttonConfigureExternalReminder.TabIndex = 1;
            this.buttonConfigureExternalReminder.Text = "Configure External Reminder";
            this.buttonConfigureExternalReminder.UseVisualStyleBackColor = true;
            this.buttonConfigureExternalReminder.Click += new System.EventHandler(this.buttonConfigureExternalReminder_Click);
            // 
            // groupBoxInformationCollectorConfiguration
            // 
            this.groupBoxInformationCollectorConfiguration.Controls.Add(this.comboBoxInformationCollectorSelect);
            this.groupBoxInformationCollectorConfiguration.Controls.Add(this.listBoxConfiguredInformationCollectors);
            this.groupBoxInformationCollectorConfiguration.Controls.Add(this.buttonConfigureInformationCollector);
            this.groupBoxInformationCollectorConfiguration.Location = new System.Drawing.Point(6, 168);
            this.groupBoxInformationCollectorConfiguration.Name = "groupBoxInformationCollectorConfiguration";
            this.groupBoxInformationCollectorConfiguration.Size = new System.Drawing.Size(269, 156);
            this.groupBoxInformationCollectorConfiguration.TabIndex = 5;
            this.groupBoxInformationCollectorConfiguration.TabStop = false;
            this.groupBoxInformationCollectorConfiguration.Text = "Information Collector Configuration";
            // 
            // comboBoxInformationCollectorSelect
            // 
            this.comboBoxInformationCollectorSelect.FormattingEnabled = true;
            this.comboBoxInformationCollectorSelect.Location = new System.Drawing.Point(6, 19);
            this.comboBoxInformationCollectorSelect.Name = "comboBoxInformationCollectorSelect";
            this.comboBoxInformationCollectorSelect.Size = new System.Drawing.Size(129, 21);
            this.comboBoxInformationCollectorSelect.TabIndex = 0;
            // 
            // listBoxConfiguredInformationCollectors
            // 
            this.listBoxConfiguredInformationCollectors.FormattingEnabled = true;
            this.listBoxConfiguredInformationCollectors.Location = new System.Drawing.Point(6, 55);
            this.listBoxConfiguredInformationCollectors.Name = "listBoxConfiguredInformationCollectors";
            this.listBoxConfiguredInformationCollectors.Size = new System.Drawing.Size(129, 95);
            this.listBoxConfiguredInformationCollectors.TabIndex = 2;
            // 
            // buttonConfigureInformationCollector
            // 
            this.buttonConfigureInformationCollector.Location = new System.Drawing.Point(141, 19);
            this.buttonConfigureInformationCollector.Name = "buttonConfigureInformationCollector";
            this.buttonConfigureInformationCollector.Size = new System.Drawing.Size(105, 51);
            this.buttonConfigureInformationCollector.TabIndex = 1;
            this.buttonConfigureInformationCollector.Text = "Configure Information Collector";
            this.buttonConfigureInformationCollector.UseVisualStyleBackColor = true;
            this.buttonConfigureInformationCollector.Click += new System.EventHandler(this.buttonConfigureInformationCollector_Click);
            // 
            // groupBoxDataManagement
            // 
            this.groupBoxDataManagement.Controls.Add(this.buttonClearData);
            this.groupBoxDataManagement.Controls.Add(this.buttonImportData);
            this.groupBoxDataManagement.Controls.Add(this.buttonExportData);
            this.groupBoxDataManagement.Location = new System.Drawing.Point(282, 7);
            this.groupBoxDataManagement.Name = "groupBoxDataManagement";
            this.groupBoxDataManagement.Size = new System.Drawing.Size(200, 155);
            this.groupBoxDataManagement.TabIndex = 4;
            this.groupBoxDataManagement.TabStop = false;
            this.groupBoxDataManagement.Text = "Data Management";
            // 
            // buttonClearData
            // 
            this.buttonClearData.Location = new System.Drawing.Point(7, 85);
            this.buttonClearData.Name = "buttonClearData";
            this.buttonClearData.Size = new System.Drawing.Size(75, 23);
            this.buttonClearData.TabIndex = 2;
            this.buttonClearData.Text = "Clear Data";
            this.buttonClearData.UseVisualStyleBackColor = true;
            // 
            // buttonImportData
            // 
            this.buttonImportData.Location = new System.Drawing.Point(7, 53);
            this.buttonImportData.Name = "buttonImportData";
            this.buttonImportData.Size = new System.Drawing.Size(75, 23);
            this.buttonImportData.TabIndex = 1;
            this.buttonImportData.Text = "Import Data";
            this.buttonImportData.UseVisualStyleBackColor = true;
            // 
            // buttonExportData
            // 
            this.buttonExportData.Location = new System.Drawing.Point(7, 20);
            this.buttonExportData.Name = "buttonExportData";
            this.buttonExportData.Size = new System.Drawing.Size(75, 23);
            this.buttonExportData.TabIndex = 0;
            this.buttonExportData.Text = "Export Data";
            this.buttonExportData.UseVisualStyleBackColor = true;
            // 
            // groupBoxNotificationConfiguration
            // 
            this.groupBoxNotificationConfiguration.Controls.Add(this.comboBoxNotifierSelect);
            this.groupBoxNotificationConfiguration.Controls.Add(this.listBoxConfiguredNotifiers);
            this.groupBoxNotificationConfiguration.Controls.Add(this.buttonConfigureNotifier);
            this.groupBoxNotificationConfiguration.Location = new System.Drawing.Point(6, 6);
            this.groupBoxNotificationConfiguration.Name = "groupBoxNotificationConfiguration";
            this.groupBoxNotificationConfiguration.Size = new System.Drawing.Size(269, 156);
            this.groupBoxNotificationConfiguration.TabIndex = 3;
            this.groupBoxNotificationConfiguration.TabStop = false;
            this.groupBoxNotificationConfiguration.Text = "Notification Configuration";
            // 
            // comboBoxNotifierSelect
            // 
            this.comboBoxNotifierSelect.FormattingEnabled = true;
            this.comboBoxNotifierSelect.Location = new System.Drawing.Point(6, 19);
            this.comboBoxNotifierSelect.Name = "comboBoxNotifierSelect";
            this.comboBoxNotifierSelect.Size = new System.Drawing.Size(129, 21);
            this.comboBoxNotifierSelect.TabIndex = 0;
            // 
            // listBoxConfiguredNotifiers
            // 
            this.listBoxConfiguredNotifiers.FormattingEnabled = true;
            this.listBoxConfiguredNotifiers.Location = new System.Drawing.Point(6, 55);
            this.listBoxConfiguredNotifiers.Name = "listBoxConfiguredNotifiers";
            this.listBoxConfiguredNotifiers.Size = new System.Drawing.Size(129, 95);
            this.listBoxConfiguredNotifiers.TabIndex = 2;
            // 
            // buttonConfigureNotifier
            // 
            this.buttonConfigureNotifier.Location = new System.Drawing.Point(141, 19);
            this.buttonConfigureNotifier.Name = "buttonConfigureNotifier";
            this.buttonConfigureNotifier.Size = new System.Drawing.Size(105, 23);
            this.buttonConfigureNotifier.TabIndex = 1;
            this.buttonConfigureNotifier.Text = "Configure Notifier";
            this.buttonConfigureNotifier.UseVisualStyleBackColor = true;
            this.buttonConfigureNotifier.Click += new System.EventHandler(this.buttonConfigureNotifier_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 475);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.tabControlMain.ResumeLayout(false);
            this.tabReminders.ResumeLayout(false);
            this.panelRemiderButtons.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBoxExternalReminderConfiguration.ResumeLayout(false);
            this.groupBoxInformationCollectorConfiguration.ResumeLayout(false);
            this.groupBoxDataManagement.ResumeLayout(false);
            this.groupBoxNotificationConfiguration.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabReminders;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.ListView listViewReminders;
        private System.Windows.Forms.ColumnHeader columnReminderTitle;
        private System.Windows.Forms.ColumnHeader columnReminderDescription;
        private System.Windows.Forms.ColumnHeader columnReminderTime;
        private System.Windows.Forms.ColumnHeader columnReminderRepeat;
        private System.Windows.Forms.Panel panelRemiderButtons;
        private System.Windows.Forms.Button buttonImportExternal;
        private System.Windows.Forms.Button buttonDeleteReminder;
        private System.Windows.Forms.Button buttonEditReminder;
        private System.Windows.Forms.Button buttonAddReminder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDeleteReport;
        private System.Windows.Forms.Button buttonEditReport;
        private System.Windows.Forms.Button buttonAddReport;
        private System.Windows.Forms.ListView listViewReports;
        private System.Windows.Forms.ColumnHeader columnReportTitle;
        private System.Windows.Forms.ColumnHeader columnReportDescription;
        private System.Windows.Forms.ColumnHeader columnReportTime;
        private System.Windows.Forms.ColumnHeader columnReportRepeat;
        private System.Windows.Forms.ColumnHeader columnReportString;
        private System.Windows.Forms.ColumnHeader columnReminderString;
        private System.Windows.Forms.ComboBox comboBoxNotifierSelect;
        private System.Windows.Forms.Button buttonConfigureNotifier;
        private System.Windows.Forms.ListBox listBoxConfiguredNotifiers;
        private System.Windows.Forms.GroupBox groupBoxNotificationConfiguration;
        private System.Windows.Forms.GroupBox groupBoxDataManagement;
        private System.Windows.Forms.Button buttonImportData;
        private System.Windows.Forms.Button buttonExportData;
        private System.Windows.Forms.Button buttonClearData;
        private System.Windows.Forms.GroupBox groupBoxInformationCollectorConfiguration;
        private System.Windows.Forms.ComboBox comboBoxInformationCollectorSelect;
        private System.Windows.Forms.ListBox listBoxConfiguredInformationCollectors;
        private System.Windows.Forms.Button buttonConfigureInformationCollector;
        private System.Windows.Forms.GroupBox groupBoxExternalReminderConfiguration;
        private System.Windows.Forms.ComboBox comboBoxExternalReminderSelect;
        private System.Windows.Forms.ListBox listBoxConfiguredExternalReminders;
        private System.Windows.Forms.Button buttonConfigureExternalReminder;
    }
}

