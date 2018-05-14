namespace VetisLog.Agent
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NotifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.PanelMain = new System.Windows.Forms.Panel();
            this.LabelRegions = new System.Windows.Forms.Label();
            this.ComboBoxRegions = new System.Windows.Forms.ComboBox();
            this.ComboBoxCron = new System.Windows.Forms.ComboBox();
            this.LabelCron = new System.Windows.Forms.Label();
            this.ComboBoxLogs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonSetScheduler = new System.Windows.Forms.Button();
            this.ButtonClearScheduler = new System.Windows.Forms.Button();
            this.ButtonPath = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.LabelHistory = new System.Windows.Forms.Label();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextBoxPath = new System.Windows.Forms.TextBox();
            this.LabelPath = new System.Windows.Forms.Label();
            this.GroupBoxScheduler = new System.Windows.Forms.GroupBox();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.GroupBoxScheduler.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIconMain
            // 
            this.NotifyIconMain.Text = "Vetis Log Agent";
            this.NotifyIconMain.Visible = true;
            this.NotifyIconMain.Click += new System.EventHandler(this.NotifyIconMain_Click);
            // 
            // PanelMain
            // 
            this.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMain.Controls.Add(this.LabelPath);
            this.PanelMain.Controls.Add(this.TextBoxPath);
            this.PanelMain.Controls.Add(this.LabelHistory);
            this.PanelMain.Controls.Add(this.DataGridView);
            this.PanelMain.Controls.Add(this.ButtonPath);
            this.PanelMain.Controls.Add(this.ButtonSetScheduler);
            this.PanelMain.Controls.Add(this.ComboBoxLogs);
            this.PanelMain.Controls.Add(this.label1);
            this.PanelMain.Controls.Add(this.ComboBoxCron);
            this.PanelMain.Controls.Add(this.LabelCron);
            this.PanelMain.Controls.Add(this.ComboBoxRegions);
            this.PanelMain.Controls.Add(this.LabelRegions);
            this.PanelMain.Controls.Add(this.GroupBoxScheduler);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(2, 2);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(561, 307);
            this.PanelMain.TabIndex = 0;
            // 
            // LabelRegions
            // 
            this.LabelRegions.AutoSize = true;
            this.LabelRegions.Location = new System.Drawing.Point(12, 4);
            this.LabelRegions.Name = "LabelRegions";
            this.LabelRegions.Size = new System.Drawing.Size(47, 14);
            this.LabelRegions.TabIndex = 0;
            this.LabelRegions.Text = "Регион";
            // 
            // ComboBoxRegions
            // 
            this.ComboBoxRegions.FormattingEnabled = true;
            this.ComboBoxRegions.Items.AddRange(new object[] {
            "Регион 1",
            "Регион 2",
            "Регион 3",
            "Регион 4",
            "Регион 5"});
            this.ComboBoxRegions.Location = new System.Drawing.Point(12, 22);
            this.ComboBoxRegions.Name = "ComboBoxRegions";
            this.ComboBoxRegions.Size = new System.Drawing.Size(190, 22);
            this.ComboBoxRegions.TabIndex = 1;
            // 
            // ComboBoxCron
            // 
            this.ComboBoxCron.FormattingEnabled = true;
            this.ComboBoxCron.Items.AddRange(new object[] {
            "1 минута",
            "5 минут",
            "10 минут"});
            this.ComboBoxCron.Location = new System.Drawing.Point(12, 78);
            this.ComboBoxCron.Name = "ComboBoxCron";
            this.ComboBoxCron.Size = new System.Drawing.Size(190, 22);
            this.ComboBoxCron.TabIndex = 3;
            // 
            // LabelCron
            // 
            this.LabelCron.AutoSize = true;
            this.LabelCron.Location = new System.Drawing.Point(12, 60);
            this.LabelCron.Name = "LabelCron";
            this.LabelCron.Size = new System.Drawing.Size(117, 14);
            this.LabelCron.TabIndex = 2;
            this.LabelCron.Text = "Частота вызова API";
            // 
            // ComboBoxLogs
            // 
            this.ComboBoxLogs.ForeColor = System.Drawing.Color.Black;
            this.ComboBoxLogs.FormattingEnabled = true;
            this.ComboBoxLogs.Items.AddRange(new object[] {
            "1 минута",
            "5 минут",
            "10 минут"});
            this.ComboBoxLogs.Location = new System.Drawing.Point(12, 136);
            this.ComboBoxLogs.Name = "ComboBoxLogs";
            this.ComboBoxLogs.Size = new System.Drawing.Size(190, 22);
            this.ComboBoxLogs.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Частота сброса логов";
            // 
            // ButtonSetScheduler
            // 
            this.ButtonSetScheduler.FlatAppearance.BorderSize = 2;
            this.ButtonSetScheduler.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonSetScheduler.Location = new System.Drawing.Point(18, 198);
            this.ButtonSetScheduler.Name = "ButtonSetScheduler";
            this.ButtonSetScheduler.Size = new System.Drawing.Size(176, 23);
            this.ButtonSetScheduler.TabIndex = 6;
            this.ButtonSetScheduler.Text = "Установить задания";
            this.ButtonSetScheduler.UseVisualStyleBackColor = true;
            // 
            // ButtonClearScheduler
            // 
            this.ButtonClearScheduler.FlatAppearance.BorderSize = 2;
            this.ButtonClearScheduler.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonClearScheduler.Location = new System.Drawing.Point(6, 62);
            this.ButtonClearScheduler.Name = "ButtonClearScheduler";
            this.ButtonClearScheduler.Size = new System.Drawing.Size(176, 23);
            this.ButtonClearScheduler.TabIndex = 7;
            this.ButtonClearScheduler.Text = "Очистить все задания";
            this.ButtonClearScheduler.UseVisualStyleBackColor = true;
            // 
            // ButtonPath
            // 
            this.ButtonPath.FlatAppearance.BorderSize = 2;
            this.ButtonPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonPath.Location = new System.Drawing.Point(503, 21);
            this.ButtonPath.Name = "ButtonPath";
            this.ButtonPath.Size = new System.Drawing.Size(46, 23);
            this.ButtonPath.TabIndex = 8;
            this.ButtonPath.Text = "...";
            this.ButtonPath.UseVisualStyleBackColor = true;
            this.ButtonPath.Click += new System.EventHandler(this.ButtonPath_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateTime,
            this.Result});
            this.DataGridView.Location = new System.Drawing.Point(226, 78);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(323, 208);
            this.DataGridView.TabIndex = 10;
            // 
            // LabelHistory
            // 
            this.LabelHistory.AutoSize = true;
            this.LabelHistory.Location = new System.Drawing.Point(223, 60);
            this.LabelHistory.Name = "LabelHistory";
            this.LabelHistory.Size = new System.Drawing.Size(104, 14);
            this.LabelHistory.TabIndex = 11;
            this.LabelHistory.Text = "История вызовов";
            // 
            // DateTime
            // 
            this.DateTime.HeaderText = "Время отравки";
            this.DateTime.MinimumWidth = 150;
            this.DateTime.Name = "DateTime";
            this.DateTime.ReadOnly = true;
            this.DateTime.Width = 150;
            // 
            // Result
            // 
            this.Result.HeaderText = "Результат";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.Location = new System.Drawing.Point(226, 22);
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.Size = new System.Drawing.Size(271, 22);
            this.TextBoxPath.TabIndex = 12;
            // 
            // LabelPath
            // 
            this.LabelPath.AutoSize = true;
            this.LabelPath.Location = new System.Drawing.Point(223, 5);
            this.LabelPath.Name = "LabelPath";
            this.LabelPath.Size = new System.Drawing.Size(138, 14);
            this.LabelPath.TabIndex = 13;
            this.LabelPath.Text = "Путь к корневой папке";
            // 
            // GroupBoxScheduler
            // 
            this.GroupBoxScheduler.Controls.Add(this.ButtonClearScheduler);
            this.GroupBoxScheduler.Location = new System.Drawing.Point(12, 165);
            this.GroupBoxScheduler.Name = "GroupBoxScheduler";
            this.GroupBoxScheduler.Size = new System.Drawing.Size(190, 121);
            this.GroupBoxScheduler.TabIndex = 14;
            this.GroupBoxScheduler.TabStop = false;
            this.GroupBoxScheduler.Text = "Планировщик заданий";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 311);
            this.Controls.Add(this.PanelMain);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(581, 350);
            this.MinimumSize = new System.Drawing.Size(581, 350);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vetis Log";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.GroupBoxScheduler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIconMain;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Label LabelRegions;
        private System.Windows.Forms.ComboBox ComboBoxRegions;
        private System.Windows.Forms.ComboBox ComboBoxCron;
        private System.Windows.Forms.Label LabelCron;
        private System.Windows.Forms.ComboBox ComboBoxLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonSetScheduler;
        private System.Windows.Forms.Button ButtonClearScheduler;
        private System.Windows.Forms.Button ButtonPath;
        private System.Windows.Forms.Label LabelHistory;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.Label LabelPath;
        private System.Windows.Forms.TextBox TextBoxPath;
        private System.Windows.Forms.GroupBox GroupBoxScheduler;
    }
}

