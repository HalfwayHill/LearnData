using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.ReflectionPrinciple
{
    public class Driver
    {
        private IVehicle _Vehicle;

        public Driver(IVehicle vehicle)
        {
            this._Vehicle = vehicle;
        }

        public void Drive()
        {
            this._Vehicle.Run();
        }
    }
}
