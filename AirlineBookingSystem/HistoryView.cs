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
    public partial class HistoryView : Form
    {
        public HistoryView()
        {
            InitializeComponent();
            LoadHistoryData();
        }

        // Method to load historical booking data into the FlowLayoutPanel
        private void LoadHistoryData(bool showArchived = false , bool showCancelled = false)
        {
            string query = "SELECT * FROM PassengerDetails ORDER BY Book_Date , Firstname DESC"; // SQL query for retrieving booking history

            if (!showArchived)
            {
                query = "SELECT * FROM PassengerDetails WHERE IsArchived = 0 ORDER BY Book_Date , Firstname DESC"; // SQL query for retrieving non-archived booking history
            }

            if (!showCancelled)
            {
                query = "SELECT * FROM PassengerDetails WHERE IsCancelled = 0 ORDER BY Book_Date , Firstname DESC"; // SQL query for retrieving non-cancelled booking history
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
                            // Clear any existing controls in the FlowLayoutPanel
                            flowHistoryViewPanel.Controls.Clear();

                            while (reader.Read())
                            {
                                // Retrieve data from the reader
                                string bookRef = reader["Book_Ref"].ToString();
                                string bookDate = reader["Book_Date"].ToString();
                                string fullName = $"{reader["Firstname"]} {reader["Middlename"]} {reader["Lastname"]}";
                                string contact = reader["Contact_No"].ToString();
                                string gender = reader["Gender"].ToString();
                                string nationality = reader["Nationality"].ToString();
                                string departureFrom = reader["Departure_From"].ToString();
                                string arrivalTo = reader["Arrival_To"].ToString();
                                string departureDate = reader["Departure_Date"].ToString();
                                string numberSeats = reader["Seat_No"].ToString();
                                string travelClass = reader["Travel_Class"].ToString();

                                // Create a new instance of the BookListView user control
                                BookListView historyControl = new BookListView();

                                // Update the control's data
                                historyControl.UpdateBookingInfo(bookRef, bookDate, fullName, contact, gender, nationality, departureFrom, arrivalTo, departureDate, numberSeats, travelClass, true);

                                // Add the user control to the FlowLayoutPanel
                                flowHistoryViewPanel.Controls.Add(historyControl);
                            }
                        }
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
    }
}
