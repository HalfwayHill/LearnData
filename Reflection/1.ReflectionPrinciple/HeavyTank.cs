using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.ReflectionPrinciple
{
    public class HeavyTank : ITank
    {
        public void Run()
        {
            Console.WriteLine("HeavyTank is Run");
        }

        public void Shot()
        {
            Console.WriteLine("HeavyTank is Shot");
        }
    }
}
