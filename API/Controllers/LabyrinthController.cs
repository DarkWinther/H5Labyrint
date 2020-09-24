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
        [HttpGet("id/{id}", Name = "GetLabyrinth")]
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
            if (IsValidLabyrinth(labyrinth))
            {
                _labyrinthService.Create(labyrinth);

                return CreatedAtRoute("GetLabyrinth", new { id = labyrinth.Id }, labyrinth);
            }
            return BadRequest();
        }

        // PUT api/labyrinth/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Labyrinth labyrinthIn)
        {
            if (!IsValidLabyrinth(labyrinthIn))
                return BadRequest();

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

        private bool IsValidLabyrinth(Labyrinth labyrinth)
        {
            if (labyrinth.LabyrinthSpaces == null)
                return false;
            int Start = 0;
            int Goal = 0;
            int Wall = 0;
            int Empty = 0;

            foreach (LabyrinthSpace[] row in labyrinth.LabyrinthSpaces)
            {
                foreach (LabyrinthSpace space in row)
                {
                    switch (space)
                    {
                        case LabyrinthSpace.Empty:
                            Empty++;
                            break;
                        case LabyrinthSpace.Wall:
                            Wall++;
                            break;
                        case LabyrinthSpace.Start:
                            Start++;
                            break;
                        case LabyrinthSpace.Goal:
                            Goal++;
                            break;
                    }
                }
            }

            if (Start == 1 && Goal >= 1)
                return true;

            return false;
        }
    }
}
