using System;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class BookListView : UserControl
    {
        private BookView _parentForm;
        public BookListView()
        {
            InitializeComponent();
        }

        public void DisplayBookingInfo(string firstname, string middlename, string lastname, string gender,
                                       string nationality, long contact, string departureFrom, string arrivalTo,
                                       DateTime departureDate, int numberSeats)
        {
            // Combine the full name by concatenating the firstname, middlename, and lastname
            string fullName = $"{firstname} {(string.IsNullOrWhiteSpace(middlename) ? "" : middlename + " ")}{lastname}";

            // Update the labels with booking info
            lblFullName.Text = fullName;  // Display full name instead of individual parts
            lblGender.Text = gender;
            lblNationality.Text = nationality;
            lblContact.Text = contact.ToString();
            lblDepartureFrom.Text = departureFrom;
            lblArrivalTo.Text = arrivalTo;
            lblDepartureDate.Text = departureDate.ToString("yyyy-MM-dd");
            lblNumberSeats.Text = numberSeats.ToString();
        }

        // This method now accepts the data and displays it on the parent form's bookListView
        public void UpdateBookingList(string firstname, string middlename, string lastname, string gender,
                                      string nationality, long contact, string departureFrom, string arrivalTo,
                                      DateTime departureDate, int numberSeats)
        {
            // Update the booking list using the parent form's bookListView method.
            // Assuming _parentForm has an instance of bookListView
            _parentForm.bookListView.DisplayBookingInfo(firstname, middlename, lastname, gender, nationality, contact,
                                                        departureFrom, arrivalTo, departureDate, numberSeats);
        }
    }
}
