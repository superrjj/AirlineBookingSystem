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
    public partial class TicketModule : Form
    {

       
        SqlConnection connect = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
       


        public TicketModule()
        {
            InitializeComponent();
           
          

        }
        
        //GTA
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate all required fields
                if (string.IsNullOrWhiteSpace(txtFirstname.Text) ||
                    string.IsNullOrWhiteSpace(txtLastname.Text) ||
                    cbGender.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtContact.Text))
                {
                    MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If everything is valid, proceed with the registration process
                if (MessageBox.Show("Are you sure you want to save this address?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(dbcon.myConnection()))
                    {
                        connect.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO User_Information(firstname, middlename, lastname, age, status, nationality, contact_no, gender, birthday, address, postal_code) " +
                                                              "VALUES (@firstname, @middlename, @lastname, @age, @status, @nationality, @contact_no, @gender, @birthday, @address, @postal_code)", connect))
                        {
                            // Add parameters for all fields
                            cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text);
                            cmd.Parameters.AddWithValue("@middlename", txtMiddlename.Text);
                            cmd.Parameters.AddWithValue("@lastname", txtLastname.Text);
                            cmd.Parameters.AddWithValue("@nationality", cbNationality.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@contact_no", txtContact.Text);
                            cmd.Parameters.AddWithValue("@gender", cbGender.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@birthday", dtBirthday.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Address has been successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
