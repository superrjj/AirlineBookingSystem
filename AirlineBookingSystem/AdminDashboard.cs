using System;
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

        }
    }
}
