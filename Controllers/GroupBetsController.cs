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
    public class GroupBetsController : ControllerBase
    {

        public GroupBetsController() {}

        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USWest2);
        private static DynamoDBContext context = new DynamoDBContext(client);

        // GET: api/Bets
        [HttpGet]
        public async Task<IEnumerable<GroupBet>> GetGroupBets()
        {
            AsyncSearch<GroupBet> search = context.ScanAsync<GroupBet>(Enumerable.Empty<ScanCondition>(), null);
            List<GroupBet> result = await search.GetRemainingAsync();
            return result;
        }
 
        // GET: api/Bets/5
        [HttpGet("{id}")]
        public async Task<GroupBet> GetGroupBet(string id)
        {
            return await context.LoadAsync<GroupBet>(id);
        }


        // PUT: api/Bets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupBet(string id, GroupBet bet)
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
        public async Task<ActionResult<GroupBet>> PostBet(GroupBet bet)
        {
            await context.SaveAsync(bet);
            return bet;
        }


        // DELETE: api/Bets/5
        [HttpDelete("{id}")]
        public async Task DeleteGroupBet(string id)
        {
            Task<GroupBet> BetTask = context.LoadAsync<GroupBet>(id);
            GroupBet bet = await BetTask;
            await context.DeleteAsync(bet);
        }
    

    }
}
