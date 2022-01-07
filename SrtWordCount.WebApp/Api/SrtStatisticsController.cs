using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SrtWordCount.Data;
using SrtWordCount.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SrtWordCount.WebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SrtStatisticsController : ControllerBase
    {
        private readonly SrtWordCountDbContext _db;

        public SrtStatisticsController(SrtWordCountDbContext db)
        {
            _db = db;
        }

        // GET: api/<SrtStatisticsController>
        [HttpGet]
        public IEnumerable<SrtStatisticsViewModel> Get()
        {
            return _db.SrtStatisticsModelList.Select(x => x.ConvertToSrtStatisticsViewModel());
        }

        // GET api/<SrtStatisticsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var srtStatistics = await _db.SrtStatisticsModelList.FindAsync(id);

            if (srtStatistics == null)
            {
                return NotFound();
            }

            return Ok(srtStatistics.ConvertToSrtStatisticsViewModel());
        }

        // POST api/<SrtStatisticsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SrtStatisticsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.SrtStatisticsModelList.Add(model);
            await _db.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = model.Id }, model.ConvertToSrtStatisticsViewModel());
        }

        // PUT api/<SrtStatisticsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] SrtStatisticsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            _db.Entry(model).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SrtStatisticsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<SrtStatisticsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var srtStatistics = await _db.SrtStatisticsModelList.FindAsync(id);

            if (srtStatistics == null)
            {
                return NotFound();
            }

            _db.SrtStatisticsModelList.Remove(srtStatistics);
            await _db.SaveChangesAsync();

            return Ok(srtStatistics);
        }

        private bool SrtStatisticsExists(int id)
        {
            return _db.SrtStatisticsModelList.Any(x => x.Id == id);
        }
    }
}
