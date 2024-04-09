namespace HeartsCardGame
{
    partial class HeartsGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeartsGame));
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RulesButton = new System.Windows.Forms.Button();
            this.ResetGameButton = new System.Windows.Forms.Button();
            this.PlayerInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.Score4TextBox = new System.Windows.Forms.TextBox();
            this.Player4Label = new System.Windows.Forms.Label();
            this.Score3TextBox = new System.Windows.Forms.TextBox();
            this.Player3Label = new System.Windows.Forms.Label();
            this.Score2TextBox = new System.Windows.Forms.TextBox();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Score1TextBox = new System.Windows.Forms.TextBox();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.GameInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.HandNumTextBox = new System.Windows.Forms.TextBox();
            this.TrickNumTextBox = new System.Windows.Forms.TextBox();
            this.TrickNumLabel = new System.Windows.Forms.Label();
            this.HandNumLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GameMenuStrip = new System.Windows.Forms.MenuStrip();
            this.StartGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HandFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TrickFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.OptionsGroupBox.SuspendLayout();
            this.PlayerInfoGroupBox.SuspendLayout();
            this.GameInfoGroupBox.SuspendLayout();
            this.GameMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.StartGameButton);
            this.OptionsGroupBox.Controls.Add(this.ExitButton);
            this.OptionsGroupBox.Controls.Add(this.RulesButton);
            this.OptionsGroupBox.Controls.Add(this.ResetGameButton);
            this.OptionsGroupBox.Location = new System.Drawing.Point(1176, 41);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(250, 391);
            this.OptionsGroupBox.TabIndex = 5;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Game Options";
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(6, 21);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(238, 91);
            this.StartGameButton.TabIndex = 6;
            this.StartGameButton.Text = "Start Round";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(6, 306);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(238, 85);
            this.ExitButton.TabIndex = 35;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // RulesButton
            // 
            this.RulesButton.Location = new System.Drawing.Point(6, 215);
            this.RulesButton.Name = "RulesButton";
            this.RulesButton.Size = new System.Drawing.Size(238, 85);
            this.RulesButton.TabIndex = 34;
            this.RulesButton.Text = "Rules";
            this.RulesButton.UseVisualStyleBackColor = true;
            this.RulesButton.Click += new System.EventHandler(this.RulesButton_Click);
            // 
            // ResetGameButton
            // 
            this.ResetGameButton.Location = new System.Drawing.Point(6, 118);
            this.ResetGameButton.Name = "ResetGameButton";
            this.ResetGameButton.Size = new System.Drawing.Size(238, 91);
            this.ResetGameButton.TabIndex = 33;
            this.ResetGameButton.Text = "Reset Game";
            this.ResetGameButton.UseVisualStyleBackColor = true;
            this.ResetGameButton.Click += new System.EventHandler(this.ResetGameButton_Click);
            // 
            // PlayerInfoGroupBox
            // 
            this.PlayerInfoGroupBox.Controls.Add(this.NameLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.Score4TextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.Player4Label);
            this.PlayerInfoGroupBox.Controls.Add(this.Score3TextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.Player3Label);
            this.PlayerInfoGroupBox.Controls.Add(this.Score2TextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.Player2Label);
            this.PlayerInfoGroupBox.Controls.Add(this.Score1TextBox);
            this.PlayerInfoGroupBox.Controls.Add(this.ScoreLabel);
            this.PlayerInfoGroupBox.Controls.Add(this.Player1Label);
            this.PlayerInfoGroupBox.Location = new System.Drawing.Point(12, 41);
            this.PlayerInfoGroupBox.Name = "PlayerInfoGroupBox";
            this.PlayerInfoGroupBox.Size = new System.Drawing.Size(250, 182);
            this.PlayerInfoGroupBox.TabIndex = 18;
            this.PlayerInfoGroupBox.TabStop = false;
            this.PlayerInfoGroupBox.Text = "Player Info";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(15, 21);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(44, 16);
            this.NameLabel.TabIndex = 32;
            this.NameLabel.Text = "Name";
            // 
            // Score4TextBox
            // 
            this.Score4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score4TextBox.Enabled = false;
            this.Score4TextBox.Location = new System.Drawing.Point(163, 141);
            this.Score4TextBox.Name = "Score4TextBox";
            this.Score4TextBox.ReadOnly = true;
            this.Score4TextBox.Size = new System.Drawing.Size(72, 15);
            this.Score4TextBox.TabIndex = 31;
            // 
            // Player4Label
            // 
            this.Player4Label.AutoSize = true;
            this.Player4Label.Location = new System.Drawing.Point(15, 150);
            this.Player4Label.Name = "Player4Label";
            this.Player4Label.Size = new System.Drawing.Size(0, 16);
            this.Player4Label.TabIndex = 30;
            // 
            // Score3TextBox
            // 
            this.Score3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score3TextBox.Enabled = false;
            this.Score3TextBox.Location = new System.Drawing.Point(163, 107);
            this.Score3TextBox.Name = "Score3TextBox";
            this.Score3TextBox.ReadOnly = true;
            this.Score3TextBox.Size = new System.Drawing.Size(72, 15);
            this.Score3TextBox.TabIndex = 28;
            // 
            // Player3Label
            // 
            this.Player3Label.AutoSize = true;
            this.Player3Label.Location = new System.Drawing.Point(15, 116);
            this.Player3Label.Name = "Player3Label";
            this.Player3Label.Size = new System.Drawing.Size(0, 16);
            this.Player3Label.TabIndex = 27;
            // 
            // Score2TextBox
            // 
            this.Score2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score2TextBox.Enabled = false;
            this.Score2TextBox.Location = new System.Drawing.Point(163, 73);
            this.Score2TextBox.Name = "Score2TextBox";
            this.Score2TextBox.ReadOnly = true;
            this.Score2TextBox.Size = new System.Drawing.Size(72, 15);
            this.Score2TextBox.TabIndex = 25;
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(15, 82);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(0, 16);
            this.Player2Label.TabIndex = 24;
            // 
            // Score1TextBox
            // 
            this.Score1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score1TextBox.Enabled = false;
            this.Score1TextBox.Location = new System.Drawing.Point(163, 39);
            this.Score1TextBox.Name = "Score1TextBox";
            this.Score1TextBox.ReadOnly = true;
            this.Score1TextBox.Size = new System.Drawing.Size(72, 15);
            this.Score1TextBox.TabIndex = 22;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(178, 21);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(43, 16);
            this.ScoreLabel.TabIndex = 19;
            this.ScoreLabel.Text = "Score";
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(15, 48);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(0, 16);
            this.Player1Label.TabIndex = 21;
            // 
            // GameInfoGroupBox
            // 
            this.GameInfoGroupBox.Controls.Add(this.HandNumTextBox);
            this.GameInfoGroupBox.Controls.Add(this.TrickNumTextBox);
            this.GameInfoGroupBox.Controls.Add(this.TrickNumLabel);
            this.GameInfoGroupBox.Controls.Add(this.HandNumLabel);
            this.GameInfoGroupBox.Controls.Add(this.label2);
            this.GameInfoGroupBox.Location = new System.Drawing.Point(12, 247);
            this.GameInfoGroupBox.Name = "GameInfoGroupBox";
            this.GameInfoGroupBox.Size = new System.Drawing.Size(250, 94);
            this.GameInfoGroupBox.TabIndex = 13;
            this.GameInfoGroupBox.TabStop = false;
            this.GameInfoGroupBox.Text = "Game Info";
            // 
            // HandNumTextBox
            // 
            this.HandNumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HandNumTextBox.Enabled = false;
            this.HandNumTextBox.Location = new System.Drawing.Point(121, 21);
            this.HandNumTextBox.Name = "HandNumTextBox";
            this.HandNumTextBox.ReadOnly = true;
            this.HandNumTextBox.Size = new System.Drawing.Size(100, 15);
            this.HandNumTextBox.TabIndex = 15;
            // 
            // TrickNumTextBox
            // 
            this.TrickNumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrickNumTextBox.Enabled = false;
            this.TrickNumTextBox.Location = new System.Drawing.Point(121, 60);
            this.TrickNumTextBox.Name = "TrickNumTextBox";
            this.TrickNumTextBox.ReadOnly = true;
            this.TrickNumTextBox.Size = new System.Drawing.Size(100, 15);
            this.TrickNumTextBox.TabIndex = 17;
            // 
            // TrickNumLabel
            // 
            this.TrickNumLabel.AutoSize = true;
            this.TrickNumLabel.Location = new System.Drawing.Point(6, 61);
            this.TrickNumLabel.Name = "TrickNumLabel";
            this.TrickNumLabel.Size = new System.Drawing.Size(91, 16);
            this.TrickNumLabel.TabIndex = 16;
            this.TrickNumLabel.Text = "Trick Number:";
            // 
            // HandNumLabel
            // 
            this.HandNumLabel.AutoSize = true;
            this.HandNumLabel.Location = new System.Drawing.Point(6, 24);
            this.HandNumLabel.Name = "HandNumLabel";
            this.HandNumLabel.Size = new System.Drawing.Size(94, 16);
            this.HandNumLabel.TabIndex = 14;
            this.HandNumLabel.Text = "Hand Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 16;
            // 
            // GameMenuStrip
            // 
            this.GameMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.GameMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartGameToolStripMenuItem,
            this.ResetGameToolStripMenuItem,
            this.RulesToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.GameMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.GameMenuStrip.Name = "GameMenuStrip";
            this.GameMenuStrip.Size = new System.Drawing.Size(1440, 28);
            this.GameMenuStrip.TabIndex = 22;
            this.GameMenuStrip.Text = "CardsMenuStrip";
            // 
            // StartGameToolStripMenuItem
            // 
            this.StartGameToolStripMenuItem.Name = "StartGameToolStripMenuItem";
            this.StartGameToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.StartGameToolStripMenuItem.Text = "Start Game";
            this.StartGameToolStripMenuItem.Click += new System.EventHandler(this.StartGameToolStripMenuItem_Click);
            // 
            // ResetGameToolStripMenuItem
            // 
            this.ResetGameToolStripMenuItem.Name = "ResetGameToolStripMenuItem";
            this.ResetGameToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.ResetGameToolStripMenuItem.Text = "Reset Game";
            this.ResetGameToolStripMenuItem.Click += new System.EventHandler(this.ResetGameToolStripMenuItem_Click);
            // 
            // RulesToolStripMenuItem
            // 
            this.RulesToolStripMenuItem.Name = "RulesToolStripMenuItem";
            this.RulesToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.RulesToolStripMenuItem.Text = "Rules";
            this.RulesToolStripMenuItem.Click += new System.EventHandler(this.RulesToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HandFlowLayoutPanel
            // 
            this.HandFlowLayoutPanel.Location = new System.Drawing.Point(12, 438);
            this.HandFlowLayoutPanel.Name = "HandFlowLayoutPanel";
            this.HandFlowLayoutPanel.Size = new System.Drawing.Size(1414, 332);
            this.HandFlowLayoutPanel.TabIndex = 23;
            // 
            // TrickFlowLayoutPanel
            // 
            this.TrickFlowLayoutPanel.Location = new System.Drawing.Point(268, 41);
            this.TrickFlowLayoutPanel.Name = "TrickFlowLayoutPanel";
            this.TrickFlowLayoutPanel.Size = new System.Drawing.Size(908, 372);
            this.TrickFlowLayoutPanel.TabIndex = 24;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(265, 416);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(383, 16);
            this.MessageLabel.TabIndex = 25;
            this.MessageLabel.Text = "MESSAGET THAT WILL BE MOVED AND ADJUSTED LATER";
            // 
            // HeartsGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 782);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.TrickFlowLayoutPanel);
            this.Controls.Add(this.HandFlowLayoutPanel);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.PlayerInfoGroupBox);
            this.Controls.Add(this.GameInfoGroupBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GameMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HeartsGame";
            this.Text = "Hearts";
            this.OptionsGroupBox.ResumeLayout(false);
            this.PlayerInfoGroupBox.ResumeLayout(false);
            this.PlayerInfoGroupBox.PerformLayout();
            this.GameInfoGroupBox.ResumeLayout(false);
            this.GameInfoGroupBox.PerformLayout();
            this.GameMenuStrip.ResumeLayout(false);
            this.GameMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button RulesButton;
        private System.Windows.Forms.Button ResetGameButton;
        private System.Windows.Forms.GroupBox PlayerInfoGroupBox;
        private System.Windows.Forms.TextBox Score4TextBox;
        private System.Windows.Forms.TextBox Score3TextBox;
        private System.Windows.Forms.TextBox Score2TextBox;
        private System.Windows.Forms.TextBox Score1TextBox;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.GroupBox GameInfoGroupBox;
        private System.Windows.Forms.TextBox HandNumTextBox;
        private System.Windows.Forms.TextBox TrickNumTextBox;
        private System.Windows.Forms.Label TrickNumLabel;
        private System.Windows.Forms.Label HandNumLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip GameMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.ToolStripMenuItem StartGameToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel HandFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel TrickFlowLayoutPanel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label Player4Label;
        private System.Windows.Forms.Label Player3Label;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label MessageLabel;
    }
}

