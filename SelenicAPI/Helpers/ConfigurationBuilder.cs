using System;
using SelenicAPI.Models;

namespace SelenicAPI.Helpers
{
    public class ConfigurationBuilder
    {
        public static ConfigurationSchema BuildDefault(SensorType sensorType)
        {
            return sensorType switch
            {
                SensorType.LED => new ConfigurationSchema
                {
                    Default = 1,
                    Pin = Constants.LED_Pin
                },
                SensorType.RELAY => new ConfigurationSchema
                {
                    Default = 0,
                    Pin = Constants.Relay_Pin
                },
                _ => throw new NotImplementedException()
            };
        }

        private static class Constants
        {
            public const short LED_Pin = WemosGPIO.BUILTIN_LED;
            public const short Relay_Pin = WemosGPIO.D1;
        }
    }
}