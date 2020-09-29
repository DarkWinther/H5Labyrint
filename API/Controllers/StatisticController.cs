using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase   // Controlleren her bruger StatisticsService.cs til kommunikation med databasen
    {
        private readonly StatisticService _statisticService;

        public StatisticController(StatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        // GET: api/Statistic
        [HttpGet]
        public ActionResult<List<Statistic>> Get() =>
            _statisticService.Get();    // Hent alle statistikker

        // GET: api/Statistic/5
        [HttpGet("{labyrinth_id}", Name = "GetStatistic")]
        public ActionResult<List<Statistic>> Get(string labyrinth_id)
        {
            var statistic = _statisticService.GetAllForId(labyrinth_id);    // Hent alle statistikker der høre til den ønskede labyrint

            if (statistic == null)
                return NotFound();  // Hvis der ikke blev fundet noget så send en HTTP 404

            return statistic;   // Send alle statistikkerne
        }

        // POST: api/Statistic
        [HttpPost]
        public ActionResult<Statistic> Create(Statistic statistic)
        {
            _statisticService.Create(statistic);    // Opret statistikkerne på databasen

            return CreatedAtRoute("GetStatistic", new { id = statistic.Id }, statistic);    // Hvis statistiken blev oprettet så send en HTTP 201 med statistiken i
        }

        // PUT: api/Statistic/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Statistic statisticIn)
        {
            var statistic = _statisticService.Get(id);  // Hent en specifik statistik

            if (statistic == null)
                return NotFound();  // Hvis der ikke blev fundet noget så send en HTTP 404

            _statisticService.Update(id, statisticIn);  // Opdater statistikken

            return NoContent();     // Hvis statistikken blev opdateret så send en HTTP 204
        }

        // DELETE: api/Statistic/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var statistic = _statisticService.Get(id);  // Hent en specifik statistik

            if (statistic == null)
                return NotFound();  // Hvis der ikke blev fundet noget så send en HTTP 404

            _statisticService.Remove(statistic.Id); // Slet statistikken

            return NoContent();     // Hvis statistikken blev slettet så send en HTTP 204
        }
    }
}
