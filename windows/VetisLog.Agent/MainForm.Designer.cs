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
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.GroupBoxScheduler = new System.Windows.Forms.GroupBox();
            this.ComboBoxCron = new System.Windows.Forms.ComboBox();
            this.LabelCron = new System.Windows.Forms.Label();
            this.ComboBoxRegions = new System.Windows.Forms.ComboBox();
            this.LabelRegions = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ContextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerLoadInfo = new System.Windows.Forms.Timer(this.components);
            this.PanelMain.SuspendLayout();
            this.GroupBoxScheduler.SuspendLayout();
            this.ContextMenuStripMain.SuspendLayout();
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
            this.PanelMain.Controls.Add(this.textBoxLog);
            this.PanelMain.Controls.Add(this.GroupBoxScheduler);
            this.PanelMain.Controls.Add(this.groupBox1);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(2, 2);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(561, 307);
            this.PanelMain.TabIndex = 0;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(224, 27);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(329, 269);
            this.textBoxLog.TabIndex = 15;
            // 
            // GroupBoxScheduler
            // 
            this.GroupBoxScheduler.Controls.Add(this.ComboBoxCron);
            this.GroupBoxScheduler.Controls.Add(this.LabelCron);
            this.GroupBoxScheduler.Controls.Add(this.ComboBoxRegions);
            this.GroupBoxScheduler.Controls.Add(this.LabelRegions);
            this.GroupBoxScheduler.Location = new System.Drawing.Point(12, 5);
            this.GroupBoxScheduler.Name = "GroupBoxScheduler";
            this.GroupBoxScheduler.Size = new System.Drawing.Size(198, 291);
            this.GroupBoxScheduler.TabIndex = 14;
            this.GroupBoxScheduler.TabStop = false;
            this.GroupBoxScheduler.Text = "Планировщик";
            // 
            // ComboBoxCron
            // 
            this.ComboBoxCron.FormattingEnabled = true;
            this.ComboBoxCron.Location = new System.Drawing.Point(6, 99);
            this.ComboBoxCron.Name = "ComboBoxCron";
            this.ComboBoxCron.Size = new System.Drawing.Size(176, 22);
            this.ComboBoxCron.TabIndex = 3;
            // 
            // LabelCron
            // 
            this.LabelCron.AutoSize = true;
            this.LabelCron.Location = new System.Drawing.Point(6, 79);
            this.LabelCron.Name = "LabelCron";
            this.LabelCron.Size = new System.Drawing.Size(117, 14);
            this.LabelCron.TabIndex = 2;
            this.LabelCron.Text = "Частота вызова API";
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
            this.ComboBoxRegions.Location = new System.Drawing.Point(6, 44);
            this.ComboBoxRegions.Name = "ComboBoxRegions";
            this.ComboBoxRegions.Size = new System.Drawing.Size(176, 22);
            this.ComboBoxRegions.TabIndex = 1;
            // 
            // LabelRegions
            // 
            this.LabelRegions.AutoSize = true;
            this.LabelRegions.Location = new System.Drawing.Point(6, 25);
            this.LabelRegions.Name = "LabelRegions";
            this.LabelRegions.Size = new System.Drawing.Size(47, 14);
            this.LabelRegions.TabIndex = 0;
            this.LabelRegions.Text = "Регион";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(217, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 293);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Лог вызовов";
            // 
            // ContextMenuStripMain
            // 
            this.ContextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestoreToolStripMenuItem,
            this.CloseToolStripMenuItem});
            this.ContextMenuStripMain.Name = "ContextMenuStripMain";
            this.ContextMenuStripMain.Size = new System.Drawing.Size(150, 48);
            // 
            // RestoreToolStripMenuItem
            // 
            this.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem";
            this.RestoreToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.RestoreToolStripMenuItem.Text = "Восстановить";
            this.RestoreToolStripMenuItem.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.CloseToolStripMenuItem.Text = "Закрыть";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // timerLoadInfo
            // 
            this.timerLoadInfo.Interval = 1000;
            this.timerLoadInfo.Tick += new System.EventHandler(this.timerLoadInfo_Tick);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.GroupBoxScheduler.ResumeLayout(false);
            this.GroupBoxScheduler.PerformLayout();
            this.ContextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIconMain;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Label LabelRegions;
        private System.Windows.Forms.ComboBox ComboBoxRegions;
        private System.Windows.Forms.ComboBox ComboBoxCron;
        private System.Windows.Forms.Label LabelCron;
        private System.Windows.Forms.GroupBox GroupBoxScheduler;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem RestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.Timer timerLoadInfo;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

