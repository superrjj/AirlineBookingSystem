namespace AirlineBookingSystem
{
    partial class AdminFlightView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminFlightView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.addIcon = new System.Windows.Forms.PictureBox();
            this.flowAdminFlightView = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addIcon)).BeginInit();
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
            this.panel1.TabIndex = 4;
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
            // flowAdminFlightView
            // 
            this.flowAdminFlightView.AutoScroll = true;
            this.flowAdminFlightView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowAdminFlightView.Location = new System.Drawing.Point(0, 0);
            this.flowAdminFlightView.Name = "flowAdminFlightView";
            this.flowAdminFlightView.Size = new System.Drawing.Size(1263, 642);
            this.flowAdminFlightView.TabIndex = 5;
            // 
            // AdminFlightView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 716);
            this.Controls.Add(this.flowAdminFlightView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminFlightView";
            this.Text = "AdminFlightView";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox addIcon;
        private System.Windows.Forms.FlowLayoutPanel flowAdminFlightView;
    }
}