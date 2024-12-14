using System;
using System.Linq;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class BookView : Form
    {
        

        public BookView()
        {
            InitializeComponent();

            // Instantiate the bookListView before adding it to the FlowLayoutPanel
            BookListView bookListView = new BookListView(); // Instantiate it here
            


        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            TicketModule tm = new TicketModule(this); // Pass the current instance of BookView
            tm.ShowDialog();
        }

        // This method will be used to add new bookings to the list
        public void AddNewBooking(string book_ref, string book_date, string fullName, string contact, string gender, string nationality,
                                       string departureFrom, string arrivalTo, string departureDate, string numberSeats, string travelClass)
        {
            // Create a new instance of BookListView user control
            BookListView newBookingControl = new BookListView();

            // Update the labels with the booking details
            newBookingControl.UpdateBookingInfo(book_ref, book_date, fullName, contact, gender, nationality, departureFrom, arrivalTo, departureDate, numberSeats, travelClass, false);

            // Add the new control to the FlowLayoutPanel (Assume the FlowLayoutPanel is named flpBookingList)
            flpBookingList.Controls.Add(newBookingControl);

            // After adding, check if any booking exists and show/hide accordingly
            ToggleBookListViewVisibility();


        }

        // Method to toggle visibility of the BookListView based on the presence of bookings
        private void ToggleBookListViewVisibility()
        {
            // Check if there are any controls in the FlowLayoutPanel that are BookListView instances
            var anyBookings = flpBookingList.Controls.OfType<BookListView>().Any();

            // Show or hide the BookListView based on whether any bookings are added
            foreach (Control control in flpBookingList.Controls)
            {
                if (control is BookListView bookListView)
                {
                    bookListView.Visible = anyBookings; // Only visible if there are bookings
                }
            }
        }



    }
}
