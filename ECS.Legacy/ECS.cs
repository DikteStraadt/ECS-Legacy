using System;

namespace ECS.Legacy
{
    public class ECS
    {
        public int _LowerTemperatureThreshold;
        public int _UpperTemperatureThreshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;

        public ECS(IHeater heater, ITempSensor sensor, IWindow window, int lowerTemperatureThreshold, int upperTemperatureThreshold)
        {
            _tempSensor = sensor;
            _heater = heater;
            _window = window;

            _LowerTemperatureThreshold = lowerTemperatureThreshold;
            _UpperTemperatureThreshold = upperTemperatureThreshold;
        }

        public int LowerTemperatureThreshold
        {
            get { return _LowerTemperatureThreshold; }
            set { 
                if (value <= _UpperTemperatureThreshold) 
                    _LowerTemperatureThreshold = value;
                else throw new ArgumentException("Lower threshold must be <= upper threshold");
            }
        }

        public int UpperTemperatureThreshold
        {
            get { return _UpperTemperatureThreshold; }
            set
            {
                if (value >= _LowerTemperatureThreshold)
                    _UpperTemperatureThreshold = value;
                else throw new ArgumentException("Upper threshold must be <= lower threshold");
            }
        }

        public void Regulate()
        {
            int t = _tempSensor.GetTemp();

            if (t < _LowerTemperatureThreshold) 
            {
                _heater.TurnOn();
                _window.Close();
            }
            else if (_LowerTemperatureThreshold <= t && t <= _UpperTemperatureThreshold)
            {
                _heater.TurnOff();
                _window.Close();
            }
            else if (t > _UpperTemperatureThreshold)
            {
                _heater.TurnOff();
                _window.Open();
            }
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest() && _window.RunSelfTest();
        }
    }
}
