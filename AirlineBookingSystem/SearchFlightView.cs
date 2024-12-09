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
    public partial class SearchFlightView : Form
    {
        public SearchFlightView()
        {
            InitializeComponent();
            // Instantiate the flightListView before adding it to the FlowLayoutPanel
            FlightListView flightListView = new FlightListView(); // Instantiate it here
        }

        public void AddFlight(string departureFrom, string arrivalTo, string departureDate, string flightCode, string travelClass)
        {
            // Create a new instance of BookListView user control
            SearchFlightView newBookingControl = new SearchFlightView();

            // Update the labels with the booking details
            newBookingControl.UpdateAddFlight(departureFrom, arrivalTo, departureDate, travelClass);

            // Add the new control to the FlowLayoutPanel (Assume the FlowLayoutPanel is named flpBookingList)
            flpSearchFlight.Controls.Add(newBookingControl);

            // After adding, check if any booking exists and show/hide accordingly
            ToggleBookListViewVisibility();


        }

        // Method to toggle visibility of the BookListView based on the presence of bookings
        private void ToggleBookListViewVisibility()
        {
            // Check if there are any controls in the FlowLayoutPanel that are FlightListView instances
            var anyBookings = flpSearchFlight.Controls.OfType<FlightListView>().Any();

            // Show or hide the BookListView based on whether any bookings are added
            foreach (Control control in flpSearchFlight.Controls)
            {
                if (control is FlightListView flightListView)
                {
                    flightListView.Visible = anyBookings; // Only visible if there are bookings
                }
            }
        }

    }
}
