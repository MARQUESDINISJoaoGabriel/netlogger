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

        private PictureBox animatedImageBox;

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
            this.ForeColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Courier New", 12, FontStyle.Bold);

            statusLabel = new Label
            {
                Text = "Starting...",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 50
            };
            this.Controls.Add(statusLabel);

            animatedImageBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile("Resources/input-onlinegiftools.gif")
            };
            this.Controls.Add(animatedImageBox);

            ResizeAnimatedImage();

            this.Resize += (s, e) => ResizeAnimatedImage();

            stageTimer = new System.Windows.Forms.Timer
            {
                Interval = 2000
            };
            stageTimer.Tick += StageTimer_Tick;
            stageTimer.Start();
        }

        private void ResizeAnimatedImage()
        {
            if (animatedImageBox.Image == null) return;

            double scale = 0.45;
            int width = (int)(this.ClientSize.Width * scale);
            int height = (int)(animatedImageBox.Image.Height * (width / (double)animatedImageBox.Image.Width));

            animatedImageBox.Size = new Size(width, height);

            animatedImageBox.Location = new Point(
                (this.ClientSize.Width - animatedImageBox.Width) / 2,
                (this.ClientSize.Height - animatedImageBox.Height) / 2 - 50
            );
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
