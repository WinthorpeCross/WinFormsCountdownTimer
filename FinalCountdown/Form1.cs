using System;
using System.Windows.Forms;

namespace FinalCountdown
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int counter = 30;
        private int standardWrapUpTime = 30;

        public Form1()
        {
            InitializeComponent();
            btnExtend.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer.Stop();
                btnExtend.Enabled = false;
            }

            lblStatus.Text = string.Format("You have {0} seconds call wrap-up time remaining...", counter); 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer = new Timer() { Interval = 1000 };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            lblStatus.Text = string.Format("You have been allocated {0} seconds call wrap-up time...", standardWrapUpTime);
            btnExtend.Enabled = true;
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (counter != 0)
            {
                counter = counter + standardWrapUpTime;
            }
        }
    }
}
