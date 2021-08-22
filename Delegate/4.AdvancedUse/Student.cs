using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegate.AdvancedUse
{
    class Student
    {
        public int ID { get; set; }
        /// <summary>
        /// 输出在控制台上的颜色
        /// </summary>
        public ConsoleColor PenColor { get; set; }

        public Student(int id,ConsoleColor penColor)
        {
            this.ID = id;
            this.PenColor = penColor;
        }

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine($"Student'{this.ID}' doing homework {i} hour(s)");
                Thread.Sleep(1000);
            }
        }
    }
}
