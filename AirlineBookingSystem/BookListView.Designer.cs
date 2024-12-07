namespace AirlineBookingSystem
{
    partial class BookListView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblDepartureFrom = new System.Windows.Forms.Label();
            this.lblArrivalTo = new System.Windows.Forms.Label();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.lblNumberSeats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(50, 24);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(73, 25);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Fname";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(50, 66);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(80, 25);
            this.lblContact.TabIndex = 1;
            this.lblContact.Text = "Contact";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(627, 24);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(49, 25);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gen";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationality.Location = new System.Drawing.Point(50, 109);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(102, 25);
            this.lblNationality.TabIndex = 3;
            this.lblNationality.Text = "Nationality";
            // 
            // lblDepartureFrom
            // 
            this.lblDepartureFrom.AutoSize = true;
            this.lblDepartureFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureFrom.Location = new System.Drawing.Point(627, 80);
            this.lblDepartureFrom.Name = "lblDepartureFrom";
            this.lblDepartureFrom.Size = new System.Drawing.Size(38, 25);
            this.lblDepartureFrom.TabIndex = 4;
            this.lblDepartureFrom.Text = "DF";
            // 
            // lblArrivalTo
            // 
            this.lblArrivalTo.AutoSize = true;
            this.lblArrivalTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalTo.Location = new System.Drawing.Point(627, 124);
            this.lblArrivalTo.Name = "lblArrivalTo";
            this.lblArrivalTo.Size = new System.Drawing.Size(39, 25);
            this.lblArrivalTo.TabIndex = 5;
            this.lblArrivalTo.Text = "AT";
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.AutoSize = true;
            this.lblDepartureDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureDate.Location = new System.Drawing.Point(1137, 24);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(40, 25);
            this.lblDepartureDate.TabIndex = 6;
            this.lblDepartureDate.Text = "DD";
            // 
            // lblNumberSeats
            // 
            this.lblNumberSeats.AutoSize = true;
            this.lblNumberSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberSeats.Location = new System.Drawing.Point(1137, 66);
            this.lblNumberSeats.Name = "lblNumberSeats";
            this.lblNumberSeats.Size = new System.Drawing.Size(40, 25);
            this.lblNumberSeats.TabIndex = 7;
            this.lblNumberSeats.Text = "DD";
            // 
            // BookListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Controls.Add(this.lblNumberSeats);
            this.Controls.Add(this.lblDepartureDate);
            this.Controls.Add(this.lblArrivalTo);
            this.Controls.Add(this.lblDepartureFrom);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblFullName);
            this.Name = "BookListView";
            this.Size = new System.Drawing.Size(1349, 182);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label lblDepartureFrom;
        private System.Windows.Forms.Label lblArrivalTo;
        private System.Windows.Forms.Label lblDepartureDate;
        private System.Windows.Forms.Label lblNumberSeats;
    }
}
