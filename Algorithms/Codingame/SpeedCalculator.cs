// 

using System;

namespace TrafficLights
{
    public class SpeedCalculator
    {
        public int FindMaxPossibleSpeed(int speedLimit, TrafficLight[] trafficLights)
        {
            int maxSpeed = 0;
            for (int currentSpeed = speedLimit; currentSpeed >= 0; currentSpeed--)
            {
                bool crossesAllLights = true;
                for (int j = 0; j < trafficLights.Length; j++)
                {
                    if (!_canCross(currentSpeed, trafficLights[j]))
                    {
                        crossesAllLights = false;
                        break;
                    }
                }

                if (crossesAllLights)
                {
                    maxSpeed = currentSpeed;
                    break;
                }
            }

            return maxSpeed;
        }

        private bool _canCross(int speed, TrafficLight trafficLight)
        {
            double timeToTrafficLight = trafficLight.Distance * 3.6 / speed; // 3.6 for km/h to m/s conversion
            double phase = timeToTrafficLight / trafficLight.Duration;
            return Math.Floor(phase) % 2 == 0;
        }
    }

    public class TrafficLight
    {
        public int Distance { get; set; }
        public int Duration { get; set; }
    }
}