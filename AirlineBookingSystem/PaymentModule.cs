using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class PaymentModule : Form
    {
        private readonly string _bookingReference;
        private readonly string _totalAmount;

        public PaymentModule(string bookingReference, string totalAmount)
        {
            InitializeComponent();
            _bookingReference = bookingReference;
            _totalAmount = totalAmount;

            txtAmount.Text = totalAmount; // Display the total amount in txtAmount
            txtAmount.ReadOnly = true;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Validate payment fields
            if (cbPayment.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                string.IsNullOrWhiteSpace(txtAccountNumber.Text))
            {
                MessageBox.Show("Please fill in all payment fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // First, check if the booking reference exists in PassengerDetails
                string checkQuery = "SELECT COUNT(*) FROM PassengerDetails WHERE book_ref = @book_ref";

                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=AirlineBookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@book_ref", _bookingReference);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            
                        }
                    }

                    // Now handle payment if booking reference is valid
                    string insertQuery = @"
                INSERT INTO PaymentDetails
                (Book_Ref, Payment_Method, Account_Name, Account_Num, Amount)
                VALUES (@book_ref, @payment_method, @account_name, @account_num, @amount)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@book_ref", _bookingReference);
                        insertCmd.Parameters.AddWithValue("@payment_method", cbPayment.SelectedItem.ToString());
                        insertCmd.Parameters.AddWithValue("@account_name", txtAccountName.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@account_num", txtAccountNumber.Text.Trim());

                        
                        // Attempt to parse the amount, removing the $ sign if present
                        string amountString = _totalAmount.Trim('₱');  // Remove the dollar sign
                        decimal amount;

                        if (decimal.TryParse(amountString, out amount)) // Safely try to parse the string
                        {
                            insertCmd.Parameters.AddWithValue("@amount", amount);
                        }
                        else
                        {
                            MessageBox.Show("Invalid amount format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        insertCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Payment Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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


        private void btnCancelPayment_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
