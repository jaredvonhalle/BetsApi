using System;
using Amazon.DynamoDBv2.DataModel;

namespace BetsApi.Models
{
    [DynamoDBTable("BetsStats")]
    public class BetsStat
    {

        public BetsStat() {}

        public String TimePeriod { get; set; }
        public String Type {get; set;}
        public String Andrew {get; set;}
        public String Ben {get; set;}
        public String Jared {get; set;}
        public String Marc {get; set;}
        public String Matt {get; set;}
        public String Max {get; set;}
        public String Zach {get; set;}

    }
}