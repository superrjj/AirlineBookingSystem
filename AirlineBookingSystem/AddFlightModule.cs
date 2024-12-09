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
    public partial class AddFlightModule : Form
    {
        private readonly AdminFlightView _adminFlightView;

        public AddFlightModule(AdminFlightView adminFlightView)
        {
            InitializeComponent();
            _adminFlightView = adminFlightView;  // Store the reference
            PopulateFlightCodes();

            // Subscribe to the SelectedIndexChanged event
            cbFlightCode.SelectedIndexChanged += cbFlightCode_SelectedIndexChanged;

        }


        private void PopulateFlightCodes()
        {
            // Clear existing items in the ComboBox
            cbFlightCode.Items.Clear();

            // Generate flight codes
            List<string> flightCodes = GenerateFlightCodes();

            // Add generated flight codes to the ComboBox
            cbFlightCode.Items.AddRange(flightCodes.ToArray());
        }

        private List<string> GenerateFlightCodes()
        {
            var flightCodes = new List<string>();
            Random random = new Random();

            // Generate 50 flight codes
            for (int i = 0; i < 50; i++)
            {
                string prefix = $"{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}";
                string suffix = random.Next(0, 10000).ToString("D4"); // Four-digit suffix
                flightCodes.Add($"{prefix}-{suffix}");
            }

            return flightCodes;
        }

        private void cbFlightCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Get the selected flight code
            string selectedFlightCode = cbFlightCode.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFlightCode))
            {
                
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            // Validate required fields
            if (cbFlightCode.SelectedItem == null ||
                cbTravel.SelectedItem == null ||
                cbDepartureFrom.SelectedItem == null ||
                cbArrivalTo.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert the booking reference into the database before proceeding to payment
            string insertBookingQuery = @"
                INSERT INTO FlightDetails
                (Flight_Code, Travel, Depart_Date, Depart_From, Arriv_To)
                VALUES (@flight_code, @travel, @depart_date, @depart_from, @arriv_to)";


            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertBookingQuery, conn))
                    {
                     
                        cmd.Parameters.AddWithValue("@flight_code", cbFlightCode.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@travel", cbTravel.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@depart_from", cbDepartureFrom.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@arrival_to", cbArrivalTo.SelectedItem?.ToString() ?? "N/A");
                        cmd.Parameters.AddWithValue("@depart_date", dtDepartureDate.Value);

                        cmd.ExecuteNonQuery(); // Execute the insert operation

                        // Call AddFlightToList method if needed (adjust as required)
                        _adminFlightView.AddFlight(
                            cbFlightCode.SelectedItem.ToString(),
                            cbTravel.SelectedItem.ToString(),
                            cbDepartureFrom.SelectedItem.ToString(),
                            cbArrivalTo.SelectedItem.ToString(),
                            dtDepartureDate.Value.ToShortDateString());
                           

                     
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
