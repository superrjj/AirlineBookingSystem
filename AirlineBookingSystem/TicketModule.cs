using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public partial class TicketModule : Form
    {
        private List<string> unavailableSeats = new List<string>();
        private readonly BookView _parentForm;

       

        public TicketModule(BookView parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;

            // Set the current date
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // Generate booking reference
            lblRefNo.Text = GenerateBookingReference();
        }

        private string GenerateBookingReference()
        {
            // Generate a reference number starting with TR followed by 10 digits
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            return $"TR{timestamp.Substring(4)}"; // Using only last 10 digits for brevity
        }

        private void btnBook_Click(object sender, EventArgs e)
        {

            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFirstname.Text) ||
                string.IsNullOrWhiteSpace(txtLastname.Text) ||
                cbGender.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtContact.Text) ||
                cbPassengerSeat.SelectedItem == null ||
                cbDeparture.SelectedItem == null ||
                cbArrival.SelectedItem == null ||
                cbTravelClass.SelectedItem == null ||
                cbPayment.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                string.IsNullOrWhiteSpace(txtAccountNumber.Text) ||
                string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate contact number
            if (!long.TryParse(txtContact.Text.Trim(), out long contactNumber))
            {
                MessageBox.Show("Invalid contact number format. Please enter numeric values only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate amount
            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount))
            {
                MessageBox.Show("Invalid amount format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate and parse account number (assuming it's also numeric and fits in BIGINT)
            if (!long.TryParse(txtAccountNumber.Text.Trim(), out long accountNumber))
            {
                MessageBox.Show("Invalid account number format. Please enter numeric values only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Database query to insert the booking information
            string query = @"
            INSERT INTO PassengerInformation 
            (Book_Ref, Book_Date ,Firstname, Middlename, Lastname, Nationality, Contact_No, Gender, Departure_From, Arrival_To, Departure_Date, Seat_No, Travel_Class, Payment_Method, Account_Name, Account_Num, Amount)
            VALUES (@book_ref, @book_date, @firstname, @middlename, @lastname, @nationality, @contact_no, @gender, @departure_from, @arrival_to, @departure_date, @seat_no, @travel_class, @payment_method, @account_name, @account_num, @amount)";



            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            // Prepare parameters for PassengerInformation insert
                            cmd.Parameters.AddWithValue("@book_ref", lblRefNo.Text); // Assuming Booking Ref is available
                            cmd.Parameters.AddWithValue("@book_date", lblDate.Text);
                            cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text.Trim());
                            cmd.Parameters.AddWithValue("@middlename", string.IsNullOrWhiteSpace(txtMiddlename.Text) ? "N/A" : txtMiddlename.Text.Trim());
                            cmd.Parameters.AddWithValue("@lastname", txtLastname.Text.Trim());
                            cmd.Parameters.AddWithValue("@nationality", cbNationality.SelectedItem?.ToString() ?? "N/A");
                            cmd.Parameters.AddWithValue("@contact_no", long.TryParse(txtContact.Text.Trim(), out long contactN) ? contactNumber : (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem?.ToString() ?? "N/A");
                            cmd.Parameters.AddWithValue("@departure_from", cbDeparture.SelectedItem?.ToString() ?? "N/A");
                            cmd.Parameters.AddWithValue("@arrival_to", cbArrival.SelectedItem?.ToString() ?? "N/A");
                            cmd.Parameters.AddWithValue("@departure_date", dtDeparture.Value);
                            cmd.Parameters.AddWithValue("@seat_no", cbPassengerSeat.SelectedItem?.ToString());
                            cmd.Parameters.AddWithValue("@travel_class", cbTravelClass.SelectedItem?.ToString());

                            // Payment information parameters
                            cmd.Parameters.AddWithValue("@payment_method", cbPayment.SelectedItem?.ToString() ?? "N/A");
                            cmd.Parameters.AddWithValue("@account_name", txtAccountName.Text.Trim());
                            cmd.Parameters.AddWithValue("@account_num", txtAccountNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@amount", amount);

                            cmd.ExecuteNonQuery(); // Insert passenger information

                            // Call AddBookingToList method if needed (adjust as required)
                            _parentForm.AddNewBooking(
                                lblRefNo.Text,                            // Booking reference
                                DateTime.Now.ToString("yyyy-MM-dd"),      // Book date
                                $"{txtFirstname.Text.Trim()} {txtLastname.Text.Trim()}", // Full Name
                                txtContact.Text.Trim(),
                                cbGender.SelectedItem.ToString(),
                                cbNationality.SelectedItem.ToString(),
                                cbDeparture.SelectedItem.ToString(),
                                cbArrival.SelectedItem.ToString(),
                                dtDeparture.Value.ToShortDateString(),
                                cbPassengerSeat.SelectedItem.ToString(),
                                cbTravelClass.SelectedItem.ToString()
                            );

                            // Clear fields after booking
                            ClearFields();

                            MessageBox.Show("Booking successfully completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
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

        private void ClearFields()
        {
            txtFirstname.Text = "";
            txtMiddlename.Text = "";
            txtLastname.Text = "";
            txtContact.Text = "";
            cbPassengerSeat.SelectedIndex = -1;
            cbArrival.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            cbDeparture.SelectedIndex = -1;
            cbNationality.SelectedIndex = -1;
            cbTravelClass.SelectedIndex = -1;
            txtAccountName.Text = "";
            txtAccountNumber.Text = "";
            cbPayment.SelectedIndex = -1;
        }

        private void TicketModule_Load(object sender, EventArgs e)
        {
            // Populate cbPassengerSeat with seat labels (A1 to D10)
            for (char row = 'A'; row <= 'D'; row++) // Rows A to D
            {
                for (int number = 1; number <= 10; number++) // Numbers 1 to 10
                {
                    string seat = $"{row}{number}";
                    cbPassengerSeat.Items.Add(seat); // Add seat label (e.g., A1, B5, D10)
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbPassengerSeat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
        private void label28_Click(object sender, EventArgs e) { }
        private void label22_Click(object sender, EventArgs e) { }



        private void btnCancelBook_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
