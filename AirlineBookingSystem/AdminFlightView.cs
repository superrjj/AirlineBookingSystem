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
    public partial class AdminFlightView : Form
    {
        public AdminFlightView()
        {
            InitializeComponent();
            LoadFlightData(); // Load existing flights on initialization
        }

        // Event handler for the add icon button
        private void addIcon_Click(object sender, EventArgs e)
        {
            // Open the AddFlightModule dialog
            AddFlightModule afm = new AddFlightModule(this);
            afm.ShowDialog();

            // Refresh the flight data after the dialog is closed
            LoadFlightData();
        }

        // Method to add a new flight to the UI
        public void AddFlight(string flightCode, string departFrom, string arrivTo, string departDate, string travel)
        {
            // Create a new instance of the FlightListView user control
            FlightListView newFlightControl = new FlightListView();

            // Update the labels with the flight details
            newFlightControl.UpdateAddFlight(flightCode, departFrom, arrivTo, departDate, travel);

            // Add the new control to the FlowLayoutPanel (Assume the FlowLayoutPanel is named flowAdminFlightView)
            flowAdminFlightView.Controls.Add(newFlightControl);

            // After adding, check if any flights exist and toggle visibility accordingly
            ToggleFlightListViewVisibility();
        }

        // Method to load all flights and display them in the FlowLayoutPanel
        private void LoadFlightData()
        {
            string query = "SELECT * FROM FlightDetails ORDER BY Depart_Date DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear the FlowLayoutPanel before adding updated data
                            flowAdminFlightView.Controls.Clear();

                            while (reader.Read())
                            {
                                // Retrieve data from the reader
                                string flightCode = reader["Flight_Code"].ToString();
                                string departFrom = reader["Depart_From"].ToString();
                                string arrivTo = reader["Arriv_To"].ToString();
                                string departDate = reader["Depart_Date"].ToString();
                                string travel = reader["Travel"].ToString();

                                // Add the flight to the UI
                                AddFlight(flightCode, departFrom, arrivTo, departDate, travel);
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

        // Method to toggle visibility of the flights based on presence of controls
        private void ToggleFlightListViewVisibility()
        {
            // Check if there are any controls in the FlowLayoutPanel that are FlightListView instances
            bool anyFlight = flowAdminFlightView.Controls.OfType<FlightListView>().Any();

            // Toggle visibility of the FlightListView controls
            foreach (Control control in flowAdminFlightView.Controls)
            {
                if (control is FlightListView flightListView)
                {
                    flightListView.Visible = anyFlight; // Only visible if there are flights
                }
            }
        }
    }
}
