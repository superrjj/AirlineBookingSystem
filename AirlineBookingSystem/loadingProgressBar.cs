using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineBookingSystem
{
    public partial class loadingProgressBar : UserControl
    {
        public loadingProgressBar()
        {
            InitializeComponent();
            this.Size = new Size(350, 25);
            this.BackColor = Color.DimGray;
            DoubleBuffered = true;
        }
        int progressB_Value = 30, pb_Max = 100, pb_Min = 0;
        float per = 0f;

        Color bar_color = Color.Aquamarine;
        public Color BarColor
        {
            get
            {
                return bar_color;
            }
            set
            {
                bar_color = value;
                Invalidate();
            }
        }
        public int Min
        {
            get
            {
                return pb_Min;
            }
            set
            {
                pb_Min = value;
                Invalidate();
            }
        }
        public int Max
        {
            get
            {
                return pb_Max;
            }
            set
            {
                pb_Max = value;
                Invalidate();
            }
        }
        public int Value
        {
            get
            {
                return progressB_Value;
            }
            set
            {
                progressB_Value = value;
                Invalidate();
            }
        }
        private void loadingProgressBar_Paint(object sender, PaintEventArgs e)
        {
            Color clr = Color.FromArgb(10, bar_color);
            SolidBrush br = new SolidBrush(bar_color);
            Brush bb = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle,bar_color,clr,100);
            e.Graphics.FillRectangle(bb,ClientRectangle);

            per = (float)ClientSize.Width / pb_Max;
            e.Graphics.FillRectangle(br, new RectangleF(0, 0, progressB_Value * per, ClientSize.Height));


            Pen pen = new Pen(Color.White, 2);
            e.Graphics.DrawRectangle(pen,0,0,ClientSize.Width,ClientSize.Height);
        }
    }
}
