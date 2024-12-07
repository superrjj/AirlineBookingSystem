using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AirlineBookingSystem
{
    public partial class LoadingScreen : Form
    {
        private Timer delayTimer;
     
        public LoadingScreen()
        {
            InitializeComponent();

            
            delayTimer = new Timer();
            delayTimer.Interval = 6000; 
            delayTimer.Tick += DelayTimer_Tick;

        }
        //Update new loading screen gif
        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            delayTimer.Start();
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
          
            delayTimer.Stop();

            
            pictureBox1.Visible = false;

          
            PerformLogin();
        }

        private void PerformLogin()
        {
            
            Login login = new Login();
            login.Show();

            
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //The animation method.
        }
        }
    }

