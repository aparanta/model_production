using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EquipmentMonitoringClient.Controllers;

[ApiController]
[Route("v1")]
public class MonitorClientController : ControllerBase
{
    

    private readonly ILogger<MonitorClientController> _logger;

    public MonitorClientController(ILogger<MonitorClientController> logger)
    {
        _logger = logger;
    }
    /// <summary>
    /// When update is triggered this callback will be called
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    [HttpPost("webhook_callback")]
    public IActionResult EquipmentUpdate(object payload)
    {
        _logger.LogInformation("Received payload: {payload}", payload);
        return Ok();
    }
}
