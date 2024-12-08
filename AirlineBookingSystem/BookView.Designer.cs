namespace AirlineBookingSystem
{
    partial class BookView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.addIcon = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flpBookingList = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addIcon)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.addIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 642);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1263, 74);
            this.panel1.TabIndex = 0;
            // 
            // addIcon
            // 
            this.addIcon.Image = ((System.Drawing.Image)(resources.GetObject("addIcon.Image")));
            this.addIcon.Location = new System.Drawing.Point(1172, 12);
            this.addIcon.Name = "addIcon";
            this.addIcon.Size = new System.Drawing.Size(79, 50);
            this.addIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addIcon.TabIndex = 0;
            this.addIcon.TabStop = false;
            this.addIcon.Click += new System.EventHandler(this.addIcon_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1249, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 65);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1263, 65);
            this.panel3.TabIndex = 3;
            // 
            // flpBookingList
            // 
            this.flpBookingList.AutoScroll = true;
            this.flpBookingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBookingList.Location = new System.Drawing.Point(0, 65);
            this.flpBookingList.Name = "flpBookingList";
            this.flpBookingList.Size = new System.Drawing.Size(1263, 577);
            this.flpBookingList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Your Book";
            // 
            // BookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1263, 716);
            this.Controls.Add(this.flpBookingList);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookView";
            this.Text = "PassengerControlView";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addIcon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox addIcon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flpBookingList;
        private System.Windows.Forms.Label label1;
    }
}