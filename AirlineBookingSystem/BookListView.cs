using System;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class BookListView : UserControl
    {
        private BookView _parentForm;

        public BookListView(BookView parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        public void DisplayBookingInfo(string firstname, string middlename, string lastname, string gender,
                                       string nationality, long contact, string departureFrom, string arrivalTo,
                                       DateTime departureDate, int numberSeats)
        {
            // Create a new ListViewItem for each booking
            ListViewItem item = new ListViewItem(firstname + " " + lastname);

            // Add additional details as subitems
            item.SubItems.Add(middlename);
            item.SubItems.Add(gender);
            item.SubItems.Add(nationality);
            item.SubItems.Add(contact.ToString());
            item.SubItems.Add(departureFrom);
            item.SubItems.Add(arrivalTo);
            item.SubItems.Add(departureDate.ToString("yyyy-MM-dd"));
            item.SubItems.Add(numberSeats.ToString());

            // Add the item to the ListView (Assuming a ListView control inside bookListView)
            listViewBookings.Items.Add(item);
        }
    }
}
