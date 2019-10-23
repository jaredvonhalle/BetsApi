using Amazon.DynamoDBv2.DataModel;

namespace PlayersApi.Models
{
    [DynamoDBTable("Players")]
    public class Player
    {
        public Player() {}

        public Player(string id){Id = id;}

        [DynamoDBHashKey]        
        public string Id { get; set; }
        public double Winnings { get; set; }
        public string Name {get; set;}
    }
}



