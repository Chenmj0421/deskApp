using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace aiDoctor
{
   
    public class NotifyIconAnimator
    {
        #region Fields

        int CurrLoopCount;
        int CurrLoopIndex;
        Icon[] Icons;
        int LoopCount;
        NotifyIcon NotifyIcon;
        //Icon PrevIcon;
        Timer Timer;

        #endregion Fields

        #region Constructors

        public NotifyIconAnimator(NotifyIcon icon)
        {
            if (icon == null)
            {
                throw new ArgumentNullException("icon");
            }
            NotifyIcon = icon;
        }

        #endregion Constructors

        #region Methods
        
        //开始闪烁，icons是图标列表，interval是Timer间隔，loopCount是闪烁次数，-1代表永远循环
        public void StartAnimation(Icon[] icons, int interval, int loopCount)
        {
            if (icons == null)
            {
                throw new ArgumentNullException("icons");
            }
            if (Timer != null) {
                StopAnimation();
            }
               
            Icons = icons;
            Timer = new Timer();
            Timer.Interval = interval;
            LoopCount = loopCount;
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        public void StopAnimation()
        {
            if (Timer != null) {
                Timer.Stop();
                Timer.Tick -= Timer_Tick;
                Timer.Dispose();
                foreach (var icon in Icons)
                {
                    icon.Dispose();
                 }
            }
            NotifyIcon.Icon = (Icon)(myAIDoctor.Properties.Resources.aiShow); ;
            Timer = null;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            CurrLoopCount++;
            if (LoopCount != -1 && CurrLoopCount > LoopCount)
            {
                StopAnimation();
                return;
            }
            if (CurrLoopIndex >= Icons.Length)
                CurrLoopIndex = 0;
            NotifyIcon.Icon = Icons[CurrLoopIndex];
            CurrLoopIndex++;
        }

        #endregion Methods
    }
}