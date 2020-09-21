using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<LabyrinthController>
        [HttpGet]
        public ActionResult<List<Labyrinth>> Get() =>
            _labyrinthService.Get();

        // GET api/<LabyrinthController>/5
        [HttpGet("{id}")]
        public ActionResult<Labyrinth> Get(string id)
        {
            var labyrinth = _labyrinthService.Get(id);

            if (labyrinth == null)
                return NotFound();

            return labyrinth;
        }

        // POST api/<LabyrinthController>
        [HttpPost]
        public ActionResult<Labyrinth> Create(Labyrinth labyrinth)
        {
            _labyrinthService.Create(labyrinth);

            return CreatedAtRoute("GetLabyrinth", new { id = labyrinth.Id.ToString() }, labyrinth);
        }

        // PUT api/<LabyrinthController>/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Labyrinth labyrinthIn)
        {
            var labyrinth = _labyrinthService.Get(id);

            if (labyrinth == null)
                return NotFound();

            _labyrinthService.Update(id, labyrinthIn);

            return NoContent();
        }

        // DELETE api/<LabyrinthController>/5
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
