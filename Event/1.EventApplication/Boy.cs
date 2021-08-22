using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Event.EventApplication
{
    class Boy
    {
        /// <summary>
        /// Timer.Elapsed的事件处理器
        /// </summary>
        /// <param name="sender">事件拥有者</param>
        /// <param name="e">事件参数</param>
        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Boy Timer.Elapsed的事件处理器被触发");
        }
    }
}
