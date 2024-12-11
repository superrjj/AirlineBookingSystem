using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class BookListView : UserControl
    {

        public BookListView()
        {
            InitializeComponent();

        }





        // Method to update all the labels with booking information
        public void UpdateBookingInfo(string book_ref, string book_date, string fullName, string contact, string gender, string nationality,
                                       string departureFrom, string arrivalTo, string departureDate, string numberSeats, string travelClass)
        {


            lblRef.Text = book_ref;
            lblDate.Text = book_date;
            lblFullName.Text = fullName;
            lblContact.Text = contact;
            lblGender.Text = gender;
            lblNationality.Text = nationality;
            lblDepartureFrom.Text = departureFrom;
            lblArrivalTo.Text = arrivalTo;
            lblDepartureDate.Text = departureDate;
            lblNumberSeats.Text = numberSeats;
            lblTravel.Text = travelClass;
        }

        #region
        private void lblGender_Click(object sender, EventArgs e) { }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblTravel_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblNumberSeats_Click(object sender, EventArgs e)
        {

        }

        private void lblDepartureDate_Click(object sender, EventArgs e)
        {

        }

        private void lblArrivalTo_Click(object sender, EventArgs e)
        {

        }

        private void lblDepartureFrom_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            TicketModule ticketModule = new TicketModule(
               null,
               lblRef.Text,
               lblDate.Text,
               lblFullName.Text,
               lblContact.Text,
               lblGender.Text,
               lblNationality.Text,
               lblDepartureFrom.Text,
               lblArrivalTo.Text,
               DateTime.Parse(lblDepartureDate.Text),
               lblNumberSeats.Text,
               lblTravel.Text);

            if (ticketModule.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void picDelete_Click(object sender, EventArgs e)
        { // Confirm the action with the user
            var result = MessageBox.Show("Are you sure you want to archive this booking?", "Archive Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Archive the booking in the database (mark as archived)
                ArchiveBookingInDatabase(lblRef.Text);

                // Remove the current booking UserControl from the UI (hide or remove it)
                this.Parent.Controls.Remove(this); // Remove this UserControl from its parent container
                this.Dispose(); // Optionally dispose the UserControl to free up resources

                MessageBox.Show("Booking archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }


        private void ArchiveBookingInDatabase(string bookingRef)
        {
            string query = "UPDATE PassengerDetails SET IsArchived = 1 WHERE Book_Ref = @book_ref";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@book_ref", bookingRef);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error archiving booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method will be called to refresh the bookings list
        public void RefreshBookings()
        {
            // Query to get non-archived bookings
            string query = "SELECT * FROM PassengerDetails WHERE IsArchived = 0"; // Only select non-archived records

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear the current list of bookings in the UI
                          //  bookingsListView.Items.Clear();

                            // Loop through the results and add them to the UI
                            while (reader.Read())
                            {
                                var bookingControl = new BookListView();

                                // Set booking info for each UserControl (you would need to implement a method to set this data)
                                bookingControl.UpdateBookingInfo(
                                    reader["Book_Ref"].ToString(),
                                    reader["Book_Date"].ToString(),
                                    reader["FullName"].ToString(),
                                    reader["Contact"].ToString(),
                                    reader["Gender"].ToString(),
                                    reader["Nationality"].ToString(),
                                    reader["DepartureFrom"].ToString(),
                                    reader["ArrivalTo"].ToString(),
                                    reader["DepartureDate"].ToString(),
                                    reader["NumberSeats"].ToString(),
                                    reader["TravelClass"].ToString()
                                );

                                // Add the UserControl to the ListView or any other container you're using
                               // bookingsListView.Controls.Add(bookingControl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BookListView_Load(object sender, EventArgs e)
        {
           
        }
    }
    }
