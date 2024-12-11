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
        public bool IsEditMode { get; private set; } = false;
        private string OriginalBookingRef;
       

     

        public TicketModule(BookView parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            

            // Set the current date
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // Generate booking reference
            lblRefNo.Text = GenerateBookingReference();

        }

        // Constructor for editing existing bookings
        public TicketModule(BookView parentForm, string bookRef, string bookDate, string fullName, string contact, string gender,
                       string nationality, string departureFrom, string arrivalTo, DateTime departureDate,
                       string seatNo, string travelClass)
                       : this(parentForm)
        {
            // If editing an existing booking, disable btnNext
            if (IsEditMode)
            {
                btnNext.Enabled = true;
                btnUpdate.Enabled = false;  // Enable Update button only when editing
            }
            else
            {
                btnNext.Enabled = false;  // Enable Next button only for new bookings
                btnUpdate.Enabled = true;
            }

            // Set the OriginalBookingRef for update functionality
            OriginalBookingRef = bookRef;

            // Now, set all the fields to display the existing booking details
            lblRefNo.Text = bookRef;
            lblDate.Text = bookDate;

            // Split the full name into parts
            string[] nameParts = fullName.Split(' ');

            // Assign first, middle, and last names (if available)
            txtFirstname.Text = nameParts[0]; // First name
            if (nameParts.Length > 2)
            {
                txtMiddlename.Text = nameParts[1]; // Middle name
                txtLastname.Text = nameParts[2];  // Last name
            }
            else if (nameParts.Length > 1)
            {
                txtLastname.Text = nameParts[1]; // If only first and last names exist
            }

            txtContact.Text = contact;
            cbGender.SelectedItem = gender;
            cbNationality.SelectedItem = nationality;
            cbDeparture.SelectedItem = departureFrom;
            cbArrival.SelectedItem = arrivalTo;
            dtDeparture.Value = departureDate;
            cbPassengerSeat.SelectedItem = seatNo;
            cbTravelClass.SelectedItem = travelClass;

            // Ensure cbPassengerSeat is populated before selecting
            if (cbPassengerSeat.Items.Count == 0)
            {
                for (char row = 'A'; row <= 'D'; row++) // Rows A to D
                {
                    for (int number = 1; number <= 10; number++) // Numbers 1 to 10
                    {
                        string seat = $"{row}{number}";
                        cbPassengerSeat.Items.Add(seat); // Add seat label (e.g., A1, B5, D10)
                    }
                }
            }

            // Select the seat only if it's in the list
            if (cbPassengerSeat.Items.Contains(seatNo))
            {
                cbPassengerSeat.SelectedItem = seatNo;
            }
            else
            {
                MessageBox.Show("Seat not found: " + seatNo);
            }

            cbTravelClass.SelectedItem = travelClass;
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

            string insertBookingQuery = @"
                INSERT INTO PassengerDetails
                (Book_Ref, Book_Date, Firstname, Middlename, Lastname, Nationality, Contact_No, Gender, 
                 Departure_From, Arrival_To, Departure_Date, Seat_No, Travel_Class, Base_Fare, Tax, Total_Amount)
                VALUES (@book_ref, @book_date, @firstname, @middlename, @lastname, @nationality, @contact_no, @gender, 
                        @departure_from, @arrival_to, @departure_date, @seat_no, @travel_class, @base_fare, @tax, @total_amount)";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertBookingQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@book_ref", lblRefNo.Text);
                        cmd.Parameters.AddWithValue("@book_date", lblDate.Text);
                        cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@middlename", string.IsNullOrWhiteSpace(txtMiddlename.Text) ? "N/A" : txtMiddlename.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastname", txtLastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@nationality", cbNationality.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@contact_no", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@departure_from", cbDeparture.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@arrival_to", cbArrival.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@departure_date", dtDeparture.Value);
                        cmd.Parameters.AddWithValue("@seat_no", cbPassengerSeat.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@travel_class", cbTravelClass.SelectedItem?.ToString());

                        // Parse Base Fare, Tax, and Total Amount as integers
                        cmd.Parameters.AddWithValue("@base_fare", int.Parse(lblBaseFare.Text, System.Globalization.NumberStyles.Currency));
                        cmd.Parameters.AddWithValue("@tax", int.Parse(lblTax.Text, System.Globalization.NumberStyles.Currency));
                        cmd.Parameters.AddWithValue("@total_amount", int.Parse(lblTotalAmount.Text, System.Globalization.NumberStyles.Currency));

                        cmd.ExecuteNonQuery();
                       
                        // Proceed to the PaymentModule with the successfully inserted Book_Ref
                        PaymentModule paymentModule = new PaymentModule(lblRefNo.Text, lblTotalAmount.Text);
                        paymentModule.Show();
                      

                        _parentForm.AddNewBooking(
                            lblRefNo.Text, lblDate.Text, $"{txtFirstname.Text} {txtMiddlename.Text} {txtLastname.Text}", txtContact.Text,
                            cbGender.SelectedItem?.ToString(), cbNationality.SelectedItem?.ToString(),
                            cbDeparture.SelectedItem?.ToString(), cbArrival.SelectedItem?.ToString(),
                            dtDeparture.Value.ToString("yyyy-MM-dd"), cbPassengerSeat.SelectedItem?.ToString(),
                            cbTravelClass.SelectedItem?.ToString());

                        
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //For update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateBookingQuery = @"
        UPDATE PassengerDetails
        SET
            Firstname = @firstname,
            Middlename = @middlename,
            Lastname = @lastname,
            Nationality = @nationality,
            Contact_No = @contact_no,
            Gender = @gender,
            Departure_From = @departure_from,
            Arrival_To = @arrival_to,
            Departure_Date = @departure_date,
            Seat_No = @seat_no,
            Travel_Class = @travel_class,
            Base_Fare = @base_fare,
            Tax = @tax,
            Total_Amount = @total_amount
        WHERE Book_Ref = @book_ref";

            try
            {
                if (string.IsNullOrWhiteSpace(OriginalBookingRef))
                {
                    MessageBox.Show("No booking reference available for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

              
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateBookingQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@book_ref", OriginalBookingRef);
                        cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@middlename", string.IsNullOrWhiteSpace(txtMiddlename.Text) ? "N/A" : txtMiddlename.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastname", txtLastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@nationality", cbNationality.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@contact_no", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", cbGender.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@departure_from", cbDeparture.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@arrival_to", cbArrival.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@departure_date", dtDeparture.Value);
                        cmd.Parameters.AddWithValue("@seat_no", cbPassengerSeat.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@travel_class", cbTravelClass.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@base_fare", int.Parse(lblBaseFare.Text, System.Globalization.NumberStyles.Currency));
                        cmd.Parameters.AddWithValue("@tax", int.Parse(lblTax.Text, System.Globalization.NumberStyles.Currency));
                        cmd.Parameters.AddWithValue("@total_amount", int.Parse(lblTotalAmount.Text, System.Globalization.NumberStyles.Currency));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were updated
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                             
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Please verify the booking reference.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void Clear()
        {
            // Clears form and optionally disables update button
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtLastname.Clear();
            txtContact.Clear();
            cbGender.SelectedItem = null;
            cbNationality.SelectedItem = null;
            cbDeparture.SelectedItem = null;
            cbArrival.SelectedItem = null;
            dtDeparture.Value = DateTime.Now;
            cbPassengerSeat.SelectedItem = null;
            cbTravelClass.SelectedItem = null;
            lblRefNo.Text = GenerateBookingReference();
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            
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
