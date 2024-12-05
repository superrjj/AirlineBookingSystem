using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class UserDashboard : Form
    {
        private string userFullName;
        public UserDashboard(string fullName)
        {
            InitializeComponent();
            userFullName = fullName;
            LoadHome();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblFullname.Text = "Welcome, " + userFullName + "!";
        }

        private void closeIcon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            userPanel.Controls.Add(childForm);
            userPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new PromoModule());
        }

       

        private void btnMyFlight_Click_1(object sender, EventArgs e)
        {
            PersonalInformation pi = new PersonalInformation();
            pi.Show();
            
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            openChildForm(new PromoModule());
        }

        public void LoadHome()
        {

            openChildForm(new PromoModule());
        
        }


    }
}
