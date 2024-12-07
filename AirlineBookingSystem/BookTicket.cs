using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class BookTicket : Form
    {

        SqlConnection connect = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        //SqlDataReader sdr;


        public BookTicket()
        {
            InitializeComponent();
            dbcon = new DBConnect();
            connect = new SqlConnection(dbcon.myConnection());
            cmd = new SqlCommand();
            //LoadBooked();
        }

        /* public void LoadBooked()
         {


             int i = 0;
             dgvBooked.Rows.Clear();
             // Select required columns from the database tables
             cmd = new SqlCommand("SELECT firstname , middlename, lastname, contact_no, nationality, gender, departure_from, arrival_to,departure_date, number_seats FROM PassengerInformation", connect);
             connect.Open();
             sdr = cmd.ExecuteReader();

             // Read data from the SqlDataReader and populate the DataGridView
             while (sdr.Read())
             {
                 i++;
                 // Add data to DataGridView, ensure that the index is within bounds of SqlDataReader
                 dgvBooked.Rows.Add(i, sdr[0].ToString(), sdr[1].ToString(), sdr[2].ToString(), sdr[3].ToString(), sdr[4].ToString(), sdr[5].ToString(), sdr[6].ToString(), sdr[7].ToString(), sdr[8].ToString(), sdr[9].ToString());
             }
             sdr.Close();
             connect.Close();

         }
        */



    }
}
