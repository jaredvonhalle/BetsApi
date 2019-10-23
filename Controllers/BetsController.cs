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
    public class BetsController : ControllerBase
    {

        public BetsController() {}

        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USWest2);
        private static DynamoDBContext context = new DynamoDBContext(client);

        // GET: api/Bets
        [HttpGet]
        public async Task<IEnumerable<Bet>> GetBets()
        {
            AsyncSearch<Bet> search = context.ScanAsync<Bet>(Enumerable.Empty<ScanCondition>(), null);
            List<Bet> result = await search.GetRemainingAsync();
            return result;
        }
 
        // GET: api/Bets/5
        [HttpGet("{id}")]
        public async Task<Bet> GetBet(string id)
        {
            return await context.LoadAsync<Bet>(id);
        }


        // PUT: api/Bets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBet(string id, Bet bet)
        {
            if (id != bet.Id)
            {
                return BadRequest();
            }

            await context.SaveAsync(bet);

            return NoContent();
        }


        // POST: api/Bets
        [HttpPost]
        public async Task<ActionResult<Bet>> PostBet(Bet bet)
        {
            await context.SaveAsync(bet);
            return bet;
        }


        // DELETE: api/Bets/5
        [HttpDelete("{id}")]
        public async Task DeleteBet(string id)
        {
            Task<Bet> BetTask = context.LoadAsync<Bet>(id);
            Bet bet = await BetTask;
            await context.DeleteAsync(bet);
        }
    

    }
}
