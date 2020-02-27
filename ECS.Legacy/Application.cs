using System.Security.Cryptography.X509Certificates;

namespace ECS.Legacy
{
    public class Application
    {
        public static void Main(string[] args)
        {
            int _lowerTemperatureThreshold = 20;
            int _upperTemperatureThreshold = 25;

            var ecs = new ECS(new Heater(), new TempSensor(), new Window(), _lowerTemperatureThreshold, _upperTemperatureThreshold);

            ecs.Regulate();
        }
    }
}
