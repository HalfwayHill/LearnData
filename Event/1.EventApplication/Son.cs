using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Event.EventApplication
{
    class Son
    {
        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Son Timer.Elapsed的事件处理器被触发");
        }
    }
}
