using System;
using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel.DataAnnotations;

namespace BetsApi.Models
{
    public class Result
    {

        public Result() {}

        public String Player { get; set; }
        public Double Amount { get; set; }

    }
}