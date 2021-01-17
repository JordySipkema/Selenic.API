using System;

namespace SelenicAPI.Models
{
    public class Node
    {
        public int Hardware_id { get; set; }
        public string Name { get; set; }
        public SensorSchema[] Sensors { get; set; }
    }
}
