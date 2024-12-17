using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
using System.Windows.Controls;

namespace AirlineBookingSystem
{
    public partial class TicketModule : Form
    {

        
        private readonly BookView _parentForm;
        public bool IsEditMode { get; private set; } = true;
        private string OriginalBookingRef;


        public TicketModule(BookView parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            

            // Set the current date
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // Generate booking reference
            lblRefNo.Text = GenerateBookingReference();

            IsEditMode = false;
            UpdateButtonState();
            SetUpDate();

        }

        private void UpdateButtonState()
        {
            if (IsEditMode)
            {
                btnNext.Enabled = false;  // Disable Next button in edit mode
                btnUpdate.Enabled = true; // Enable Update button in edit mode
            }
            else
            {
                btnNext.Enabled = true;  // Enable Next button for new bookings
                btnUpdate.Enabled = false; // Disable Update button for new bookings
            }
        }

        // Constructor for editing existing bookings
        public TicketModule(BookView parentForm, string bookRef, string bookDate, string fullName, string contact, string gender,
                       string nationality, string departureFrom, string arrivalTo, DateTime departureDate,
                       string seatNo, string travelClass)
                       : this(parentForm)
        {
            IsEditMode = true;
            // Update button states
            UpdateButtonState();

            // Set the OriginalBookingRef for update functionality
            OriginalBookingRef = bookRef;

            // Now, set all the fields to display the existing booking details
            lblRefNo.Text = bookRef;
            lblDate.Text = bookDate;

            // Split the full name into parts
            string[] nameParts = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length == 1)
            {
                // Only one part, assume it’s the first name
                txtFirstname.Text = nameParts[0];
                txtMiddlename.Text = "";
                txtLastname.Text = "";
            }
            else if (nameParts.Length == 2)
            {
                // Two parts, first name and last name
                txtFirstname.Text = nameParts[0];
                txtMiddlename.Text = "";
                txtLastname.Text = nameParts[1];
            }
            else
            {
                // Three or more parts
                txtFirstname.Text = string.Join(" ", nameParts, 0, nameParts.Length - 2); // All parts except the last two
                txtMiddlename.Text = nameParts[nameParts.Length - 2]; // Second-to-last part
                txtLastname.Text = nameParts[nameParts.Length - 1]; // Last part
            }



            txtContact.Text = contact;
            cbGender.SelectedItem = gender;
            cbNationality.SelectedItem = nationality;
            cbDeparture.SelectedItem = departureFrom;
            cbArrival.SelectedItem = arrivalTo;
            dtDeparture.Value = departureDate;
            cbPassengerSeat.SelectedItem = seatNo;
            cbTravelClass.SelectedItem = travelClass;

          
        }


        private string GenerateBookingReference()
        {
            // Generate a reference number starting with TR followed by 10 digits
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            return $"TR{timestamp.Substring(4)}"; // Using only last 10 digits for brevity
        }

