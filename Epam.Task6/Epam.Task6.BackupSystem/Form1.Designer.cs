namespace Epam.Task6.BackupSystem
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.watchingModeButton = new System.Windows.Forms.Button();
            this.recoveryModeButton = new System.Windows.Forms.Button();
            this.panelWatching = new System.Windows.Forms.Panel();
            this.labelCurrentPath = new System.Windows.Forms.Label();
            this.textBoxCurrentPath = new System.Windows.Forms.TextBox();
            this.buttonChooseCurrentPath = new System.Windows.Forms.Button();
            this.folderBrowserDialogCurrentPath = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonStopWatch = new System.Windows.Forms.Button();
            this.panelRecovery = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTimePicker = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttonSaveRecoveryChanges = new System.Windows.Forms.Button();
            this.panelWatching.SuspendLayout();
            this.panelRecovery.SuspendLayout();
            this.SuspendLayout();
            // 
            // watchingModeButton
            // 
            this.watchingModeButton.Enabled = false;
            this.watchingModeButton.Location = new System.Drawing.Point(34, 93);
            this.watchingModeButton.Name = "watchingModeButton";
            this.watchingModeButton.Size = new System.Drawing.Size(103, 35);
            this.watchingModeButton.TabIndex = 0;
            this.watchingModeButton.Text = "Watching mode";
            this.watchingModeButton.UseVisualStyleBackColor = true;
            this.watchingModeButton.Click += new System.EventHandler(this.watchingModeButton_Click);
            // 
            // recoveryModeButton
            // 
            this.recoveryModeButton.Enabled = false;
            this.recoveryModeButton.Location = new System.Drawing.Point(34, 165);
            this.recoveryModeButton.Name = "recoveryModeButton";
            this.recoveryModeButton.Size = new System.Drawing.Size(103, 35);
            this.recoveryModeButton.TabIndex = 1;
            this.recoveryModeButton.Text = "Recovery mode";
            this.recoveryModeButton.UseVisualStyleBackColor = true;
            this.recoveryModeButton.Click += new System.EventHandler(this.recoveryModeButton_Click);
            // 
            // panelWatching
            // 
            this.panelWatching.Controls.Add(this.buttonStopWatch);
            this.panelWatching.Enabled = false;
            this.panelWatching.Location = new System.Drawing.Point(156, 62);
            this.panelWatching.Name = "panelWatching";
            this.panelWatching.Size = new System.Drawing.Size(213, 75);
            this.panelWatching.TabIndex = 2;
            // 
            // labelCurrentPath
            // 
            this.labelCurrentPath.AutoSize = true;
            this.labelCurrentPath.Location = new System.Drawing.Point(12, 11);
            this.labelCurrentPath.Name = "labelCurrentPath";
            this.labelCurrentPath.Size = new System.Drawing.Size(63, 13);
            this.labelCurrentPath.TabIndex = 4;
            this.labelCurrentPath.Text = "Folder path:";
            // 
            // textBoxCurrentPath
            // 
            this.textBoxCurrentPath.Enabled = false;
            this.textBoxCurrentPath.Location = new System.Drawing.Point(12, 27);
            this.textBoxCurrentPath.Name = "textBoxCurrentPath";
            this.textBoxCurrentPath.Size = new System.Drawing.Size(287, 20);
            this.textBoxCurrentPath.TabIndex = 5;
            // 
            // buttonChooseCurrentPath
            // 
            this.buttonChooseCurrentPath.Location = new System.Drawing.Point(306, 27);
            this.buttonChooseCurrentPath.Name = "buttonChooseCurrentPath";
            this.buttonChooseCurrentPath.Size = new System.Drawing.Size(63, 23);
            this.buttonChooseCurrentPath.TabIndex = 6;
            this.buttonChooseCurrentPath.Text = "Choose";
            this.buttonChooseCurrentPath.UseVisualStyleBackColor = true;
            this.buttonChooseCurrentPath.Click += new System.EventHandler(this.buttonChooseCurrentPath_Click);
            // 
            // buttonStopWatch
            // 
            this.buttonStopWatch.Location = new System.Drawing.Point(59, 19);
            this.buttonStopWatch.Name = "buttonStopWatch";
            this.buttonStopWatch.Size = new System.Drawing.Size(104, 23);
            this.buttonStopWatch.TabIndex = 0;
            this.buttonStopWatch.Text = "Stop watching";
            this.buttonStopWatch.UseVisualStyleBackColor = true;
            this.buttonStopWatch.Click += new System.EventHandler(this.buttonStopWatch_Click);
            // 
            // panelRecovery
            // 
            this.panelRecovery.Controls.Add(this.buttonSaveRecoveryChanges);
            this.panelRecovery.Controls.Add(this.dateTimePicker2);
            this.panelRecovery.Controls.Add(this.button1);
            this.panelRecovery.Controls.Add(this.labelTimePicker);
            this.panelRecovery.Controls.Add(this.dateTimePicker1);
            this.panelRecovery.Enabled = false;
            this.panelRecovery.Location = new System.Drawing.Point(156, 144);
            this.panelRecovery.Name = "panelRecovery";
            this.panelRecovery.Size = new System.Drawing.Size(213, 138);
            this.panelRecovery.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Recovery";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelTimePicker
            // 
            this.labelTimePicker.AutoSize = true;
            this.labelTimePicker.Location = new System.Drawing.Point(6, 21);
            this.labelTimePicker.Name = "labelTimePicker";
            this.labelTimePicker.Size = new System.Drawing.Size(157, 13);
            this.labelTimePicker.TabIndex = 7;
            this.labelTimePicker.Text = "Choose recovery date and time:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 65);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(3, 39);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // buttonSaveRecoveryChanges
            // 
            this.buttonSaveRecoveryChanges.Location = new System.Drawing.Point(111, 91);
            this.buttonSaveRecoveryChanges.Name = "buttonSaveRecoveryChanges";
            this.buttonSaveRecoveryChanges.Size = new System.Drawing.Size(75, 44);
            this.buttonSaveRecoveryChanges.TabIndex = 10;
            this.buttonSaveRecoveryChanges.Text = "Save to backup file";
            this.buttonSaveRecoveryChanges.UseVisualStyleBackColor = true;
            this.buttonSaveRecoveryChanges.Click += new System.EventHandler(this.buttonSaveRecoveryChanges_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 363);
            this.Controls.Add(this.panelRecovery);
            this.Controls.Add(this.buttonChooseCurrentPath);
            this.Controls.Add(this.textBoxCurrentPath);
            this.Controls.Add(this.labelCurrentPath);
            this.Controls.Add(this.panelWatching);
            this.Controls.Add(this.recoveryModeButton);
            this.Controls.Add(this.watchingModeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelWatching.ResumeLayout(false);
            this.panelRecovery.ResumeLayout(false);
            this.panelRecovery.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button watchingModeButton;
        private System.Windows.Forms.Button recoveryModeButton;
        private System.Windows.Forms.Panel panelWatching;
        private System.Windows.Forms.Label labelCurrentPath;
        private System.Windows.Forms.TextBox textBoxCurrentPath;
        private System.Windows.Forms.Button buttonChooseCurrentPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogCurrentPath;
        private System.Windows.Forms.Button buttonStopWatch;
        private System.Windows.Forms.Panel panelRecovery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTimePicker;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button buttonSaveRecoveryChanges;
    }
}

