using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using NLog;
using VetisLog.Agent.Code;
using VetisLog.Agent.Properties;

namespace VetisLog.Agent
{
    public partial class MainForm : Form
    {
        private readonly ReestrHelper _reestr = new ReestrHelper();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static readonly List<string> Lines = new List<string>();

        public MainForm()
        {
            InitializeComponent();

            NotifyIconMain.Icon = Resources.NotifyIcon;
            ComboBoxRegions.DataSource =
                Dictionary.GetRegions()
                    .OrderBy(x => x.Id)
                    .ToList();

            ComboBoxRegions.DisplayMember = "Name";
            ComboBoxRegions.ValueMember = "Id";
            ComboBoxRegions.DropDownStyle = ComboBoxStyle.DropDownList;


            var minutes = new[]
            {
                new {Id = "1", Name = "1 минута"},
                new {Id = "5", Name = "5 минут"},
                new {Id = "10", Name = "10 минут"},
                new {Id = "20", Name = "20 минут"}
            };

            ComboBoxCron.DataSource = minutes.ToList();
            ComboBoxCron.DisplayMember = "Name";
            ComboBoxCron.ValueMember = "Id";
            ComboBoxCron.DropDownStyle = ComboBoxStyle.DropDownList;

            CallApi();

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    NotifyIconMain.Visible = true;
                    Hide();
                    break;
                case FormWindowState.Normal:
                    NotifyIconMain.Visible = false;
                    break;
                case FormWindowState.Maximized:
                    break;
                default:
                    break;
            }
        }

        private void NotifyIconMain_Click(object sender, EventArgs e)
        {
            ContextMenuStripMain.Show(this, Control.MousePosition);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();


            _reestr.Write("region", ComboBoxRegions.SelectedValue);
            _reestr.Write("cron_frequency", ComboBoxCron.SelectedValue);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var regionCode = _reestr.Read("region")?.ToString() ?? "Unknown";
            var cronFrequency = _reestr.Read("cron_frequency")?.ToString() ?? "10";

            ComboBoxRegions.SelectedValue = regionCode;
            ComboBoxCron.SelectedValue = cronFrequency;

            switch (cronFrequency)
            {
                case "1":
                    timerLoadInfo.Interval = 1000 * 60;
                    break;
                case "5":
                    timerLoadInfo.Interval = 1000 * 60 * 5;
                    break;
                case "10":
                    timerLoadInfo.Interval = 1000 * 60 * 10;
                    break;
                case "20":
                    timerLoadInfo.Interval = 1000 * 60 * 20;
                    break;
                default:
                    timerLoadInfo.Interval = 1000;
                    break;
            }

            timerLoadInfo.Start();
        }

        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "Вы подтверждаете завершение работы приложения?";
            const string caption = "Завершение работы";
            var result = MessageBox.Show(message, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }



        public void ShowError(string text, string caption)
        {
            text = (text ?? string.Empty).Trim();
            caption = (caption ?? string.Empty).Trim();
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string text, string caption)
        {
            text = (text ?? string.Empty).Trim();
            caption = (caption ?? string.Empty).Trim();
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timerLoadInfo_Tick(object sender, EventArgs e)
        {
            CallApi();
        }

        public void CallApi()
        {
            if (Lines.Count > 1000)
            {
                Lines.RemoveAt(0);
            }

            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                var vetisLog = new VetisLog();
                var result = vetisLog.Ping();
                Lines.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - OK, http status={result.HttpStatus}" +
                          (!string.IsNullOrEmpty(result.Error) ? $", error ={result.Error}" : "") +
                          Environment.NewLine);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                Lines.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Error: {ex.Message}" + Environment.NewLine);
            }

            textBoxLog.Lines = Lines.ToArray();
        }
    }
}

