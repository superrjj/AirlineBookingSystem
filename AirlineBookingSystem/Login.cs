using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineBookingSystem
{

    public partial class Login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\INIMAF\Downloads\Group-3 System\AirlineBookingSystem\AirlineBookingSystem\AirlineBookingDB.mdf"";Integrated Security=True");
        public Login()
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
            txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        private void lblCreateOne_Click(object sender, EventArgs e)
        {
            CreateAccount create = new CreateAccount();
            create.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    // Query to validate the username and password
                    string selectData = "SELECT fullName FROM Account WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

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
                            MessageBox.Show("Incorrect Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
