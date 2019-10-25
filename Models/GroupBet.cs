using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace BetsApi.Models
{
    [DynamoDBTable("Bets")]
    public class GroupBet
    {

        public GroupBet() {}

        public String Id { get; set; }
        //public System.DateTime ExpirationDate { get; set; }
        public List<String> Players {get; set;}
        public Double Amount {get; set;}
        public String Description {get; set;}
        public String CreateDate {get; set;}
        public String EndDate {get; set;}
        public List<Result> Results {get; set;}
        public String ResultString {get; set;}
        public bool IsComplete {get; set;} = false;
        public String Type {get; set;} = "GROUP";

    }
}