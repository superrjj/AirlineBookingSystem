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


        private bool IsValidAccountName(string name)
        {
            // Regular expression to match a name with letters and spaces
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z\s]+$");
            return regex.IsMatch(name);
        }

        private bool IsValidAccountNumber(string contact)
        {
            // Regular expression to match a contact number starting with "09" and a total length of 11 characters
            var regex = new System.Text.RegularExpressions.Regex(@"^09\d{9}$");
            return regex.IsMatch(contact);
        }

        private bool IsValidGcashNumber(string number)
        {
            // Match "09" followed by exactly 9 digits (total of 11 characters)
            var regex = new System.Text.RegularExpressions.Regex(@"^09\d{9}$");
            return regex.IsMatch(number);
        }

        private bool IsValidCardOrBankingNumber(string number)
        {
            // Match exactly 16 numeric digits
            var regex = new System.Text.RegularExpressions.Regex(@"^\d{16}$");
            return regex.IsMatch(number);
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

            // For  validation
            string accountName = txtAccountName.Text;

            if (!IsValidAccountName(accountName))
            {
                MessageBox.Show("Account name can only contain letters.", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Payment method validation
            string paymentMethod = cbPayment.SelectedItem?.ToString(); // Get selected payment method
            string input = txtAccountNumber.Text; // Assuming user input is in txtPaymentDetails

            if (paymentMethod == "Gcash")
            {
                // Validate Gcash contact number
                if (!IsValidGcashNumber(input))
                {
                    MessageBox.Show("Gcash contact number must start with '09' and have a total of 11 digits.",
                                    "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (paymentMethod == "Credit/Debit Card" || paymentMethod == "Online Banking")
            {
                // Validate card or online banking number
                if (!IsValidCardOrBankingNumber(input))
                {
                    MessageBox.Show($"{paymentMethod} number must be exactly 16 digits.",
                                    "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                // If no payment method is selected
                MessageBox.Show("Please select a valid payment method.",
                                "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            this.Hide();
        }
    }
}
