namespace AirlineBookingSystem
{
    partial class PaymentModule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbPayment = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancelPayment = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(34, 362);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(419, 30);
            this.txtAmount.TabIndex = 94;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(29, 333);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(86, 25);
            this.label29.TabIndex = 93;
            this.label29.Text = "Amount:";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Location = new System.Drawing.Point(34, 287);
            this.txtAccountNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(419, 30);
            this.txtAccountNumber.TabIndex = 92;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(29, 257);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(164, 25);
            this.label28.TabIndex = 91;
            this.label28.Text = "Account Number:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(34, 214);
            this.txtAccountName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(419, 30);
            this.txtAccountName.TabIndex = 90;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(29, 184);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(147, 25);
            this.label27.TabIndex = 89;
            this.label27.Text = "Account Name:";
            // 
            // cbPayment
            // 
            this.cbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPayment.FormattingEnabled = true;
            this.cbPayment.Items.AddRange(new object[] {
            "Gcash",
            "Credit/Debit Card",
            "Online Banking"});
            this.cbPayment.Location = new System.Drawing.Point(31, 147);
            this.cbPayment.Margin = new System.Windows.Forms.Padding(4);
            this.cbPayment.Name = "cbPayment";
            this.cbPayment.Size = new System.Drawing.Size(422, 33);
            this.cbPayment.TabIndex = 88;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(27, 120);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(226, 25);
            this.label22.TabIndex = 87;
            this.label22.Text = "Select Payment Method:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 76);
            this.panel1.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(166, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Payment";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(313, 477);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(140, 41);
            this.btnPay.TabIndex = 97;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnCancelPayment
            // 
            this.btnCancelPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelPayment.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnCancelPayment.Location = new System.Drawing.Point(153, 477);
            this.btnCancelPayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelPayment.Name = "btnCancelPayment";
            this.btnCancelPayment.Size = new System.Drawing.Size(140, 41);
            this.btnCancelPayment.TabIndex = 96;
            this.btnCancelPayment.Text = "Cancel";
            this.btnCancelPayment.UseVisualStyleBackColor = true;
            // 
            // PaymentModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 550);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnCancelPayment);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.cbPayment);
            this.Controls.Add(this.label22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentModule";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbPayment;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancelPayment;
    }
}