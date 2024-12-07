using System;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class BookView : Form
    {
        public BookListView bookListView; // Expose bookListView publicly

        public BookView()
        {
            InitializeComponent();
            bookListView = new BookListView(this); // Initialize bookListView

            // Add bookListView to FlowLayoutPanel
            flpBookingList.Controls.Add(bookListView); // Assuming flpBookingList is the FlowLayoutPanel

            // Initially, hide the bookListView
            bookListView.Visible = false;

            UpdateBookingList(); // Initialize the booking list (with default empty values)
        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            TicketModule tm = new TicketModule(this);
            tm.ShowDialog();
        }

        // This method updates the booking list. If no data is passed, it hides the ListView.
        public void UpdateBookingList(string firstname = "", string middlename = "", string lastname = "", string gender = "",
                                      string nationality = "", long contact = 0, string departureFrom = "", string arrivalTo = "",
                                      DateTime departureDate = default, int numberSeats = 0)
        {
            // If booking data exists, unhide the bookListView and add a new entry
            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname))
            {
                // Unhide the bookListView when booking occurs
                bookListView.Visible = true;

                // Add new booking to the ListView using the DisplayBookingInfo method
                bookListView.DisplayBookingInfo(firstname, middlename, lastname, gender, nationality, contact,
                                                departureFrom, arrivalTo, departureDate, numberSeats);
            }
        }

        // Hide bookListView when passenger has not attempted to book
        public void HideBookingListView()
        {
            bookListView.Visible = false;
        }
    }
}
