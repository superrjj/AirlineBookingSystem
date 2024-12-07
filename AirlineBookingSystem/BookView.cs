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
    public partial class BookView : Form
    {
        public BookListView bookListView; // Expose bookListView publiclyA
        public BookView()
        {
            InitializeComponent();
            bookListView = new BookListView(); // Initialize bookListView
            this.Controls.Add(bookListView); // Add bookListView to the form's controls
            LoadBookListView();
        }

        private void addIcon_Click(object sender, EventArgs e)
        {
           TicketModule tm = new TicketModule(this);
            tm.ShowDialog();
        }

        public void LoadBookListView()
        {
            this.bookListView = new BookListView();
            this.Controls.Add(bookListView);
        }
    }
}
