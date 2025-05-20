namespace FinalProject
{
    partial class PluginConfigForm
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
            this.flowLayoutPanelRequiredParameters = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelOptionalParameters = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddPlugin = new System.Windows.Forms.Button();
            this.buttonCancelPlugin = new System.Windows.Forms.Button();
            this.labelPluginName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelRequiredParameters
            // 
            this.flowLayoutPanelRequiredParameters.AutoSize = true;
            this.flowLayoutPanelRequiredParameters.Location = new System.Drawing.Point(13, 41);
            this.flowLayoutPanelRequiredParameters.Name = "flowLayoutPanelRequiredParameters";
            this.flowLayoutPanelRequiredParameters.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanelRequiredParameters.TabIndex = 1;
            // 
            // flowLayoutPanelOptionalParameters
            // 
            this.flowLayoutPanelOptionalParameters.AutoScroll = true;
            this.flowLayoutPanelOptionalParameters.AutoSize = true;
            this.flowLayoutPanelOptionalParameters.Location = new System.Drawing.Point(13, 148);
            this.flowLayoutPanelOptionalParameters.Name = "flowLayoutPanelOptionalParameters";
            this.flowLayoutPanelOptionalParameters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanelOptionalParameters.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanelOptionalParameters.TabIndex = 2;
            // 
            // buttonAddPlugin
            // 
            this.buttonAddPlugin.AutoSize = true;
            this.buttonAddPlugin.Location = new System.Drawing.Point(12, 254);
            this.buttonAddPlugin.Name = "buttonAddPlugin";
            this.buttonAddPlugin.Size = new System.Drawing.Size(94, 23);
            this.buttonAddPlugin.TabIndex = 3;
            this.buttonAddPlugin.Text = "Add Plugin";
            this.buttonAddPlugin.UseVisualStyleBackColor = true;
            this.buttonAddPlugin.Click += new System.EventHandler(this.buttonAddPlugin_Click);
            // 
            // buttonCancelPlugin
            // 
            this.buttonCancelPlugin.Location = new System.Drawing.Point(119, 254);
            this.buttonCancelPlugin.Name = "buttonCancelPlugin";
            this.buttonCancelPlugin.Size = new System.Drawing.Size(94, 23);
            this.buttonCancelPlugin.TabIndex = 4;
            this.buttonCancelPlugin.Text = "Cancel";
            this.buttonCancelPlugin.UseVisualStyleBackColor = true;
            this.buttonCancelPlugin.Click += new System.EventHandler(this.buttonCancelPlugin_Click);
            // 
            // labelPluginName
            // 
            this.labelPluginName.AutoSize = true;
            this.labelPluginName.Location = new System.Drawing.Point(13, 13);
            this.labelPluginName.Name = "labelPluginName";
            this.labelPluginName.Size = new System.Drawing.Size(39, 13);
            this.labelPluginName.TabIndex = 5;
            this.labelPluginName.Text = "Plugin:";
            // 
            // PluginConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(242, 289);
            this.Controls.Add(this.labelPluginName);
            this.Controls.Add(this.buttonCancelPlugin);
            this.Controls.Add(this.buttonAddPlugin);
            this.Controls.Add(this.flowLayoutPanelOptionalParameters);
            this.Controls.Add(this.flowLayoutPanelRequiredParameters);
            this.Name = "PluginConfigForm";
            this.Text = "PluginConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRequiredParameters;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOptionalParameters;
        private System.Windows.Forms.Button buttonAddPlugin;
        private System.Windows.Forms.Button buttonCancelPlugin;
        private System.Windows.Forms.Label labelPluginName;
    }
}