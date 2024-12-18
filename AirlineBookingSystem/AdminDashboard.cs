﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AirlineBookingSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            LoadFlight();
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
            adminPanel.Controls.Add(childForm);
            adminPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.adminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminFlightView());
        }

        public void LoadFlight()
        {
            openChildForm(new AdminFlightView());
        }

        private void btnLogoutAdmin_Click(object sender, EventArgs e)
        {
            // Confirm logout
            if (MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
        }

        private void btnPassenger_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminViewPassenger());
        }

        private void closeIcon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCancellation_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminViewCancellation());
        }

        private void btnArchived_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminViewArchive());
        }
    }
}
