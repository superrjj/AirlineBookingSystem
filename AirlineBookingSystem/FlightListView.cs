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


        public void UpdateAddFlight(string departFrom, string arrivTo, string departDate, string flightCode, string travel)
        {
            lblDepartureFrom.Text = departFrom;
            lblArrivalTo.Text = arrivTo;
            lblDate.Text = departDate;
            lblFlightCode.Text = flightCode;
            lblTravel.Text = travel;
        }


    }

    }

