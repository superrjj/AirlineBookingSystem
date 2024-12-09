namespace AirlineBookingSystem
{
    partial class AddFlightModule
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbFlightCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTravel = new System.Windows.Forms.ComboBox();
            this.cbDepartureFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbArrivalTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancelBook = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(905, 73);
            this.panel3.TabIndex = 39;
            // 
            // cbFlightCode
            // 
            this.cbFlightCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFlightCode.FormattingEnabled = true;
            this.cbFlightCode.Items.AddRange(new object[] {
            "Filipino ",
            "Japanese ",
            "Chinese",
            "Indian",
            "Korean",
            "Vietnamese",
            "Thai ",
            "Malaysian",
            "Singaporean",
            "Indonesian ",
            "Bangladeshi ",
            "Pakistani ",
            "Saudi Arabian",
            "Emirati ",
            "Qatari "});
            this.cbFlightCode.Location = new System.Drawing.Point(30, 132);
            this.cbFlightCode.Margin = new System.Windows.Forms.Padding(4);
            this.cbFlightCode.Name = "cbFlightCode";
            this.cbFlightCode.Size = new System.Drawing.Size(164, 33);
            this.cbFlightCode.TabIndex = 49;
            this.cbFlightCode.SelectedIndexChanged += new System.EventHandler(this.cbFlightCode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 105);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 25);
            this.label7.TabIndex = 48;
            this.label7.Text = "Flight Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "Travel Class:";
            // 
            // cbTravel
            // 
            this.cbTravel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTravel.FormattingEnabled = true;
            this.cbTravel.Items.AddRange(new object[] {
            "Filipino ",
            "Japanese ",
            "Chinese",
            "Indian",
            "Korean",
            "Vietnamese",
            "Thai ",
            "Malaysian",
            "Singaporean",
            "Indonesian ",
            "Bangladeshi ",
            "Pakistani ",
            "Saudi Arabian",
            "Emirati ",
            "Qatari "});
            this.cbTravel.Location = new System.Drawing.Point(214, 132);
            this.cbTravel.Margin = new System.Windows.Forms.Padding(4);
            this.cbTravel.Name = "cbTravel";
            this.cbTravel.Size = new System.Drawing.Size(274, 33);
            this.cbTravel.TabIndex = 51;
            // 
            // cbDepartureFrom
            // 
            this.cbDepartureFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartureFrom.FormattingEnabled = true;
            this.cbDepartureFrom.Items.AddRange(new object[] {
            "Filipino ",
            "Japanese ",
            "Chinese",
            "Indian",
            "Korean",
            "Vietnamese",
            "Thai ",
            "Malaysian",
            "Singaporean",
            "Indonesian ",
            "Bangladeshi ",
            "Pakistani ",
            "Saudi Arabian",
            "Emirati ",
            "Qatari "});
            this.cbDepartureFrom.Location = new System.Drawing.Point(30, 206);
            this.cbDepartureFrom.Margin = new System.Windows.Forms.Padding(4);
            this.cbDepartureFrom.Name = "cbDepartureFrom";
            this.cbDepartureFrom.Size = new System.Drawing.Size(844, 33);
            this.cbDepartureFrom.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 52;
            this.label3.Text = "Departure From:";
            // 
            // cbArrivalTo
            // 
            this.cbArrivalTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArrivalTo.FormattingEnabled = true;
            this.cbArrivalTo.Items.AddRange(new object[] {
            "Filipino ",
            "Japanese ",
            "Chinese",
            "Indian",
            "Korean",
            "Vietnamese",
            "Thai ",
            "Malaysian",
            "Singaporean",
            "Indonesian ",
            "Bangladeshi ",
            "Pakistani ",
            "Saudi Arabian",
            "Emirati ",
            "Qatari "});
            this.cbArrivalTo.Location = new System.Drawing.Point(30, 270);
            this.cbArrivalTo.Margin = new System.Windows.Forms.Padding(4);
            this.cbArrivalTo.Name = "cbArrivalTo";
            this.cbArrivalTo.Size = new System.Drawing.Size(844, 33);
            this.cbArrivalTo.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 243);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 54;
            this.label4.Text = "Arrival To:";
            // 
            // dtDepartureDate
            // 
            this.dtDepartureDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDepartureDate.Location = new System.Drawing.Point(509, 132);
            this.dtDepartureDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtDepartureDate.Name = "dtDepartureDate";
            this.dtDepartureDate.Size = new System.Drawing.Size(365, 30);
            this.dtDepartureDate.TabIndex = 57;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(504, 103);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 25);
            this.label12.TabIndex = 56;
            this.label12.Text = "Departure Date:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnCancelBook);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 340);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 76);
            this.panel2.TabIndex = 58;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(730, 19);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 41);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnCancelBook
            // 
            this.btnCancelBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBook.ForeColor = System.Drawing.Color.LightSlateGray;
            this.btnCancelBook.Location = new System.Drawing.Point(570, 19);
            this.btnCancelBook.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelBook.Name = "btnCancelBook";
            this.btnCancelBook.Size = new System.Drawing.Size(140, 41);
            this.btnCancelBook.TabIndex = 37;
            this.btnCancelBook.Text = "Cancel";
            this.btnCancelBook.UseVisualStyleBackColor = true;
            // 
            // AddFlightModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 416);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtDepartureDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbArrivalTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDepartureFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTravel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFlightCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddFlightModule";
            this.Text = "AddFlightModule";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbFlightCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTravel;
        private System.Windows.Forms.ComboBox cbDepartureFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbArrivalTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDepartureDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancelBook;
    }
}