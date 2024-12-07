using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace AirlineBookingSystem
{
    public partial class TicketModule : Form
    {
        private readonly BookView _parentForm;

        public TicketModule(BookView parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form when cancel button is clicked
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFirstname.Text) ||
                string.IsNullOrWhiteSpace(txtLastname.Text) ||
                cbGender.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtNumberSeats.Text) ||
                cbDeparture.SelectedItem == null ||
                cbArrival.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"INSERT INTO PassengerInformation 
                            (Firstname, Middlename, Lastname, Nationality, Contact_No, Gender, Departure_From, Arrival_To, Departure_Date, Number_Seats) 
                            VALUES (@firstname, @middlename, @lastname, @nationality, @contact_no, @gender, @departure_from, @arrival_to, @departure_date, @number_seats)";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Prepare parameters
                        cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@middlename", string.IsNullOrWhiteSpace(txtMiddlename.Text) ? "N/A" : txtMiddlename.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastname", txtLastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@nationality", cbNationality.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@contact_no", Convert.ToInt64(txtContact.Text.Trim()));
                        cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@departure_from", cbDeparture.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@arrival_to", cbArrival.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@departure_date", dtDeparture.Value);
                        cmd.Parameters.AddWithValue("@number_seats", Convert.ToInt32(txtNumberSeats.Text.Trim()));

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Add the new booking to the BookView's booking list
                        _parentForm.AddNewBooking(
                            txtFirstname.Text.Trim() + " " + txtMiddlename.Text.Trim() + " " + txtLastname.Text.Trim(),
                            txtContact.Text.Trim(), cbGender.SelectedItem.ToString(),
                            cbNationality.SelectedItem.ToString(), cbDeparture.SelectedItem.ToString(),
                            cbArrival.SelectedItem.ToString(), dtDeparture.Value.ToString("yyyy-MM-dd"),
                            txtNumberSeats.Text.Trim());

                        // Clear fields after booking
                        txtFirstname.Text = "";
                        txtMiddlename.Text = "";
                        txtLastname.Text = "";
                        txtContact.Text = "";
                        txtNumberSeats.Text = "";
                        cbArrival.SelectedIndex = -1;
                        cbGender.SelectedIndex = -1;
                        cbDeparture.SelectedIndex = -1;
                        cbNationality.SelectedIndex = -1;

                        MessageBox.Show("Booking successfully completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid data format: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
