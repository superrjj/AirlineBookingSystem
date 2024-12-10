using System;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class BookListView : UserControl
    {
        
        public BookListView()
        {
            InitializeComponent();
           
        }

      



        // Method to update all the labels with booking information
        public void UpdateBookingInfo(string book_ref, string book_date, string fullName, string contact, string gender, string nationality,
                                       string departureFrom, string arrivalTo, string departureDate, string numberSeats, string travelClass)
        {
            lblRef.Text = book_ref;
            lblDate.Text = book_date;
            lblFullName.Text = fullName;
            lblContact.Text = contact;
            lblGender.Text = gender;
            lblNationality.Text = nationality;
            lblDepartureFrom.Text = departureFrom;
            lblArrivalTo.Text = arrivalTo;
            lblDepartureDate.Text = departureDate;
            lblNumberSeats.Text = numberSeats;
            lblTravel.Text = travelClass;
        }

        #region
        private void lblGender_Click(object sender, EventArgs e) { }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblTravel_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblNumberSeats_Click(object sender, EventArgs e)
        {

        }

        private void lblDepartureDate_Click(object sender, EventArgs e)
        {

        }

        private void lblArrivalTo_Click(object sender, EventArgs e)
        {

        }

        private void lblDepartureFrom_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}