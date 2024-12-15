using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class BookView : Form
    {
        public BookView()
        {
            InitializeComponent();
            RetrieveAllBookingsFromDatabase();
            RetrieveAllBookingsFromDatabase(showArchived: false, showCancelled: false);

        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            TicketModule tm = new TicketModule(this); // Pass the current instance of BookView
            tm.ShowDialog();
        }


        // This method will be used to add new bookings to the list
        public void AddNewBooking(string book_ref, string book_date, string fullName, string contact, string gender, string nationality,
                                       string departureFrom, string arrivalTo, string departureDate, string numberSeats, string travelClass)
        {
            // Create a new instance of BookListView user control
            BookListView newBookingControl = new BookListView();

            // Update the labels with the booking details
            newBookingControl.UpdateBookingInfo(book_ref, book_date, fullName, contact, gender, nationality, departureFrom, arrivalTo, departureDate, numberSeats, travelClass, false, false);

            // Add the new control to the FlowLayoutPanel (Assume the FlowLayoutPanel is named flpBookingList)
            flpBookingList.Controls.Add(newBookingControl);

            // After adding, check if any booking exists and show/hide accordingly
            ToggleBookListViewVisibility();
        }

        // Method to toggle visibility of the BookListView based on the presence of bookings
        private void ToggleBookListViewVisibility()
        {
            // Check if there are any controls in the FlowLayoutPanel that are BookListView instances
            var anyBookings = flpBookingList.Controls.OfType<BookListView>().Any();

            // Show or hide the BookListView based on whether any bookings are added
            foreach (Control control in flpBookingList.Controls)
            {
                if (control is BookListView bookListView)
                {
                    bookListView.Visible = anyBookings; // Only visible if there are bookings
                }
            }
        }

        // Method to retrieve and display all bookings from the database
        public void RetrieveAllBookingsFromDatabase(bool showArchived = false, bool showCancelled = false)
        {
            // Default query, retrieves all bookings
            string query = "SELECT * FROM PassengerDetails";

            // Add filters for IsArchived and IsCancelled based on parameters
            if (!showArchived)
            {
                query += " WHERE IsArchived = 0"; // Exclude archived bookings
            }

            if (!showCancelled)
            {
                if (query.Contains("WHERE"))
                {
                    query += " AND IsCancelled = 0"; // Exclude cancelled bookings if "WHERE" clause is already present
                }
                else
                {
                    query += " WHERE IsCancelled = 0"; // If there's no WHERE clause, add it to filter out cancelled bookings
                }
            }

            // Sort the bookings by date and then by firstname (or any other sorting logic you prefer)
            query += " ORDER BY Book_Date, Firstname DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear the current controls
                        flpBookingList.Controls.Clear();

                        while (reader.Read())
                        {
                            // Retrieve each column from the database
                            string bookRef = reader["Book_Ref"].ToString();
                            string bookDate = reader["Book_Date"].ToString();
                            string fullName = $"{reader["Firstname"]} {reader["Middlename"]} {reader["Lastname"]}";
                            string contact = reader["Contact_No"].ToString();
                            string gender = reader["Gender"].ToString();
                            string nationality = reader["Nationality"].ToString();
                            string departureFrom = reader["Departure_From"].ToString();
                            string arrivalTo = reader["Arrival_To"].ToString();
                            string departureDate = reader["Departure_Date"].ToString();
                            string seatNo = reader["Seat_No"].ToString();
                            string travelClass = reader["Travel_Class"].ToString();

                            // Add the retrieved data to the BookView
                            AddNewBooking(bookRef, bookDate, fullName, contact, gender, nationality, departureFrom, arrivalTo, departureDate, seatNo, travelClass);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving bookings: " + ex.Message);
            }
        }

    }
}
