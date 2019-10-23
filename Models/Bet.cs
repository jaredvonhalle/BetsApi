using System;
using Amazon.DynamoDBv2.DataModel;

namespace BetsApi.Models
{
    [DynamoDBTable("Bets")]
    public class Bet
    {

        public Bet() {}

        public String Id { get; set; }
        //public System.DateTime ExpirationDate { get; set; }
        public String Challenger {get; set;}
        public String Accepter {get; set;}
        public String Odds {get; set;}
        public Double Amount {get; set;}
        public String Description {get; set;}
        public DateTime CreateDate {get; set;}
        public DateTime EndDate {get; set;}
        public String Status {get; set;}
        public bool IsComplete {get; set;} = false;
        public String Winner {get; set;}

    }
}