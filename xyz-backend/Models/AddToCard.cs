
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace xyz_backend.Models
{
    public class AddToCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string dressId { get; set; }
        public string name { get; set; }
        public string dressType { get; set; }
        public int price { get; set; }
        public int count { get; set; }
        public string imageUrl { get; set; }
        public List<string> selectedServices { get; set; }
    }
}