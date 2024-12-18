﻿using System;
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

            lblFullname.Text = $"Welcome, {userFullName}!";
            LoadHome();
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
            openChildForm(new PromoModule()); // Suggested airport
        }


        public void LoadHome()
        {

            openChildForm(new PromoModule()); //Loload nya yung promo module sa home
        
        }

        private void btnSearchFlight_Click(object sender, EventArgs e)
        {
            openChildForm(new SearchFlightView()); //Searh for flight
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            HistoryView historyView = new HistoryView();
            openChildForm(historyView);
            
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            openChildForm(new BookView()); //Kapag magbobook na siya
        }

        private void btnLogoutUser_Click(object sender, EventArgs e)
        {
            // Confirm logout
            if (MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}
