using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class Login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

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

            try
            {
                connect.Open();

                string query = "SELECT fullName FROM UserAccount WHERE username = @username AND password = @password";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string fullName = result.ToString();
                        MessageBox.Show("Logged In Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lblAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin admin = new AdminLogin();
            admin.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}
