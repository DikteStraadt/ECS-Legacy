using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;

namespace ECS.Unit.Test
{
    class FakeWindow : IWindow
    {
        public bool _IsOpen = false;

        public void Open()
        {
            System.Console.WriteLine("Window is open");

            _IsOpen = true;
        }

        public void Close()
        {
            System.Console.WriteLine("Window is closed");

            _IsOpen = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
