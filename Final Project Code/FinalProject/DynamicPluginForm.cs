using FinalProject.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Checked
namespace FinalProject
{
    public partial class DynamicPluginForm : Form
    {
        private ConfigurablePluginIF pluginInstance;
        public DynamicPluginForm(ConfigurablePluginIF pluginInstance)
        {
            InitializeComponent();
            this.pluginInstance = pluginInstance;
            labelPluginName.Text = "Config" + pluginInstance.GetName();
            LoadParameters(null);
        }
        private void LoadParameters(Dictionary<string, string> initialConfig)
        {
            flowLayoutPanelRequiredParameters.Controls.Clear();
            flowLayoutPanelOptionalParameters.Controls.Clear();

            var requiredParams = pluginInstance.GetRunTimeRequiredParameters();
            foreach (var entry in requiredParams)
            {
                string initialValue = initialConfig != null && initialConfig.TryGetValue(entry.Key, out string val) ? val : "";
                AddParametersToRow(flowLayoutPanelRequiredParameters, entry.Key, initialValue);
            }

            var optionalParams = pluginInstance.GetRunTimeOptionalParameters();
            foreach (var entry in optionalParams)
            {
                string initialValue = initialConfig != null && initialConfig.TryGetValue(entry.Key, out string val) ? val : "";
                AddParametersToRow(flowLayoutPanelOptionalParameters, entry.Key, initialValue);
            }
        }
        private void AddParametersToRow(FlowLayoutPanel panel, string key, string value)
        {
            Label label = new Label() 
            {
                Text = key, Width = 100 
            };
            TextBox input = new TextBox() 
            {
                Name = key, Text = value, Width = 150 
            };
            FlowLayoutPanel row = new FlowLayoutPanel() 
            {
                AutoSize = true 
            };
            row.Controls.Add(label);
            row.Controls.Add(input);
            panel.Controls.Add(row);
        }

        private void buttonAddPlugin_Click(object sender, EventArgs e)
        {
            var required = GetParametersFromPanel(flowLayoutPanelRequiredParameters);
            var optional = GetParametersFromPanel(flowLayoutPanelOptionalParameters);

            foreach (var key in pluginInstance.GetRunTimeRequiredParameters().Keys)
            {
                if (!required.ContainsKey(key) || string.IsNullOrWhiteSpace(required[key]))
                {
                    MessageBox.Show("Missing required parameter: "+key);
                    return;
                }
            }

            pluginInstance.SetRunTimeParameters(required, optional);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private Dictionary<string, string> GetParametersFromPanel(FlowLayoutPanel panel)
        {
            var result = new Dictionary<string, string>();
            foreach (FlowLayoutPanel row in panel.Controls)
            {
                string key = null, value = null;
                foreach (Control ctrl in row.Controls)
                {
                    if (ctrl is Label lbl) key = lbl.Text;
                    if (ctrl is TextBox txt) value = txt.Text;
                }
                if (!string.IsNullOrEmpty(key)) result[key] = value;
            }
            return result;
        }
        public Dictionary<string, string> GetConfiguredParameters()
        {
            Dictionary<string, string> requiredParameters = GetParametersFromPanel(flowLayoutPanelRequiredParameters);
            Dictionary<string, string> optionalParameters = GetParametersFromPanel(flowLayoutPanelOptionalParameters);
            Dictionary<string, string> allParameters = new Dictionary<string, string>();
            foreach (var item in requiredParameters)
            {
                allParameters[item.Key] = item.Value;
            }
            foreach (var item in optionalParameters)
            {
                allParameters[item.Key] = item.Value;
            }
            return allParameters;
        }

        private void buttonCancelPlugin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
