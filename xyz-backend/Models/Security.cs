using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace  xyz_backend.Models
{
    public class Security
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string email { get; set; }
        public int phoneNo { get; set; }
        public bool isAvailable { get; set; } = true;
        public DateTime updatedOn { get; set; } = DateTime.Now;
        public DateTime createdOn { get; set; } = DateTime.Now;

    }
}