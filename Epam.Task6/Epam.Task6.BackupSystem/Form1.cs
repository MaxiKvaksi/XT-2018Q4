using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task6.BackupSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void ButtonChooseCurrentPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogCurrentPath.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            BackupManager.CurrentPath = folderBrowserDialogCurrentPath.SelectedPath;
            textBoxCurrentPath.Text = BackupManager.CurrentPath;
            watchingModeButton.Enabled = true;
            recoveryModeButton.Enabled = true;
        }

        private void WatchingModeButton_Click(object sender, EventArgs e)
        {
            if (FileHelper.BackUpFileExists())
            {
                DialogResult dialogResult = MessageBox.Show("Backup file already exist in chosen folder. Use its?", "Backup file", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    FileHelper.CreateBackUpFile();
                }
            }
            else
            {
                FileHelper.CreateBackUpFile();
            }

            recoveryModeButton.Enabled = false;
            buttonChooseCurrentPath.Enabled = false;
            panelWatching.Enabled = true;
            watchingModeButton.Enabled = false;
            panelRecovery.Enabled = false;
            BackupManager.Watch();
        }

        private void RecoveryModeButton_Click(object sender, EventArgs e)
        {
            buttonChooseCurrentPath.Enabled = false;
            panelRecovery.Enabled = true;
            if (FileHelper.BackUpFileExists())
            {
                BackupManager.ParseChanges();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Backup file not exist in chosen folder.", "Backup file", MessageBoxButtons.OK);
            }

            BackupManager.LastBackupTime = DateTime.Now;
        }

        private void ButtonStopWatch_Click(object sender, EventArgs e)
        {
            recoveryModeButton.Enabled = true;
            buttonChooseCurrentPath.Enabled = true;
            panelWatching.Enabled = false;
            watchingModeButton.Enabled = true;
            BackupManager.StopWatch();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            DateTime time = dateTimePicker2.Value;
            DateTime dateTime = new DateTime(
                date.Year, 
                date.Month, 
                date.Day, 
                time.Hour, 
                time.Minute, 
                time.Second);
            BackupManager.RestoreFiles(dateTime);
        }
    }
}
