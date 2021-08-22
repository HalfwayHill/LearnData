using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.ReflectionPrinciple
{
    public class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is Run");
        }
    }
}
