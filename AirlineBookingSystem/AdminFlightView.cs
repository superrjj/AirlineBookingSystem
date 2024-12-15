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

        public void AddFlight(string flightCode, string departFrom, string arrivTo, string departDate, string travel)
        {
            // Add a new row to the DataGridView with the new flight details
            dgFlights.Rows.Add(flightCode, departFrom, arrivTo, departDate, travel);

            // Optionally, you can also handle any additional UI changes here (like toggling visibility)
        }

        // Method to load all flights and display them in the FlowLayoutPanel
        private void LoadFlightData()
        {
            dgFlights.Rows.Clear(); // Clear existing rows in DataGridView

            string query = "SELECT Flight_Code, Depart_From, Arriv_To, Depart_Date, Travel " +
                           "FROM FlightDetails";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader sdr = cmd.ExecuteReader();

                        // Read data from SqlDataReader and populate DataGridView
                        while (sdr.Read())
                        {
                            dgFlights.Rows.Add(sdr[0].ToString(), sdr[1].ToString(),
                                                   sdr[2].ToString(), sdr[3].ToString(),
                                                   sdr[4].ToString());
                        }
                        sdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving flight data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBar.Text.Trim(); // Get the search input
            SearchFlights(searchQuery); // Call the search method with the query
        }

        private void SearchFlights(string searchQuery)
        {
            dgFlights.Rows.Clear(); //Clear existing rows in DataGridView

            //SQL query with a WHERE clause to filter based on searchQuery in various columns
            string query = @"
                SELECT Flight_Code, Depart_From, Arriv_To, Depart_Date, Travel
                FROM FlightDetails 
                WHERE Flight_Code LIKE @searchQuery
                OR Depart_From LIKE @searchQuery
                OR Arriv_To LIKE @searchQuery
                ORDER BY Depart_Date DESC"; // Adjust the sorting column if needed

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter to prevent SQL injection
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read data from SqlDataReader and populate DataGridView
                            while (reader.Read())
                            {
                                dgFlights.Rows.Add(
                                    reader["Flight_Code"].ToString(),
                                    reader["Depart_From"].ToString(),
                                    reader["Arriv_To"].ToString(),
                                    reader["Depart_Date"].ToString(),
                                    reader["Travel"].ToString()
                                );
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
