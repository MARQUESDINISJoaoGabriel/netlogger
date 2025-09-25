using System;
using System.Drawing;
using System.Windows.Forms;

namespace netlogger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            this.Text = "netlogger";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.FromArgb(65, 65, 65);
            this.ForeColor = Color.FromArgb(245, 245, 245);; 
            this.Font = new Font("Courier New", 12);
        }
    }
}
