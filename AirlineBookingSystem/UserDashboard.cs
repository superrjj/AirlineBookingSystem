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
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new HomeModule());
        }

        private void btnMyFlight_Click(object sender, EventArgs e)
        {
            openChildForm(new Booked_History());
            PersonalInformation myFlightDashboard = new PersonalInformation();
            myFlightDashboard.ShowDialog();

        }
    }
}
