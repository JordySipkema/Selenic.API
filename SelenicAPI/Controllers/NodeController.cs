using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelenicAPI.Helpers;
using SelenicAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelenicAPI.Controllers
{
    [ApiController]
    [Route("nodes")]
    public class NodeController : ControllerBase
    {
        private readonly ILogger<NodeController> _logger;

        public NodeController(ILogger<NodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Node> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Node
            {
                Hardware_id = index,
                Name = $"Example {index}",
                Sensors = Array.Empty<SensorSchema>()
            })
            .ToArray();
        }

        [HttpGet("{hardwareId}")]
        public NodeResult GetNodeConfiguration(string hardwareId)
        {
            int hwId = 0;
            try {
                hwId = Int32.Parse(hardwareId, System.Globalization.NumberStyles.HexNumber);
            } catch (Exception) {
                _logger.LogWarning("Could not parse chipId: {hardwareId}. Using 0 as a default.", hardwareId);
            }

            _logger.LogInformation("Returning information for node {hardwareId}", hwId);


            // Return a static node untill we have a database up and running.
            // Or have some configuration in place to load dynamic node settings
            return NodeResult.FromNode(
                new Node {
                    Hardware_id = hwId,
                    Name = "DefaultNode",
                    Sensors = new[] { SensorSchemaBuilder.BuildDefault(SensorType.LED)}
                }
            );
        }

        [HttpPost("ping/{hardwareId}")]
        public IActionResult Ping(string hardwareId, [FromBody] Heartbeat heartbeat)
        {
            _logger.LogInformation("ESP8266 {hardwareId} is sending a heartbeat: {@heartbeat}", hardwareId, heartbeat);
            
            return Ok();
        }
    }
}
