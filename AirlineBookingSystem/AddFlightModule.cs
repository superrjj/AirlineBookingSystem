using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class AddFlightModule : Form
    {
        public AddFlightModule()
        {
            InitializeComponent();

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
    }
}
