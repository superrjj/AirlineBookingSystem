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
        
     
        public LoadingScreen()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Start();
            
           

        }
        
        private void LoadingScreen_Load(object sender, EventArgs e)
        {
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Updating progress bar in loading screen
            if(loadingProgressBar1.Value<loadingProgressBar1.Max)
            {
                loadingProgressBar1.Value++;
                loadingProgressBar1.Refresh();
            }
            if(loadingProgressBar1.Value==loadingProgressBar1.Max)
            {
                timer1.Stop();
                Login login = new Login();
                login.Show();

                
                this.Hide();
            }
        }
    }
    }

