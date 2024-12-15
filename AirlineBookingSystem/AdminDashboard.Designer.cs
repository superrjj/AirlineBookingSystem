namespace AirlineBookingSystem
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFullname = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.adminPanel = new System.Windows.Forms.Panel();
            this.btnLogoutAdmin = new System.Windows.Forms.Button();
            this.btnPassenger = new System.Windows.Forms.Button();
            this.btnArchived = new System.Windows.Forms.Button();
            this.btnCancellation = new System.Windows.Forms.Button();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.closeIcon = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.closeIcon);
            this.panel1.Controls.Add(this.lblFullname);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 89);
            this.panel1.TabIndex = 1;
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullname.ForeColor = System.Drawing.Color.White;
            this.lblFullname.Location = new System.Drawing.Point(16, 26);
            this.lblFullname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(0, 39);
            this.lblFullname.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnLogoutAdmin);
            this.panel2.Controls.Add(this.btnPassenger);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 608);
            this.panel2.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnArchived);
            this.panel6.Location = new System.Drawing.Point(0, 217);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(225, 53);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnCancellation);
            this.panel5.Location = new System.Drawing.Point(0, 161);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(225, 47);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 103);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 54);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddFlight);
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 49);
            this.panel3.TabIndex = 0;
            // 
            // adminPanel
            // 
            this.adminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanel.Location = new System.Drawing.Point(225, 89);
            this.adminPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(1275, 608);
            this.adminPanel.TabIndex = 3;
            // 
            // btnLogoutAdmin
            // 
            this.btnLogoutAdmin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogoutAdmin.FlatAppearance.BorderSize = 0;
            this.btnLogoutAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoutAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogoutAdmin.ForeColor = System.Drawing.Color.White;
            this.btnLogoutAdmin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogoutAdmin.Image")));
            this.btnLogoutAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoutAdmin.Location = new System.Drawing.Point(0, 555);
            this.btnLogoutAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogoutAdmin.Name = "btnLogoutAdmin";
            this.btnLogoutAdmin.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnLogoutAdmin.Size = new System.Drawing.Size(225, 53);
            this.btnLogoutAdmin.TabIndex = 4;
            this.btnLogoutAdmin.Text = "Logout";
            this.btnLogoutAdmin.UseVisualStyleBackColor = true;
            this.btnLogoutAdmin.Click += new System.EventHandler(this.btnLogoutAdmin_Click);
            // 
            // btnPassenger
            // 
            this.btnPassenger.FlatAppearance.BorderSize = 0;
            this.btnPassenger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassenger.ForeColor = System.Drawing.Color.White;
            this.btnPassenger.Image = ((System.Drawing.Image)(resources.GetObject("btnPassenger.Image")));
            this.btnPassenger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassenger.Location = new System.Drawing.Point(0, 100);
            this.btnPassenger.Margin = new System.Windows.Forms.Padding(4);
            this.btnPassenger.Name = "btnPassenger";
            this.btnPassenger.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnPassenger.Size = new System.Drawing.Size(225, 54);
            this.btnPassenger.TabIndex = 0;
            this.btnPassenger.Text = "   Passenger";
            this.btnPassenger.Click += new System.EventHandler(this.btnPassenger_Click);
            // 
            // btnArchived
            // 
            this.btnArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArchived.FlatAppearance.BorderSize = 0;
            this.btnArchived.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchived.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchived.ForeColor = System.Drawing.Color.White;
            this.btnArchived.Image = ((System.Drawing.Image)(resources.GetObject("btnArchived.Image")));
            this.btnArchived.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArchived.Location = new System.Drawing.Point(0, 0);
            this.btnArchived.Margin = new System.Windows.Forms.Padding(4);
            this.btnArchived.Name = "btnArchived";
            this.btnArchived.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnArchived.Size = new System.Drawing.Size(225, 53);
            this.btnArchived.TabIndex = 0;
            this.btnArchived.Text = "     Archived";
            this.btnArchived.UseVisualStyleBackColor = true;
            this.btnArchived.Click += new System.EventHandler(this.btnArchived_Click);
            // 
            // btnCancellation
            // 
            this.btnCancellation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancellation.FlatAppearance.BorderSize = 0;
            this.btnCancellation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancellation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancellation.ForeColor = System.Drawing.Color.White;
            this.btnCancellation.Image = ((System.Drawing.Image)(resources.GetObject("btnCancellation.Image")));
            this.btnCancellation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancellation.Location = new System.Drawing.Point(0, 0);
            this.btnCancellation.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancellation.Name = "btnCancellation";
            this.btnCancellation.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnCancellation.Size = new System.Drawing.Size(225, 47);
            this.btnCancellation.TabIndex = 4;
            this.btnCancellation.Text = "    Cancellation";
            this.btnCancellation.UseVisualStyleBackColor = true;
            this.btnCancellation.Click += new System.EventHandler(this.btnCancellation_Click);
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.FlatAppearance.BorderSize = 0;
            this.btnAddFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFlight.ForeColor = System.Drawing.Color.White;
            this.btnAddFlight.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFlight.Image")));
            this.btnAddFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFlight.Location = new System.Drawing.Point(0, 4);
            this.btnAddFlight.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAddFlight.Size = new System.Drawing.Size(225, 49);
            this.btnAddFlight.TabIndex = 2;
            this.btnAddFlight.Text = "        Add Flight";
            this.btnAddFlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFlight.UseVisualStyleBackColor = true;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // closeIcon
            // 
            this.closeIcon.Image = ((System.Drawing.Image)(resources.GetObject("closeIcon.Image")));
            this.closeIcon.Location = new System.Drawing.Point(1444, 4);
            this.closeIcon.Margin = new System.Windows.Forms.Padding(4);
            this.closeIcon.Name = "closeIcon";
            this.closeIcon.Size = new System.Drawing.Size(52, 36);
            this.closeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeIcon.TabIndex = 2;
            this.closeIcon.TabStop = false;
            this.closeIcon.Click += new System.EventHandler(this.closeIcon_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 697);
            this.Controls.Add(this.adminPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox closeIcon;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPassenger;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnArchived;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddFlight;
        private System.Windows.Forms.Panel adminPanel;
        private System.Windows.Forms.Button btnLogoutAdmin;
        private System.Windows.Forms.Button btnCancellation;
    }
}