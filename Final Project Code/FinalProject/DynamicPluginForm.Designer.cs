namespace FinalProject
{
    partial class DynamicPluginForm
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
            this.labelPluginName = new System.Windows.Forms.Label();
            this.buttonCancelPlugin = new System.Windows.Forms.Button();
            this.buttonAddPlugin = new System.Windows.Forms.Button();
            this.flowLayoutPanelOptionalParameters = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelRequiredParameters = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // labelPluginName
            // 
            this.labelPluginName.AutoSize = true;
            this.labelPluginName.Location = new System.Drawing.Point(12, 9);
            this.labelPluginName.Name = "labelPluginName";
            this.labelPluginName.Size = new System.Drawing.Size(39, 13);
            this.labelPluginName.TabIndex = 10;
            this.labelPluginName.Text = "Plugin:";
            // 
            // buttonCancelPlugin
            // 
            this.buttonCancelPlugin.Location = new System.Drawing.Point(219, 67);
            this.buttonCancelPlugin.Name = "buttonCancelPlugin";
            this.buttonCancelPlugin.Size = new System.Drawing.Size(94, 23);
            this.buttonCancelPlugin.TabIndex = 9;
            this.buttonCancelPlugin.Text = "Cancel";
            this.buttonCancelPlugin.UseVisualStyleBackColor = true;
            this.buttonCancelPlugin.Click += new System.EventHandler(this.buttonCancelPlugin_Click);
            // 
            // buttonAddPlugin
            // 
            this.buttonAddPlugin.Location = new System.Drawing.Point(219, 37);
            this.buttonAddPlugin.Name = "buttonAddPlugin";
            this.buttonAddPlugin.Size = new System.Drawing.Size(94, 23);
            this.buttonAddPlugin.TabIndex = 8;
            this.buttonAddPlugin.Text = "Add Plugin";
            this.buttonAddPlugin.UseVisualStyleBackColor = true;
            this.buttonAddPlugin.Click += new System.EventHandler(this.buttonAddPlugin_Click);
            // 
            // flowLayoutPanelOptionalParameters
            // 
            this.flowLayoutPanelOptionalParameters.Location = new System.Drawing.Point(12, 144);
            this.flowLayoutPanelOptionalParameters.Name = "flowLayoutPanelOptionalParameters";
            this.flowLayoutPanelOptionalParameters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanelOptionalParameters.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanelOptionalParameters.TabIndex = 7;
            // 
            // flowLayoutPanelRequiredParameters
            // 
            this.flowLayoutPanelRequiredParameters.Location = new System.Drawing.Point(12, 37);
            this.flowLayoutPanelRequiredParameters.Name = "flowLayoutPanelRequiredParameters";
            this.flowLayoutPanelRequiredParameters.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanelRequiredParameters.TabIndex = 6;
            // 
            // DynamicPluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 258);
            this.Controls.Add(this.labelPluginName);
            this.Controls.Add(this.buttonCancelPlugin);
            this.Controls.Add(this.buttonAddPlugin);
            this.Controls.Add(this.flowLayoutPanelOptionalParameters);
            this.Controls.Add(this.flowLayoutPanelRequiredParameters);
            this.Name = "DynamicPluginForm";
            this.Text = "DynamicPluginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPluginName;
        private System.Windows.Forms.Button buttonCancelPlugin;
        private System.Windows.Forms.Button buttonAddPlugin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOptionalParameters;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRequiredParameters;
    }
}