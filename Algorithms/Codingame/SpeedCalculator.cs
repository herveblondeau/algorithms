// 

using System;
using System.Collections.Generic;

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
                    if (currentSpeed == 60 && !_canCross(currentSpeed, trafficLights[j].Distance, trafficLights[j].Duration))
                    {

                    }
                    if (!_canCross(currentSpeed, trafficLights[j].Distance, trafficLights[j].Duration))
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

        private bool _canCross(int speed, int distance, int duration)
        {
            double timeToTrafficLight = distance * 3.6 / speed; // 3.6 for km/h to m/s conversion
            double phase = timeToTrafficLight / duration;
            return Math.Floor(phase) % 2 == 0;
        }
    }

    public class TrafficLight
    {
        public int Distance { get; set; }
        public int Duration { get; set; }
    }
}