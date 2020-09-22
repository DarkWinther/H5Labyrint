using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabyrinthController : ControllerBase
    {
        private readonly LabyrinthService _labyrinthService;

        public LabyrinthController(LabyrinthService labyrinthService)
        {
            _labyrinthService = labyrinthService;
        }

        // GET: api/labyrinth
        [HttpGet]
        public ActionResult<Labyrinth> GetRandom() =>
            _labyrinthService.GetRandom();

        // GET: api/labyrinth/all
        [HttpGet("all")]
        public ActionResult<List<Labyrinth>> Get() =>
            _labyrinthService.Get();

        // GET api/labyrinth/id/{id}
        [HttpGet("id/{id}")]
        public ActionResult<Labyrinth> Get(string id)
        {
            var labyrinth = _labyrinthService.Get(id);

            if (labyrinth == null)
                return NotFound();

            return labyrinth;
        }

        // POST api/labyrinth
        [HttpPost]
        public ActionResult<Labyrinth> Create(Labyrinth labyrinth)
        {
            _labyrinthService.Create(labyrinth);

            return CreatedAtRoute("GetLabyrinth", new { id = labyrinth.Id.ToString() }, labyrinth);
        }

        // PUT api/labyrinth/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Labyrinth labyrinthIn)
        {
            var labyrinth = _labyrinthService.Get(id);

            if (labyrinth == null)
                return NotFound();

            _labyrinthService.Update(id, labyrinthIn);

            return NoContent();
        }

        // DELETE api/labyrinth/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var labyrinth = _labyrinthService.Get(id);

            if (labyrinth == null)
                return NotFound();

            _labyrinthService.Remove(labyrinth.Id);

            return NoContent();
        }
    }
}
