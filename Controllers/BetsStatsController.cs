using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BetsApi.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace BetsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetsStatsController : ControllerBase
    {

        public BetsStatsController() {}

        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USWest2);
        private static DynamoDBContext context = new DynamoDBContext(client);

        // GET: api/BetsStats
        [HttpGet]
        public async Task<IEnumerable<BetsStat>> GetBetsStats()
        {
            AsyncSearch<BetsStat> search = context.ScanAsync<BetsStat>(Enumerable.Empty<ScanCondition>(), null);
            List<BetsStat> result = await search.GetRemainingAsync();
            return result;
        }
 
        // GET: api/BetsStats/5
        [HttpGet("{timePeriod}")]
        public async Task<BetsStat> GetBet(string timePeriod)
        {
            return await context.LoadAsync<BetsStat>(timePeriod);
        }


        // PUT: api/BetsStats/5
        [HttpPut("{timePeriod}")]
        public async Task<IActionResult> PutBet(string timePeriod, BetsStat stat)
        {
            if (timePeriod != stat.TimePeriod)
            {
                return BadRequest();
            }

            await context.SaveAsync(stat);

            return NoContent();
        }


        // POST: api/BetsStats
        [HttpPost]
        public async Task<ActionResult<BetsStat>> PostBet(BetsStat stat)
        {
            await context.SaveAsync(stat);
            return stat;
        }


        // DELETE: api/BetsStats/5
        [HttpDelete("{timePeriod}")]
        public async Task DeleteBetsStat(string timePeriod)
        {
            Task<BetsStat> BetsStatTask = context.LoadAsync<BetsStat>(timePeriod);
            BetsStat stat = await BetsStatTask;
            await context.DeleteAsync(stat);
        }
    

    }
}
