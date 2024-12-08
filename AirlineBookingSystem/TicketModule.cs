using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AirlineBookingSystem
{
    public partial class TicketModule : Form
    {
        
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
                cbTravelClass.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert the booking reference into the database before proceeding to payment
            string insertBookingQuery = @"
                INSERT INTO PassengerDetails
                (Book_Ref, Book_Date, Firstname, Middlename, Lastname, Nationality, Contact_No, Gender, Departure_From, Arrival_To, Departure_Date, Seat_No, Travel_Class)
                VALUES (@book_ref, @book_date, @firstname, @middlename, @lastname, @nationality, @contact_no, @gender, @departure_from, @arrival_to, @departure_date, @seat_no, @travel_class)";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertBookingQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@book_ref", lblRefNo.Text); // Booking reference to be inserted
                        cmd.Parameters.AddWithValue("@book_date", lblDate.Text);
                        cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@middlename", string.IsNullOrWhiteSpace(txtMiddlename.Text) ? "N/A" : txtMiddlename.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastname", txtLastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@nationality", cbNationality.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@contact_no", long.TryParse(txtContact.Text.Trim(), out long contactN) ? contactN : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@departure_from", cbDeparture.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@arrival_to", cbArrival.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@departure_date", dtDeparture.Value);
                        cmd.Parameters.AddWithValue("@seat_no", cbPassengerSeat.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@travel_class", cbTravelClass.SelectedItem?.ToString());

                        cmd.ExecuteNonQuery(); // Execute the insert operation

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
                            cbTravelClass.SelectedItem.ToString());

                        // Proceed to the PaymentModule with the successfully inserted Book_Ref
                        PaymentModule paymentModule = new PaymentModule(lblRefNo.Text, lblTotalAmount.Text);
                        this.Hide();
                        if (paymentModule.ShowDialog() == DialogResult.OK)
                        {
                            // Only proceed to complete the transaction after payment is successful
                            MessageBox.Show("Booking and payment completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BookView bookView = new BookView();
                            bookView.Show();
                            
                        }
                        this.Close();
                    }
                }
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

        #region
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

        #endregion


        private void btnCancelBook_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTravelClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Define price ranges based on travel class
            Random random = new Random(); // To generate random prices within the range
            int baseFare = 0;
            int tax = 0;

            if (cbTravelClass.SelectedItem != null)
            {
                switch (cbTravelClass.SelectedItem.ToString())
                {
                    case "Economy Class":
                        baseFare = random.Next(1500, 5001); // 1500 - 5000 inclusive
                        tax = 1620;
                        break;
                    case "Premium Economy Class":
                        baseFare = random.Next(15000, 25001); // 15000 - 25000 inclusive
                        tax = 2200;
                        break;
                    case "Business Class":
                        baseFare = random.Next(50000, 100001); // 50000 - 30000 inclusive
                        tax = 2700;
                        break;
                    default:
                        baseFare = 0; // Default value if no valid class is selected
                        break;
                }

                // Display the calculated base fare
                lblBaseFare.Text = $"{baseFare:C}"; // Format as currency
                lblTax.Text = $"{tax:C}";

                decimal totalAmount = baseFare + tax;
                lblTotalAmount.Text = $"{totalAmount:C}";
            }
            else
            {
                lblBaseFare.Text = "Base Fare: Not Selected";
            }
        }
    }
}
