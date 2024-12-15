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
    public partial class CreateAccount : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private bool IsValidUsername(string username)
        {
            // Regular expression to match a username with letters, numbers, underscores, dashes, and periods
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_.-]+$");
            return regex.IsMatch(username);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string fullName = txtFullname.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate the username
            if (!IsValidUsername(username))
            {
                MessageBox.Show("Username can only contain letters, numbers, underscores (_), dashes (-), and periods (.)", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password does not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                connect.Open();

                // Check if the username already exists
                string checkQuery = "SELECT COUNT(*) FROM UserAccount WHERE username = @username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connect);
                checkCmd.Parameters.AddWithValue("@username", username);
                int userCount = (int)checkCmd.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists, please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Insert the new user into the database
                    string insertQuery = "INSERT INTO UserAccount (fullName, username, password) VALUES (@fullname, @username, @password)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, connect);
                    insertCmd.Parameters.AddWithValue("@fullname", fullName);
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", password);

                    int result = insertCmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Registered successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login = new Login();
                        login.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string strengthMessage;
            Color strengthColor;

            if (password.Length < 6)
            {
                strengthMessage = "Password is too short (min 6 characters)";
                strengthColor = Color.Red;
            }
            else if (!HasUpperCase(password) || !HasLowerCase(password) || !HasDigit(password))
            {
                strengthMessage = "Password should include uppercase, lowercase, and a number";
                strengthColor = Color.Orange;
            }
            else
            {
                strengthMessage = "Strong password";
                strengthColor = Color.Green;
            }

            lblPassword.Text = strengthMessage;
            lblPassword.ForeColor = strengthColor;
        }

        private bool HasUpperCase(string input) => input.Any(char.IsUpper);
        private bool HasLowerCase(string input) => input.Any(char.IsLower);
        private bool HasDigit(string input) => input.Any(char.IsDigit);
    }
}