namespace HeartsCardGame
{
    partial class GameSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSetupForm));
            this.GameSetupGroupBox1 = new System.Windows.Forms.GroupBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ConfirmSetupButton = new System.Windows.Forms.Button();
            this.GUIThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.CardsThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.DarkThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.LightThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.ThemeSelectionLabel = new System.Windows.Forms.Label();
            this.PlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.NumOfPlayerComboBox = new System.Windows.Forms.ComboBox();
            this.NumOfPlayerLabel = new System.Windows.Forms.Label();
            this.MaxScoreLabel = new System.Windows.Forms.Label();
            this.MaxScoreTextBox = new System.Windows.Forms.TextBox();
            this.GameSetupGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameSetupGroupBox1
            // 
            this.GameSetupGroupBox1.Controls.Add(this.ResetButton);
            this.GameSetupGroupBox1.Controls.Add(this.ConfirmSetupButton);
            this.GameSetupGroupBox1.Controls.Add(this.GUIThemeRadioButton);
            this.GameSetupGroupBox1.Controls.Add(this.CardsThemeRadioButton);
            this.GameSetupGroupBox1.Controls.Add(this.DarkThemeRadioButton);
            this.GameSetupGroupBox1.Controls.Add(this.LightThemeRadioButton);
            this.GameSetupGroupBox1.Controls.Add(this.ThemeSelectionLabel);
            this.GameSetupGroupBox1.Controls.Add(this.PlayerNameTextBox);
            this.GameSetupGroupBox1.Controls.Add(this.PlayerNameLabel);
            this.GameSetupGroupBox1.Controls.Add(this.NumOfPlayerComboBox);
            this.GameSetupGroupBox1.Controls.Add(this.NumOfPlayerLabel);
            this.GameSetupGroupBox1.Controls.Add(this.MaxScoreLabel);
            this.GameSetupGroupBox1.Controls.Add(this.MaxScoreTextBox);
            this.GameSetupGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GameSetupGroupBox1.Name = "GameSetupGroupBox1";
            this.GameSetupGroupBox1.Size = new System.Drawing.Size(315, 288);
            this.GameSetupGroupBox1.TabIndex = 1;
            this.GameSetupGroupBox1.TabStop = false;
            this.GameSetupGroupBox1.Text = "Game Setup";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(197, 252);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(109, 23);
            this.ResetButton.TabIndex = 12;
            this.ResetButton.Text = "Reset Setup";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ConfirmSetupButton
            // 
            this.ConfirmSetupButton.Location = new System.Drawing.Point(6, 252);
            this.ConfirmSetupButton.Name = "ConfirmSetupButton";
            this.ConfirmSetupButton.Size = new System.Drawing.Size(109, 23);
            this.ConfirmSetupButton.TabIndex = 11;
            this.ConfirmSetupButton.Text = "Confirm Setup";
            this.ConfirmSetupButton.UseVisualStyleBackColor = true;
            this.ConfirmSetupButton.Click += new System.EventHandler(this.ConfirmSetupButton_Click);
            // 
            // GUIThemeRadioButton
            // 
            this.GUIThemeRadioButton.AutoSize = true;
            this.GUIThemeRadioButton.Location = new System.Drawing.Point(155, 214);
            this.GUIThemeRadioButton.Name = "GUIThemeRadioButton";
            this.GUIThemeRadioButton.Size = new System.Drawing.Size(132, 20);
            this.GUIThemeRadioButton.TabIndex = 10;
            this.GUIThemeRadioButton.TabStop = true;
            this.GUIThemeRadioButton.Tag = "GUI";
            this.GUIThemeRadioButton.Text = "GUI Base Theme";
            this.GUIThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // CardsThemeRadioButton
            // 
            this.CardsThemeRadioButton.AutoSize = true;
            this.CardsThemeRadioButton.Location = new System.Drawing.Point(6, 214);
            this.CardsThemeRadioButton.Name = "CardsThemeRadioButton";
            this.CardsThemeRadioButton.Size = new System.Drawing.Size(143, 20);
            this.CardsThemeRadioButton.TabIndex = 9;
            this.CardsThemeRadioButton.TabStop = true;
            this.CardsThemeRadioButton.Tag = "Card";
            this.CardsThemeRadioButton.Text = "Card Game Theme";
            this.CardsThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // DarkThemeRadioButton
            // 
            this.DarkThemeRadioButton.AutoSize = true;
            this.DarkThemeRadioButton.Location = new System.Drawing.Point(155, 173);
            this.DarkThemeRadioButton.Name = "DarkThemeRadioButton";
            this.DarkThemeRadioButton.Size = new System.Drawing.Size(103, 20);
            this.DarkThemeRadioButton.TabIndex = 8;
            this.DarkThemeRadioButton.TabStop = true;
            this.DarkThemeRadioButton.Tag = "Dark";
            this.DarkThemeRadioButton.Text = "Dark Theme";
            this.DarkThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // LightThemeRadioButton
            // 
            this.LightThemeRadioButton.AutoSize = true;
            this.LightThemeRadioButton.Location = new System.Drawing.Point(6, 173);
            this.LightThemeRadioButton.Name = "LightThemeRadioButton";
            this.LightThemeRadioButton.Size = new System.Drawing.Size(102, 20);
            this.LightThemeRadioButton.TabIndex = 7;
            this.LightThemeRadioButton.TabStop = true;
            this.LightThemeRadioButton.Tag = "Light";
            this.LightThemeRadioButton.Text = "Light Theme";
            this.LightThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ThemeSelectionLabel
            // 
            this.ThemeSelectionLabel.AutoSize = true;
            this.ThemeSelectionLabel.Location = new System.Drawing.Point(3, 133);
            this.ThemeSelectionLabel.Name = "ThemeSelectionLabel";
            this.ThemeSelectionLabel.Size = new System.Drawing.Size(112, 16);
            this.ThemeSelectionLabel.TabIndex = 6;
            this.ThemeSelectionLabel.Text = "Theme Selection:";
            // 
            // PlayerNameTextBox
            // 
            this.PlayerNameTextBox.Location = new System.Drawing.Point(155, 96);
            this.PlayerNameTextBox.Name = "PlayerNameTextBox";
            this.PlayerNameTextBox.Size = new System.Drawing.Size(151, 22);
            this.PlayerNameTextBox.TabIndex = 3;
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Location = new System.Drawing.Point(3, 99);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(89, 16);
            this.PlayerNameLabel.TabIndex = 5;
            this.PlayerNameLabel.Text = "Player Name:";
            // 
            // NumOfPlayerComboBox
            // 
            this.NumOfPlayerComboBox.FormattingEnabled = true;
            this.NumOfPlayerComboBox.Items.AddRange(new object[] {
            "2 Player",
            "4 Player"});
            this.NumOfPlayerComboBox.Location = new System.Drawing.Point(155, 58);
            this.NumOfPlayerComboBox.Name = "NumOfPlayerComboBox";
            this.NumOfPlayerComboBox.Size = new System.Drawing.Size(100, 24);
            this.NumOfPlayerComboBox.TabIndex = 4;
            // 
            // NumOfPlayerLabel
            // 
            this.NumOfPlayerLabel.AutoSize = true;
            this.NumOfPlayerLabel.Location = new System.Drawing.Point(3, 61);
            this.NumOfPlayerLabel.Name = "NumOfPlayerLabel";
            this.NumOfPlayerLabel.Size = new System.Drawing.Size(87, 16);
            this.NumOfPlayerLabel.TabIndex = 3;
            this.NumOfPlayerLabel.Text = "Player Mode:";
            // 
            // MaxScoreLabel
            // 
            this.MaxScoreLabel.AutoSize = true;
            this.MaxScoreLabel.Location = new System.Drawing.Point(3, 24);
            this.MaxScoreLabel.Name = "MaxScoreLabel";
            this.MaxScoreLabel.Size = new System.Drawing.Size(74, 16);
            this.MaxScoreLabel.TabIndex = 1;
            this.MaxScoreLabel.Text = "Max Score:";
            // 
            // MaxScoreTextBox
            // 
            this.MaxScoreTextBox.Location = new System.Drawing.Point(155, 21);
            this.MaxScoreTextBox.Name = "MaxScoreTextBox";
            this.MaxScoreTextBox.Size = new System.Drawing.Size(100, 22);
            this.MaxScoreTextBox.TabIndex = 2;
            // 
            // GameSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 313);
            this.Controls.Add(this.GameSetupGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(354, 360);
            this.MinimumSize = new System.Drawing.Size(354, 360);
            this.Name = "GameSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Setup";
            this.GameSetupGroupBox1.ResumeLayout(false);
            this.GameSetupGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GameSetupGroupBox1;
        private System.Windows.Forms.ComboBox NumOfPlayerComboBox;
        private System.Windows.Forms.Label NumOfPlayerLabel;
        private System.Windows.Forms.Label MaxScoreLabel;
        private System.Windows.Forms.TextBox MaxScoreTextBox;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.TextBox PlayerNameTextBox;
        private System.Windows.Forms.RadioButton GUIThemeRadioButton;
        private System.Windows.Forms.RadioButton CardsThemeRadioButton;
        private System.Windows.Forms.RadioButton DarkThemeRadioButton;
        private System.Windows.Forms.RadioButton LightThemeRadioButton;
        private System.Windows.Forms.Label ThemeSelectionLabel;
        private System.Windows.Forms.Button ConfirmSetupButton;
        private System.Windows.Forms.Button ResetButton;
    }
}