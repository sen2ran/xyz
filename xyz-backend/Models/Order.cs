using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace xyz_backend.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string address { get; set; }
        public string userId { get; set; }
        public bool isHigh { get; set; }
        public int subtotal { get; set; }
        public int total { get; set; }
        public string status { get; set; } = "Neworder";
        public List<AddToCard> addToCard { get; set; }
    }
}