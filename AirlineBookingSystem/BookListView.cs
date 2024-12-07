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
        public void UpdateBookingInfo(string fullName, string contact, string gender, string nationality,
                                       string departureFrom, string arrivalTo, string departureDate, string numberSeats)
        {
            lblFullName.Text = fullName;
            lblContact.Text = contact;
            lblGender.Text = gender;
            lblNationality.Text = nationality;
            lblDepartureFrom.Text = departureFrom;
            lblArrivalTo.Text = arrivalTo;
            lblDepartureDate.Text = departureDate;
            lblNumberSeats.Text = numberSeats;
        }
    }
}
