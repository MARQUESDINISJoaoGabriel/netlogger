using System;
using System.Drawing;
using System.Windows.Forms;

namespace netlogger
{
    public class MainForm : Form
    {
        private Label statusLabel;
        private System.Windows.Forms.Timer stageTimer;
        private int stageIndex = 0;

        private string[] stages = new string[]
        {
            "Wiring...",
            "Fetching modem...",
            "Routing...",
            "Initializing...",
            "Connecting to network...",
            "Tunneling...",
            "You are now online."
        };

        public MainForm()
        {

            this.Text = "netlogger";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.FromArgb(65, 65, 65);
            this.ForeColor = Color.FromArgb(245, 245, 245); ;
            this.Font = new Font("Courier New", 12, FontStyle.Bold);

            statusLabel = new Label();
            statusLabel.Text = "Starting...";
            statusLabel.AutoSize = false;
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Dock = DockStyle.Bottom;
            statusLabel.Height = 50;
            this.Controls.Add(statusLabel);

            stageTimer = new System.Windows.Forms.Timer();
            stageTimer.Interval = 2000;
            stageTimer.Tick += StageTimer_Tick;
            stageTimer.Start();
        }
                
        private void StageTimer_Tick(object? sender, EventArgs e)
        {
            if (stageIndex < stages.Length)
            {
                statusLabel.Text = stages[stageIndex];
                stageIndex++;
            }
            else
            {
                stageTimer.Stop();
                this.Text = "netlogger - Online";
            }
        }
    }
}
