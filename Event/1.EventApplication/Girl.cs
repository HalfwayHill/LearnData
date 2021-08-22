using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Event.EventApplication
{
    class Girl
    {
        public Timer timer { get; set; }

        public Girl(Timer timer)
        {
            if (timer != null)
            {
                this.timer = timer;
                timer.Elapsed += TimerElapsed;
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Girl Timer.Elapsed的事件处理器被触发");
        }
    }
}
