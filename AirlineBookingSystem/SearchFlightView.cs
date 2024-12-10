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
    public partial class SearchFlightView : Form
    {
        public SearchFlightView()
        {
            InitializeComponent();
            LoadFlightData();
           
        }

        private void LoadFlightData()
        {
            string query = "SELECT * FROM FlightDetails ORDER BY Depart_Date DESC"; // SQL query for retrieving booking history

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
                            flpSearchFlight.Controls.Clear();

                            while (reader.Read())
                            {
                                // Retrieve data from the reader

                                string flightCode = reader["Flight_Code"].ToString();
                                string departFrom = reader["Depart_From"].ToString();
                                string arrivTo = reader["Arriv_To"].ToString();
                                string departDate = reader["Depart_Date"].ToString();
                                string travel = reader["Travel"].ToString();


                                // Create a new instance of the BookListView user control
                                FlightListView flightControl = new FlightListView();

                                // Update the control's data
                                flightControl.UpdateAddFlight(flightCode, departFrom, arrivTo, departDate, travel);

                                // Add the user control to the FlowLayoutPanel
                                flpSearchFlight.Controls.Add(flightControl);
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
