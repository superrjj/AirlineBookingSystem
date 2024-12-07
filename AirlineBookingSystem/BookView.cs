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
           

            // Add bookListView to the FlowLayoutPanel instead of the form's Controls
            //flpBookingList.Controls.Add(bookListView); // Assuming flpBookingList is the name of your FlowLayoutPanel

          
        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            TicketModule tm = new TicketModule(this);
            tm.ShowDialog();
        }

        // This method will be used to add new bookings to the list
        public void AddNewBooking(string fullName, string contact, string gender, string nationality,
                                   string departureFrom, string arrivalTo, string departureDate, string numberSeats)
        {
            // Create a new instance of BookListView user control
            BookListView newBookingControl = new BookListView();

            // Update the labels with the booking details
            newBookingControl.UpdateBookingInfo(fullName, contact, gender, nationality, departureFrom, arrivalTo, departureDate, numberSeats);

            // Add the new control to the FlowLayoutPanel (Assume the FlowLayoutPanel is named flpBookingList)
            flpBookingList.Controls.Add(newBookingControl);
        }
    }
}
