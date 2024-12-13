﻿namespace AirlineBookingSystem
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
            this.closeIcon = new System.Windows.Forms.PictureBox();
            this.lblFullname = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPassenger = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSearchFlight = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.adminPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1125, 72);
            this.panel1.TabIndex = 1;
            // 
            // closeIcon
            // 
            this.closeIcon.Image = ((System.Drawing.Image)(resources.GetObject("closeIcon.Image")));
            this.closeIcon.Location = new System.Drawing.Point(1083, 3);
            this.closeIcon.Name = "closeIcon";
            this.closeIcon.Size = new System.Drawing.Size(39, 29);
            this.closeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeIcon.TabIndex = 2;
            this.closeIcon.TabStop = false;
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
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnPassenger);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 494);
            this.panel2.TabIndex = 2;
            // 
            // btnPassenger
            // 
            this.btnPassenger.FlatAppearance.BorderSize = 0;
            this.btnPassenger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassenger.ForeColor = System.Drawing.Color.White;
            this.btnPassenger.Image = ((System.Drawing.Image)(resources.GetObject("btnPassenger.Image")));
            this.btnPassenger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassenger.Location = new System.Drawing.Point(0, 81);
            this.btnPassenger.Name = "btnPassenger";
            this.btnPassenger.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.btnPassenger.Size = new System.Drawing.Size(169, 44);
            this.btnPassenger.TabIndex = 0;
            this.btnPassenger.Text = "   Passenger";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSearchFlight);
            this.panel6.Location = new System.Drawing.Point(0, 176);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(169, 43);
            this.panel6.TabIndex = 3;
            // 
            // btnSearchFlight
            // 
            this.btnSearchFlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchFlight.FlatAppearance.BorderSize = 0;
            this.btnSearchFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchFlight.ForeColor = System.Drawing.Color.White;
            this.btnSearchFlight.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchFlight.Image")));
            this.btnSearchFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchFlight.Location = new System.Drawing.Point(0, 0);
            this.btnSearchFlight.Name = "btnSearchFlight";
            this.btnSearchFlight.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.btnSearchFlight.Size = new System.Drawing.Size(169, 43);
            this.btnSearchFlight.TabIndex = 0;
            this.btnSearchFlight.Text = "     Search Flight";
            this.btnSearchFlight.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnViewHistory);
            this.panel5.Location = new System.Drawing.Point(0, 131);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(169, 38);
            this.panel5.TabIndex = 2;
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewHistory.FlatAppearance.BorderSize = 0;
            this.btnViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewHistory.ForeColor = System.Drawing.Color.White;
            this.btnViewHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnViewHistory.Image")));
            this.btnViewHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewHistory.Location = new System.Drawing.Point(0, 0);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.btnViewHistory.Size = new System.Drawing.Size(169, 38);
            this.btnViewHistory.TabIndex = 3;
            this.btnViewHistory.Text = "    View History";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(169, 44);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddFlight);
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(169, 40);
            this.panel3.TabIndex = 0;
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.FlatAppearance.BorderSize = 0;
            this.btnAddFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFlight.ForeColor = System.Drawing.Color.White;
            this.btnAddFlight.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFlight.Image")));
            this.btnAddFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFlight.Location = new System.Drawing.Point(0, 3);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.btnAddFlight.Size = new System.Drawing.Size(169, 40);
            this.btnAddFlight.TabIndex = 2;
            this.btnAddFlight.Text = "        Add Flight";
            this.btnAddFlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFlight.UseVisualStyleBackColor = true;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // adminPanel
            // 
            this.adminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanel.Location = new System.Drawing.Point(169, 72);
            this.adminPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(956, 494);
            this.adminPanel.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 451);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(19, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(169, 43);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 566);
            this.Controls.Add(this.adminPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox closeIcon;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPassenger;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSearchFlight;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddFlight;
        private System.Windows.Forms.Panel adminPanel;
        private System.Windows.Forms.Button btnLogout;
    }
}