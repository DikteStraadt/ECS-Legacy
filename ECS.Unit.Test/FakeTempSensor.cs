using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;

namespace ECS.Unit.Test
{
    class FakeTempSensor : ITempSensor
    {
        public int Temp = 0;

        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
