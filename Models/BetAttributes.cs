using System;

namespace BetsApi.Models
{
    public class BetAttributes
    {

        public BetAttributes() {}

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