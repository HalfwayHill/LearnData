using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.ReflectionPrinciple
{
    public class MediumTank : ITank
    {
        public void Run()
        {
            Console.WriteLine("MediumTank is Run");
        }

        public void Shot()
        {
            Console.WriteLine("MediumTank is Shot");
        }
    }
}
