using Microsoft.AspNetCore.Mvc;


namespace EquipmentMonitoring.Controllers;

[ApiController]
[Route("v1")]
public class EquipmentMonitorController : ControllerBase
{
  

    private readonly ILogger<EquipmentMonitorController> _logger;
    private readonly WebhookService _webhook;

    public EquipmentMonitorController(ILogger<EquipmentMonitorController> logger, WebhookService webhook)
    {
        _logger = logger;
        _webhook = webhook;
    }
  /// <summary>
  /// Subscribe to Topic 
  /// </summary>
  /// <param name="sub"></param>
  /// <returns></returns>
    [HttpPost("subscribe")]
    public IActionResult Subscribe(Subscription sub)
    {
        _webhook.Subscribe(sub);
        return Ok();
    }
    /// <summary>
    /// Trigger should invoke this method
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpPost("publish_message")]
    public async Task<IActionResult> PublishMessage([FromBody] PublishRequest req)
    {
        await _webhook.PublishMessage(req.Topic, req.Message);

        return Ok();
    }
}
