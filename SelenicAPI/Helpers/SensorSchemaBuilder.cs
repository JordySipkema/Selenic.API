using SelenicAPI.Models;

namespace SelenicAPI.Helpers
{
    public static class SensorSchemaBuilder
    {
        public static SensorSchema BuildDefault(SensorType sensorType)
        {
            return new SensorSchema
            {
                Type = sensorType,
                Config = ConfigurationBuilder.BuildDefault(sensorType)
            };
        }
    }
}