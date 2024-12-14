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
                                      string departureFrom, string arrivalTo, string departureDate, string numberSeats, string travelClass, bool isBookingCreated)
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

            // Hide the picEdit, picDelete, and lblCancel if the booking is created
            if (isBookingCreated)
            {
                picEdit.Visible = false;
                picDelete.Visible = false;
                lblCancel.Visible = false;
            }
            else
            {
                picEdit.Visible = true;  // Show the controls if the booking is not yet created
                picDelete.Visible = true;
                lblCancel.Visible = true;
            }

        }

        #region UI Event Handlers
        private void lblGender_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void lblTravel_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void lblNumberSeats_Click(object sender, EventArgs e) { }
        private void lblDepartureDate_Click(object sender, EventArgs e) { }
        private void lblArrivalTo_Click(object sender, EventArgs e) { }
        private void lblDepartureFrom_Click(object sender, EventArgs e) { }
        #endregion

        private void picEdit_Click(object sender, EventArgs e)
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
        {
            // Confirm the action with the user
            var result = MessageBox.Show("Are you sure you want to archive this booking?", "Archive Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Mark the booking as archived in the database
                MarkBookingAsArchived(lblRef.Text);

                // Remove the UserControl from the parent container
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                    this.Dispose();
                }

                // Notify the user
                MessageBox.Show("Booking archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to mark the booking as archived in the database
        private void MarkBookingAsArchived(string bookingRef)
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

        public void RefreshBookings(Control parentControl, bool showArchived, bool showCancelled)
        {
            string query = "SELECT * FROM PassengerDetails";

            if (!showArchived)
            {
                query += " WHERE IsArchived = 0"; // Only select non-archived records
            }

            if (!showCancelled)
            {
                query += " WHERE IsCancelled = 0"; //Only select cancelled records
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            parentControl.Controls.Clear();

                            while (reader.Read())
                            {
                                BookListView bookingView = new BookListView();
                                bookingView.UpdateBookingInfo(
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
                                    reader["TravelClass"].ToString(), false);

                                parentControl.Controls.Add(bookingView);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblCancel_Click(object sender, EventArgs e)
{

            var result = MessageBox.Show("Are you sure you want to cancel this booking?", "Cancel Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Mark the booking as canceled in the database
                MarkBookingAsCancelled(lblRef.Text);

                // Remove the UserControl from the parent container
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                    this.Dispose();
                }


                // Notify the user
                MessageBox.Show("Booking canceled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void MarkBookingAsCancelled(string bookingRef)
        {
            string query = "UPDATE PassengerDetails SET IsCancelled = 1 WHERE Book_Ref = @book_ref";

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
                MessageBox.Show($"Error canceling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void BookListView_Load(object sender, EventArgs e) { }
        #endregion

    
    }
}
