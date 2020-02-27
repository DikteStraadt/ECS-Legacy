using System;
using ECS;
using NUnit.Framework;

namespace ECS.Unit.Test
{
    [TestFixture]
    public class UnitTest
    {
        private int _lowerTemperatureThreshold;
        private int _upperTemperatureThreshold;

        private FakeHeater _heater;
        private FakeTempSensor _sensor;
        private FakeWindow _window;

        private Legacy.ECS _uut; 

        [SetUp]
        public void SetUp()
        {
            _lowerTemperatureThreshold = 20; 
            _upperTemperatureThreshold = 25;

            _heater = new FakeHeater();
            _sensor = new FakeTempSensor();
            _window = new FakeWindow();

            _uut = new Legacy.ECS(_heater, _sensor, _window, _lowerTemperatureThreshold, _upperTemperatureThreshold);
        }

        [TestCase(23,false)]
        [TestCase(19, true)]
        [TestCase(28, false)]
        public void Test_Regulate_IsOn(int temp, bool res)
        {
            _sensor.Temp = temp;

            _uut.Regulate();

            Assert.That(_heater._IsOn,Is.EqualTo(res));
        }

        [TestCase(23, false)]
        [TestCase(19, false)]
        [TestCase(28, true)]
        public void Test_Regulate_IsOpen(int temp, bool res)
        {
            _sensor.Temp = temp;

            _uut.Regulate();

            Assert.That(_window._IsOpen, Is.EqualTo(res));
        }

        [Test]
        public void Test_Heater_Selftest()
        {
            Assert.That(_heater.RunSelfTest(),Is.EqualTo(true));
        }

        [Test]
        public void Test_Sensor_Selftest()
        {
            Assert.That(_sensor.RunSelfTest(), Is.EqualTo(true));
        }

        [Test]
        public void Test_Window_Selftest()
        {
            Assert.That(_window.RunSelfTest(), Is.EqualTo(true));
        }


    }
}
