namespace AirlineBookingSystem
{
    partial class UserDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeIcon = new System.Windows.Forms.PictureBox();
            this.lblFullname = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnMyFlight = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnHistory = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.closeIcon);
            this.panel1.Controls.Add(this.lblFullname);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 72);
            this.panel1.TabIndex = 0;
            // 
            // closeIcon
            // 
            this.closeIcon.Image = ((System.Drawing.Image)(resources.GetObject("closeIcon.Image")));
            this.closeIcon.Location = new System.Drawing.Point(1025, 3);
            this.closeIcon.Name = "closeIcon";
            this.closeIcon.Size = new System.Drawing.Size(39, 29);
            this.closeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeIcon.TabIndex = 2;
            this.closeIcon.TabStop = false;
            this.closeIcon.Click += new System.EventHandler(this.closeIcon_Click);
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullname.ForeColor = System.Drawing.Color.White;
            this.lblFullname.Location = new System.Drawing.Point(12, 21);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(0, 31);
            this.lblFullname.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 494);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnMyFlight);
            this.panel5.Location = new System.Drawing.Point(0, 104);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 38);
            this.panel5.TabIndex = 2;
            // 
            // btnMyFlight
            // 
            this.btnMyFlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMyFlight.FlatAppearance.BorderSize = 0;
            this.btnMyFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyFlight.ForeColor = System.Drawing.Color.White;
            this.btnMyFlight.Image = ((System.Drawing.Image)(resources.GetObject("btnMyFlight.Image")));
            this.btnMyFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyFlight.Location = new System.Drawing.Point(0, 0);
            this.btnMyFlight.Name = "btnMyFlight";
            this.btnMyFlight.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMyFlight.Size = new System.Drawing.Size(156, 38);
            this.btnMyFlight.TabIndex = 3;
            this.btnMyFlight.Text = "    My Flight";
            this.btnMyFlight.UseVisualStyleBackColor = true;
            this.btnMyFlight.Click += new System.EventHandler(this.btnMyFlight_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDiscount);
            this.panel4.Location = new System.Drawing.Point(0, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(156, 44);
            this.panel4.TabIndex = 1;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDiscount.FlatAppearance.BorderSize = 0;
            this.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscount.Image")));
            this.btnDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscount.Location = new System.Drawing.Point(0, 0);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDiscount.Size = new System.Drawing.Size(156, 44);
            this.btnDiscount.TabIndex = 0;
            this.btnDiscount.Text = "    Discount";
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnHome);
            this.panel3.Location = new System.Drawing.Point(0, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(156, 40);
            this.panel3.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(156, 40);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "        Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(156, 72);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mainPanel.Size = new System.Drawing.Size(908, 494);
            this.mainPanel.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnHistory);
            this.panel6.Location = new System.Drawing.Point(0, 146);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(156, 43);
            this.panel6.TabIndex = 3;
            // 
            // btnHistory
            // 
            this.btnHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
            this.btnHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistory.Location = new System.Drawing.Point(0, 0);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHistory.Size = new System.Drawing.Size(156, 43);
            this.btnHistory.TabIndex = 0;
            this.btnHistory.Text = "  History";
            this.btnHistory.UseVisualStyleBackColor = true;
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 566);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.PictureBox closeIcon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnMyFlight;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnHistory;
    }
}