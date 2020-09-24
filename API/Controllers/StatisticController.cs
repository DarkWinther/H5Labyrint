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
    public class StatisticController : ControllerBase
    {
        private readonly StatisticService _statisticService;

        public StatisticController(StatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        // GET: api/Statistic
        [HttpGet]
        public ActionResult<List<Statistic>> Get() =>
            _statisticService.Get();

        // GET: api/Statistic/5
        [HttpGet("{id}", Name = "GetStatistic")]
        public ActionResult<Statistic> Get(string id)
        {
            var statistic = _statisticService.Get(id);

            if (statistic == null)
                return NotFound();

            return statistic;
        }

        // POST: api/Statistic
        [HttpPost]
        public ActionResult<Statistic> Create(Statistic statistic)
        {
            _statisticService.Create(statistic);

            return CreatedAtRoute("GetStatistic", new { id = statistic.Id }, statistic);
        }

        // PUT: api/Statistic/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Statistic statisticIn)
        {
            var statistic = _statisticService.Get(id);

            if (statistic == null)
                return NotFound();

            _statisticService.Update(id, statisticIn);

            return NoContent();
        }

        // DELETE: api/Statistic/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var statistic = _statisticService.Get(id);

            if (statistic == null)
                return NotFound();

            _statisticService.Remove(statistic.Id);

            return NoContent();
        }
    }
}
