using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace  xyz_backend.Models
{
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}