        private bool IsValidFullName(string name)
        {
            // Regular expression to match a name with letters and spaces
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z\s]+$");
            return regex.IsMatch(name);
        }

        private bool IsValidContactNumber(string contact)
        {
            // Regular expression to match a contact number starting with "09" and a total length of 11 characters
            var regex = new System.Text.RegularExpressions.Regex(@"^09\d{9}$");
            return regex.IsMatch(contact);
        }

        public void SetUpDate()
        {
            dtDeparture.MinDate = DateTime.Now;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            //Here the validation for the next button
            #region
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFirstname.Text) ||
                string.IsNullOrWhiteSpace(txtMiddlename.Text) ||
                string.IsNullOrWhiteSpace(txtLastname.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // For full name validation
            string lastName = txtLastname.Text;
            string middleName = txtMiddlename.Text;
            string firstName = txtFirstname.Text;

            if (!IsValidFullName(lastName))
            {
                MessageBox.Show("Last name can only contain letters.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidFullName(middleName))
            {
                MessageBox.Show("Middle name can only contain letters.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidFullName(firstName))
            {
                MessageBox.Show("First name can only contain letters.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // For contact number validation
            string contactNumber = txtContact.Text;

            if (!IsValidContactNumber(contactNumber))
            {
                MessageBox.Show("Contact number must start with '09' and have a total of 11 digits.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For nationality validation
            if (cbNationality.SelectedItem == null || cbNationality.SelectedItem.ToString() == "Please Select Nationality")
            {
                MessageBox.Show("Please select a valid nationality.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For gender validation
            if (cbGender.SelectedItem == null || cbGender.SelectedItem.ToString() == "Please Select Gender")
            {
                MessageBox.Show("Please select a valid gender.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For departure validation
            if (cbDeparture.SelectedItem == null || cbDeparture.SelectedItem.ToString() == "Please Select Departure From")
            {
                MessageBox.Show("Please select a valid departure.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For arrival validation
            if (cbArrival.SelectedItem == null || cbArrival.SelectedItem.ToString() == "Please Select Arrival To")
            {
                MessageBox.Show("Please select a valid arrival.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For passenger seat validation
            if (cbPassengerSeat.SelectedItem == null || cbPassengerSeat.SelectedItem.ToString() == "Please Select Passenger Seat")
            {
                MessageBox.Show("Please select a valid passenger seat.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For travel class validation
            if (cbTravelClass.SelectedItem == null || cbTravelClass.SelectedItem.ToString() == "Please Select Travel Class")
            {
                MessageBox.Show("Please select a valid travel class.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string departFrom = cbDeparture.SelectedItem.ToString();
            string arrivalTo = cbArrival.SelectedItem.ToString();

            // Validate that Departure and Arrival locations are not the same
            if (departFrom == arrivalTo)
            {
                MessageBox.Show("Departure and Arrival locations cannot be the same!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            #endregion



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
                        paymentModule.ShowDialog();
                        this.Hide();
                      

                        _parentForm.AddNewBooking(
                            lblRefNo.Text, lblDate.Text, $"{txtFirstname.Text} {txtMiddlename.Text} {txtLastname.Text}", txtContact.Text,
                            cbGender.SelectedItem?.ToString(), cbNationality.SelectedItem?.ToString(),
                            cbDeparture.SelectedItem?.ToString(), cbArrival.SelectedItem?.ToString(),
                            dtDeparture.Value.ToString("yyyy-MM-dd"), cbPassengerSeat.SelectedItem?.ToString(),
                            cbTravelClass.SelectedItem?.ToString());

                        _parentForm.RetrieveAllBookingsFromDatabase();


                    }
                    
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
            //Here the validation for update button
            #region

            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFirstname.Text) ||
                string.IsNullOrWhiteSpace(txtLastname.Text) ||
                string.IsNullOrWhiteSpace(txtMiddlename.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // For full name validation
            string lastName = txtLastname.Text;
            string middleName = txtMiddlename.Text;
            string firstName = txtFirstname.Text;

            if (!IsValidFullName(lastName))
            {
                MessageBox.Show("Last name can only contain letters.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidFullName(middleName))
            {
                MessageBox.Show("Middle name can only contain letters.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidFullName(firstName))
            {
                MessageBox.Show("First name can only contain letters.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For contact number validation
            string contactNumber = txtContact.Text;

            if (!IsValidContactNumber(contactNumber))
            {
                MessageBox.Show("Contact number must start with '09' and have a total of 11 digits.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For nationality validation
            if (cbNationality.SelectedItem == null || cbNationality.SelectedItem.ToString() == "Please Select Nationality")
            {
                MessageBox.Show("Please select a valid nationality.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For gender validation
            if (cbGender.SelectedItem == null || cbGender.SelectedItem.ToString() == "Please Select Gender")
            {
                MessageBox.Show("Please select a valid gender.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For departure validation
            if (cbDeparture.SelectedItem == null || cbDeparture.SelectedItem.ToString() == "Please Select Departure From")
            {
                MessageBox.Show("Please select a valid departure.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For arrival validation
            if (cbArrival.SelectedItem == null || cbArrival.SelectedItem.ToString() == "Please Select Arrival To")
            {
                MessageBox.Show("Please select a valid arrival.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For passenger seat validation
            if (cbPassengerSeat.SelectedItem == null || cbPassengerSeat.SelectedItem.ToString() == "Please Select Passenger Seat")
            {
                MessageBox.Show("Please select a valid passenger seat.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For travel class validation
            if (cbTravelClass.SelectedItem == null || cbTravelClass.SelectedItem.ToString() == "Please Select Travel Class")
            {
                MessageBox.Show("Please select a valid travel class.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For travel class validation
            if (cbTravelClass.SelectedItem == null || cbTravelClass.SelectedItem.ToString() == "Please Select Travel Class")
            {
                MessageBox.Show("Please select a valid travel class.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string departFrom = cbDeparture.SelectedItem.ToString();
            string arrivalTo = cbArrival.SelectedItem.ToString();

            // Validate that Departure and Arrival locations are not the same
            if (departFrom == arrivalTo)
            {
                MessageBox.Show("Departure and Arrival locations cannot be the same!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion


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


        private void TicketModule_Load(object sender, EventArgs e)
        {
            
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
                        baseFare = random.Next(1500, 3001); // 1500 - 3001 inclusive
                        tax = 850;
                        break;
                    case "Premium Economy Class":
                        baseFare = random.Next(3002, 7001); // 3002 - 7001 inclusive
                        tax = 1150;
                        break;
                    case "Business Class":
                        baseFare = random.Next(7002, 10001); // 7002 - 10001 inclusive
                        tax = 1620;
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



        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
