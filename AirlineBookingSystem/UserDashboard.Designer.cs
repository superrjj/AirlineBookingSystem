﻿namespace AirlineBookingSystem
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSearchFlight = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTicket = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.userPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 89);
            this.panel1.TabIndex = 0;
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
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 608);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSearchFlight);
            this.panel6.Location = new System.Drawing.Point(0, 216);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(225, 53);
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
            this.btnSearchFlight.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchFlight.Name = "btnSearchFlight";
            this.btnSearchFlight.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSearchFlight.Size = new System.Drawing.Size(225, 53);
            this.btnSearchFlight.TabIndex = 0;
            this.btnSearchFlight.Text = "     Search Flight";
            this.btnSearchFlight.UseVisualStyleBackColor = true;
            this.btnSearchFlight.Click += new System.EventHandler(this.btnSearchFlight_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnViewHistory);
            this.panel5.Location = new System.Drawing.Point(0, 161);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(225, 47);
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
            this.btnViewHistory.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnViewHistory.Size = new System.Drawing.Size(225, 47);
            this.btnViewHistory.TabIndex = 4;
            this.btnViewHistory.Text = "    View History";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnTicket);
            this.panel4.Location = new System.Drawing.Point(0, 103);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 54);
            this.panel4.TabIndex = 1;
            // 
            // btnTicket
            // 
            this.btnTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTicket.FlatAppearance.BorderSize = 0;
            this.btnTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicket.ForeColor = System.Drawing.Color.White;
            this.btnTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnTicket.Image")));
            this.btnTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTicket.Location = new System.Drawing.Point(0, 0);
            this.btnTicket.Margin = new System.Windows.Forms.Padding(4);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnTicket.Size = new System.Drawing.Size(225, 54);
            this.btnTicket.TabIndex = 1;
            this.btnTicket.Text = " Ticket";
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnHome);
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 49);
            this.panel3.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 4);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(225, 49);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "         Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // userPanel
            // 
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userPanel.Location = new System.Drawing.Point(225, 89);
            this.userPanel.Margin = new System.Windows.Forms.Padding(4);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(1275, 608);
            this.userPanel.TabIndex = 2;
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
            this.btnLogout.Location = new System.Drawing.Point(0, 555);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(225, 53);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "     Search Flight";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 697);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSearchFlight;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnLogout;
    }
}