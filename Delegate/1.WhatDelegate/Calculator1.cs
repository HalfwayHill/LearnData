using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.WhatDelegate
{
    class Calculator1
    {
        public void Report()
        {
            Console.WriteLine("I have three methods.");
        }

        public int Add(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public int Sub(int a, int b)
        {
            int result = a - b;
            return result;
        }
    }
}
