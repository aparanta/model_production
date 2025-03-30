using Microsoft.AspNetCore.Mvc;

namespace CoreApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly ILogger<EquipmentController> _logger;
    private static readonly List<Equipment> _equipments = new();

    public EquipmentController(ILogger<EquipmentController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAll")]
    public IEnumerable<Equipment> Get()
    {
        return _equipments;
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<Equipment> GetById(Guid id)
    {
        var equipment = _equipments.FirstOrDefault(e => e.ID == id);
        if (equipment == null)
        {
            return NotFound();
        }
        return equipment;
    }

    

    [HttpPut("{id}", Name = "Update")]
    public IActionResult Update(Guid id, Equipment updatedEquipment)
    {
        var equipment = _equipments.FirstOrDefault(e => e.ID == id);
        if (equipment == null)
        {
            return NotFound();
        }
        equipment.State = updatedEquipment.State;
        equipment.LastUpdated = DateTime.UtcNow;
        return NoContent();
    }

    
}
