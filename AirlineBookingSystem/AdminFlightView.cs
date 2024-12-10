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
    public partial class AdminFlightView : Form
    {


        public AdminFlightView()
        {
            InitializeComponent();
            // Instantiate the FlightListView and add it to the FlowLayoutPanel
            FlightListView flightListView = new FlightListView();
            
        }

        private void flpAdminFlightView_Paint(object sender, PaintEventArgs e)
        {

        }


        public void AddFlight(string departFrom, string arrivTo, string departDate, string flightCode, string travel)
        {
            
            // Create a new instance of FlightListView user control
            FlightListView newFlightControl = new FlightListView();

            // Update the labels with the booking details
            newFlightControl.UpdateAddFlight(departFrom, arrivTo, departDate, travel, flightCode);

            // Add the new control to the FlowLayoutPanel (Assume the FlowLayoutPanel is named flpBookingList)
            flpAdminFlightView.Controls.Add(newFlightControl);

            // After adding, check if any booking exists and show/hide accordingly
            ToggleBookListViewVisibility();


        }


        // Method to toggle visibility of the BookListView based on the presence of bookings
        private void ToggleBookListViewVisibility()
        {
            // Check if there are any controls in the FlowLayoutPanel that are FlightListView instances
            var anyFlight = flpAdminFlightView.Controls.OfType<FlightListView>().Any();

            // Show or hide the BookListView based on whether any bookings are added
            foreach (Control control in flpAdminFlightView.Controls)
            {
                if (control is FlightListView flightListView)
                {
                    flightListView.Visible = anyFlight; // Only visible if there are bookings
                }
            }
        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            AddFlightModule afm = new AddFlightModule(this);
            afm.ShowDialog();
        }
    }
}
