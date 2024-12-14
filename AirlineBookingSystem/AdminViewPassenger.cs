using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class AdminViewPassenger : Form
    {
        public AdminViewPassenger()
        {
            InitializeComponent();
            LoadTicketData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadTicketData()
        {
            
            dataGridView1.Rows.Clear(); // Clear existing rows in DataGridView

            // SQL query to select required columns from the database
            string query = "SELECT Book_Ref, Book_Date, Firstname, Middlename, Lastname, Nationality, Contact_No, Gender, " +
                           "Departure_From, Arrival_To, Departure_Date, Seat_No, Travel_Class " +
                           "FROM PassengerDetails";

            // Open database connection and execute query
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader sdr = cmd.ExecuteReader();

                        // Read data from SqlDataReader and populate DataGridView
                        while (sdr.Read())
                        {
                           
                                 // Add rows to DataGridView (ensure correct mapping of columns from SqlDataReader)
                            dataGridView1.Rows.Add( sdr[0].ToString(), sdr[1].ToString(),
                                                   sdr[2].ToString(), sdr[3].ToString(),
                                                   sdr[4].ToString(), sdr[5].ToString(),
                                                   sdr[6].ToString(), sdr[7].ToString(),
                                                   sdr[8].ToString(), sdr[9].ToString(),
                                                   sdr[10].ToString(), sdr[11].ToString(),
                                                   sdr[12].ToString());
                        }
                        sdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void SearchBookings(string searchQuery)
        {
            
            dataGridView1.Rows.Clear(); // Clear existing rows in DataGridView

            // SQL query with a WHERE clause to filter based on searchQuery in various columns
            string query = @"
        SELECT Book_Ref, Book_Date, Firstname, Middlename, Lastname, Nationality, Contact_No, Gender, 
               Departure_From, Arrival_To, Departure_Date, Seat_No, Travel_Class
        FROM PassengerDetails 
        WHERE Book_Ref LIKE @searchQuery
        OR Firstname LIKE @searchQuery
        OR Lastname LIKE @searchQuery
        OR Departure_From LIKE @searchQuery
        OR Arrival_To LIKE @searchQuery
        ORDER BY Book_Date DESC"; // Adjust the sorting column if needed

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter to prevent SQL injection
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read data from SqlDataReader and populate DataGridView
                            while (reader.Read())
                            {
                               
                                     // Add rows to DataGridView (ensure correct mapping of columns from SqlDataReader)
                                dataGridView1.Rows.Add(reader["Book_Ref"].ToString(), reader["Book_Date"].ToString(),
                                                       reader["Firstname"].ToString(), reader["Middlename"].ToString(),
                                                       reader["Lastname"].ToString(), reader["Nationality"].ToString(),
                                                       reader["Contact_No"].ToString(), reader["Gender"].ToString(),
                                                       reader["Departure_From"].ToString(), reader["Arrival_To"].ToString(),
                                                       reader["Departure_Date"].ToString(), reader["Seat_No"].ToString(),
                                                       reader["Travel_Class"].ToString());
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchPassenger_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearchPassenger.Text.Trim(); //get the search input
            SearchBookings(searchQuery); //call the search method with the query
        }
    }
}
