namespace HeartsCardGame
{
    partial class RulesForm
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
            this.RulesGroupBox = new System.Windows.Forms.GroupBox();
            this.RulesTextBox = new System.Windows.Forms.TextBox();
            this.RulesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RulesGroupBox
            // 
            this.RulesGroupBox.Controls.Add(this.RulesTextBox);
            this.RulesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.RulesGroupBox.Name = "RulesGroupBox";
            this.RulesGroupBox.Size = new System.Drawing.Size(443, 289);
            this.RulesGroupBox.TabIndex = 0;
            this.RulesGroupBox.TabStop = false;
            this.RulesGroupBox.Text = "Hearts Rules";
            // 
            // RulesTextBox
            // 
            this.RulesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RulesTextBox.Location = new System.Drawing.Point(6, 21);
            this.RulesTextBox.Multiline = true;
            this.RulesTextBox.Name = "RulesTextBox";
            this.RulesTextBox.ReadOnly = true;
            this.RulesTextBox.Size = new System.Drawing.Size(431, 262);
            this.RulesTextBox.TabIndex = 0;
            this.RulesTextBox.Text = "Placeholder Text...";
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 313);
            this.Controls.Add(this.RulesGroupBox);
            this.Name = "RulesForm";
            this.Text = "Rules Form";
            this.RulesGroupBox.ResumeLayout(false);
            this.RulesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RulesGroupBox;
        private System.Windows.Forms.TextBox RulesTextBox;
    }
}