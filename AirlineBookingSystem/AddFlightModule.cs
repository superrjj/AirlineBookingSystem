﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class AddFlightModule : Form
    {
        private readonly AdminFlightView _adminFlightView;
        public bool IsEditMode { get; private set; } = false;
     


        public AddFlightModule(AdminFlightView adminFlightView)
        {
            InitializeComponent();
  

            if (adminFlightView == null)
            {
                MessageBox.Show("AdminFlightView reference is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            _adminFlightView = adminFlightView; // Store the reference
            PopulateFlightCodes();
            cbFlightCode.SelectedIndexChanged += cbFlightCode_SelectedIndexChanged;
            UpdateButtonState();
            
          
        }

        private void UpdateButtonState()
        {
            if (IsEditMode)
            {
                btnAdd.Visible = false;  // Disable Next button in edit mode
                btnUpdate.Visible = true; // Enable Update button in edit mode
            }
            else
            {
                btnAdd.Visible = true;  // Enable Next button for new bookings
                btnUpdate.Visible = false; // Disable Update button for new bookings
            }
        }

        // Method to switch to Edit mode when editing a flight
        public void SwitchToEditMode()
        {
            IsEditMode = true; // Set mode to Edit
            UpdateButtonState(); // Update button visibility
          //  LoadFlightDetails();


        }
      

        private void PopulateFlightCodes()
        {
            cbFlightCode.Items.Clear(); // Clear existing items
            List<string> flightCodes = GenerateFlightCodes(); // Generate flight codes
            cbFlightCode.Items.AddRange(flightCodes.ToArray()); // Populate the ComboBox
        }

        private List<string> GenerateFlightCodes()
        {
            var flightCodes = new List<string>();
            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                string prefix = $"{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}";
                string suffix = random.Next(0, 10000).ToString("D4");
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
            if (cbFlightCode.SelectedItem == null ||
                cbTravel.SelectedItem == null ||
                cbDepartureFrom.SelectedItem == null ||
                cbArrivalTo.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbFlightCode.SelectedItem == null ||
       cbTravel.SelectedItem == null ||
       cbDepartureFrom.SelectedItem == null ||
       cbArrivalTo.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                    string updateBookingQuery = @"
                UPDATE FlightDetails
                SET Travel = @travel, Depart_Date = @depart_date, Depart_From = @depart_from, Arriv_To = @arriv_to
                WHERE Flight_Code = @flight_code";

                    using (SqlCommand cmd = new SqlCommand(updateBookingQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@flight_code", flightCode);
                        cmd.Parameters.AddWithValue("@travel", travel);
                        cmd.Parameters.AddWithValue("@depart_date", dtDepartureDate.Value);
                        cmd.Parameters.AddWithValue("@depart_from", departFrom);
                        cmd.Parameters.AddWithValue("@arriv_to", arrivalTo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            _adminFlightView.AddFlight(departFrom, arrivalTo, departDate, flightCode, travel); // Update the flight list
                            MessageBox.Show("Flight updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Flight update failed. Please check the flight code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadFlightDetails(string flightCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    string selectQuery = @"
                SELECT Travel, Depart_Date, Depart_From, Arriv_To
                FROM FlightDetails
                WHERE Flight_Code = @flight_code";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@flight_code", flightCode);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the form with the retrieved values
                                cbFlightCode.SelectedItem = flightCode;
                                cbTravel.SelectedItem = reader["Travel"].ToString();
                                dtDepartureDate.Value = Convert.ToDateTime(reader["Depart_Date"]);
                                cbDepartureFrom.SelectedItem = reader["Depart_From"].ToString();
                                cbArrivalTo.SelectedItem = reader["Arriv_To"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Flight not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
