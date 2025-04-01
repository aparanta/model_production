using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreApplication.Controllers
{
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

            // Mock database save
            SaveToDatabase(equipment);

            return NoContent();
        }

        private void SaveToDatabase(Equipment equipment)
        {
            // Mock database save logic
            var index = _equipments.FindIndex(e => e.ID == equipment.ID);
            if (index != -1)
            {
                _equipments[index] = equipment;
            }
            //Trigger webhook on successful save
        }
    }

   
}
