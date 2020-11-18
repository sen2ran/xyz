using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace  xyz_backend.Models
{
    public class Logs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string apartmentId { get; set; }
        public string unitId { get; set; }
        public string imageUrl { get; set; }
        public string ownerName { get; set; }
        public string phoneNo { get; set; }
        public int noOfPeople { get; set; }
        public string nic { get; set; }
        public DateTime startMonth { get; set; }
        public DateTime endMonth { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedOn { get; set; } = DateTime.Now;
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}