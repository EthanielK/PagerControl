using System;
using System.Drawing;

namespace ctlClockLib
{
    public partial class ctlAlarmClock : ctlClock
    {
        private DateTime dteAlarmTime;
        private bool blnAlarmSet;
        private bool blnColorTicker;

        public ctlAlarmClock()
        {
            InitializeComponent();
        }

        public DateTime AlarmTime { get => dteAlarmTime; set => dteAlarmTime = value; }
        public bool AlarmSet { get => blnAlarmSet; set => blnAlarmSet = value; }

        protected override void timer1_Tick(object sender, EventArgs e)
        {
            base.timer1_Tick(sender, e);// 基类中的timer1_Tick功能正常运行
            if (AlarmSet == false)
                return;
            else
            {
                if (AlarmTime.Date == DateTime.Now.Date && AlarmTime.Hour ==
                    DateTime.Now.Hour && AlarmTime.Minute == DateTime.Now.Minute)
                {
                    lblAlarm.Visible = true;
                    if (blnColorTicker == false)
                    {
                        lblAlarm.BackColor = Color.Red;
                        blnColorTicker = true;
                    }
                    else
                    {
                        lblAlarm.BackColor = Color.Blue;
                        blnColorTicker = false;
                    }
                }
                else
                {
                    lblAlarm.Visible = false;
                }
            }
        }

        private void lblAlarm_Click(object sender, EventArgs e)
        {
            AlarmSet = false;
            lblAlarm.Visible = false;
        }
    }
}