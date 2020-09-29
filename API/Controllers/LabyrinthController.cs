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
    public class LabyrinthController : ControllerBase   // Controlleren her bruger LabyrinthService.cs til kommunikation med databasen
    {
        private readonly LabyrinthService _labyrinthService;

        public LabyrinthController(LabyrinthService labyrinthService)
        {
            _labyrinthService = labyrinthService;
        }

        // GET: api/labyrinth
        [HttpGet]
        public ActionResult<List<Labyrinth>> Get() =>
            _labyrinthService.Get();    // Hent alle labyrinter

        // GET: api/labyrinth/random
        [HttpGet("random")]
        public ActionResult<Labyrinth> GetRandom() =>
            _labyrinthService.GetRandom();  // Hent en tilfældig labyrint

        // GET api/labyrinth/id/{id}
        [HttpGet("id/{id}", Name = "GetLabyrinth")]
        public ActionResult<Labyrinth> Get(string id)
        {
            var labyrinth = _labyrinthService.Get(id);  // Hent labyrinten vha. id

            if (labyrinth == null)
                return NotFound();  // Hvis labyrinten ikke eksisterer så send en HTTP 404

            return labyrinth;   // Send labyrinten tilbage
        }

        // POST api/labyrinth
        [HttpPost]
        public ActionResult<Labyrinth> Create(Labyrinth labyrinth)
        {
            if (IsValidLabyrinth(labyrinth))    // Check om labyrinten er gyldig
            {
                _labyrinthService.Create(labyrinth);    // Opret labyrinten

                return CreatedAtRoute("GetLabyrinth", new { id = labyrinth.Id }, labyrinth);    // Hvis labyrinten blev oprettet så send en HTTP 201 med labyrinten i
            }
            return BadRequest();    // Hvis labyrinten ikke er gyldig så send en HTTP 400
        }

        // PUT api/labyrinth/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Labyrinth labyrinthIn)
        {
            if (!IsValidLabyrinth(labyrinthIn)) // Check om labyrinten er gyldig
                return BadRequest();    // Hvis labyrinten ikke eksisterer så send en HTTP 404

            var labyrinth = _labyrinthService.Get(id);  // Hent labyrinten vha. id

            if (labyrinth == null)
                return NotFound();  // Hvis labyrinten ikke eksisterer så send en HTTP 404

            _labyrinthService.Update(id, labyrinthIn);  // Opdater labyrinten

            return NoContent();     // Hvis labyrinten blev opdateret så send en HTTP 204
        }

        // DELETE api/labyrinth/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var labyrinth = _labyrinthService.Get(id);  // Hent labyrinten vha. id

            if (labyrinth == null)
                return NotFound();  // Hvis labyrinten ikke eksisterer så send en HTTP 404

            _labyrinthService.Remove(labyrinth.Id);     // Slet labyrinten

            return NoContent();     // Hvis labyrinten blev slettet så send en HTTP 204
        }

        private bool IsValidLabyrinth(Labyrinth labyrinth)
        {
            if (labyrinth.LabyrinthSpaces == null)
                return false;   // Hvis "labyrinth" ikke har nogen labyrint så returner false

            int Start = 0;  // Antallet af start felter
            int Goal = 0;   // Antallet af mål
            int Wall = 0;   // Antallet af vægge
            int Empty = 0;  // Antallet af tomme felter

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

            if (Start == 1 && Goal >= 1)    // Der skal være et start felt og mindst et mål
                return true;

            return false;
        }
    }
}
