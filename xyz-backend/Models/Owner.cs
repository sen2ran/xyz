using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace  xyz_backend.Models
{
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string imageUrl { get; set; }
        public string ownerName { get; set; }
        public string phoneNo { get; set; }
        public string nic { get; set; }
        public string email { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedOn { get; set; } = DateTime.Now;
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}