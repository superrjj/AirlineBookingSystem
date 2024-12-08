namespace AirlineBookingSystem
{
    partial class HistoryView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowHistoryViewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 653);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1263, 63);
            this.panel1.TabIndex = 0;
            // 
            // flowHistoryViewPanel
            // 
            this.flowHistoryViewPanel.AutoScroll = true;
            this.flowHistoryViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowHistoryViewPanel.Location = new System.Drawing.Point(0, 0);
            this.flowHistoryViewPanel.Margin = new System.Windows.Forms.Padding(4);
            this.flowHistoryViewPanel.Name = "flowHistoryViewPanel";
            this.flowHistoryViewPanel.Size = new System.Drawing.Size(1263, 653);
            this.flowHistoryViewPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1250, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(13, 653);
            this.panel3.TabIndex = 3;
            // 
            // HistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 716);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowHistoryViewPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HistoryView";
            this.Text = "Booked_History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowHistoryViewPanel;
        private System.Windows.Forms.Panel panel3;
    }
}