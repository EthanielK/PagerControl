using System;
using System.Drawing;
using System.Windows.Forms;

namespace ctlClockLib
{
    public partial class ctlClock : UserControl
    {
        private Color colFColor;
        private Color colBColor;

        public Color ClockBackColor
        {
            get => colBColor;
            set
            {
                colBColor = value;
                lblDisplay.BackColor = colBColor;
            }
        }

        public Color ClockForeColor
        {
            get => colFColor;
            set
            {
                colFColor = value;
                lblDisplay.ForeColor = colFColor;
            }
        }

        public ctlClock()
        {
            InitializeComponent();
        }

        protected virtual void timer1_Tick(object sender, EventArgs e)
        {
            lblDisplay.Text = DateTime.Now.ToLongTimeString();
        }
    }
}