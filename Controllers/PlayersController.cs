using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayersApi.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace PlayersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        public PlayersController() {}

        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USWest2);
        private static DynamoDBContext context = new DynamoDBContext(client);

        // GET: api/Players
        [HttpGet]
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            AsyncSearch<Player> search = context.ScanAsync<Player>(Enumerable.Empty<ScanCondition>(), null);
            List<Player> result = await search.GetRemainingAsync();
            return result;
        }
 
        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<Player> GetPlayer(string id)
        {
            return await context.LoadAsync<Player>(id);
        }


        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(string id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            await context.SaveAsync(player);

            return NoContent();
        }


        // POST: api/Players
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            await context.SaveAsync(player);
            return player;
        }


        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task DeletePlayer(string id)
        {
            Task<Player> PlayerTask = context.LoadAsync<Player>(id);
            Player player = await PlayerTask;
            await context.DeleteAsync(player);
        }
    

    }
}
