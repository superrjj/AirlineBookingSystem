﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class AddFlightModule : Form
    {
        private readonly AdminFlightView _adminFlightView;
       
     


        public AddFlightModule(AdminFlightView adminFlightView)
        {
            InitializeComponent();
  

            if (adminFlightView == null)
            {
                MessageBox.Show("AdminFlightView reference is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            PopulateFlightCodes();
            SetUpDate();

            _adminFlightView = adminFlightView; // Store the reference
            cbFlightCode.SelectedIndexChanged += cbFlightCode_SelectedIndexChanged;

        }
        private void PopulateFlightCodes()
        {
            cbFlightCode.Items.Clear(); // Clear existing items
            List<string> flightCodes = GenerateFlightCodes(); // Generate flight codes
            cbFlightCode.Items.AddRange(flightCodes.ToArray()); // Populate the ComboBox
        }

        public void SetUpDate()
        {
            dtDepartureDate.MinDate = DateTime.Now;
        }

        private List<string> GenerateFlightCodes()
        {
            var flightCodes = new List<string>();
            Random random = new Random();

            // Define airline prefixes
            List<string> prefixes = new List<string> { "PAL", "CEB", "AIR" };

            for (int i = 0; i < 30; i++)
            {
                // Choose a random prefix from the list
                string prefix = prefixes[random.Next(prefixes.Count)];

                // Generate a random 6-digit number
                string suffix = random.Next(100000, 999999).ToString();

                // Add the flight code in the format "PREFIX-XXXXXX"
                flightCodes.Add($"{prefix}-{suffix}");
            }

            return flightCodes;
        }



        private void cbFlightCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFlightCode = cbFlightCode.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedFlightCode))
            {
                // Handle flight code selection logic (if needed)
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Validation for add flight
            #region

            if (cbFlightCode.SelectedItem == null ||
                cbTravel.SelectedItem == null ||
                cbDepartureFrom.SelectedItem == null ||
                cbArrivalTo.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string depart = cbDepartureFrom.SelectedItem.ToString();
            string arrival = cbArrivalTo.SelectedItem.ToString();

            //For flight code validation
            if (cbFlightCode.SelectedItem == null || cbFlightCode.SelectedItem.ToString() == "Please Select FlightCode")
            {
                MessageBox.Show("Please select a valid flight code.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //For travel class validation
            if (cbTravel.SelectedItem == null || cbTravel.SelectedItem.ToString() == "Please Select Travel Class")
            {
                MessageBox.Show("Please select a valid travel class.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //For departure from validation
            if (cbDepartureFrom.SelectedItem == null || cbDepartureFrom.SelectedItem.ToString() == "Please Select Departure From")
            {
                MessageBox.Show("Please select a valid departure from.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //For arrival to validation
            if (cbArrivalTo.SelectedItem == null || cbArrivalTo.SelectedItem.ToString() == "Please Select Arrival To")
            {
                MessageBox.Show("Please select a valid arrival to.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate that Departure and Arrival locations are not the same
            if (depart == arrival)
            {
                MessageBox.Show("Departure and Arrival locations cannot be the same!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

         

            #endregion


            string flightCode = cbFlightCode.SelectedItem.ToString();
            string departFrom = cbDepartureFrom.SelectedItem.ToString();
            string arrivalTo = cbArrivalTo.SelectedItem.ToString();
            string travel = cbTravel.SelectedItem.ToString();
            string departDate = dtDepartureDate.Value.ToShortDateString();

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    string insertBookingQuery = @"
                        INSERT INTO FlightDetails (Flight_Code, Travel, Depart_Date, Depart_From, Arriv_To)
                        VALUES (@flight_code, @travel, @depart_date, @depart_from, @arriv_to)";

                    using (SqlCommand cmd = new SqlCommand(insertBookingQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@flight_code", flightCode);
                        cmd.Parameters.AddWithValue("@travel", travel);
                        cmd.Parameters.AddWithValue("@depart_date", dtDepartureDate.Value);
                        cmd.Parameters.AddWithValue("@depart_from", departFrom);
                        cmd.Parameters.AddWithValue("@arriv_to", arrivalTo);

                        cmd.ExecuteNonQuery();
                    }
                }

                _adminFlightView.AddFlight(departFrom, arrivalTo, departDate, flightCode, travel); // Update flight list
                ClearFormFields(); // Reset fields
                MessageBox.Show("Flight added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormFields()
        {
            cbFlightCode.SelectedIndex = -1;
            cbDepartureFrom.SelectedIndex = -1;
            cbArrivalTo.SelectedIndex = -1;
            cbTravel.SelectedIndex = -1;
        }

        private void btnCancelBook_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
