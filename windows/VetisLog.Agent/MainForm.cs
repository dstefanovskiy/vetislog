using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using VetisLog.Agent.Properties;

namespace VetisLog.Agent
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            NotifyIconMain.Icon = Resources.NotifyIcon;
            TextBoxPath.Text = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            TextBoxPath.ReadOnly = true;
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

            Show();
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ButtonPath_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog
            {
                SelectedPath = TextBoxPath.Text
            };
            var dialogResult = dlg.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                TextBoxPath.Text = dlg.SelectedPath;
            }
        }
    }
}
