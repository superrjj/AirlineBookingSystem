using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class AdminLogin : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtAdminPassword.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtAdminName.Text) || string.IsNullOrWhiteSpace(txtAdminPassword.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check for admin credentials first
            if (txtAdminName.Text == "Admin01" && txtAdminPassword.Text == "adminpass")
            {
                // If admin credentials match, show the admin dashboard or perform admin-specific actions
                MessageBox.Show("Logged in as Admin", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Admin dashboard or special action
                AdminDashboard adminDash = new AdminDashboard();  // Assuming you have an AdminDashboard form
                adminDash.Show();
                this.Hide();
                return;
            }

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    // Query to validate the username and password
                    string selectData = "SELECT fullName FROM AdminAccount WHERE admin_name = @admin_name AND admin_password = @Admin_password";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@admin_name", txtAdminName.Text);
                        cmd.Parameters.AddWithValue("@admin_password", txtAdminPassword.Text);

                        object result = cmd.ExecuteScalar();

                        if (result != null) // User found
                        {
                            string fullName = result.ToString(); // Get the full name

                            MessageBox.Show("Logged In Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Pass the full name to the Dashboard
                            UserDashboard dash = new UserDashboard(fullName);
                            dash.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Admin Name/Admin Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Connecting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

            }
        }
    }
}
