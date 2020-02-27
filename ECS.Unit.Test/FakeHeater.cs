using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;

namespace ECS.Unit.Test
{
    class FakeHeater : IHeater
    {
        public bool _IsOn = false;


        public void TurnOn()
        {
            System.Console.WriteLine("Heater is on");

            _IsOn = true;
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Heater is off");

            _IsOn = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
