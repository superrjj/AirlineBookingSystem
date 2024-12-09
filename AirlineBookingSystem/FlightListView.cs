using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class FlightListView : UserControl
    {
        public FlightListView()
        {
            InitializeComponent();
        }

      
        public void UpdateAddFlight( string departureFrom, string arrivalTo, string departureDate, string flightCode, string travelClass)
        {
            lblDepartureFrom.Text = departureFrom;
            lblArrivalTo.Text = arrivalTo;
            lblDate.Text = departureDate;
            lblFlightCode.Text = flightCode;
            lblTravel.Text = travelClass;
        }
    }

    }

