using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.ReflectionPrinciple
{
    public class LightTank : ITank
    {
        public void Run()
        {
            Console.WriteLine("LightTank is Run");
        }

        public void Shot()
        {
            Console.WriteLine("LightTank is Shot");
        }
    }
}
